using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

using MacGen;
using CSharpBasicViewerApp;


// TESTERS/CODERS WANTED!  I currently don't have a machine to test this on
// I'm using an Arduino (328) with a scope only for testing at the
// moment

// NOTICE:
// This is currently under development and is only recommended for
// air cutting in a controlled environment!

// HISTORY
//
// 0.1.0.0 - initial version
// 0.1.1.0 - feed hold / soft reset 
// 0.1.2.0 - restructuring of serial comm code
//         - known problem with feedhold/cyclestart
// 0.1.3.0 - fixed feedhold/cyclestart problem caused by ok response confusion
//		   - known problem ocassionally with re-running after abort 
// 0.1.4.0 - modified delegates for use in threads (created at startup)
//         - starting to create preprocessor that only accepts Grbl gcode
//         - fixed status update interval problem
//         - fixed re-run after abort problem (added lock in commreceive)
//         - added timers for RX and TX indicators
//         - added basic preprocessor for grbl code
//           that is actually loaded and displayed in the backplotter
// 0.1.5.0 - Grbl preprocessor modifications (needs more thorough testing)
//         - changes to settings form, more options
//         - initial code to support joystick
// 0.1.6.0 - Error checking to detect grbl when opening serial port
//         - Added machine/world toggle on display
//         - regex now used to parse Grbl status report
// 0.1.7.0 - Switched to Visual C# Express 2010 due to some
//           problems with SharpDevelop 3.2
// TODO
// REPORTING:
// Grbl reporting of status is undergoing development:
// listbox shows line being buffered in Grbl, not actual line executing (Grbl code for line status needed)
// XON/XOFF is being worked as well in Grbl for flow control need to update this when code stabilizes
//
// MDI
// JOG
// Zero axes (world/machine?)
// Joystick/Joypad integration - having issues on X64 Win7 development box at moment
// Load/Save settings
// Color preferences
//
// KNOWN PROBLEMS
// Abort when feedhold is active, sometime causes loss of sync
// with Grbl.  Hard reset of grbl from Settings page restores
// stability. 

/*
FEATURES:

Hardware (DTR) Reset in Settings
Software Reset (0x18) on main form
Feed Hold / Cycle start
Zero Axes - Untested

INCOMPLETE FEATURES:

Status reporting - GRbl is undergoing heavy development in this area. What is
currently there is mostly a placeholder as a proof of concept but is functional

Feed Override - Grbl work in progress
JOG - Not yet coded, GUI components in place
MDI - Not yet coded, GUI components in place 
Status of modal gcodes - Maybe some indicators?
*/
//===============================================================
	
namespace CNCInfusion
{
public enum eMode { CONNECTED, DISCONNECTED, RUNNING, FEEDHOLD, CYCLESTART, FINISHED, ABORTED, WAITING, READY, LOADING, SOFTRESET, INACTIVE };

public partial class frmViewer : Form
{
	Settings settingsForm;

    private string mCncFile;
    private clsProcessor mProcessor = clsProcessor.Instance();
    private clsSettings mSetup = clsSettings.Instance();
    private MG_CS_BasicViewer mViewer;
    private Thread workThread;
    private List<object> gcode;
    
    private bool toolchange;
    private bool feedHold;
	private bool gettingSettings;
	private bool statusUpdates;
	private bool useGrblOnly;
	private bool GrblReportsInches;
	
    private volatile bool waitingOnACK;
    private volatile bool cancelled;
    
    private Stopwatch sw;
    private string executingLine;
    private List<string> Settings;

	private eMode specialMode;
    private System.Timers.Timer TXLEDoff;
    private System.Timers.Timer RXLEDoff;
    
    // comm thread callback to gui thread
    public delegate void ThreadFinishActionsDelegate();
    ThreadFinishActionsDelegate FinishActions;
    
    public delegate void UpdateGUIThreadDelegate(int i);
    UpdateGUIThreadDelegate UpdateGUIAction;
    
    public delegate void UpdatePositionLEDSDelegate(string str);
    UpdatePositionLEDSDelegate UpdatePositionLEDSAction;
    	
    public delegate void TransmitLEDDelegate();
    TransmitLEDDelegate TX_LED;
    
    public delegate void ReceiveLEDDelegate();
    ReceiveLEDDelegate RX_LED;
    
    public eMode currentMode;

    // Regex for reporting status
	private static Regex Reportrgx;
    
        
    public bool PerformStatusUpdates { get { return statusUpdates; } set { statusUpdates = value; } }
    public int UpdateInterval 		 { get { return timerStatusQuery.Interval; } set { timerStatusQuery.Interval = value; } }
	public bool PreprocessorMode 	 { get { return useGrblOnly; } 
    							   	   set { useGrblOnly = value;     	
    									 	 if(useGrblOnly)
    										 	lblGcodeMode.Text = "Preprocessed ";
    									 	 else 
    											lblGcodeMode.Text = string.Empty;
    									 	 
								    	 	 lblGcodeMode.Text += "Gcode";
    									   }
    								 }
	public bool GrblReportMode 		 { get { return GrblReportsInches; } set { GrblReportsInches = value; } }
	
    public frmViewer()
    {
        InitializeComponent();
		settingsForm = null;
        getSerialPorts();
        mViewer = this.MG_Viewer1;
        mProcessor.OnAddBlock += new clsProcessor.OnAddBlockEventHandler(mProcessor_OnAddBlock);
        MG_CS_BasicViewer.OnSelection += new MG_CS_BasicViewer.OnSelectionEventHandler(mViewer_OnSelection);
        MG_CS_BasicViewer.MouseLocation += new MG_CS_BasicViewer.MouseLocationEventHandler(mViewer_MouseLocation);
        mSetup.MachineActivated+=new clsSettings.MachineActivatedEventHandler(mSetup_MachineActivated);

        mSetup.LoadAllMachines(System.IO.Directory.GetCurrentDirectory() + "\\Data");
        mProcessor.Init(mSetup.Machine);
        cancelled = false;
        workThread = null;
        sw = new Stopwatch();

        // create delegate functions for use in threads
        TX_LED = new TransmitLEDDelegate(TransmitLED);
        RX_LED = new ReceiveLEDDelegate(ReceiveLED);
        FinishActions = new ThreadFinishActionsDelegate(ThreadFinishActions);
        UpdateGUIAction = new UpdateGUIThreadDelegate(UpdateGUI);
        UpdatePositionLEDSAction = new UpdatePositionLEDSDelegate(UpdatePositionLEDS);
        
        setMode(eMode.DISCONNECTED);
        UpdateInterval = 200; // 5 updates sec
        statusUpdates = false; // when enabled
        feedHold = false;
        PreprocessorMode = true;
        GrblReportsInches = false;
        
        TXLEDoff = new System.Timers.Timer(10);
        TXLEDoff.Elapsed += TXLEDoffElapsed;
        RXLEDoff = new System.Timers.Timer(10);
       	RXLEDoff.Elapsed += RXLEDoffElapsed; 
		
       	Reportrgx = new Regex(
	      "MPos:\\[([-+]?[0-9]*[\\\\.,]?[0-9]*),([-+]?[0-9]*[\\\\.,]?[0"+
	      "-9]*),([-+]?[0-9]*[\\\\.,]?[0-9]*)\\],WPos:\\[([-+]?[0-9]*[\\\\."+
	      ",]?[0-9]*),([-+]?[0-9]*[\\\\.,]?[0-9]*),([-+]?[0-9]*[\\\\.,]"+
	      "?[0-9]*)\\].*",  
	      RegexOptions.CultureInvariant | RegexOptions.Compiled
	    );       	
    }
   
    private string getVersion()
    {
		System.Reflection.Assembly asm;
		System.Reflection.AssemblyName asn;
		asm = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.ExecutablePath);
		asn = asm.GetName();
		return asn.Version.ToString();    	
    }
    
    private void frmViewer_Load(object sender, System.EventArgs e)
    {
    	lblVersion.Text = "CNCInfusion: "+  getVersion();


        if (Properties.Settings.Default.Virgin == true)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        } else {
            this.Location = Properties.Settings.Default.ViewFormLocation;
            this.Size = Properties.Settings.Default.ViewFormSize;
        }

        PreprocessorMode = Properties.Settings.Default.GrblPreprocesor;
        PerformStatusUpdates = Properties.Settings.Default.StatusUpdates;
        UpdateInterval = Properties.Settings.Default.UpdateInterval;
     
        mViewer.DrawRapidLines = false;
        mViewer.DrawRapidPoints = false;
        mViewer.DrawAxisLines = true;
        mViewer.DrawAxisIndicator = true;

        SetDefaultViews();
    }

    private void mViewer_MouseLocation(float x, float y)
    {
        Coordinates.Text = "X=" + x.ToString("0.000") + " Y=" + y.ToString("0.000");
    }

    private void mProcessor_OnAddBlock(int idx, int  ct)
    {
        try {
            this.Progress.Maximum = ct;

            this.Progress.Value = idx;
            if (ct > 10000) {
				//Refresh every 1000 blocks
                if (1000 % idx == 0) {
                    mViewer.FindExtents();
                    mViewer.Redraw(true);
                }
            }
        } 
    	catch  {  }
    }

    private void ViewportActivated(object sender, System.EventArgs e)
    {
        mViewer = (MG_CS_BasicViewer)sender;
    }

    private void SetDefaultViews()
    {
        MG_Viewer1.Pitch = 0f;
        MG_Viewer1.Roll = 0f;
        MG_Viewer1.Yaw = 0f;
        MG_Viewer1.FindExtents();

        mViewer.Redraw(true);
    }

    private void mViewer_OnSelection(System.Collections.Generic.List<clsMotionRecord> hits)
    {
        lblStatus.Text = hits[0].Codestring;
        string[] tipString = new
        string[hits.Count];
        for (int r = 0; r <= hits.Count- 1; r++) {
            tipString[r] = hits[r].Codestring;
        }
        this.CodeTip.SetToolTip(mViewer, string.Join(Environment.NewLine, tipString));
    }

    private void mViewer_OnStatus(string msg, int index, int max)
    {
        lblStatus.Text = msg;
        Progress.Maximum = max;
        Progress.Value = index;
        StatusStrip1.Refresh();
    }

    private void mSetup_MachineActivated(clsMachine m)
    {
        MG_Viewer1.RotaryDirection = (RotaryDirection)m.RotaryDir;
        MG_Viewer1.RotaryPlane = (Axis)m.RotaryAxis;
        MG_Viewer1.RotaryType = (RotaryMotionType)m.RotaryType;
        MG_Viewer1.ViewManipMode = MG_CS_BasicViewer.ManipMode.SELECTION;

        MG_Viewer1.FindExtents();
        mViewer.Redraw(true);
    }

    private void OpenFile(string fileName)
    {
        long[] ticks = new long[2];
        mCncFile = fileName;

        mSetup.MatchMachineToFile(mCncFile);
        ProcessFile(mCncFile);
        mViewer.BreakPoint = MG_CS_BasicViewer.MotionBlocks.Count - 1;

        mViewer.Pitch =  mSetup.Machine.ViewAngles[0];
        mViewer.Roll =  mSetup.Machine.ViewAngles[1];
        mViewer.Yaw = mSetup.Machine.ViewAngles[2];
        mViewer.Init();

        mViewer.DrawRapidLines = true;
        mViewer.DrawRapidPoints = true;
        mViewer.DrawAxisLines = true;
        mViewer.DrawAxisIndicator = true;

        ticks[0] = DateTime.Now.Ticks;
        MG_Viewer1.FindExtents();
        ticks[1] = DateTime.Now.Ticks;

        MG_Viewer1.DynamicViewManipulation = (ticks[1] - ticks[0]) < 2000000;
        mViewer.Redraw(true);
    }

    private void ProcessFile(string fileName)
    {
        string lastStatus;
        String line;
        string buffer = string.Empty;
		const string mCommentMatch = "\\([^()]*\\)";
		
		Regex cmtrgx = new Regex(mCommentMatch, RegexOptions.IgnoreCase);
        lastStatus = lblMode.Text;

        if (fileName == null) {
            return;
        }
        if(!System.IO.File.Exists(fileName)) {
            lblStatus.Text =
                "File does not exist!";
            return;
        }
        lblMode.Text = "PROCESSING";
        lblMode.Invalidate();
        Application.DoEvents();

        System.IO.StreamReader sr = new System.IO.StreamReader(OpenFileDialog1.FileName);
        
        while ((line = sr.ReadLine()) !=  null) {
        	if(useGrblOnly == true) {
        		
        		// skip comments for efficiency
        		MatchCollection cmtmatches = cmtrgx.Matches(line);
				if (cmtmatches.Count > 0)
						continue;
					
            	if(GrblPreprocess(line) == true) {
					// supported line - add it
					buffer += line;
					buffer += "\r\n";
                	listBoxGcode.Items.Add(line);
            	} 
        		else
        		{
        			// in Grbl mode and found unrecognized/supported command
            		listBoxGcode.Items.Clear();
            		MessageBox.Show(
						"Selected file contains commands unrecognized by Grbl\n'" +
						line + "'\nCheck Settings->Options if this error was unexpected\n",
                		"Preprocessing file",
                		MessageBoxButtons.OK, MessageBoxIcon.Error,
                		MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            		break;
            	}
        	}
        	// add any command - just for backplotting visualization
       		else 
       		{
       			buffer += line;
       			buffer += "\r\n";
       			listBoxGcode.Items.Add(line);
       		}
            Application.DoEvents();
        }
        sr.Close();        
        
        MG_CS_BasicViewer.MotionBlocks.Clear();
        mProcessor.Init(mSetup.Machine);
        
		mProcessor.ProcessFile(buffer, MG_CS_BasicViewer.MotionBlocks);
		
        if (mViewer.BreakPoint >
                MG_CS_BasicViewer.MotionBlocks.Count - 1) {
            mViewer.BreakPoint = MG_CS_BasicViewer.MotionBlocks.Count - 1;
        }
        mViewer.GatherTools();
        Progress.Value = 0;
        lblMode.Text = lastStatus;
    }

    private void BtnLoadClick(object sender, EventArgs e)
    {
        if(OpenFileDialog1.ShowDialog() ==  DialogResult.OK) {
            setMode(eMode.LOADING);
            OpenFile(OpenFileDialog1.FileName);
            
            if(comPort.IsOpen)
            	setMode(eMode.CONNECTED);
            else
            	setMode(eMode.DISCONNECTED);
            
            Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName);
        }
    }

    private void ListBox1SelectedIndexChanged(object
            sender, EventArgs e)
    {
        if(currentMode == eMode.RUNNING) {
            return;
        }

        mViewer.BreakPoint =  listBoxGcode.SelectedIndex;
        mViewer.Redraw(true);
        Application.DoEvents();
    }

    // Serial port functions
    //----------------------
    #region Serial

    private void connect()
    {
        if(cbxComPort.Text == "NOPORTS") {
            MessageBox.Show(
                "No serial ports are currently available on this system.\n\n" +
                "1. Connect Grbl controller\n" +
                "2. Wait a few seconds\n" +
                "3. Press 'OK'\n" +
                "4. Choose COM port in dropdown box in statusbar\n" +
                "5. Retry connect\n",
                "Serial",
                MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            getSerialPorts();
            return;
        }

        comPort.PortName = cbxComPort.Text;
        comPort.BaudRate = 9600;
        comPort.DtrEnable = false;
        comPort.NewLine = "\n";
        try {
        	// open port, prod for a reponse within 500 ms
        	comPort.Open();
        	comPort.ReadTimeout = 500;
        	comPort.Write("\n");
        	setMode(eMode.CONNECTED);
        	comPort.ReadTimeout = -1;
        	
        }
        catch(Exception ex) {
        	MessageBox.Show(ex.Message,
        	                "Serial Port",
                			MessageBoxButtons.OK, MessageBoxIcon.Error,
                			MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);        	                
        	setMode(eMode.DISCONNECTED);	
        }

    }

    private void disconnect()
    {
        comPort.Close();
        setMode(eMode.DISCONNECTED);
    }

    private void getSerialPorts()
    {
        cbxComPort.Items.Clear();


        cbxComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        if(cbxComPort.Items.Count == 0) {
            cbxComPort.Items.Add("NOPORTS");
        }
        // choose first available index
        cbxComPort.SelectedIndex = 0;
    }

    public void hardReset()
    {
        // no actions enabled
        timerStatusQuery.Enabled = false;
        
        setMode(eMode.DISCONNECTED);
		pnlControl.Enabled = false;

        if(workThread != null) {
            terminateThread();
        }

        cancelled = true;
        Progress.Value = 0;

        comPort.DtrEnable = true;
        Thread.Sleep(50);
        comPort.DtrEnable = false;

        waitForReset();

        // restore actions
        setMode(eMode.CONNECTED);
    }

    private void softreset()
    {
        string command = "\x18\n";

        WriteSerial(command);
        setMode(eMode.SOFTRESET);    	
    }
    
    private void waitForReset()
    {
        setMode(eMode.WAITING);

        // delay for bootloader timeout
        for(int i=3; i> 0; i--) {
            lblMode.Text =
                string.Format("WAIT {0}", i);
            Application.DoEvents();
            Thread.Sleep(1000);
        }

        setMode(eMode.READY);
    }
	
    private void clearSerialBuffers()
    {
        if(comPort.IsOpen) {
            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();
            comPort.Close();
        }    	
    }
    
    private void WriteSerial(string cmd)
    {
        if(comPort.IsOpen) {
            comPort.Write(cmd);
        }
    }

    // separate thread to keep GUI responsive during
    // serial activity and when paused for tool change
    // Invoke is used to sync updates back to GUI thread
    private void ThreadedCommunication()
    {
        int i = 0;
        cancelled = false;

        foreach(string line in gcode) {
            toolchange = false;
            executingLine = line;

            if(cancelled == true) {
               	break;
            }
            
            // flag M6 command here and prompt for tool change in ComPortDataReceived()
            // caveat - line with M6 should only be an exclusive toolchange command
            // i.e "T0 M6" as entire line will not get transmitted to Grbl
            if(line.Contains("M6")) {
                toolchange = true;
            }

            try {
                Invoke(TX_LED);
                if(comPort.IsOpen)
                	comPort.Write(line + "\n");
                
                Invoke(UpdateGUIAction, i++);
                
                // wait for ComPortDataReceived() to
                // acknowledge reply
                while(waitingOnACK == true) {
                	Application.DoEvents();
                    Thread.Sleep(5);
                }

                if(cancelled == true) 
                	break;
                
               	waitingOnACK = true;
                
            } catch(Exception) {  }
        }
        Invoke(FinishActions);
    }

    // all interrupt driven comm is received here
    // as comport is threaded, we need to Invoke functions back to GUI thread
    private void ComPortDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string ACK = string.Empty;
        
        // status interval timer and ThreadedCommunication each will trigger this
        // only allow one at a time 
		lock(this)
    	{
	        // empty buffer by reading all received lines
	        while(comPort.BytesToRead > 0) {
	
		        if(cancelled == true) {
		            return;
		        }
	        	
	            if(comPort.IsOpen)
	                ACK = comPort.ReadLine();
	
	            // test cases for responses back from GRbl
	
	            // normal response
	            if(ACK.ToUpper().Trim() == "OK") {
	                // strobe RX LED (only on affirm ACKs, not status queries)
	                Invoke(RX_LED);
	                if(specialMode == eMode.FEEDHOLD) {
	                	// swallow the first OK sent by the command on resume
	                	waitingOnACK = true;
	                } else {
	                	waitingOnACK = false;	
	                }
	            }
	            // status update
	            else if(ACK.ToUpper().StartsWith("MPOS")) {
	                // show the machine/world position on 7 segment displays
	                Invoke(UpdatePositionLEDSAction, ACK);
	            }
	            else if(ACK.StartsWith("'$x=value'")){
	            	// break out of loop getting setting values
	            	gettingSettings = false; 
	            }
	            // response to a setting query
	            else if(ACK.StartsWith("$")) {
	            	// accumulate responses
	                // add to list in GetSettings()
	                Settings.Add(ACK);
	            }
	            // tool change
	            else if(toolchange) {
	                executingLine = "Manual tool change :\n" + executingLine;
	
	                MessageBox.Show(executingLine, "Manual intervention required",
	                                MessageBoxButtons.OK,
	                                MessageBoxIcon.Exclamation,
	                                MessageBoxDefaultButton.Button1,
	                                MessageBoxOptions.DefaultDesktopOnly);
	
	                waitingOnACK = false;
	            }
	            // Grbl unsupported statement or error
	            else if(ACK.ToUpper().StartsWith("ERROR")) {
	                executingLine = "Unknown or unsupported gcode execution attempt: " + executingLine;
	                executingLine += "\nDo you want to ABORT this run?";
	
	                DialogResult res =  MessageBox.Show(executingLine, ACK, 
	                                    MessageBoxButtons.YesNo,
	                                    MessageBoxIcon.Error,
	                                    MessageBoxDefaultButton.Button2,
	                                    MessageBoxOptions.DefaultDesktopOnly);
	                if(res ==  DialogResult.Yes) {
	                    cancelled =  true;
	                }
	                waitingOnACK = false;
	            }
	        }
	        Application.DoEvents();
		}
    }

    #endregion Serial
	//----------------------

    private void terminateThread()
    {
        waitingOnACK = false;
        // wait for worker thread
        workThread.Abort();
        Thread.Sleep(100);
        workThread.Join();
        Thread.Sleep(100);
    }

    private void ThreadFinishActions()
    {
        sw.Stop();
        timerStatusQuery.Enabled = false;

        // was cancelled by user request inside comm notify by unsupported command
        if(cancelled) 
            setMode(eMode.ABORTED);
        else 
            setMode(eMode.FINISHED);

    }

    private void UpdateGUI(int i)
    {
        Progress.Value = i;
        
        //UseMnemonic is just used as a semaphore
        if(btnCompleted.UseMnemonic) {
            // show completed
            listBoxGcode.SelectedIndex = i;
            //listBoxGcode.ScrollIntoView(listBoxGcode.Items[listBoxGcode.SelectedIndex]);
            mViewer.BreakPoint = i;
        } else {
            // show all
            listBoxGcode.SelectedIndex = i;
            //listBoxGcode.ScrollIntoView(listBoxGcode.Items[listBoxGcode.SelectedIndex]);
            mViewer.BreakPoint = 0;
        }
        mViewer.Redraw(true);
    }

    private void UpdatePositionLEDS(string str)
    {
        // Grbl edge status update looks like this: (Feb 2012)
		//MPos:[0.00,0.00,0.00],WPos:[0.00,0.00,0.00]

        double mx, wx;
        double my, wy;
        double mz, wz;
        double TOINCHES = 0.0393700787;

        MatchCollection matches = Reportrgx.Matches(str);
        GroupCollection groups = matches[0].Groups;
		
		//Debug.WriteLine(str + "\r\n");

        try {
			mx = double.Parse(groups[1].Value.ToString());
			my = double.Parse(groups[2].Value.ToString());
			mz = double.Parse(groups[3].Value.ToString());
			wx = double.Parse(groups[4].Value.ToString());
			wy = double.Parse(groups[5].Value.ToString());
			wz = double.Parse(groups[6].Value.ToString());

            if(GrblReportsInches) {
                mx = mx * TOINCHES;
                my = my * TOINCHES;
                mz = mz * TOINCHES;				
                wx = wx * TOINCHES;
                wy = wy * TOINCHES;
                wz = wz * TOINCHES;
            }
        	
			if(rbMachine.Checked) {
	            // TODO rounding issue?
	            Xdisplay.Value = string.Format("{0:0.0000}", mx);
	            Ydisplay.Value = string.Format("{0:0.0000}", my);
	            Zdisplay.Value = string.Format("{0:0.0000}", mz);
			}
			else {
	            Xdisplay.Value = string.Format("{0:0.0000}", wx);
	            Ydisplay.Value = string.Format("{0:0.0000}", wy);
	            Zdisplay.Value = string.Format("{0:0.0000}", wz);				
			}
            //Debug.WriteLine(string.Format("M X={0} Y={1} Z={2}", mx, my, mz));
            //Debug.WriteLine(string.Format("W X={0} Y={1} Z={2}", wx, wy, wz));
            
		} catch(Exception ex) { MessageBox.Show(str, ex.Message); }
    }	
    
    private void TransmitLED()
    {
        lblTX.BackColor = System.Drawing.Color.LightGreen;
		TXLEDoff.Enabled = true;
    }

    private void TXLEDoffElapsed(object sender, EventArgs e)
    {
    	TXLEDoff.Enabled = false;
        lblTX.BackColor = System.Drawing.Color.DarkGray;
    }
    
    private void ReceiveLED()
    {
    	RXLEDoff.Enabled = true;
        lblRX.BackColor = System.Drawing.Color.Khaki;
    }

    private void RXLEDoffElapsed(object sender, EventArgs e)
    {
    	RXLEDoff.Enabled = false;
        lblRX.BackColor = System.Drawing.Color.DarkGray;
    }
    
    public List<string> GetSettings()
    {
        /*
        $0 = 755.906 (steps/mm x)
        $1 = 755.906 (steps/mm y)
        $2 = 755.906 (steps/mm z)
        $3 = 30 (microseconds step pulse)
        $4 = 500.000 (mm/min default feed rate)
        $5 = 500.000 (mm/min default seek rate)
        $6 = 0.100 (mm/arc segment)
        $7 = 28 (step port invert mask. binary =
        11100)
        $8 = 50.000 (acceleration in mm/sec^2)
        $9 = 0.050 (cornering junction deviation in mm)
        '$x=value' to set parameter or just '$' to dump current settings
        */
        Settings = new List<string>();
        
        gettingSettings = true; 
        WriteSerial("$\n");
        
        while(gettingSettings) {
        	Application.DoEvents();
        	Thread.Sleep(10);	
        }

        return Settings;
    }

    public void WriteSettings(List<string> values)
    {
        foreach(string command in values) {
    		waitingOnACK = true;
            WriteSerial(command);
            
            while(waitingOnACK) {
            	Application.DoEvents();
            	Thread.Sleep(10);
            }
        }
    }

    private void TimerStatusQueryTick(object sender, EventArgs e)
    {
        string str;
        // status request
        // response is processed in ComPortDataReceived()
        if(statusUpdates) {
            if(comPort.IsOpen) {
                WriteSerial("?");
            }
        }
        // elapsed time update
        str =  string.Format("{0:00}:{1:00}:{2:00}", 
                             sw.Elapsed.Hours, 
                             sw.Elapsed.Minutes, 
                             sw.Elapsed.Seconds);
        lblElapsedTime.Text = str;
    }

    private void setMode(eMode newMode)
    {
        switch(newMode) {
	        case eMode.CONNECTED:
	            currentMode =  eMode.CONNECTED;
	            pnlControl.Enabled = true;
	            btnConnect.Enabled = false;
	            cbxComPort.Enabled = false;
	            customPanel1.Enabled = true;
	            tabControl1.Enabled = true;
	            cbxComPort.Enabled = false;
	            btnConnect.BackColor = System.Drawing.Color.LightGreen;
	            btnDisconnect.BackColor = System.Drawing.Color.Coral;
	            btnDisconnect.Enabled = true;
	            btnMDIExecute.Enabled = true;
	            btnZminus.Enabled = true;
	            btnZplus.Enabled = true;
	            btnYminus.Enabled = true;
	            btnYplus.Enabled = true;
	            btnXminus.Enabled = true;
	            btnXplus.Enabled = true;
	            btnReset.Enabled = true;
	            btnRun.Enabled = true;
	            lblMode.BackColor = System.Drawing.Color.LightGreen;
	            lblMode.Text = "CONNECTED";
	            Cursor = Cursors.Default;
	            break;
	        case eMode.DISCONNECTED:
	            currentMode = eMode.DISCONNECTED;
	            pnlControl.Enabled = true;
	            btnDisconnect.Enabled = false;
	            btnDisconnect.BackColor = System.Drawing.Color.DarkGray;
	            btnConnect.Enabled = true;
	            btnConnect.BackColor = System.Drawing.Color.DarkGray;
	            btnRun.Enabled = false;
	            btnMDIExecute.Enabled = false;
	            btnZminus.Enabled = false;
	            btnZplus.Enabled = false;
	            btnYminus.Enabled = false;
	            btnYplus.Enabled = false;
	            btnXminus.Enabled = false;
	            btnXplus.Enabled = false;
	            btnReset.Enabled = false;
	            btnZeroAll.Enabled = false;
	            btnZeroX.Enabled = false;
	            btnZeroY.Enabled = false;
	            btnZeroZ.Enabled = false;            
	            cbxComPort.Enabled = true;
	            lblMode.BackColor = System.Drawing.Color.Khaki;
	            lblMode.Text = "OFFLINE";
	            Cursor = Cursors.Default;
	            break;
	        case eMode.RUNNING:
	            listBoxGcode.SelectedIndex = 0;
	            currentMode =  eMode.RUNNING;
	            specialMode = eMode.CYCLESTART;
	            Cursor =  Cursors.AppStarting;
	            workThread = new Thread(ThreadedCommunication);
	            Progress.Minimum = 0;
	            Progress.Maximum = gcode.Count;
	            btnLoad.Enabled = false;
	            btnDisconnect.Enabled = false;
	            lblMode.BackColor = System.Drawing.Color.Gainsboro;
	            lblMode.Text =  "RUNNING";
	            btnFeedHold.BackColor = System.Drawing.Color.Khaki;
	            btnFeedHold.Text = "Feed Hold";
	            feedHold = false;
	            btnReset.Enabled = false;
	            btnZeroAll.Enabled = false;
	            btnZeroX.Enabled = false;
	            btnZeroY.Enabled = false;
	            btnZeroZ.Enabled = false;
	            btnFeedHold.Enabled = true;
	            btnCancel.Enabled = true;
	            btnRun.Enabled =  false;
	            lblElapsedTime.Text = "00:00:00";
	            waitingOnACK =  true;
	            workThread.Start();
	            sw.Reset();
	            sw.Start();
	            timerStatusQuery.Enabled = true;
	            break;
	        case eMode.FINISHED:
	            currentMode = eMode.FINISHED;
	            btnDisconnect.Enabled = true;
	            btnReset.Enabled = true;
	            btnLoad.Enabled = true;
	            btnZeroAll.Enabled = true;
	            btnZeroX.Enabled = true;
	            btnZeroY.Enabled = true;
	            btnZeroZ.Enabled = true;
	            btnFeedHold.Enabled = false;
	            btnCancel.Enabled = false;
	            Progress.Value = 0;
	            lblRX.BackColor = System.Drawing.Color.DarkGray;
	            btnRun.Enabled = true;
	            lblMode.BackColor = System.Drawing.Color.Chartreuse;
	            lblMode.Text = "FINISHED";
            	MessageBox.Show("Normal Completion", "Run completed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);	            
	            Cursor = Cursors.Default;
	            break;
	        case eMode.ABORTED:
	            currentMode =  eMode.ABORTED;
	            sw.Stop();
	            cancelled = true;
	            waitingOnACK =  false;
	            terminateThread();
	            timerStatusQuery.Enabled = false;
	            lblMode.BackColor = System.Drawing.Color.Salmon;
	            lblRX.BackColor = System.Drawing.Color.DarkGray;
	            lblMode.Text = "ABORTED";
	            Progress.Value = 0;
	            Cursor = Cursors.Default;
	            btnRun.Enabled = true;
	            btnReset.Enabled = true;
	            btnLoad.Enabled = true;
	            btnDisconnect.Enabled = true;
	            btnZeroAll.Enabled = true;
	            btnZeroX.Enabled = true;
	            btnZeroY.Enabled = true;
	            btnZeroZ.Enabled = true;
	            btnFeedHold.Enabled = false;
	            btnCancel.Enabled = false;
	            Cursor = Cursors.Default;
	            
	            MessageBox.Show("Cancel has been requested", "Run aborted",
	                            MessageBoxButtons.OK,
	                            MessageBoxIcon.Hand,
	                            MessageBoxDefaultButton.Button1,
	                            MessageBoxOptions.DefaultDesktopOnly);
	            cancelled = false;
	            break;
	        case eMode.WAITING:
	            currentMode = eMode.WAITING;
	            Cursor = Cursors.WaitCursor;
	            lblMode.BackColor = System.Drawing.Color.Yellow;
	            break;
	        case eMode.READY:
	            currentMode = eMode.READY;
	            lblMode.BackColor = System.Drawing.Color.Gainsboro;
	            lblMode.Text = "READY";
	            Cursor = Cursors.Default;
	            break;
	        case eMode.LOADING:
	            Cursor = Cursors.AppStarting;
	            pnlControl.Enabled = false;
	            btnRun.Enabled = false;
	            listBoxGcode.Items.Clear();
	            this.Refresh();
	            lblMode.BackColor = System.Drawing.Color.SkyBlue;
	            lblMode.Text = "LOADING";
	            break;
	        case eMode.SOFTRESET:
	            currentMode = eMode.SOFTRESET;
	            lblMode.BackColor = System.Drawing.Color.SkyBlue;
	            lblMode.Text = "SOFT RESET";
	            break;
	        case eMode.FEEDHOLD:
	            // transient mode, don't update currentmode
	            specialMode = eMode.FEEDHOLD;
	            lblMode.BackColor = System.Drawing.Color.Orange;
	            lblMode.Text = "FEED HOLD";
	            btnFeedHold.BackColor = System.Drawing.Color.Orange;
	            btnFeedHold.Text = "Cycle Start";
	            break;
	            case eMode.CYCLESTART:
	            // transient  mode, don't update currentmode
	            specialMode = eMode.CYCLESTART;
	            lblMode.BackColor = System.Drawing.Color.Gainsboro;
	            lblMode.Text = "RUNNING";
	            btnFeedHold.BackColor = System.Drawing.Color.Khaki;
	            btnFeedHold.Text = "Feed Hold";
	            break;
        }
    }

    private void BtnConnectClick(object sender, EventArgs e)
    {
        try {
            connect();
            if(!comPort.IsOpen) 
                return;
            
            setMode(eMode.CONNECTED);
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
            setMode(eMode.DISCONNECTED);
            disconnect();
        }
    }

    private void BtnRunClick(object sender, EventArgs e)
    {
        //  need to have a loaded gcode file
        if(listBoxGcode.Items.Count == 0) {
            return;
        }
        
        // warn use if file is going to be run, but was loaded
        // without the Grbl preprocessor enabled
        if(useGrblOnly == false) {
                DialogResult res =  MessageBox.Show(
        							"The current file was loaded WITHOUT the use of the Grbl\n" +
        	                        "Preprocessor. (Settings->Options) Continuing is not recommended.\n" +
        	                        "Do you want to continue execution of this file?\n",
        	                        "WARNING!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.DefaultDesktopOnly);
                if(res ==  DialogResult.No) {
                    return;
                }        	
        }
        
        // use existing buffer
        // copy of gcode for use in thread
        gcode = new List<object>();
        foreach(object o in listBoxGcode.Items) {
            gcode.Add(o);
        }

        setMode(eMode.RUNNING);
    }

    private void BtnCancelClick(object sender, System.EventArgs e)
    {
    	if(specialMode == eMode.FEEDHOLD) {
    		// exit mode or grbl will still be waiting to resume
    		string command = "~\n";
            WriteSerial(command);
            
            // clear mode
    		setMode(eMode.CYCLESTART);
    	}     
    	setMode(eMode.ABORTED);
    }

    private void BtnDisconnectClick(object sender, EventArgs e)
    {
        disconnect();
        setMode(eMode.DISCONNECTED);
    }

    private void BtnResetClick(object sender, EventArgs e)
    {
    	softreset();
    }

    /*
    #define CMD_STATUS_REPORT '?'
    #define CMD_FEED_HOLD '!'
    #define CMD_CYCLE_START '~'
    #define CMD_RESET 0x18 // ctrl-x
    */
   
    void BtnFeedHoldClick(object sender, EventArgs e)
    {
        string command;
        feedHold = !feedHold;

        if(feedHold == true) {
            command = "!\n";
            WriteSerial(command);
            setMode(eMode.FEEDHOLD);

            // no sense doing status updates if grbl is paused
            if(statusUpdates)
                    timerStatusQuery.Enabled = false;
        } 
        else  {
            command = "~\n";
            WriteSerial(command);
            setMode(eMode.CYCLESTART);

            // restore status updates if they were previously enabled
            if(statusUpdates)
	            timerStatusQuery.Enabled = true;
        }
    }

    private void BtnZeroAllClick(object sender, EventArgs e)
    {
        string command = "G92 X0 Y0 Z0\n";
        Xdisplay.Value = "000.000";
        Ydisplay.Value = "000.000";
        Zdisplay.Value = "000.000";
        WriteSerial(command);
    }

    void BtnZeroXClick(object sender, EventArgs e)
    {
        string command = "G92 X0\n";
        Xdisplay.Value = "000.000";
        WriteSerial(command);
    }

	 void BtnZeroYClick(object sender, EventArgs e)
    {
        string command = "G92 Y0\n";
		Ydisplay.Value = "000.000";
        WriteSerial(command);
    }

    void BtnZeroZClick(object sender, EventArgs e)
    {
        string command = "G92 Z0\n";
        Zdisplay.Value = "000.000";
        WriteSerial(command);
    }

    private void BtnSettingsClick(object sender, EventArgs e)
    {
    	settingsForm = new Settings();
        settingsForm.caller = this;

        settingsForm.setUpdateInterval(timerStatusQuery.Interval);
        settingsForm.setGrblMode(useGrblOnly);
        settingsForm.setUpdateMode(statusUpdates);
        settingsForm.setInchUnits(GrblReportsInches);
        settingsForm.ShowDialog();
    }

    void BtnXplusClick(object sender,
                       EventArgs e)
    {
        // G21/G20
        // G91
        // G0 X distance F rate
        // G90

        // cbJogSpeed.Text is rate
    }

    void BtnXminusClick(object sender, EventArgs e)
    {

    }

    void BtnYplusClick(object sender, EventArgs e)
    {

    }

    void BtnYminusClick(object sender, EventArgs e)
    {

    }

    void BtnZplusClick(object sender, EventArgs e)
    {

    }

    void BtnZminusClick(object sender, EventArgs e)
    {

    }

    void BtnMDIExecuteClick(object sender, EventArgs e)
    {
        string command =
            tbMDICommand.Text + "\n";

        cbMDIHistory.Items.Add(tbMDICommand.Text);
        WriteSerial(command);
    }

    //UseMnemonic is just used as a toggle semaphore for the next few functions
    private void BtnRapidLinesClick(object sender, EventArgs e)
    {
        if(mViewer == null) {
            return;
        }

        btnRapidLines.UseMnemonic =!btnRapidLines.UseMnemonic;
        mViewer.DrawRapidLines = btnRapidLines.UseMnemonic;
        mViewer.Redraw(true);
    }

    private void BtnRapidPointsClick(object sender, EventArgs e)
    {
        if(mViewer == null) {
            return;
        }

        btnRapidPoints.UseMnemonic = !btnRapidPoints.UseMnemonic;
        mViewer.DrawRapidPoints = btnRapidPoints.UseMnemonic;
        mViewer.Redraw(true);
    }

    private void BtnAxisLinesClick(object sender, EventArgs e)
    {
        if(mViewer == null) {
            return;
        }

        btnAxisLines.UseMnemonic = !btnAxisLines.UseMnemonic;
        mViewer.DrawAxisLines =  btnAxisLines.UseMnemonic;
        mViewer.Redraw(true);
    }

    private void BtnAxisIndicatorClick(object sender, EventArgs e)
    {
        if(mViewer == null) {
            return;
        }

        btnAxisIndicator.UseMnemonic = !btnAxisIndicator.UseMnemonic;
        mViewer.DrawAxisIndicator = btnAxisIndicator.UseMnemonic;
        mViewer.Redraw(true);
    }

    // toggle between current progress position indicated in listbox
    // and the entire gcode drawing
    private void BtnCompletedClick(object sender, EventArgs e)
    {
        if(mViewer == null) {
            return;
        }

        btnCompleted.UseMnemonic = !btnCompleted.UseMnemonic;

        if(btnCompleted.UseMnemonic)  {
            if(listBoxGcode.SelectedIndex != -1)
            {
                mViewer.BreakPoint = listBoxGcode.SelectedIndex;
            } else

            {
                mViewer.BreakPoint = 0;
            }
        } else {
            // disable update
            mViewer.BreakPoint = 0;
        }
        mViewer.Redraw(true);
    }
    
    private void BtnTopClick(object sender, EventArgs e)
    {
        mViewer.Pitch = 0;
        mViewer.Roll = 0;
        mViewer.Yaw = 0;
        mViewer.FindExtents();
        mViewer.Redraw(true);

    }

    private void BtnRightClick(object sender, EventArgs e)
    {
        mViewer.Pitch = 270;
        mViewer.Roll = 0;
        mViewer.Yaw = 360;
        mViewer.FindExtents();
        mViewer.Redraw(true);

    }

    private void BtnFrontClick(object sender, EventArgs e)
    {
        mViewer.Pitch = 270;
        mViewer.Roll = 0;
        mViewer.Yaw = 270;
        mViewer.FindExtents();
        mViewer.Redraw(true);

    }

    private void BtnISOClick(object sender, EventArgs e)
    {
        mViewer.Pitch = 315;
        mViewer.Roll = 0;
        mViewer.Yaw = 315;
        mViewer.FindExtents();
        mViewer.Redraw(true);
    }

    private void BtnAboutClick(object sender, EventArgs e)
    {
        about aboutForm = new
        about();
        aboutForm.ShowDialog();
    }

    private void ViewButtonClicked(object sender, EventArgs e)
    {
        string tag = sender.GetType().GetProperty("Tag").GetValue(sender, null).ToString();
        
        switch (tag) {
	        case "Fit":
	            mViewer.FindExtents();
	            break;
	        case "Pan":
	            mViewer.ViewManipMode = MG_CS_BasicViewer.ManipMode.PAN;
	            break;
	        case "Fence":
	            mViewer.ViewManipMode = MG_CS_BasicViewer.ManipMode.FENCE;
	            break;
	        case "Zoom":
	            mViewer.ViewManipMode = MG_CS_BasicViewer.ManipMode.ZOOM;
	            break;
	        case "Rotate":
	            mViewer.ViewManipMode = MG_CS_BasicViewer.ManipMode.ROTATE;
	            break;
	        case "Select":
	            mViewer.ViewManipMode = MG_CS_BasicViewer.ManipMode.SELECTION;
	            break;
	        }
    }

    private void frmViewer_ResizeEnd(object sender, EventArgs e)
    {
        MG_Viewer1.FindExtents();
        mViewer.Redraw(true);
    }

    private void tsbToolsFilter_Click(object sender, EventArgs e)
    {
        TreeNode nd = default(TreeNode);
        using (frmToolLayers frm = new
        frmToolLayers()) {

            frm.tvTools.Nodes.Clear();
            foreach(clsToolLayer tl in MG_CS_BasicViewer.ToolLayers.Values) {
                nd = frm.tvTools.Nodes.Add("Tool " + tl.Number.ToString());
                nd.ForeColor = tl.Color;
                nd.Checked = !tl.Hidden;
                nd.Tag = tl;
            }

            frm.tvTools.BackColor = this.MG_Viewer1.BackColor;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location =  Control.MousePosition;
            frm.ShowDialog();
        }
        mViewer.Redraw(true);
    }    
    // TODO feed rate override - not yet supported in Grbl?
    //
    private void LbKnob1KnobChangeValue(object sender, CPOL.Knobs.LBKnobEventArgs e)
    {
        lblFeedOverride.Text =
            string.Format("{0}%", Math.Truncate(lbKnob1.Value));
    }

    // prohibit tab changing of mode when running
    private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
    {
        if(currentMode == eMode.RUNNING)
            tabControl1.SelectedTab = AutoPage;
    }
    
    private void FrmViewerFormClosing(object sender, FormClosingEventArgs e)
    {
        if(currentMode == eMode.RUNNING) {
            MessageBox.Show(
                "Currently running.  Abort current program first!", "Program active",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            e.Cancel = true;
            return;
        }

        try {
            if(this.WindowState == FormWindowState.Normal) {
                Properties.Settings.Default.ViewFormLocation = this.Location;
                Properties.Settings.Default.ViewFormSize = this.Size;
            }
            Properties.Settings.Default.LastMachine = "Mill.xml";
            Properties.Settings.Default.Virgin = false;
            Properties.Settings.Default.GrblPreprocesor = PreprocessorMode;
            Properties.Settings.Default.StatusUpdates = PerformStatusUpdates;
            Properties.Settings.Default.UpdateInterval = UpdateInterval;
            Properties.Settings.Default.Save();
        } catch {
        }
        
        e.Cancel = false;
    }

    private void FrmViewerFormClosed(object sender, FormClosedEventArgs e)
    {
        timerStatusQuery.Enabled = false;
        clearSerialBuffers();
        if(comPort.IsOpen)
        	comPort.Close();
    }
}
}



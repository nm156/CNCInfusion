using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

using MacGen;
using CSharpBasicViewerApp;

// TODO

// Grbl reporting of status is undergoing development:

// XON/XOFF is being worked as well for flow control,
// need to update this code when available

// check gcode flavor of grbl before processing

// grbl currently seems to only report G21 (metric)
// even if G20 is in the nc file
// kludged code to get reporting in inches
// using variable G20set (search for it here)


namespace CNCInfusion
{
  	public enum eMode { CONNECTED, DISCONNECTED, RUNNING, FEEDHOLD, CYCLESTART, FINISHED, ABORTED, WAITING, READY, LOADING, SOFTRESET };
  
	public partial class frmViewer : Form 
	{ 
	    private string mCncFile; 
	    private clsProcessor mProcessor = clsProcessor.Instance(); 
	    private clsSettings mSetup = clsSettings.Instance(); 
	    private MG_CS_BasicViewer mViewer; 
		private bool cancelled;
		private Thread workThread;
		private List<object> gcode;
		private bool toolchange;
		private volatile bool waitingOnACK;
		private Stopwatch sw;
		private string executingLine;
		private List<string> Settings;
		private bool G20set;
		private bool feedHold;
	    public eMode currentMode;
		public bool doStatusUpdates;
		public int UpdateInterval;
		
	    public frmViewer(){
	        InitializeComponent();
	        
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
			currentMode = eMode.DISCONNECTED;
			setMode(currentMode);
			UpdateInterval = 200; // 5 updates sec
			doStatusUpdates = false; // when enabled
			feedHold = false;
	    }
	
	    private void frmViewer_Load(object sender, System.EventArgs e) 
	    { 
	        if (Properties.Settings.Default.Virgin == true) { 
	            this.StartPosition = FormStartPosition.CenterScreen; 
	        } 
	        else { 
	            this.Location = Properties.Settings.Default.ViewFormLocation; 
	            this.Size = Properties.Settings.Default.ViewFormSize; 
	        } 
	
	    	// nc file as splash screen if in directory
	        OpenFile(System.IO.Directory.GetCurrentDirectory() + "\\Samples\\Splash.nc"); 
	        
	        Properties.Settings.Default.Virgin = false; 
			mViewer.DrawRapidLines = false;
			mViewer.DrawRapidPoints = false;
			mViewer.DrawAxisLines = false;
			mViewer.DrawAxisIndicator = false;
	
	        SetDefaultViews(); 
	    } 
	    
	    private void frmViewer_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) 
	    { 
	        try { 
	            if (this.WindowState == FormWindowState.Normal) { 
	                Properties.Settings.Default.ViewFormLocation = this.Location; 
	                Properties.Settings.Default.ViewFormSize = this.Size; 
	            } 
	            Properties.Settings.Default.LastMachine = "Mill.xml"; 
	        } 
	        catch { 
	        } 
	    } 
	    
	    private void OpenFile(string fileName) 
	    { 
	        long[] ticks = new long[2]; 
	        mCncFile = fileName; 
	        mSetup.MatchMachineToFile(mCncFile); 
	        ProcessFile(mCncFile); 
	        mViewer.BreakPoint = MG_CS_BasicViewer.MotionBlocks.Count - 1; 
	        
	        mViewer.Pitch = mSetup.Machine.ViewAngles[0]; 
	        mViewer.Roll = mSetup.Machine.ViewAngles[1]; 
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
	    	
	    	lastStatus = lblMode.Text;
	    	
	        if (fileName == null) { 
	            return; 
	        } 
	        if (!System.IO.File.Exists(fileName)) { 
	            lblStatus.Text = "File does not exist!"; 
	            return; 
	        } 
	        lblMode.Text = "PROCESSING"; 
	        MG_CS_BasicViewer.MotionBlocks.Clear(); 
	        mProcessor.Init(mSetup.Machine); 
	        mProcessor.ProcessFile(fileName, MG_CS_BasicViewer.MotionBlocks); 
	        
	        if (mViewer.BreakPoint > MG_CS_BasicViewer.MotionBlocks.Count - 1) { 
	            mViewer.BreakPoint = MG_CS_BasicViewer.MotionBlocks.Count - 1; 
	        } 
	        mViewer.GatherTools(); 
	        Progress.Value = 0; 
	        lblMode.Text = lastStatus;
	    } 
	     
	    private void mViewer_MouseLocation(float x, float y) 
	    { 
	        Coordinates.Text = "X=" + x.ToString("0.000") + " Y=" + y.ToString("0.000"); 
	    } 
	     
	    private void mProcessor_OnAddBlock(int idx, int ct) 
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
	        catch (Exception ex) { 
	        } 
	        
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
	        string[] tipString = new string[hits.Count]; 
	        for (int r = 0; r <= hits.Count - 1; r++) { 
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
	        { 
	            MG_Viewer1.RotaryDirection = (RotaryDirection)m.RotaryDir; 
	            MG_Viewer1.RotaryPlane = (Axis)m.RotaryAxis; 
	            MG_Viewer1.RotaryType = (RotaryMotionType)m.RotaryType; 
	            MG_Viewer1.ViewManipMode = MG_CS_BasicViewer.ManipMode.SELECTION;
	            
	            MG_Viewer1.FindExtents();
	            mViewer.Redraw(true);
	
	        } 
	    } 
	    
	    private void ViewButtonClicked(object sender, EventArgs e)
	    {
	        string tag = sender.GetType().GetProperty("Tag").GetValue(sender, null).ToString();
	        switch (tag)
	        {
	            case "Fit":
	                if (Control.ModifierKeys==Keys.Shift)
	                    MG_Viewer1.FindExtents();
	                else
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
	
        private void BtnRapidLinesClick(object sender, EventArgs e)
        {
	        if(mViewer == null) return;

	        btnRapidLines.UseMnemonic = !btnRapidLines.UseMnemonic;
	        mViewer.DrawRapidLines = btnRapidLines.UseMnemonic; 
	        
	        mViewer.Redraw(true);
        }

        private void BtnRapidPointsClick(object sender, EventArgs e)
        {
	        if(mViewer == null) return;

	        btnRapidPoints.UseMnemonic = !btnRapidPoints.UseMnemonic;
	        mViewer.DrawRapidPoints = btnRapidPoints.UseMnemonic; 
	        
	        mViewer.Redraw(true);        	
        }
        
        private void BtnAxisLinesClick(object sender, EventArgs e)
        {
	        if(mViewer == null) return;

	        btnAxisLines.UseMnemonic = !btnAxisLines.UseMnemonic;
	        mViewer.DrawAxisLines = btnAxisLines.UseMnemonic; 
	        
	        mViewer.Redraw(true);        	
        }
        
        private void BtnAxisIndicatorClick(object sender, EventArgs e)
        {
	        if(mViewer == null) return;

	        btnAxisIndicator.UseMnemonic = !btnAxisIndicator.UseMnemonic;
	        mViewer.DrawAxisIndicator = btnAxisIndicator.UseMnemonic; 
	        
	        mViewer.Redraw(true);        	
        }
        
        // toggle between current progress position indicated in listbox
        // and the entire gcode drawing
        private void BtnCompletedClick(object sender, EventArgs e)
        {
        	if(mViewer == null) return;

        	btnCompleted.UseMnemonic = !btnCompleted.UseMnemonic;
        	
        	if(btnCompleted.UseMnemonic)  {
        		if(listBoxGcode.SelectedIndex != -1)
        			mViewer.BreakPoint = listBoxGcode.SelectedIndex;
        		else
        			mViewer.BreakPoint = 0;
        	}
   			else {
        		// disable update
        		mViewer.BreakPoint = 0;
   			}
        	mViewer.Redraw(true);
        }
                
	    private void tsbToolsFilter_Click(object sender, EventArgs e)
	    {
	
           TreeNode nd = default(TreeNode);
            using (frmToolLayers frm = new frmToolLayers())
            {
                frm.tvTools.Nodes.Clear();
                foreach (clsToolLayer tl in MG_CS_BasicViewer.ToolLayers.Values)
                {
                    nd = frm.tvTools.Nodes.Add("Tool " + tl.Number.ToString());
                    nd.ForeColor = tl.Color;
                    nd.Checked = !tl.Hidden;
                    nd.Tag = tl;
                }
                frm.tvTools.BackColor = this.MG_Viewer1.BackColor;
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = Control.MousePosition;
                frm.ShowDialog();
            }
            mViewer.Redraw(true);
	    }
	    
	    private void BtnLoadClick(object sender, EventArgs e)
	    {
			String line, laststatus;
			eMode lastMode;
			
			G20set = false;
			
			if(OpenFileDialog1.ShowDialog() == DialogResult.OK)
			{
				lastMode = currentMode;
				setMode(eMode.LOADING);
	   			System.IO.StreamReader sr = new 
	       		System.IO.StreamReader(OpenFileDialog1.FileName);
	   			while ((line = sr.ReadLine()) != null) {
	   				listBoxGcode.Items.Add(line);
	   				Application.DoEvents();
	   			}
	   			sr.Close();
	   			OpenFile(OpenFileDialog1.FileName);
	   			
	   			setMode(lastMode);
	   			Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName);
			}  
	    }
    
	    private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
	    {
	    	if(currentMode == eMode.RUNNING)
	    		return;
	    	
	    	mViewer.BreakPoint = listBoxGcode.SelectedIndex;
	    	mViewer.Redraw(true);
	    	Application.DoEvents();
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
        	about aboutForm = new about();	
        	aboutForm.ShowDialog();	    		
	    }
	    
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
			comPort.Open();
			currentMode = eMode.CONNECTED; 
			setMode(currentMode);
	    }
	    
	    private void disconnect()
	    {
	    	comPort.Close();  
	    	currentMode = eMode.DISCONNECTED;
	    	setMode(currentMode);
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
	    	customPanel3.Enabled = false;
	    	currentMode = eMode.DISCONNECTED;
	    	setMode(currentMode);
	    	
	    	if(workThread != null)
	    		terminateThread();
	    	
	    	cancelled = true;
	    	Progress.Value = 0;
	    	
	    	comPort.DtrEnable = true;
	    	Thread.Sleep(100);
	    	comPort.DtrEnable = false;
	    	
	    	waitForReset();
	    	
	    	// restore actions
	    	customPanel3.Enabled = true;
	    	currentMode = eMode.CONNECTED;
	    	setMode(currentMode);	    	
	    }
	    
	    private void waitForReset()
	    {
	    	currentMode = eMode.WAITING;
	    	setMode(currentMode);
	    	
    		// wait for bootloader timeout
    		for(int i=3; i> 0; i--) {
    			lblMode.Text = string.Format("WAIT {0}", i);
    			Application.DoEvents();
    			Thread.Sleep(1000);
    		}
    		
    		// clear out startup message
    		//	Grbl 0.7d
			// '$' to dump current settings
			
    		while(comPort.BytesToRead > 0) {
				ReadSerial();
    			Application.DoEvents();
    		}	
			
			currentMode = eMode.READY;
			setMode(currentMode);
	    }	    
    
	    // non interrupt driven serial RX
	    // for reading settings
	    private string ReadSerial()
	    {
	    	string result = string.Empty;
	    	
		   	lblRX.BackColor = System.Drawing.Color.Khaki;
	    	lblRX.Invalidate();
	    	Application.DoEvents();
	    	Thread.Sleep(50);
	    	try {
	    		if(comPort.IsOpen)
	    			if(comPort.BytesToRead > 0)
	    				result = comPort.ReadLine();
	    	}
	    	catch (TimeoutException e)
        	{
	    		MessageBox.Show( 
	    		                "Grbl failed to respond in allocated time", 
	    		                "Serial port timeout",
	    		                MessageBoxButtons.OK, 
	    		                MessageBoxIcon.Error,
	    		                MessageBoxDefaultButton.Button1, 
	    		                MessageBoxOptions.DefaultDesktopOnly);
        	}
	    	lblRX.BackColor = System.Drawing.Color.DarkGray;
	    	lblRX.Invalidate();
	    	return result;
	    }
	    
	    // non interrupt driven serial TX
	    // for writing settings
	    private void WriteSerial(string cmd)
	    {
	    	lblTX.BackColor = System.Drawing.Color.LightGreen;
	    	lblTX.Invalidate(); 
	    	Application.DoEvents();
	    	if(comPort.IsOpen)
	    		comPort.Write(cmd);
	    	Thread.Sleep(50);
	    	lblTX.BackColor = System.Drawing.Color.DarkGray;
	    	lblTX.Invalidate();	    	
	    }
	
	    void disableCommNotify()
	    {
	    	// non interrupt driven routine, disable processing
	   	    comPort.DataReceived -= ComPortDataReceived;
	   	    // set a timeout
	   	    comPort.ReadTimeout = 500;	
	    }
	    
	    void enableCommNotify()
	    {
	    	// reenable event
	    	comPort.DataReceived += ComPortDataReceived;
	    	// no timeout when threaded interrupt is running
	    	comPort.ReadTimeout = -1;	    	
	    }
	    
	    // non interrupt TX and wait affirm ACK
	    public bool SerialSendWaitACK(String command)
	    {
	    	string ACK = String.Empty;
	
			disableCommNotify();
		  	WriteSerial(command);
		  	
		  	while(comPort.BytesToRead > 0) {
		    	ACK = ReadSerial(); 
		    	
		    	if(ACK.TrimEnd() == string.Empty)
		    		return true;
		    	   
			  	// postive ACK
		    	if(ACK.ToUpper().Trim() == "OK") {
		    		return true;
		    	}
			  	// "Stored new setting"
			  	else if(ACK.ToUpper().Contains("STORED")) {
			  		return true;
			  	}
			  	// '$' to dump current settings
			  	else if(ACK.ToUpper().Contains("DUMP")) {
			  		return true;
			  	}
			  	// probably an error
				else {
			  		MessageBox.Show(ACK, "Unexpected response", 
			  		                MessageBoxButtons.OK, 
			  		                MessageBoxIcon.Exclamation,
			  		                MessageBoxDefaultButton.Button1, 
			  		                MessageBoxOptions.DefaultDesktopOnly);
		    		return false;
		    	}
		  	}
		  	enableCommNotify();
	  	  	return false;
	    }	
	   
	    // separate thread to keep GUI responsive during 
	    // serial activity and when paused for tool change
	    // Invoke is used to sync updates back to GUI thread
	    private void ThreadedCommunication()
	    {
	    	int i = 0;
	    	cancelled = false;

	    	foreach(string line in gcode)
	    	{
				toolchange = false;
				executingLine = line;
				
				// flag M6 command here and prompt for tool change in ComPortDataReceived()
				// caveat - line with M6 should only be an exclusive toolchange command
				// i.e "T0 M6" as entire line will not get transmitted to Grbl
	    		if(line.Contains("M6")) {
	    			toolchange = true;
	    		}
	    		
	    		try {
		    		if(cancelled) {
		    			break;
		    		}
					Invoke(new TransmitLEDCallback(TransmitLED));
					if(comPort.IsOpen)
						comPort.Write(line + "\n");
					
					// wait for ComPortDataReceived() to
					// acknowledge reply
					while(waitingOnACK == true) {
						Thread.Sleep(1);
					}

					Invoke(new UpdateGUIThreadCallback(UpdateGUI), i++);
	    			waitingOnACK = true;
	    		}
	    		catch(Exception) {  }
	    	}    
	    	
	    	Invoke(new ThreadFinishActionsCallback(ThreadFinishActions));
	    }
        
       
        // all interrupt driven comm is received here
        private void ComPortDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string ACK = string.Empty;

            if(cancelled)
            	return;
            
	    	// empty buffer by reading all lines
	    	while(comPort.BytesToRead > 0) {
	    		
	    		if(comPort.IsOpen)
	    			ACK = comPort.ReadLine();
				
	    		// normal response
	    		if(ACK.ToLower().Trim() == "ok") {
	    			// strobe RX LED (only on affirm ACKs, not status queries)
	    			Invoke(new ReceiveLEDCallback(ReceiveLED));
	    			waitingOnACK = false;	
	    		}
	    		// status update
	    		else if(ACK.ToUpper().StartsWith("MPOS")) {
	    			// show the machine/world position on 7 segment displays
	    			Invoke(new UpdatePositionLEDSCallback(UpdatePositionLEDS), ACK);
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
	    		// unsupported statement or error
	    		else if(ACK.ToUpper().StartsWith("ERROR")) {
	    			executingLine = "Unknown or unsupported gcode execution attempt: " + executingLine;
	    			executingLine += "\nDo you want to ABORT this run?";
	    			
	    			DialogResult res = MessageBox.Show(ACK, executingLine, 
	    			                                   MessageBoxButtons.YesNo, 
	    			                                   MessageBoxIcon.Error,
	    			                                   MessageBoxDefaultButton.Button2, 
	    			                                   MessageBoxOptions.DefaultDesktopOnly);
	    			if(res == DialogResult.Yes) {
	    				cancelled = true;
	    			}
					
	    			waitingOnACK = false;
	    		}
	    	}
	    	Application.DoEvents();
        }
        
#endregion Serial
	    private void terminateThread()
	    {
        	waitingOnACK = false;
        	// wait for worker thread 
	    	workThread.Abort();
	    	Thread.Sleep(100);
	    	workThread.Join();	
	    }
	    
	    // comm thread callback to gui thread
	    public delegate void ThreadFinishActionsCallback();
	    private void ThreadFinishActions()
	    {
	    	sw.Stop();
	    	timerStatusQuery.Enabled = false;

	    	// was cancelled by request inside comm notify by unsupported command
			if(cancelled) {
	    		currentMode = eMode.ABORTED;
	    		setMode(currentMode);
			}
			else {
	    		currentMode = eMode.FINISHED;
				setMode(currentMode);
	    		MessageBox.Show("Normal Completion", "Run completed",
				                MessageBoxButtons.OK, 
				                MessageBoxIcon.Information,
				                MessageBoxDefaultButton.Button1, 
				                MessageBoxOptions.DefaultDesktopOnly);
	    	}
	    }
	    
	    // comm thread callback to gui thread
	    public delegate void UpdateGUIThreadCallback(int i);
	    private void UpdateGUI(int i)
	    {
	    	Progress.Value = i;
	    	if(btnCompleted.UseMnemonic) {
	    		// show completed
	    		listBoxGcode.SelectedIndex = i;
	    		mViewer.BreakPoint = i;
	    	}
	    	else {
	    		// show all
	    		listBoxGcode.SelectedIndex = i;
	    		mViewer.BreakPoint = 0;	
	    	}
	    	mViewer.Redraw(true);
	    }

        // comm thread callback to gui thread
	    public delegate void UpdatePositionLEDSCallback(string str);
	    private void UpdatePositionLEDS(string str)
	    {
			// Grbl edge status update looks like this:  (Feb 2012)
	    	//MPos:[0.00,0.00,0.00],WPos:[0.00,0.00,0.00]

			string parts;
			string [] status;
			double TOINCHES = 0.03937;
			//lblStatus.Text = str;
			
			// skip 'MPos:['
			parts = str.Substring(7);
			//0.00,0.00,0.00]
			status = parts.Split(',');

			double x = double.Parse(status[0]);
			double y = double.Parse(status[1]);
			// remove trailing ']'
			double z = double.Parse(status[2].Substring(1, status[2].Length-2));

			if(G20set) {
				x = x * TOINCHES;
				y = y * TOINCHES;
				z = z * TOINCHES;
			}
			// rounding issue?
			Xdisplay.Value = string.Format("{0:0.0000}", x);
			Ydisplay.Value = string.Format("{0:0.0000}", y);
			Zdisplay.Value = string.Format("{0:0.0000}", z);
	    }
	    
	    // LED ON indicates data transmission
	    public delegate void TransmitLEDCallback();
	    private void TransmitLED()
	    {
	    	lblTX.BackColor = System.Drawing.Color.LightGreen;
	    	lblTX.Invalidate();	
	    	Application.DoEvents();
	    	Thread.Sleep(50);
	    	lblTX.BackColor = System.Drawing.Color.DarkGray;
	    	lblTX.Invalidate();	
	    	Application.DoEvents();
	    }
	    
	    // LED ON indicates waiting for response from Grbl
	    public delegate void ReceiveLEDCallback();
	    private void ReceiveLED()
	    {
	    	lblRX.BackColor = System.Drawing.Color.DarkGray;
	    	lblRX.Invalidate();	
	    	Application.DoEvents();
	    	Thread.Sleep(50);
	    	lblRX.BackColor = System.Drawing.Color.Khaki;
	    	lblRX.Invalidate();	
	    	Application.DoEvents();	
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
			$7 = 28 (step port invert mask. binary = 11100)
			$8 = 50.000 (acceleration in mm/sec^2)
			$9 = 0.050 (cornering junction deviation in mm)
			'$x=value' to set parameter or just '$' to dump current settings
		   	*/
		   	
		   	string val;
	   		Settings = new List<string>();
	
		    // non interrupt driven routine, disable processing
	   	    disableCommNotify();
	    	WriteSerial("$\n");

	    	while(comPort.BytesToRead > 0) {
				val = ReadSerial(); 
				if(val.StartsWith("$")) {
					Settings.Add(val);
					Application.DoEvents();
				}
	    	}
	    	
	    	// reenable event
	    	enableCommNotify();
	    	return Settings;
		}
	
	    public void WriteSettings(List<string> values)
	    {
	    	disableCommNotify();
	    	foreach(string command in values) {
	    		SerialSendWaitACK(command);
	    	}
	    	enableCommNotify();
	    }
	    
        private void TimerStatusQueryTick(object sender, EventArgs e)
        {
        	string str;
        	
        	// status request
        	// response is processed in ComPortDataReceived()
        	if(doStatusUpdates)
        		if(comPort.IsOpen)
        			comPort.Write("?");	
        	
        	// elapsed time update
        	str = string.Format("{0:00}:{1:00}:{2:00}", sw.Elapsed.Hours, sw.Elapsed.Minutes, sw.Elapsed.Seconds);
        	lblElapsedTime.Text = str;	
        }
        
	    private void setMode(eMode newMode)
	    {
	    	switch(newMode) {
	    		case eMode.CONNECTED:
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
		    			cbxComPort.Enabled = true;
						lblMode.BackColor = System.Drawing.Color.Khaki;
						lblMode.Text = "OFFLINE";
						Cursor = Cursors.Default;
	    			break;
	    		case eMode.RUNNING:
		    			Cursor = Cursors.AppStarting;
		    			workThread = new Thread(ThreadedCommunication);
						Progress.Minimum = 0;
						Progress.Maximum = gcode.Count;
						btnLoad.Enabled = false;
						btnDisconnect.Enabled = false;
						lblMode.BackColor = System.Drawing.Color.Gainsboro;
				    	lblMode.Text = "RUNNING";
				    	btnFeedHold.BackColor = System.Drawing.Color.Khaki;
        				btnFeedHold.Text = "Feed Hold";
        				feedHold = false;
						btnZeroAll.Enabled = false;  
						btnZeroX.Enabled = false;  
						btnZeroY.Enabled = false;  
						btnZeroZ.Enabled = false;  
						btnFeedHold.Enabled = true;
						btnCancel.Enabled = true;
						btnRun.Enabled = false;
		    			lblElapsedTime.Text = "00:00:00";
		    			waitingOnACK = true;
		    			workThread.Start();
		    			sw.Reset();
		    			sw.Start();
		    			timerStatusQuery.Enabled = true;
	    			break;
	    		case eMode.FINISHED:
		    			btnDisconnect.Enabled = true;
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
						Cursor = Cursors.Default;
	    			break;
	    		case eMode.ABORTED:
		    			cancelled = true;
		    			timerStatusQuery.Enabled = false;
		    			terminateThread();
				    	sw.Stop();
				    	lblMode.BackColor = System.Drawing.Color.Salmon;
				    	lblRX.BackColor = System.Drawing.Color.DarkGray;
				    	lblMode.Text = "ABORTED";
				    	Progress.Value = 0;
				    	Cursor = Cursors.Default;
				    	btnRun.Enabled = true;
		    			btnLoad.Enabled = true;
		    			btnDisconnect.Enabled = true;
						btnZeroAll.Enabled = true; 
						btnZeroX.Enabled = true; 
						btnZeroY.Enabled = true;
						btnZeroZ.Enabled = true;  
						btnFeedHold.Enabled = false;
						btnCancel.Enabled = false;			    			
		    			Cursor = Cursors.Default;
		    			comPort.DiscardInBuffer();
				    	comPort.DiscardOutBuffer();	    
				    	MessageBox.Show("Cancel has been requested", "Run aborted",
				    	                MessageBoxButtons.OK, 
				    	                MessageBoxIcon.Hand,
				    	                MessageBoxDefaultButton.Button1, 
				    	                MessageBoxOptions.DefaultDesktopOnly);
				    	cancelled = false;
	    			break;
	    		case eMode.WAITING:
	    				Cursor = Cursors.WaitCursor;
	    				lblMode.BackColor = System.Drawing.Color.Yellow;
	    			break;
	    		case eMode.READY:
						lblMode.BackColor = System.Drawing.Color.Gainsboro;
						lblMode.Text = "READY";		
					Cursor = Cursors.Default;
	    			break;	
	    		case eMode.LOADING:
		    			Cursor = Cursors.AppStarting;
						listBoxGcode.Items.Clear();
						this.Refresh();
						lblMode.BackColor = System.Drawing.Color.SkyBlue;
						lblMode.Text = "LOADING";
					break;
				case eMode.SOFTRESET:
						lblMode.BackColor = System.Drawing.Color.SkyBlue;
						lblMode.Text = "SOFT RESET";
					break;
				case eMode.FEEDHOLD:
						lblMode.BackColor = System.Drawing.Color.Orange;
						lblMode.Text = "FEED HOLD";
        				btnFeedHold.BackColor = System.Drawing.Color.Orange;
        				btnFeedHold.Text = "Cycle Start";						
					break;			
				case eMode.CYCLESTART:
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
	    		{
	    			return;
	    		}
	    		//waitForReset();
	    		currentMode = eMode.CONNECTED;
	    		setMode(currentMode);
				
	    	} catch (Exception ex) {
   				MessageBox.Show(ex.Message);
   				currentMode = eMode.DISCONNECTED;
   				setMode(currentMode);
   				disconnect();
	    	}
	    }
	   
	    private void BtnRunClick(object sender, EventArgs e)
	    {
			//  need to have a loaded gcode file
	    	if(listBoxGcode.Items.Count == 0)
	    		return;

	    	// copy of gcode for use in thread
	    	gcode = new List<object>(); 
	    	foreach(object o in listBoxGcode.Items) {
	    		// TODO fix this better
	    		// any other modal codes to be checked here?
	    		if(o.ToString().Contains("G20")) {
					// use inches in UpdatePositionLEDS() 
					// 
	    			G20set = true;
	    		}
	    		gcode.Add(o);
	    	}
			
			currentMode = eMode.RUNNING;
			setMode(currentMode);
	    }
	    
	    private void BtnCancelClick(object sender, System.EventArgs e)
	    {
	    	currentMode = eMode.ABORTED;
	    	setMode(currentMode);
	    }
	    
	    private void BtnDisconnectClick(object sender, EventArgs e)
	    {
	    	disconnect();
	    	currentMode = eMode.DISCONNECTED;
	    	setMode(currentMode);
	    }
	    
	    private void BtnResetClick(object sender, EventArgs e)
	    {
	    	string command = "\x18\n";
			SerialSendWaitACK(command);          
			
			// signon message 
    		while(comPort.BytesToRead > 0) {
				ReadSerial();
    			Application.DoEvents();
    		}	
	    	currentMode = eMode.SOFTRESET;
	    	setMode(currentMode);			
	    	
	    }
	    /*
	    #define CMD_STATUS_REPORT '?'
		#define CMD_FEED_HOLD '!'
		#define CMD_CYCLE_START '~'
		#define CMD_RESET 0x18 // ctrl-x
		*/
        void BtnFeedHoldClick(object sender, EventArgs e)
        {
        	feedHold = !feedHold;
        	
        	if(feedHold == true) {
        		//comPort.DataReceived -= ComPortDataReceived;
        		//comPort.Write("!\n");
        		//comPort.DataReceived += ComPortDataReceived;
        		SerialSendWaitACK("!\n");
        		//transient mode, don't update currentMode
        		setMode(eMode.FEEDHOLD);
        		if(doStatusUpdates)
        			timerStatusQuery.Enabled = false;        		
        	}
        	else {
        		//comPort.DataReceived -= ComPortDataReceived;
        		//comPort.Write("~\n");
        		//comPort.DataReceived += ComPortDataReceived;
        		SerialSendWaitACK("~\n");
        		//transient mode, don't update currentMode
				setMode(eMode.CYCLESTART);
        		if(doStatusUpdates)
        			timerStatusQuery.Enabled = true;
        	}
        }
        
        private void BtnZeroAllClick(object sender, EventArgs e)
        {
        	Xdisplay.Value = "000.000"; 
        	Ydisplay.Value = "000.000"; 
        	Zdisplay.Value = "000.000"; 
        	SerialSendWaitACK("G92 X0 Y0 Z0\n");
        }
        
        void BtnZeroXClick(object sender, EventArgs e)
        {
       		Xdisplay.Value = "000.000"; 
       		SerialSendWaitACK("G92 X0\n");
        }
        
        void BtnZeroYClick(object sender, EventArgs e)
        {
        	Ydisplay.Value = "000.000";	
        	SerialSendWaitACK("G92 Y0\n");
        }
        
        void BtnZeroZClick(object sender, EventArgs e)
        {
        	Zdisplay.Value = "000.000";	
        	SerialSendWaitACK("G92 Z0\n");
        }
        
        private void BtnSettingsClick(object sender, EventArgs e)
        {
        	Settings settingsForm = new Settings();	
        	settingsForm.caller = this;
        	settingsForm.setUpdateInterval(timerStatusQuery.Interval);
        	settingsForm.setUpdateMode(doStatusUpdates);
        	settingsForm.ShowDialog();
        }
        
        void BtnXplusClick(object sender, EventArgs e)
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
        	cbMDIHistory.Items.Add(tbMDICommand.Text);
        	SerialSendWaitACK(tbMDICommand.Text + "\n");
        }
        
        // TODO feed rate override - not yet supported in Grbl?
        //
        private void LbKnob1KnobChangeValue(object sender, CPOL.Knobs.LBKnobEventArgs e)
        {
        	lblFeedOverride.Text = string.Format("{0}%", Math.Truncate(lbKnob1.Value));
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
        		MessageBox.Show( "Currently running.  Abort current program first!", "Program active",
        		                MessageBoxButtons.OK, 
        		                MessageBoxIcon.Hand,
        		                MessageBoxDefaultButton.Button1, 
        		                MessageBoxOptions.DefaultDesktopOnly);
        		e.Cancel = true;
        		return;
        	}
   	
        	e.Cancel = false;
        }

        private void FrmViewerFormClosed(object sender, FormClosedEventArgs e)
        {
        	timerStatusQuery.Enabled = false;
        	
        	if(comPort.IsOpen) {
	    		comPort.DiscardInBuffer();
	    		comPort.DiscardOutBuffer();
        		comPort.Close();
        	}
        }	    
   } 
}
	

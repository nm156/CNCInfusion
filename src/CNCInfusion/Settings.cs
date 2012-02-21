/*
 * Created by SharpDevelop.
 * User: pdf
 * Date: 2/14/2012
 * Time: 9:17 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

namespace CNCInfusion
{
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public partial class Settings : Form
	{
		// reference to parent form
		public Form caller;
		private bool modified;
		private JoystickInterface.Joystick jst;
		private string[] sticks;
		
		public Settings()
		{
			InitializeComponent();
			modified = false;
		}
		
		// minimize flicker of stupid tab control
		protected override CreateParams CreateParams
		{
	        get  {
	                CreateParams cp = base.CreateParams;
	                cp.ExStyle |= 0x02000000;
	                return cp;
	        }
		}

		public void setUpdateMode(bool enabled)
		{
			rbStatusUpdate.Checked = enabled;
		}
		
		public void setGrblMode(bool enabled)
		{
			rbGrblOnly.Checked = enabled;
			rbAny.Checked = !enabled;
		}		
		
		public void setInchUnits(bool enabled)
		{
			rbImperial.Checked = enabled;
			rbMetric.Checked = !enabled;
		}	
		
		public void setUpdateInterval(int interval)
		{
			trackbarUpdateInterval.Value = interval;	
			int timerInterval = 1000/trackbarUpdateInterval.Value;
			lblUpdate.Text = timerInterval + " updates / second";
		}
		
		void BtnReadSettingsClick(object sender, EventArgs e)
		{
			List<string> RawSettings;
	    	string [] temp;
	   	    string [] paramtext;
	   	    string dollar;
	   	    string description;
	   	    string readvalue;
	   	    string conversion;
	   	    char[] charsToTrim = {'\r', '\n', ')'};

	   	    dataGridView1.Rows.Clear();
   	    	modified = false;
   	    	
	   	    // TODO I still can't figure all of the delegate stuff
	   	    // between forms, so just do it the old fashioned "C" way...
			RawSettings = ((frmViewer)caller).GetSettings();
			dataGridView1.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
			
			foreach(string val in RawSettings)
	    	{
	    		if(val.StartsWith("$")) {
					temp = val.Split('=');
					// Settings: $0 = 755.906 (steps/mm x)
					// temp[0] : $0
					// temp[1] : 755.906 (steps/mm x)
					paramtext = temp[1].Split('(');
					// paramtext[0] : 755.906
					// paramtext[1] : steps/mm x)
					
					dollar = temp[0].Trim();
					description = paramtext[1].TrimEnd(charsToTrim); 
					readvalue = paramtext[0].Trim();
					
					conversion = convertUnits(readvalue, val);
					dataGridView1.Rows.Add(new object[]{dollar, description, readvalue, conversion});
					Application.DoEvents();
	    		}
			}
			btnSetSettings.Enabled = true;
		}
		
		string convertUnits(string readvalue, string setting)
		{
			double TOINCHES = 0.0393700787;
			string convert;	   	    
			
			try {
				if(setting.Contains("steps/mm")) {
					double fval = double.Parse(readvalue)*(1.0/TOINCHES);
					convert = fval.ToString();
				}
				else if(setting.Contains("mm")) {
					double fval = double.Parse(readvalue)*TOINCHES;
					convert = fval.ToString();
				}
				else if(setting.Contains("binary")) {
					int fval = int.Parse(readvalue);
					convert = GetIntBinaryString(fval);
				}
				else {
					convert = readvalue;
				}
			}
			catch (Exception ex)
			{
				convert = string.Empty;
				MessageBox.Show(ex.Message);
			}	
			
			return convert;
		}
		
		void BtnSetSettingsClick(object sender, EventArgs e)
		{
			List<string> WriteSettings = new List<string>();
			string parameter;
			string setValue;
			string command;
			
			WriteSettings.Clear();
			
			foreach (DataGridViewRow dgval in dataGridView1.Rows)
			{
				parameter = dgval.Cells[0].Value.ToString().Trim();
				setValue = dgval.Cells[2].Value.ToString().Trim();
				command = parameter + "=" + setValue + "\n";
				// TODO only update changed settings
				WriteSettings.Add(command);
			}
			
			((frmViewer)caller).WriteSettings(WriteSettings);
			MessageBox.Show("Settings have been successfully written",  
			                "Write Settings",  
			                MessageBoxButtons.OK,
			                MessageBoxIcon.Information,
			                MessageBoxDefaultButton.Button1, 
			                MessageBoxOptions.DefaultDesktopOnly);
		}
		
	    void DataGridView1CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	    {
		    float enteredValue;
		
		    // Don't try to validate the 'new row' until finished 
		    // editing since there is no point in validating its initial value.
		    if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
		    
		    // only continue if it is the editable column
		    if (!dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("Value")) return;
		    
		    //if (sVal.Contains(".")) { 
            //	 float.Parse(sVal); 
        	//}
        	
		    // TODO error checking is weak
		    try {
		    	enteredValue = float.Parse(e.FormattedValue.ToString());
	     	}
		    catch {
		    		MessageBox.Show("The value must be a non-negative number. You entered '" + 
		    	                e.FormattedValue.ToString() + "' for parameter " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value,
		    	                "Invalid Settings Parameter", 
		    	                MessageBoxButtons.OK, 
		    	                MessageBoxIcon.Error,
		    	                MessageBoxDefaultButton.Button1, 
		    	                MessageBoxOptions.DefaultDesktopOnly);
		    		e.Cancel = true;
		    		return;
		    }
		    
		    e.Cancel = false;
	    }	
		
		// http://www.dotnetperls.com/binary-representation
		string GetIntBinaryString(int n)
    	{
			char[] b = new char[8];
			int pos = 7;
			int i = 0;

			while (i < 8) {
	    		if ((n & (1 << i)) != 0)
					b[pos] = '1';
	    		else
					b[pos] = '0';
	    		pos--;
	    		i++;
			}
			return new string(b);
    	}
		
		void TrackbarUpdateIntervalScroll(object sender, EventArgs e)
		{
			int timerInterval = 1000/trackbarUpdateInterval.Value;
			lblUpdate.Text = timerInterval + " updates / second";
			((frmViewer)caller).UpdateInterval = trackbarUpdateInterval.Value;
		}
		
		void RbStatusUpdateClick(object sender, EventArgs e)
		{
			rbStatusUpdate.Checked  = !rbStatusUpdate.Checked;
			((frmViewer)caller).PerformStatusUpdates = rbStatusUpdate.Checked;
		}
		
		void SettingsShown(object sender, EventArgs e)
		{
			// what mode are we in?
			eMode mainMode = ((frmViewer)caller).currentMode;
			
			// only these modes allowed to change settings
			// otherwise Grbl is processing
			if( mainMode == eMode.CONNECTED || mainMode == eMode.ABORTED ||
			    mainMode == eMode.FINISHED || mainMode == eMode.SOFTRESET) {
				pnlSettings.Enabled = true;	
				dataGridView1.Enabled = true;
				pnlReset.Enabled = true;
			}
			else {
				pnlSettings.Enabled = false;	
				dataGridView1.Enabled = false;	
				pnlReset.Enabled = false;
			}			
		}
		
		void BtnResetClick(object sender, EventArgs e)
		{
			((frmViewer)caller).hardReset();
		}
		
		void RbGrblOnlyCheckedChanged(object sender, EventArgs e)
		{
			((frmViewer)caller).PreprocessorMode = rbGrblOnly.Checked;
		}
	
		void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(dataGridView1.SelectedRows.Count > 0) {
				modified = true;
		    	int row = dataGridView1.SelectedRows[0].Index;
	
		    	dataGridView1.Rows[row].Cells[3].Value = 
		    		convertUnits(dataGridView1.Rows[row].Cells[2].Value.ToString(),
		    	            	 dataGridView1.Rows[row].Cells[1].Value.ToString());	
		    	
		    	dataGridView1.Rows[row].Cells[2].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			}
		}
		
		void SettingsFormClosing(object sender, FormClosingEventArgs e)
		{
			if(modified) {
                DialogResult res =  MessageBox.Show("There are unsaved changes.  Do you still want to close settings?", 
			                        "Notice",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button2,
                                    MessageBoxOptions.DefaultDesktopOnly);
                if(res ==  DialogResult.No) {
                    e.Cancel =  true;
                }				
			}
		}
	
		void RbImperialCheckedChanged(object sender, EventArgs e)
		{
			((frmViewer)caller).GrblReportMode = rbImperial.Checked;			
		}
		
		void Button4Click(object sender, EventArgs e)
		{

		}
		//jst.UpdateStatus();

		void CbJoySticksSelectedIndexChanged(object sender, EventArgs e)
		{
			try {
				jst.AcquireJoystick(sticks[cbJoySticks.SelectedIndex]);
				label9.Text = string.Format("Axes = {0}", jst.AxisCount);
				label10.Text = string.Format("Buttons = {0}", jst.ButtonCount);
			}
			catch {}
		}
		
		void getJoysticks()
		{
			//cbJoySticks.SelectedIndexChanged -= CbJoySticksSelectedIndexChanged;
			
			jst = new JoystickInterface.Joystick(this.Handle);
            sticks = jst.FindJoysticks();	
            cbJoySticks.Items.Clear();
            foreach(string joyName in sticks)
            	cbJoySticks.Items.Add(joyName);
            
            if(cbJoySticks.Items.Count > 0)
            	cbJoySticks.SelectedIndex = 0;
            
            //cbJoySticks.SelectedIndexChanged += CbJoySticksSelectedIndexChanged;
		}
		
		void SettingsLoad(object sender, EventArgs e)
		{
			getJoysticks();
		}
	}
}

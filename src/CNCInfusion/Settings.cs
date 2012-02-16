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
	
namespace CNCInfusion
{
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public partial class Settings : Form
	{
		// reference to parent form
		public Form caller;
		
		public Settings()
		{
			InitializeComponent();
		}
		
		public void setUpdateMode(bool enabled)
		{
			rbStatusUpdate.Checked = enabled;
		}
		
		public void setUpdateInterval(int interval)
		{
			trackbarUpdateInterval.Value = interval;		
		}
		
		void BtnReadSettingsClick(object sender, EventArgs e)
		{
			List<string> RawSettings;
	    	string [] temp;
	   	    string [] paramtext;
	   	    string dollar;
	   	    string description;
	   	    string readvalue;
	   	    char[] charsToTrim = {'\r', '\n', ')'};
	   	    
	   	    dataGridView1.Rows.Clear();
   	    
	   	    // TODO I still can't figure all of the delegate stuff
	   	    // between forms, so just do it the old fashioned "C" way...
			RawSettings = ((frmViewer)caller).GetSettings();
			
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
					
					dataGridView1.Rows.Add(new object[]{dollar, description, readvalue});
					Application.DoEvents();
	    		}
			}
			btnSetSettings.Enabled = true;
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
		    }
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
			((frmViewer)caller).doStatusUpdates = rbStatusUpdate.Checked;
		}
		
		void SettingsShown(object sender, EventArgs e)
		{
			// what mode are we in?
			eMode mainMode = ((frmViewer)caller).currentMode;
			
			// only these modes allowed to change settings
			// otherwise Grbl is processing
			if( mainMode == eMode.CONNECTED || mainMode == eMode.ABORTED || mainMode == eMode.FINISHED ) {
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
	}
}

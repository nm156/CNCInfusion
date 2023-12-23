/*
 * Created by SharpDevelop.
 * User: pdf
 * Date: 2/14/2012
 * Time: 9:17 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using CNCInfusion.joystick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CNCInfusion;

/// <summary>
/// Description of Settings.
/// </summary>
public partial class Settings : Form
{
    // reference to parent caller form
    public Form caller;
    private bool modified;
    private MyJoystick jst;
    private string[] sticks;

    public Settings()
    {
        InitializeComponent();
        modified = false;
    }

    // minimize flicker of stupid tab control
    protected override CreateParams CreateParams
    {
        get
        {
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
        int timerInterval = 1000 / trackbarUpdateInterval.Value;
        lblUpdate.Text = timerInterval + " updates / second";
    }

    private void BtnReadSettingsClick(object sender, EventArgs e)
    {
        List<string> RawSettings;
        string[] temp;
        string[] paramtext;
        string dollar;
        string description;
        string readvalue;
        string conversion;
        char[] charsToTrim = ['\r', '\n', ')'];

        dataGridView1.Rows.Clear();
        modified = false;

        // TODO I still can't figure all of the delegate stuff
        // between forms, so just do it the old fashioned "C" way...
        RawSettings = ((frmViewer)caller).GetSettings();
        dataGridView1.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;

        foreach (string val in RawSettings)
        {
            if (val.StartsWith("$"))
            {
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
                _ = dataGridView1.Rows.Add([dollar, description, readvalue, conversion]);
                Application.DoEvents();
            }
        }
        btnSetSettings.Enabled = true;
    }

    private string convertUnits(string readvalue, string setting)
    {
        double TOINCHES = 0.0393700787;
        string convert;

        try
        {
            if (setting.Contains("steps/mm"))
            {
                double fval = double.Parse(readvalue) * (1.0 / TOINCHES);
                convert = fval.ToString();
            }
            else if (setting.Contains("mm"))
            {
                double fval = double.Parse(readvalue) * TOINCHES;
                convert = fval.ToString();
            }
            else if (setting.Contains("binary"))
            {
                int fval = int.Parse(readvalue);
                convert = GetIntBinaryString(fval);
            }
            else
            {
                convert = readvalue;
            }
        }
        catch (Exception ex)
        {
            convert = string.Empty;
            _ = MessageBox.Show(ex.Message);
        }

        return convert;
    }

    private void BtnSetSettingsClick(object sender, EventArgs e)
    {
        List<string> WriteSettings = [];
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
        _ = MessageBox.Show("Settings have been successfully written",
                        "Write Settings",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
    }

    private void DataGridView1CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        float enteredValue;

        // Don't try to validate the 'new row' until finished 
        // editing since there is no point in validating its initial value.
        if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }

        // only continue if it is the editable column
        if (!dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("Value"))
        {
            return;
        }

        //if (sVal.Contains("."))  
        //	 float.Parse(sVal); 
        //else
        //   int.Parse(sVal);

        // TODO error checking is weak
        try
        {
            enteredValue = float.Parse(e.FormattedValue.ToString());
        }
        catch
        {
            _ = MessageBox.Show("The value must be a non-negative number. You entered '" +
                        e.FormattedValue.ToString() + "' for parameter " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value,
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
    private string GetIntBinaryString(int n)
    {
        char[] b = new char[8];
        int pos = 7;
        int i = 0;

        while (i < 8)
        {
            b[pos] = (n & (1 << i)) != 0 ? '1' : '0';
            pos--;
            i++;
        }
        return new string(b);
    }

    private void TrackbarUpdateIntervalScroll(object sender, EventArgs e)
    {
        int timerInterval = 1000 / trackbarUpdateInterval.Value;
        lblUpdate.Text = timerInterval + " updates / second";
        ((frmViewer)caller).UpdateInterval = trackbarUpdateInterval.Value;
    }

    private void RbStatusUpdateClick(object sender, EventArgs e)
    {
        rbStatusUpdate.Checked = !rbStatusUpdate.Checked;
        ((frmViewer)caller).PerformStatusUpdates = rbStatusUpdate.Checked;
    }

    private void SettingsShown(object sender, EventArgs e)
    {
        // what mode are we in?
        eMode mainMode = ((frmViewer)caller).currentMode;

        // only these modes allowed to change settings
        // otherwise Grbl is processing
        if (mainMode is eMode.CONNECTED or eMode.ABORTED or
            eMode.FINISHED or eMode.SOFTRESET)
        {
            pnlSettings.Enabled = true;
            dataGridView1.Enabled = true;
            pnlReset.Enabled = true;
        }
        else
        {
            pnlSettings.Enabled = false;
            dataGridView1.Enabled = false;
            pnlReset.Enabled = false;
        }

        colorComboBox1.SelectedColor = tabPage3.BackColor;
    }

    private void BtnResetClick(object sender, EventArgs e)
    {
        ((frmViewer)caller).hardReset();
    }

    private void BtnJoystickRefreshClick(object sender, EventArgs e)
    {
        getJoysticks();
    }

    private void RbGrblOnlyCheckedChanged(object sender, EventArgs e)
    {
        ((frmViewer)caller).PreprocessorMode = rbGrblOnly.Checked;
    }

    private void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            modified = true;
            int row = dataGridView1.SelectedRows[0].Index;

            dataGridView1.Rows[row].Cells[3].Value =
                convertUnits(dataGridView1.Rows[row].Cells[2].Value.ToString(),
                             dataGridView1.Rows[row].Cells[1].Value.ToString());

            dataGridView1.Rows[row].Cells[2].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
        }
    }

    private void SettingsFormClosing(object sender, FormClosingEventArgs e)
    {
        if (modified)
        {
            DialogResult res = MessageBox.Show("There are unsaved changes.  Do you still want to close settings?",
                                "Notice",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button2,
                                MessageBoxOptions.DefaultDesktopOnly);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }

    private void RbImperialCheckedChanged(object sender, EventArgs e)
    {
        ((frmViewer)caller).GrblReportMode = rbImperial.Checked;
    }


    // Placeholder test code for joystick:

    // Need to work out some issues with joystick code
    // I'm developing on Win7 X64, but I want to target back to XP X32
    // I get some exceptions from DX on startup, so I'll have to revist
    // how to get joystick code integrated
    //
    //Error while loading
    //C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0\Microsoft.DirectX.dll
    //An attempt was made to load a program with an incorrect format. (Exception from HRESULT: 0x8007000B)
    //
    // TODO poll
    //jst.UpdateStatus();

    private void CbJoySticksSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _ = jst.AcquireJoystick(sticks[cbJoySticks.SelectedIndex]);
            label9.Text = string.Format("Axes = {0}", jst.AxisCount);
            label10.Text = string.Format("Buttons = {0}", jst.ButtonCount);

            cbJoySticks.Items.Clear();
            cbXaxisJog.Items.Clear();
            cbYaxisJog.Items.Clear();
            cbZaxisJog.Items.Clear();
            cbAbort.Items.Clear();
            cbFeedHold.Items.Clear();
            cbJogSpeedDec.Items.Clear();
            cbJogSpeedInc.Items.Clear();

            for (int i = 0; i < jst.AxisCount; i++)
            {
                _ = cbXaxisJog.Items.Add("AXIS " + (i + 1).ToString());
                _ = cbYaxisJog.Items.Add("AXIS " + (i + 1).ToString());
                _ = cbZaxisJog.Items.Add("AXIS " + (i + 1).ToString());
            }

            for (int i = 0; i < jst.ButtonCount; i++)
            {
                _ = cbAbort.Items.Add("Button " + (i + 1).ToString());
                _ = cbFeedHold.Items.Add("Button " + (i + 1).ToString());
                _ = cbJogSpeedDec.Items.Add("Button " + (i + 1).ToString());
                _ = cbJogSpeedInc.Items.Add("Button " + (i + 1).ToString());
            }
        }
        catch { }
    }

    private void getJoysticks()
    {
        cbJoySticks.SelectedIndexChanged -= CbJoySticksSelectedIndexChanged;

        try
        {
            jst = new JoystickInterface.MyJoystick(Handle);
            sticks = jst.FindJoysticks() ?? [];


            foreach (string joyName in sticks)
            {
                _ = cbJoySticks.Items.Add(joyName);
            }
        }
        catch { } //(Exception ex) { MessageBox.Show(ex.Message); }

        cbJoySticks.SelectedIndexChanged += CbJoySticksSelectedIndexChanged;

        if (cbJoySticks.Items.Count > 0)
        {
            cbJoySticks.SelectedIndex = 0;
        }
    }

    private void SettingsLoad(object sender, EventArgs e)
    {
        getJoysticks();
    }

    private void colorComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        panel1.BackColor = colorComboBox1.SelectedColor;
    }

    private void colorComboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        customPanel5.BackColor = colorComboBox2.SelectedColor;
        customPanel5.Invalidate();
    }

    private void colorComboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        customPanel5.BackColor2 = colorComboBox3.SelectedColor;
        customPanel5.Invalidate();
    }

    private void colorComboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
        customPanel5.BorderColor = colorComboBox4.SelectedColor;
        customPanel5.Invalidate();
    }

    private void SetBackColorRecursive(Control control, Color color)
    {
        control.BackColor = color;

        foreach (Control c in control.Controls)
        {
            SetBackColorRecursive(c, color);
        }
    }

    private void SetTextBoxBackColor(Control Page, Color clr)
    {

        foreach (Control ctrl in Page.Controls)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).BackColor = clr;
            }
            else
            {
                if (ctrl.Controls.Count > 0)
                {
                    SetTextBoxBackColor(ctrl, clr);
                }
            }
        }
    }

}

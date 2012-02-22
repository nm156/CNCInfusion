/*
 * Created by SharpDevelop.
 * User: pdf
 * Date: 2/14/2012
 * Time: 9:17 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CNCInfusion
{
	partial class Settings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.Label lblUpdateInterval;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customPanel4 = new Utility.Panel.CustomPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlSettings = new Utility.Panel.CustomPanel();
            this.btnReadSettings = new System.Windows.Forms.Button();
            this.btnSetSettings = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.customPanel1 = new Utility.Panel.CustomPanel();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.rbStatusUpdate = new System.Windows.Forms.RadioButton();
            this.trackbarUpdateInterval = new System.Windows.Forms.TrackBar();
            this.customPanel3 = new Utility.Panel.CustomPanel();
            this.rbAny = new System.Windows.Forms.RadioButton();
            this.rbGrblOnly = new System.Windows.Forms.RadioButton();
            this.customPanel2 = new Utility.Panel.CustomPanel();
            this.rbImperial = new System.Windows.Forms.RadioButton();
            this.rbMetric = new System.Windows.Forms.RadioButton();
            this.pnlReset = new Utility.Panel.CustomPanel();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.colorComboBox10 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox9 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox8 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox7 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox6 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox5 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox4 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox3 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox2 = new EmrColorComboBox.ColorComboBox();
            this.colorComboBox1 = new EmrColorComboBox.ColorComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customPanel5 = new Utility.Panel.CustomPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.customPanel6 = new Utility.Panel.CustomPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ckEnableJoystick = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFeedHold = new System.Windows.Forms.ComboBox();
            this.cbJogSpeedDec = new System.Windows.Forms.ComboBox();
            this.cbAbort = new System.Windows.Forms.ComboBox();
            this.cbJogSpeedInc = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbYaxisJog = new System.Windows.Forms.ComboBox();
            this.cbXaxisJog = new System.Windows.Forms.ComboBox();
            this.cbZaxisJog = new System.Windows.Forms.ComboBox();
            this.btnJoystickRefresh = new System.Windows.Forms.Button();
            this.cbJoySticks = new System.Windows.Forms.ComboBox();
            lblUpdateInterval = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            this.customPanel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarUpdateInterval)).BeginInit();
            this.customPanel3.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.pnlReset.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.customPanel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.customPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUpdateInterval
            // 
            lblUpdateInterval.Location = new System.Drawing.Point(9, 13);
            lblUpdateInterval.Name = "lblUpdateInterval";
            lblUpdateInterval.Size = new System.Drawing.Size(118, 18);
            lblUpdateInterval.TabIndex = 46;
            lblUpdateInterval.Text = "Status Update Interval";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(22, 13);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(127, 18);
            label3.TabIndex = 48;
            label3.Text = "Gcode Preprocessor";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(18, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(111, 18);
            label4.TabIndex = 48;
            label4.Text = "Grbl Units";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(34, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(86, 18);
            label2.TabIndex = 48;
            label2.Text = "(DTR toggle)";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(29, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 18);
            label1.TabIndex = 47;
            label1.Text = "Hardware reset";
            // 
            // label27
            // 
            label27.Location = new System.Drawing.Point(125, 294);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(106, 18);
            label27.TabIndex = 70;
            label27.Text = "Text Color";
            // 
            // label26
            // 
            label26.Location = new System.Drawing.Point(125, 265);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(113, 18);
            label26.TabIndex = 68;
            label26.Text = "Viewer Background";
            // 
            // label25
            // 
            label25.Location = new System.Drawing.Point(124, 238);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(121, 18);
            label25.TabIndex = 66;
            label25.Text = "Neutral Color";
            // 
            // label24
            // 
            label24.Location = new System.Drawing.Point(124, 211);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(121, 18);
            label24.TabIndex = 64;
            label24.Text = "Warn Color";
            // 
            // label23
            // 
            label23.Location = new System.Drawing.Point(124, 184);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(121, 18);
            label23.TabIndex = 63;
            label23.Text = "Caution Color";
            // 
            // label22
            // 
            label22.Location = new System.Drawing.Point(124, 157);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(121, 18);
            label22.TabIndex = 62;
            label22.Text = "Safe Color";
            // 
            // label20
            // 
            label20.Location = new System.Drawing.Point(122, 130);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(121, 18);
            label20.TabIndex = 60;
            label20.Text = "Panel Border";
            // 
            // label19
            // 
            label19.Location = new System.Drawing.Point(122, 75);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(121, 18);
            label19.TabIndex = 59;
            label19.Text = "Panel Background Top";
            // 
            // label18
            // 
            label18.Location = new System.Drawing.Point(122, 48);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(121, 18);
            label18.TabIndex = 58;
            label18.Text = "Main Background";
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(6, 18);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(149, 18);
            label5.TabIndex = 50;
            label5.Text = "CNCInfusion color choices...";
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(29, 13);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 18);
            label6.TabIndex = 47;
            label6.Text = "Color Preview";
            // 
            // label17
            // 
            label17.Location = new System.Drawing.Point(124, 121);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(116, 18);
            label17.TabIndex = 70;
            label17.Text = "Jog Speed Decrement";
            // 
            // label14
            // 
            label14.Location = new System.Drawing.Point(124, 40);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(116, 18);
            label14.TabIndex = 64;
            label14.Text = "Feed Hold/Cycle Start";
            // 
            // label16
            // 
            label16.Location = new System.Drawing.Point(124, 94);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(116, 18);
            label16.TabIndex = 68;
            label16.Text = "Jog Speed Increment";
            // 
            // label15
            // 
            label15.Location = new System.Drawing.Point(124, 67);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(116, 18);
            label15.TabIndex = 66;
            label15.Text = "Abort";
            // 
            // label11
            // 
            label11.Location = new System.Drawing.Point(123, 40);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(70, 18);
            label11.TabIndex = 60;
            label11.Text = "X Axis Jog";
            // 
            // label12
            // 
            label12.Location = new System.Drawing.Point(123, 67);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(70, 18);
            label12.TabIndex = 61;
            label12.Text = "Y Axis Jog";
            // 
            // label13
            // 
            label13.Location = new System.Drawing.Point(123, 94);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(70, 18);
            label13.TabIndex = 62;
            label13.Text = "Z Axis Jog";
            // 
            // label8
            // 
            label8.ForeColor = System.Drawing.Color.Khaki;
            label8.Location = new System.Drawing.Point(15, 18);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(326, 18);
            label8.TabIndex = 52;
            label8.Text = "A WORK IN PROGRESS";
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(18, 36);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(193, 18);
            label7.TabIndex = 51;
            label7.Text = "Joysticks available";
            // 
            // label21
            // 
            label21.Location = new System.Drawing.Point(122, 102);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(140, 18);
            label21.TabIndex = 93;
            label21.Text = "Panel Background Bottom";
            // 
            // customPanel4
            // 
            this.customPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customPanel4.BackColor2 = System.Drawing.Color.Gray;
            this.customPanel4.BorderColor = System.Drawing.Color.Gold;
            this.customPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel4.BorderWidth = 2;
            this.customPanel4.Controls.Add(this.tabControl1);
            this.customPanel4.Curvature = 8;
            this.customPanel4.ForeColor = System.Drawing.Color.Black;
            this.customPanel4.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel4.Location = new System.Drawing.Point(3, 3);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.Size = new System.Drawing.Size(629, 406);
            this.customPanel4.TabIndex = 52;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 376);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.pnlSettings);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grbl Configuration";
            // 
            // pnlSettings
            // 
            this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSettings.BackColor = System.Drawing.Color.Gray;
            this.pnlSettings.BackColor2 = System.Drawing.Color.DarkGray;
            this.pnlSettings.BorderColor = System.Drawing.Color.Gold;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.BorderWidth = 2;
            this.pnlSettings.Controls.Add(this.btnReadSettings);
            this.pnlSettings.Controls.Add(this.btnSetSettings);
            this.pnlSettings.Curvature = 8;
            this.pnlSettings.ForeColor = System.Drawing.Color.Black;
            this.pnlSettings.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.pnlSettings.Location = new System.Drawing.Point(6, 11);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(94, 330);
            this.pnlSettings.TabIndex = 44;
            // 
            // btnReadSettings
            // 
            this.btnReadSettings.BackColor = System.Drawing.Color.LightGreen;
            this.btnReadSettings.Location = new System.Drawing.Point(9, 13);
            this.btnReadSettings.Name = "btnReadSettings";
            this.btnReadSettings.Size = new System.Drawing.Size(75, 34);
            this.btnReadSettings.TabIndex = 13;
            this.btnReadSettings.Text = "Read";
            this.btnReadSettings.UseVisualStyleBackColor = false;
            this.btnReadSettings.Click += new System.EventHandler(this.BtnReadSettingsClick);
            // 
            // btnSetSettings
            // 
            this.btnSetSettings.BackColor = System.Drawing.Color.Coral;
            this.btnSetSettings.Enabled = false;
            this.btnSetSettings.Location = new System.Drawing.Point(9, 53);
            this.btnSetSettings.Name = "btnSetSettings";
            this.btnSetSettings.Size = new System.Drawing.Size(75, 34);
            this.btnSetSettings.TabIndex = 14;
            this.btnSetSettings.Text = "Set";
            this.btnSetSettings.UseVisualStyleBackColor = false;
            this.btnSetSettings.Click += new System.EventHandler(this.BtnSetSettingsClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Function,
            this.Column2,
            this.conversion});
            this.dataGridView1.Location = new System.Drawing.Point(106, 11);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(575, 330);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView1CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "$";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 32;
            // 
            // Function
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Function.DefaultCellStyle = dataGridViewCellStyle2;
            this.Function.HeaderText = "Function";
            this.Function.Name = "Function";
            this.Function.ReadOnly = true;
            this.Function.Width = 175;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGreen;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            // 
            // conversion
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.conversion.DefaultCellStyle = dataGridViewCellStyle4;
            this.conversion.HeaderText = "Inch/Binary";
            this.conversion.Name = "conversion";
            this.conversion.ReadOnly = true;
            this.conversion.Width = 152;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage2.Controls.Add(this.customPanel1);
            this.tabPage2.Controls.Add(this.customPanel3);
            this.tabPage2.Controls.Add(this.customPanel2);
            this.tabPage2.Controls.Add(this.pnlReset);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.Silver;
            this.customPanel1.BackColor2 = System.Drawing.Color.Gainsboro;
            this.customPanel1.BorderColor = System.Drawing.Color.Gold;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 2;
            this.customPanel1.Controls.Add(this.lblUpdate);
            this.customPanel1.Controls.Add(this.rbStatusUpdate);
            this.customPanel1.Controls.Add(lblUpdateInterval);
            this.customPanel1.Controls.Add(this.trackbarUpdateInterval);
            this.customPanel1.Curvature = 8;
            this.customPanel1.ForeColor = System.Drawing.Color.Black;
            this.customPanel1.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel1.Location = new System.Drawing.Point(7, 145);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(166, 118);
            this.customPanel1.TabIndex = 46;
            // 
            // lblUpdate
            // 
            this.lblUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUpdate.ForeColor = System.Drawing.Color.Black;
            this.lblUpdate.Location = new System.Drawing.Point(22, 67);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(118, 18);
            this.lblUpdate.TabIndex = 48;
            this.lblUpdate.Text = "5 updates / second";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbStatusUpdate
            // 
            this.rbStatusUpdate.AutoCheck = false;
            this.rbStatusUpdate.Location = new System.Drawing.Point(22, 88);
            this.rbStatusUpdate.Name = "rbStatusUpdate";
            this.rbStatusUpdate.Size = new System.Drawing.Size(75, 24);
            this.rbStatusUpdate.TabIndex = 47;
            this.rbStatusUpdate.Text = "Enabled";
            this.rbStatusUpdate.UseVisualStyleBackColor = true;
            this.rbStatusUpdate.Click += new System.EventHandler(this.RbStatusUpdateClick);
            // 
            // trackbarUpdateInterval
            // 
            this.trackbarUpdateInterval.AutoSize = false;
            this.trackbarUpdateInterval.BackColor = System.Drawing.Color.Silver;
            this.trackbarUpdateInterval.LargeChange = 50;
            this.trackbarUpdateInterval.Location = new System.Drawing.Point(22, 34);
            this.trackbarUpdateInterval.Maximum = 500;
            this.trackbarUpdateInterval.Minimum = 100;
            this.trackbarUpdateInterval.Name = "trackbarUpdateInterval";
            this.trackbarUpdateInterval.Size = new System.Drawing.Size(118, 32);
            this.trackbarUpdateInterval.SmallChange = 50;
            this.trackbarUpdateInterval.TabIndex = 45;
            this.trackbarUpdateInterval.TickFrequency = 50;
            this.trackbarUpdateInterval.Value = 200;
            this.trackbarUpdateInterval.Scroll += new System.EventHandler(this.TrackbarUpdateIntervalScroll);
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.Color.Silver;
            this.customPanel3.BackColor2 = System.Drawing.Color.Gainsboro;
            this.customPanel3.BorderColor = System.Drawing.Color.Gold;
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.BorderWidth = 2;
            this.customPanel3.Controls.Add(label3);
            this.customPanel3.Controls.Add(this.rbAny);
            this.customPanel3.Controls.Add(this.rbGrblOnly);
            this.customPanel3.Curvature = 8;
            this.customPanel3.ForeColor = System.Drawing.Color.Black;
            this.customPanel3.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel3.Location = new System.Drawing.Point(7, 21);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(166, 118);
            this.customPanel3.TabIndex = 49;
            // 
            // rbAny
            // 
            this.rbAny.Location = new System.Drawing.Point(22, 65);
            this.rbAny.Name = "rbAny";
            this.rbAny.Size = new System.Drawing.Size(130, 18);
            this.rbAny.TabIndex = 1;
            this.rbAny.Text = "All (Backplotting only)";
            this.rbAny.UseVisualStyleBackColor = true;
            // 
            // rbGrblOnly
            // 
            this.rbGrblOnly.Checked = true;
            this.rbGrblOnly.Location = new System.Drawing.Point(22, 46);
            this.rbGrblOnly.Name = "rbGrblOnly";
            this.rbGrblOnly.Size = new System.Drawing.Size(130, 18);
            this.rbGrblOnly.TabIndex = 0;
            this.rbGrblOnly.TabStop = true;
            this.rbGrblOnly.Text = "Grbl supported";
            this.rbGrblOnly.UseVisualStyleBackColor = true;
            this.rbGrblOnly.CheckedChanged += new System.EventHandler(this.RbGrblOnlyCheckedChanged);
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.Silver;
            this.customPanel2.BackColor2 = System.Drawing.Color.Gainsboro;
            this.customPanel2.BorderColor = System.Drawing.Color.Gold;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 2;
            this.customPanel2.Controls.Add(label4);
            this.customPanel2.Controls.Add(this.rbImperial);
            this.customPanel2.Controls.Add(this.rbMetric);
            this.customPanel2.Curvature = 8;
            this.customPanel2.ForeColor = System.Drawing.Color.Black;
            this.customPanel2.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel2.Location = new System.Drawing.Point(179, 23);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(139, 116);
            this.customPanel2.TabIndex = 50;
            // 
            // rbImperial
            // 
            this.rbImperial.Location = new System.Drawing.Point(18, 65);
            this.rbImperial.Name = "rbImperial";
            this.rbImperial.Size = new System.Drawing.Size(111, 18);
            this.rbImperial.TabIndex = 1;
            this.rbImperial.Text = "Imperial (inches)";
            this.rbImperial.UseVisualStyleBackColor = true;
            this.rbImperial.CheckedChanged += new System.EventHandler(this.RbImperialCheckedChanged);
            // 
            // rbMetric
            // 
            this.rbMetric.Checked = true;
            this.rbMetric.Location = new System.Drawing.Point(18, 46);
            this.rbMetric.Name = "rbMetric";
            this.rbMetric.Size = new System.Drawing.Size(100, 18);
            this.rbMetric.TabIndex = 0;
            this.rbMetric.TabStop = true;
            this.rbMetric.Text = "Metric (mm)";
            this.rbMetric.UseVisualStyleBackColor = true;
            // 
            // pnlReset
            // 
            this.pnlReset.BackColor = System.Drawing.Color.Silver;
            this.pnlReset.BackColor2 = System.Drawing.Color.Gainsboro;
            this.pnlReset.BorderColor = System.Drawing.Color.Gold;
            this.pnlReset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReset.BorderWidth = 2;
            this.pnlReset.Controls.Add(label2);
            this.pnlReset.Controls.Add(label1);
            this.pnlReset.Controls.Add(this.btnReset);
            this.pnlReset.Curvature = 8;
            this.pnlReset.ForeColor = System.Drawing.Color.Black;
            this.pnlReset.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.pnlReset.Location = new System.Drawing.Point(179, 145);
            this.pnlReset.Name = "pnlReset";
            this.pnlReset.Size = new System.Drawing.Size(139, 118);
            this.pnlReset.TabIndex = 47;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Coral;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(34, 67);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 31);
            this.btnReset.TabIndex = 39;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(label21);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(label27);
            this.tabPage3.Controls.Add(this.colorComboBox10);
            this.tabPage3.Controls.Add(label26);
            this.tabPage3.Controls.Add(this.colorComboBox9);
            this.tabPage3.Controls.Add(label25);
            this.tabPage3.Controls.Add(this.colorComboBox8);
            this.tabPage3.Controls.Add(label24);
            this.tabPage3.Controls.Add(label23);
            this.tabPage3.Controls.Add(label22);
            this.tabPage3.Controls.Add(label20);
            this.tabPage3.Controls.Add(label19);
            this.tabPage3.Controls.Add(label18);
            this.tabPage3.Controls.Add(this.colorComboBox7);
            this.tabPage3.Controls.Add(this.colorComboBox6);
            this.tabPage3.Controls.Add(this.colorComboBox5);
            this.tabPage3.Controls.Add(this.colorComboBox4);
            this.tabPage3.Controls.Add(this.colorComboBox3);
            this.tabPage3.Controls.Add(this.colorComboBox2);
            this.tabPage3.Controls.Add(this.colorComboBox1);
            this.tabPage3.Controls.Add(label5);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 347);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Preferences";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(461, 281);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 31);
            this.button4.TabIndex = 92;
            this.button4.Text = "Apply Changes";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // colorComboBox10
            // 
            this.colorComboBox10.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox10.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox10.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox10.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox10.FormattingEnabled = true;
            this.colorComboBox10.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox10.Location = new System.Drawing.Point(6, 291);
            this.colorComboBox10.Name = "colorComboBox10";
            this.colorComboBox10.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox10.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox10.TabIndex = 69;
            // 
            // colorComboBox9
            // 
            this.colorComboBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox9.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox9.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox9.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox9.FormattingEnabled = true;
            this.colorComboBox9.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox9.Location = new System.Drawing.Point(6, 262);
            this.colorComboBox9.Name = "colorComboBox9";
            this.colorComboBox9.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox9.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox9.TabIndex = 67;
            // 
            // colorComboBox8
            // 
            this.colorComboBox8.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox8.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox8.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox8.FormattingEnabled = true;
            this.colorComboBox8.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox8.Location = new System.Drawing.Point(6, 235);
            this.colorComboBox8.Name = "colorComboBox8";
            this.colorComboBox8.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox8.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox8.TabIndex = 65;
            // 
            // colorComboBox7
            // 
            this.colorComboBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox7.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox7.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox7.FormattingEnabled = true;
            this.colorComboBox7.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox7.Location = new System.Drawing.Point(6, 208);
            this.colorComboBox7.Name = "colorComboBox7";
            this.colorComboBox7.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox7.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox7.TabIndex = 57;
            // 
            // colorComboBox6
            // 
            this.colorComboBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox6.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox6.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox6.FormattingEnabled = true;
            this.colorComboBox6.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox6.Location = new System.Drawing.Point(6, 181);
            this.colorComboBox6.Name = "colorComboBox6";
            this.colorComboBox6.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox6.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox6.TabIndex = 56;
            // 
            // colorComboBox5
            // 
            this.colorComboBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox5.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox5.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox5.FormattingEnabled = true;
            this.colorComboBox5.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox5.Location = new System.Drawing.Point(6, 154);
            this.colorComboBox5.Name = "colorComboBox5";
            this.colorComboBox5.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox5.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox5.TabIndex = 55;
            // 
            // colorComboBox4
            // 
            this.colorComboBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox4.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox4.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox4.FormattingEnabled = true;
            this.colorComboBox4.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox4.Location = new System.Drawing.Point(6, 127);
            this.colorComboBox4.Name = "colorComboBox4";
            this.colorComboBox4.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox4.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox4.TabIndex = 54;
            this.colorComboBox4.SelectedIndexChanged += new System.EventHandler(this.colorComboBox4_SelectedIndexChanged);
            // 
            // colorComboBox3
            // 
            this.colorComboBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox3.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox3.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox3.FormattingEnabled = true;
            this.colorComboBox3.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox3.Location = new System.Drawing.Point(6, 100);
            this.colorComboBox3.Name = "colorComboBox3";
            this.colorComboBox3.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox3.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox3.TabIndex = 53;
            this.colorComboBox3.SelectedIndexChanged += new System.EventHandler(this.colorComboBox3_SelectedIndexChanged);
            // 
            // colorComboBox2
            // 
            this.colorComboBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox2.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox2.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox2.FormattingEnabled = true;
            this.colorComboBox2.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox2.Location = new System.Drawing.Point(6, 72);
            this.colorComboBox2.Name = "colorComboBox2";
            this.colorComboBox2.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox2.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox2.TabIndex = 52;
            this.colorComboBox2.SelectedIndexChanged += new System.EventHandler(this.colorComboBox2_SelectedIndexChanged);
            // 
            // colorComboBox1
            // 
            this.colorComboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.colorComboBox1.Appearance = EmrColorComboBox.ColorComboBox.ControlView.Skinned;
            this.colorComboBox1.ControlColor = System.Drawing.SystemColors.ButtonFace;
            this.colorComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox1.FormattingEnabled = true;
            this.colorComboBox1.Items.AddRange(new object[] {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "Transparent",
            "Snow",
            "RosyBrown",
            "Red",
            "Maroon",
            "LightCoral",
            "IndianRed",
            "Firebrick",
            "DarkRed",
            "Brown",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "SaddleBrown",
            "Chocolate",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "LemonChiffon",
            "Khaki",
            "PaleGoldenrod",
            "DarkKhaki",
            "Yellow",
            "Olive",
            "LightYellow",
            "Beige",
            "LightGoldenrodYellow",
            "Ivory",
            "Violet",
            "Thistle",
            "Purple",
            "Plum",
            "Magenta",
            "Fuchsia",
            "DarkMagenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
            "Pink",
            "LightPink",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "Lime",
            "LightGreen",
            "PaleGreen",
            "Honeydew",
            "Green",
            "ForestGreen",
            "DarkGreen",
            "LimeGreen",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "Aqua",
            "Teal",
            "LightCyan",
            "DarkSlateGray",
            "DarkCyan",
            "Cyan",
            "PaleTurquoise",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "LightSlateGray",
            "SlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "DarkBlue",
            "Blue",
            "Navy",
            "GhostWhite",
            "MidnightBlue",
            "MediumBlue",
            "Lavender",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Other"});
            this.colorComboBox1.Location = new System.Drawing.Point(6, 45);
            this.colorComboBox1.Name = "colorComboBox1";
            this.colorComboBox1.SelectedColor = System.Drawing.Color.White;
            this.colorComboBox1.Size = new System.Drawing.Size(110, 21);
            this.colorComboBox1.TabIndex = 51;
            this.colorComboBox1.SelectedIndexChanged += new System.EventHandler(this.colorComboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.customPanel5);
            this.panel1.Location = new System.Drawing.Point(444, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 238);
            this.panel1.TabIndex = 49;
            // 
            // customPanel5
            // 
            this.customPanel5.BackColor = System.Drawing.Color.Gray;
            this.customPanel5.BackColor2 = System.Drawing.Color.Gray;
            this.customPanel5.BorderColor = System.Drawing.Color.Gold;
            this.customPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel5.BorderWidth = 2;
            this.customPanel5.Controls.Add(this.button3);
            this.customPanel5.Controls.Add(this.button2);
            this.customPanel5.Controls.Add(label6);
            this.customPanel5.Controls.Add(this.button1);
            this.customPanel5.Curvature = 8;
            this.customPanel5.ForeColor = System.Drawing.Color.Black;
            this.customPanel5.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel5.Location = new System.Drawing.Point(8, 19);
            this.customPanel5.Name = "customPanel5";
            this.customPanel5.Size = new System.Drawing.Size(117, 195);
            this.customPanel5.TabIndex = 48;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Coral;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(23, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 31);
            this.button3.TabIndex = 50;
            this.button3.Text = "Warn";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(23, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 49;
            this.button2.Text = "Caution";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(23, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 39;
            this.button1.Text = "Safe";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage4.Controls.Add(this.customPanel6);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(597, 347);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Joystick/Joypad";
            // 
            // customPanel6
            // 
            this.customPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel6.BackColor = System.Drawing.Color.Gray;
            this.customPanel6.BackColor2 = System.Drawing.Color.Silver;
            this.customPanel6.BorderColor = System.Drawing.Color.Gold;
            this.customPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel6.BorderWidth = 2;
            this.customPanel6.Controls.Add(this.label10);
            this.customPanel6.Controls.Add(this.label9);
            this.customPanel6.Controls.Add(this.ckEnableJoystick);
            this.customPanel6.Controls.Add(this.groupBox2);
            this.customPanel6.Controls.Add(this.groupBox1);
            this.customPanel6.Controls.Add(label8);
            this.customPanel6.Controls.Add(label7);
            this.customPanel6.Controls.Add(this.btnJoystickRefresh);
            this.customPanel6.Controls.Add(this.cbJoySticks);
            this.customPanel6.Curvature = 8;
            this.customPanel6.ForeColor = System.Drawing.Color.Black;
            this.customPanel6.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel6.Location = new System.Drawing.Point(6, 7);
            this.customPanel6.Name = "customPanel6";
            this.customPanel6.Size = new System.Drawing.Size(585, 334);
            this.customPanel6.TabIndex = 65;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(18, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 23);
            this.label10.TabIndex = 56;
            this.label10.Text = "Detected Buttons = 0";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(18, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 18);
            this.label9.TabIndex = 55;
            this.label9.Text = "Detected Axes = 0";
            // 
            // ckEnableJoystick
            // 
            this.ckEnableJoystick.Location = new System.Drawing.Point(333, 60);
            this.ckEnableJoystick.Name = "ckEnableJoystick";
            this.ckEnableJoystick.Size = new System.Drawing.Size(157, 24);
            this.ckEnableJoystick.TabIndex = 73;
            this.ckEnableJoystick.Text = "Joystick Jog Enabled";
            this.ckEnableJoystick.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFeedHold);
            this.groupBox2.Controls.Add(label17);
            this.groupBox2.Controls.Add(label14);
            this.groupBox2.Controls.Add(this.cbJogSpeedDec);
            this.groupBox2.Controls.Add(this.cbAbort);
            this.groupBox2.Controls.Add(label16);
            this.groupBox2.Controls.Add(label15);
            this.groupBox2.Controls.Add(this.cbJogSpeedInc);
            this.groupBox2.Location = new System.Drawing.Point(235, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 158);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buttons";
            // 
            // cbFeedHold
            // 
            this.cbFeedHold.FormattingEnabled = true;
            this.cbFeedHold.Location = new System.Drawing.Point(18, 37);
            this.cbFeedHold.Name = "cbFeedHold";
            this.cbFeedHold.Size = new System.Drawing.Size(100, 21);
            this.cbFeedHold.TabIndex = 63;
            // 
            // cbJogSpeedDec
            // 
            this.cbJogSpeedDec.FormattingEnabled = true;
            this.cbJogSpeedDec.Location = new System.Drawing.Point(18, 118);
            this.cbJogSpeedDec.Name = "cbJogSpeedDec";
            this.cbJogSpeedDec.Size = new System.Drawing.Size(100, 21);
            this.cbJogSpeedDec.TabIndex = 69;
            // 
            // cbAbort
            // 
            this.cbAbort.FormattingEnabled = true;
            this.cbAbort.Location = new System.Drawing.Point(18, 64);
            this.cbAbort.Name = "cbAbort";
            this.cbAbort.Size = new System.Drawing.Size(100, 21);
            this.cbAbort.TabIndex = 65;
            // 
            // cbJogSpeedInc
            // 
            this.cbJogSpeedInc.FormattingEnabled = true;
            this.cbJogSpeedInc.Location = new System.Drawing.Point(18, 91);
            this.cbJogSpeedInc.Name = "cbJogSpeedInc";
            this.cbJogSpeedInc.Size = new System.Drawing.Size(100, 21);
            this.cbJogSpeedInc.TabIndex = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbYaxisJog);
            this.groupBox1.Controls.Add(this.cbXaxisJog);
            this.groupBox1.Controls.Add(this.cbZaxisJog);
            this.groupBox1.Controls.Add(label11);
            this.groupBox1.Controls.Add(label12);
            this.groupBox1.Controls.Add(label13);
            this.groupBox1.Location = new System.Drawing.Point(18, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 158);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axes";
            // 
            // cbYaxisJog
            // 
            this.cbYaxisJog.FormattingEnabled = true;
            this.cbYaxisJog.Location = new System.Drawing.Point(17, 64);
            this.cbYaxisJog.Name = "cbYaxisJog";
            this.cbYaxisJog.Size = new System.Drawing.Size(100, 21);
            this.cbYaxisJog.TabIndex = 58;
            // 
            // cbXaxisJog
            // 
            this.cbXaxisJog.FormattingEnabled = true;
            this.cbXaxisJog.Location = new System.Drawing.Point(17, 37);
            this.cbXaxisJog.Name = "cbXaxisJog";
            this.cbXaxisJog.Size = new System.Drawing.Size(100, 21);
            this.cbXaxisJog.TabIndex = 57;
            // 
            // cbZaxisJog
            // 
            this.cbZaxisJog.FormattingEnabled = true;
            this.cbZaxisJog.Location = new System.Drawing.Point(17, 91);
            this.cbZaxisJog.Name = "cbZaxisJog";
            this.cbZaxisJog.Size = new System.Drawing.Size(100, 21);
            this.cbZaxisJog.TabIndex = 59;
            // 
            // btnJoystickRefresh
            // 
            this.btnJoystickRefresh.BackColor = System.Drawing.Color.LightGreen;
            this.btnJoystickRefresh.Location = new System.Drawing.Point(217, 57);
            this.btnJoystickRefresh.Name = "btnJoystickRefresh";
            this.btnJoystickRefresh.Size = new System.Drawing.Size(75, 29);
            this.btnJoystickRefresh.TabIndex = 53;
            this.btnJoystickRefresh.Text = "Refresh";
            this.btnJoystickRefresh.UseVisualStyleBackColor = false;
            this.btnJoystickRefresh.Click += new System.EventHandler(this.BtnJoystickRefreshClick);
            // 
            // cbJoySticks
            // 
            this.cbJoySticks.FormattingEnabled = true;
            this.cbJoySticks.Location = new System.Drawing.Point(18, 57);
            this.cbJoySticks.Name = "cbJoySticks";
            this.cbJoySticks.Size = new System.Drawing.Size(193, 21);
            this.cbJoySticks.TabIndex = 54;
            this.cbJoySticks.SelectedIndexChanged += new System.EventHandler(this.CbJoySticksSelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.customPanel4);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormClosing);
            this.Load += new System.EventHandler(this.SettingsLoad);
            this.Shown += new System.EventHandler(this.SettingsShown);
            this.customPanel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackbarUpdateInterval)).EndInit();
            this.customPanel3.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.pnlReset.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.customPanel5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.customPanel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.CheckBox ckEnableJoystick;
		private System.Windows.Forms.ComboBox cbAbort;
		private System.Windows.Forms.ComboBox cbFeedHold;
		private System.Windows.Forms.ComboBox cbZaxisJog;
		private System.Windows.Forms.ComboBox cbXaxisJog;
		private System.Windows.Forms.ComboBox cbYaxisJog;
		private System.Windows.Forms.ComboBox cbJogSpeedDec;
		private System.Windows.Forms.ComboBox cbJogSpeedInc;
		private EmrColorComboBox.ColorComboBox colorComboBox9;
		private EmrColorComboBox.ColorComboBox colorComboBox10;
		private EmrColorComboBox.ColorComboBox colorComboBox8;
		private EmrColorComboBox.ColorComboBox colorComboBox2;
		private EmrColorComboBox.ColorComboBox colorComboBox3;
		private EmrColorComboBox.ColorComboBox colorComboBox4;
		private EmrColorComboBox.ColorComboBox colorComboBox5;
		private EmrColorComboBox.ColorComboBox colorComboBox6;
		private EmrColorComboBox.ColorComboBox colorComboBox7;
		private EmrColorComboBox.ColorComboBox colorComboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private Utility.Panel.CustomPanel customPanel6;
		private System.Windows.Forms.Button btnJoystickRefresh;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbJoySticks;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private Utility.Panel.CustomPanel customPanel5;
		private Utility.Panel.CustomPanel customPanel4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.RadioButton rbImperial;
		private System.Windows.Forms.RadioButton rbMetric;
		private Utility.Panel.CustomPanel customPanel2;
		private System.Windows.Forms.DataGridViewTextBoxColumn conversion;
		private System.Windows.Forms.RadioButton rbGrblOnly;
		private System.Windows.Forms.RadioButton rbAny;
		private Utility.Panel.CustomPanel pnlReset;
		private Utility.Panel.CustomPanel customPanel3;
		private System.Windows.Forms.Button btnReset;
		private Utility.Panel.CustomPanel pnlSettings;
		private System.Windows.Forms.Label lblUpdate;
		private System.Windows.Forms.TrackBar trackbarUpdateInterval;
		private System.Windows.Forms.RadioButton rbStatusUpdate;
		private Utility.Panel.CustomPanel customPanel1;
		private System.Windows.Forms.Button btnReadSettings;
		private System.Windows.Forms.Button btnSetSettings;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Function;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
	}
}

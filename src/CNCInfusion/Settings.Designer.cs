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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSetSettings = new System.Windows.Forms.Button();
			this.btnReadSettings = new System.Windows.Forms.Button();
			this.pnlSettings = new Utility.Panel.CustomPanel();
			this.trackbarUpdateInterval = new System.Windows.Forms.TrackBar();
			this.customPanel1 = new Utility.Panel.CustomPanel();
			this.lblUpdate = new System.Windows.Forms.Label();
			this.rbStatusUpdate = new System.Windows.Forms.RadioButton();
			this.pnlReset = new Utility.Panel.CustomPanel();
			this.btnReset = new System.Windows.Forms.Button();
			this.customPanel3 = new Utility.Panel.CustomPanel();
			this.rbAny = new System.Windows.Forms.RadioButton();
			this.rbGrblOnly = new System.Windows.Forms.RadioButton();
			this.customPanel2 = new Utility.Panel.CustomPanel();
			this.rbImperial = new System.Windows.Forms.RadioButton();
			this.rbMetric = new System.Windows.Forms.RadioButton();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.customPanel5 = new Utility.Panel.CustomPanel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cbJoySticks = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.customPanel4 = new Utility.Panel.CustomPanel();
			lblUpdateInterval = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.pnlSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackbarUpdateInterval)).BeginInit();
			this.customPanel1.SuspendLayout();
			this.pnlReset.SuspendLayout();
			this.customPanel3.SuspendLayout();
			this.customPanel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.customPanel5.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.customPanel4.SuspendLayout();
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
			// label1
			// 
			label1.Location = new System.Drawing.Point(29, 13);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(86, 18);
			label1.TabIndex = 47;
			label1.Text = "Hardware reset";
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(34, 31);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(86, 18);
			label2.TabIndex = 48;
			label2.Text = "(DTR toggle)";
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
			// label6
			// 
			label6.Location = new System.Drawing.Point(29, 13);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(86, 18);
			label6.TabIndex = 47;
			label6.Text = "Color Preview";
			// 
			// label5
			// 
			label5.Location = new System.Drawing.Point(26, 25);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(159, 18);
			label5.TabIndex = 50;
			label5.Text = "CNCInfusion color choices...";
			// 
			// label7
			// 
			label7.Location = new System.Drawing.Point(33, 72);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(193, 18);
			label7.TabIndex = 51;
			label7.Text = "Joysticks available";
			// 
			// label8
			// 
			label8.Location = new System.Drawing.Point(33, 44);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(326, 18);
			label8.TabIndex = 52;
			label8.Text = "A WORK IN PROGRESS";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
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
			this.dataGridView1.Size = new System.Drawing.Size(485, 330);
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView1CellValidating);
			// 
			// Column1
			// 
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column1.HeaderText = "$";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 32;
			// 
			// Function
			// 
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.Function.DefaultCellStyle = dataGridViewCellStyle6;
			this.Function.HeaderText = "Function";
			this.Function.Name = "Function";
			this.Function.ReadOnly = true;
			this.Function.Width = 175;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGreen;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
			this.Column2.HeaderText = "Value";
			this.Column2.Name = "Column2";
			// 
			// conversion
			// 
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.conversion.DefaultCellStyle = dataGridViewCellStyle8;
			this.conversion.HeaderText = "Inch/Binary";
			this.conversion.Name = "conversion";
			this.conversion.ReadOnly = true;
			this.conversion.Width = 152;
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
			// pnlSettings
			// 
			this.pnlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.pnlSettings.BackColor = System.Drawing.Color.Gray;
			this.pnlSettings.BackColor2 = System.Drawing.Color.Gray;
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
			// trackbarUpdateInterval
			// 
			this.trackbarUpdateInterval.AutoSize = false;
			this.trackbarUpdateInterval.BackColor = System.Drawing.Color.Gray;
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
			// customPanel1
			// 
			this.customPanel1.BackColor = System.Drawing.Color.Gray;
			this.customPanel1.BackColor2 = System.Drawing.Color.Gray;
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
			this.lblUpdate.ForeColor = System.Drawing.Color.Gainsboro;
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
			// pnlReset
			// 
			this.pnlReset.BackColor = System.Drawing.Color.Gray;
			this.pnlReset.BackColor2 = System.Drawing.Color.Gray;
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
			// customPanel3
			// 
			this.customPanel3.BackColor = System.Drawing.Color.Gray;
			this.customPanel3.BackColor2 = System.Drawing.Color.Gray;
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
			this.customPanel2.BackColor = System.Drawing.Color.Gray;
			this.customPanel2.BackColor2 = System.Drawing.Color.Gray;
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
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
			this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage3.Controls.Add(label5);
			this.tabPage3.Controls.Add(this.panel1);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(597, 347);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Preferences";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.customPanel5);
			this.panel1.Location = new System.Drawing.Point(347, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(231, 294);
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
			this.customPanel5.Location = new System.Drawing.Point(11, 13);
			this.customPanel5.Name = "customPanel5";
			this.customPanel5.Size = new System.Drawing.Size(209, 195);
			this.customPanel5.TabIndex = 48;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.BackColor = System.Drawing.Color.Coral;
			this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
			this.button3.Location = new System.Drawing.Point(29, 136);
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
			this.button2.Location = new System.Drawing.Point(29, 99);
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
			this.button1.Location = new System.Drawing.Point(29, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 31);
			this.button1.TabIndex = 39;
			this.button1.Text = "Safe";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// tabPage4
			// 
			this.tabPage4.BackColor = System.Drawing.Color.DarkGray;
			this.tabPage4.Controls.Add(this.label10);
			this.tabPage4.Controls.Add(this.label9);
			this.tabPage4.Controls.Add(this.cbJoySticks);
			this.tabPage4.Controls.Add(this.button4);
			this.tabPage4.Controls.Add(label8);
			this.tabPage4.Controls.Add(label7);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(597, 347);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Joystick/Joypad";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(103, 135);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 56;
			this.label10.Text = "Buttons = 0";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(33, 135);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 55;
			this.label9.Text = "Axes = 0";
			// 
			// cbJoySticks
			// 
			this.cbJoySticks.FormattingEnabled = true;
			this.cbJoySticks.Location = new System.Drawing.Point(33, 93);
			this.cbJoySticks.Name = "cbJoySticks";
			this.cbJoySticks.Size = new System.Drawing.Size(193, 21);
			this.cbJoySticks.TabIndex = 54;
			this.cbJoySticks.SelectedIndexChanged += new System.EventHandler(this.CbJoySticksSelectedIndexChanged);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.LightGreen;
			this.button4.Location = new System.Drawing.Point(232, 80);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 34);
			this.button4.TabIndex = 53;
			this.button4.Text = "Update";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.Button4Click);
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
			this.Load += new System.EventHandler(this.SettingsLoad);
			this.Shown += new System.EventHandler(this.SettingsShown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.pnlSettings.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackbarUpdateInterval)).EndInit();
			this.customPanel1.ResumeLayout(false);
			this.pnlReset.ResumeLayout(false);
			this.customPanel3.ResumeLayout(false);
			this.customPanel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.customPanel5.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.customPanel4.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbJoySticks;
		private System.Windows.Forms.Button button4;
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
	}
}

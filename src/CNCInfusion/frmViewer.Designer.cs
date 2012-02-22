namespace CNCInfusion
{
    partial class frmViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CodeTip = new System.Windows.Forms.ToolTip(this.components);
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Coordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbxComPort = new System.Windows.Forms.ToolStripComboBox();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.rmbView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.timerStatusQuery = new System.Windows.Forms.Timer(this.components);
            this.customPanel4 = new Utility.Panel.CustomPanel();
            this.btnCompleted = new System.Windows.Forms.Button();
            this.btnToolFilter = new System.Windows.Forms.Button();
            this.btnAxisIndicator = new System.Windows.Forms.Button();
            this.btnAxisLines = new System.Windows.Forms.Button();
            this.btnRapidPoints = new System.Windows.Forms.Button();
            this.btnRapidLines = new System.Windows.Forms.Button();
            this.btnISO = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.MG_Viewer1 = new MacGen.MG_CS_BasicViewer();
            this.customPanel1 = new Utility.Panel.CustomPanel();
            this.rbWorld = new System.Windows.Forms.RadioButton();
            this.rbMachine = new System.Windows.Forms.RadioButton();
            this.btnZeroAll = new System.Windows.Forms.Button();
            this.btnZeroZ = new System.Windows.Forms.Button();
            this.btnZeroY = new System.Windows.Forms.Button();
            this.btnZeroX = new System.Windows.Forms.Button();
            this.Zdisplay = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.Ydisplay = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.Xdisplay = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.customPanel5 = new Utility.Panel.CustomPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AutoPage = new System.Windows.Forms.TabPage();
            this.lblFeedOverride = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbKnob1 = new CPOL.Knobs.LBKnob();
            this.btnRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFeedHold = new System.Windows.Forms.Button();
            this.jogPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbJogSpeed = new System.Windows.Forms.ComboBox();
            this.btnZminus = new System.Windows.Forms.Button();
            this.btnYminus = new System.Windows.Forms.Button();
            this.btnXminus = new System.Windows.Forms.Button();
            this.btnZplus = new System.Windows.Forms.Button();
            this.btnYplus = new System.Windows.Forms.Button();
            this.btnXplus = new System.Windows.Forms.Button();
            this.MDIpage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMDIHistory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMDICommand = new System.Windows.Forms.TextBox();
            this.btnMDIExecute = new System.Windows.Forms.Button();
            this.customPanel8 = new Utility.Panel.CustomPanel();
            this.lblGcodeMode = new System.Windows.Forms.Label();
            this.listBoxGcode = new System.Windows.Forms.ListBox();
            this.pnlControl = new Utility.Panel.CustomPanel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.customPanel2 = new Utility.Panel.CustomPanel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.StatusStrip1.SuspendLayout();
            this.rmbView.SuspendLayout();
            this.customPanel4.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.customPanel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.AutoPage.SuspendLayout();
            this.jogPage.SuspendLayout();
            this.MDIpage.SuspendLayout();
            this.customPanel8.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeTip
            // 
            this.CodeTip.AutoPopDelay = 3000;
            this.CodeTip.InitialDelay = 100;
            this.CodeTip.IsBalloon = true;
            this.CodeTip.OwnerDraw = true;
            this.CodeTip.ReshowDelay = 100;
            this.CodeTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.AutoSize = false;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTX,
            this.lblRX,
            this.lblMode,
            this.lblElapsedTime,
            this.lblStatus,
            this.Coordinates,
            this.cbxComPort,
            this.Progress});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 537);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(784, 25);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 6;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // lblTX
            // 
            this.lblTX.AutoSize = false;
            this.lblTX.BackColor = System.Drawing.Color.Gray;
            this.lblTX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblTX.Name = "lblTX";
            this.lblTX.Size = new System.Drawing.Size(32, 20);
            this.lblTX.Text = "TX";
            // 
            // lblRX
            // 
            this.lblRX.AutoSize = false;
            this.lblRX.BackColor = System.Drawing.Color.Gray;
            this.lblRX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblRX.Name = "lblRX";
            this.lblRX.Size = new System.Drawing.Size(32, 20);
            this.lblRX.Text = "RX";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = false;
            this.lblMode.BackColor = System.Drawing.Color.Khaki;
            this.lblMode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(80, 20);
            this.lblMode.Text = "OFFLINE";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = false;
            this.lblElapsedTime.BackColor = System.Drawing.Color.Gainsboro;
            this.lblElapsedTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(64, 20);
            this.lblElapsedTime.Text = "00:00";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(256, 20);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Coordinates
            // 
            this.Coordinates.BackColor = System.Drawing.Color.Gainsboro;
            this.Coordinates.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Coordinates.Name = "Coordinates";
            this.Coordinates.Size = new System.Drawing.Size(121, 20);
            this.Coordinates.Spring = true;
            this.Coordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxComPort
            // 
            this.cbxComPort.AutoSize = false;
            this.cbxComPort.BackColor = System.Drawing.Color.Gainsboro;
            this.cbxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxComPort.IntegralHeight = false;
            this.cbxComPort.Name = "cbxComPort";
            this.cbxComPort.Size = new System.Drawing.Size(80, 25);
            // 
            // Progress
            // 
            this.Progress.MarqueeAnimationSpeed = 0;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 19);
            // 
            // rmbView
            // 
            this.rmbView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFit,
            this.mnuFence,
            this.mnuPan,
            this.mnuRotate,
            this.mnuZoom,
            this.mnuSelect});
            this.rmbView.Name = "rmbView";
            this.rmbView.Size = new System.Drawing.Size(109, 136);
            // 
            // mnuFit
            // 
            this.mnuFit.Image = global::CNCInfusion.Properties.Resources.ViewFit;
            this.mnuFit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuFit.Name = "mnuFit";
            this.mnuFit.Size = new System.Drawing.Size(108, 22);
            this.mnuFit.Tag = "Fit";
            this.mnuFit.Text = "Fit";
            this.mnuFit.Click += new System.EventHandler(this.ViewButtonClicked);
            // 
            // mnuFence
            // 
            this.mnuFence.Image = global::CNCInfusion.Properties.Resources.ViewFence;
            this.mnuFence.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuFence.Name = "mnuFence";
            this.mnuFence.Size = new System.Drawing.Size(108, 22);
            this.mnuFence.Tag = "Fence";
            this.mnuFence.Text = "Fence";
            this.mnuFence.Click += new System.EventHandler(this.ViewButtonClicked);
            // 
            // mnuPan
            // 
            this.mnuPan.Image = global::CNCInfusion.Properties.Resources.ViewPan;
            this.mnuPan.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuPan.Name = "mnuPan";
            this.mnuPan.Size = new System.Drawing.Size(108, 22);
            this.mnuPan.Tag = "Pan";
            this.mnuPan.Text = "Pan";
            this.mnuPan.Click += new System.EventHandler(this.ViewButtonClicked);
            // 
            // mnuRotate
            // 
            this.mnuRotate.Image = global::CNCInfusion.Properties.Resources.ViewRotate;
            this.mnuRotate.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuRotate.Name = "mnuRotate";
            this.mnuRotate.Size = new System.Drawing.Size(108, 22);
            this.mnuRotate.Tag = "Rotate";
            this.mnuRotate.Text = "Rotate";
            this.mnuRotate.Click += new System.EventHandler(this.ViewButtonClicked);
            // 
            // mnuZoom
            // 
            this.mnuZoom.Image = global::CNCInfusion.Properties.Resources.ViewZoom;
            this.mnuZoom.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuZoom.Name = "mnuZoom";
            this.mnuZoom.Size = new System.Drawing.Size(108, 22);
            this.mnuZoom.Tag = "Zoom";
            this.mnuZoom.Text = "Zoom";
            this.mnuZoom.Click += new System.EventHandler(this.ViewButtonClicked);
            // 
            // mnuSelect
            // 
            this.mnuSelect.Image = global::CNCInfusion.Properties.Resources._Select;
            this.mnuSelect.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuSelect.Name = "mnuSelect";
            this.mnuSelect.Size = new System.Drawing.Size(108, 22);
            this.mnuSelect.Tag = "Select";
            this.mnuSelect.Text = "Select";
            this.mnuSelect.Click += new System.EventHandler(this.ViewButtonClicked);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.Title = "Open File";
            // 
            // comPort
            // 
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ComPortDataReceived);
            // 
            // timerStatusQuery
            // 
            this.timerStatusQuery.Interval = 200;
            this.timerStatusQuery.Tick += new System.EventHandler(this.TimerStatusQueryTick);
            // 
            // customPanel4
            // 
            this.customPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel4.BackColor = System.Drawing.Color.Black;
            this.customPanel4.BackColor2 = System.Drawing.Color.Black;
            this.customPanel4.BorderColor = System.Drawing.Color.Gold;
            this.customPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel4.BorderWidth = 2;
            this.customPanel4.Controls.Add(this.btnCompleted);
            this.customPanel4.Controls.Add(this.btnToolFilter);
            this.customPanel4.Controls.Add(this.btnAxisIndicator);
            this.customPanel4.Controls.Add(this.btnAxisLines);
            this.customPanel4.Controls.Add(this.btnRapidPoints);
            this.customPanel4.Controls.Add(this.btnRapidLines);
            this.customPanel4.Controls.Add(this.btnISO);
            this.customPanel4.Controls.Add(this.btnFront);
            this.customPanel4.Controls.Add(this.btnRight);
            this.customPanel4.Controls.Add(this.btnTop);
            this.customPanel4.Controls.Add(this.MG_Viewer1);
            this.customPanel4.Curvature = 8;
            this.customPanel4.ForeColor = System.Drawing.Color.Black;
            this.customPanel4.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel4.Location = new System.Drawing.Point(9, 6);
            this.customPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.Size = new System.Drawing.Size(430, 319);
            this.customPanel4.TabIndex = 46;
            // 
            // btnCompleted
            // 
            this.btnCompleted.BackColor = System.Drawing.Color.Black;
            this.btnCompleted.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleted.Image = global::CNCInfusion.Properties.Resources.eye;
            this.btnCompleted.Location = new System.Drawing.Point(7, 287);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(22, 22);
            this.btnCompleted.TabIndex = 58;
            this.btnCompleted.Tag = "";
            this.CodeTip.SetToolTip(this.btnCompleted, "Listbox Index/Total View");
            this.btnCompleted.UseVisualStyleBackColor = false;
            this.btnCompleted.Click += new System.EventHandler(this.BtnCompletedClick);
            // 
            // btnToolFilter
            // 
            this.btnToolFilter.BackColor = System.Drawing.Color.Black;
            this.btnToolFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnToolFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolFilter.Image = global::CNCInfusion.Properties.Resources.wrench_orange;
            this.btnToolFilter.Location = new System.Drawing.Point(7, 244);
            this.btnToolFilter.Name = "btnToolFilter";
            this.btnToolFilter.Size = new System.Drawing.Size(22, 22);
            this.btnToolFilter.TabIndex = 57;
            this.btnToolFilter.Tag = "";
            this.CodeTip.SetToolTip(this.btnToolFilter, "Tool Filter");
            this.btnToolFilter.UseVisualStyleBackColor = false;
            this.btnToolFilter.Click += new System.EventHandler(this.tsbToolsFilter_Click);
            // 
            // btnAxisIndicator
            // 
            this.btnAxisIndicator.BackColor = System.Drawing.Color.Black;
            this.btnAxisIndicator.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnAxisIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxisIndicator.Image = global::CNCInfusion.Properties.Resources.chart_curve_edit;
            this.btnAxisIndicator.Location = new System.Drawing.Point(7, 210);
            this.btnAxisIndicator.Name = "btnAxisIndicator";
            this.btnAxisIndicator.Size = new System.Drawing.Size(22, 22);
            this.btnAxisIndicator.TabIndex = 56;
            this.btnAxisIndicator.Tag = "";
            this.CodeTip.SetToolTip(this.btnAxisIndicator, "Axis Indicator");
            this.btnAxisIndicator.UseVisualStyleBackColor = false;
            this.btnAxisIndicator.Click += new System.EventHandler(this.BtnAxisIndicatorClick);
            // 
            // btnAxisLines
            // 
            this.btnAxisLines.BackColor = System.Drawing.Color.Black;
            this.btnAxisLines.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnAxisLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxisLines.Image = global::CNCInfusion.Properties.Resources.bullet_toggle_plus;
            this.btnAxisLines.Location = new System.Drawing.Point(7, 182);
            this.btnAxisLines.Name = "btnAxisLines";
            this.btnAxisLines.Size = new System.Drawing.Size(22, 22);
            this.btnAxisLines.TabIndex = 55;
            this.btnAxisLines.Tag = "";
            this.CodeTip.SetToolTip(this.btnAxisLines, "Axis Lines");
            this.btnAxisLines.UseVisualStyleBackColor = false;
            this.btnAxisLines.Click += new System.EventHandler(this.BtnAxisLinesClick);
            // 
            // btnRapidPoints
            // 
            this.btnRapidPoints.BackColor = System.Drawing.Color.Black;
            this.btnRapidPoints.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnRapidPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapidPoints.Image = global::CNCInfusion.Properties.Resources.bullet_blue;
            this.btnRapidPoints.Location = new System.Drawing.Point(7, 154);
            this.btnRapidPoints.Name = "btnRapidPoints";
            this.btnRapidPoints.Size = new System.Drawing.Size(22, 22);
            this.btnRapidPoints.TabIndex = 54;
            this.btnRapidPoints.Tag = "";
            this.CodeTip.SetToolTip(this.btnRapidPoints, "Rapid Points");
            this.btnRapidPoints.UseVisualStyleBackColor = false;
            this.btnRapidPoints.Click += new System.EventHandler(this.BtnRapidPointsClick);
            // 
            // btnRapidLines
            // 
            this.btnRapidLines.BackColor = System.Drawing.Color.Black;
            this.btnRapidLines.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnRapidLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapidLines.Image = global::CNCInfusion.Properties.Resources.chart_line_edit;
            this.btnRapidLines.Location = new System.Drawing.Point(7, 126);
            this.btnRapidLines.Name = "btnRapidLines";
            this.btnRapidLines.Size = new System.Drawing.Size(22, 22);
            this.btnRapidLines.TabIndex = 53;
            this.btnRapidLines.Tag = "";
            this.CodeTip.SetToolTip(this.btnRapidLines, "Rapid Lines");
            this.btnRapidLines.UseVisualStyleBackColor = false;
            this.btnRapidLines.Click += new System.EventHandler(this.BtnRapidLinesClick);
            // 
            // btnISO
            // 
            this.btnISO.BackColor = System.Drawing.Color.Black;
            this.btnISO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnISO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnISO.Image = global::CNCInfusion.Properties.Resources.shape_flip_vertical;
            this.btnISO.Location = new System.Drawing.Point(7, 98);
            this.btnISO.Name = "btnISO";
            this.btnISO.Size = new System.Drawing.Size(22, 22);
            this.btnISO.TabIndex = 52;
            this.CodeTip.SetToolTip(this.btnISO, "Isometric");
            this.btnISO.UseVisualStyleBackColor = false;
            this.btnISO.Click += new System.EventHandler(this.BtnISOClick);
            // 
            // btnFront
            // 
            this.btnFront.BackColor = System.Drawing.Color.Black;
            this.btnFront.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFront.Image = global::CNCInfusion.Properties.Resources.shape_align_middle;
            this.btnFront.Location = new System.Drawing.Point(7, 70);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(22, 22);
            this.btnFront.TabIndex = 51;
            this.CodeTip.SetToolTip(this.btnFront, "Right");
            this.btnFront.UseVisualStyleBackColor = false;
            this.btnFront.Click += new System.EventHandler(this.BtnFrontClick);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Black;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Image = global::CNCInfusion.Properties.Resources.shape_align_left;
            this.btnRight.Location = new System.Drawing.Point(7, 42);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(22, 22);
            this.btnRight.TabIndex = 50;
            this.CodeTip.SetToolTip(this.btnRight, "Front");
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.BtnRightClick);
            // 
            // btnTop
            // 
            this.btnTop.BackColor = System.Drawing.Color.Black;
            this.btnTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTop.Image = global::CNCInfusion.Properties.Resources.shape_align_center;
            this.btnTop.Location = new System.Drawing.Point(7, 14);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(22, 22);
            this.btnTop.TabIndex = 49;
            this.CodeTip.SetToolTip(this.btnTop, "Top");
            this.btnTop.UseVisualStyleBackColor = false;
            this.btnTop.Click += new System.EventHandler(this.BtnTopClick);
            // 
            // MG_Viewer1
            // 
            this.MG_Viewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MG_Viewer1.AxisIndicatorScale = 0.75F;
            this.MG_Viewer1.BackColor = System.Drawing.Color.Black;
            this.MG_Viewer1.BreakPoint = -1;
            this.MG_Viewer1.ContextMenuStrip = this.rmbView;
            this.MG_Viewer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MG_Viewer1.DynamicViewManipulation = true;
            this.MG_Viewer1.FourthAxis = 0F;
            this.MG_Viewer1.Location = new System.Drawing.Point(32, 8);
            this.MG_Viewer1.Margin = new System.Windows.Forms.Padding(0);
            this.MG_Viewer1.Name = "MG_Viewer1";
            this.MG_Viewer1.Pitch = 0F;
            this.MG_Viewer1.Roll = 0F;
            this.MG_Viewer1.RotaryType = MacGen.RotaryMotionType.BMC;
            this.MG_Viewer1.Size = new System.Drawing.Size(388, 303);
            this.MG_Viewer1.TabIndex = 9;
            this.MG_Viewer1.ViewManipMode = MacGen.MG_CS_BasicViewer.ManipMode.SELECTION;
            this.MG_Viewer1.Yaw = 0F;
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BackColor = System.Drawing.Color.Gray;
            this.customPanel1.BackColor2 = System.Drawing.Color.Gray;
            this.customPanel1.BorderColor = System.Drawing.Color.Gold;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 2;
            this.customPanel1.Controls.Add(this.rbWorld);
            this.customPanel1.Controls.Add(this.rbMachine);
            this.customPanel1.Controls.Add(this.btnZeroAll);
            this.customPanel1.Controls.Add(this.btnZeroZ);
            this.customPanel1.Controls.Add(this.btnZeroY);
            this.customPanel1.Controls.Add(this.btnZeroX);
            this.customPanel1.Controls.Add(this.Zdisplay);
            this.customPanel1.Controls.Add(this.Ydisplay);
            this.customPanel1.Controls.Add(this.Xdisplay);
            this.customPanel1.Curvature = 8;
            this.customPanel1.Enabled = false;
            this.customPanel1.ForeColor = System.Drawing.Color.Black;
            this.customPanel1.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel1.Location = new System.Drawing.Point(445, 41);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(327, 258);
            this.customPanel1.TabIndex = 45;
            // 
            // rbWorld
            // 
            this.rbWorld.Checked = true;
            this.rbWorld.Location = new System.Drawing.Point(232, 220);
            this.rbWorld.Name = "rbWorld";
            this.rbWorld.Size = new System.Drawing.Size(59, 24);
            this.rbWorld.TabIndex = 1;
            this.rbWorld.TabStop = true;
            this.rbWorld.Text = "World";
            this.rbWorld.UseVisualStyleBackColor = true;
            // 
            // rbMachine
            // 
            this.rbMachine.Location = new System.Drawing.Point(232, 202);
            this.rbMachine.Name = "rbMachine";
            this.rbMachine.Size = new System.Drawing.Size(71, 24);
            this.rbMachine.TabIndex = 0;
            this.rbMachine.Text = "Machine";
            this.rbMachine.UseVisualStyleBackColor = true;
            // 
            // btnZeroAll
            // 
            this.btnZeroAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZeroAll.BackColor = System.Drawing.Color.Silver;
            this.btnZeroAll.Location = new System.Drawing.Point(8, 202);
            this.btnZeroAll.Name = "btnZeroAll";
            this.btnZeroAll.Size = new System.Drawing.Size(50, 37);
            this.btnZeroAll.TabIndex = 50;
            this.btnZeroAll.Text = "Zero All";
            this.btnZeroAll.UseVisualStyleBackColor = false;
            this.btnZeroAll.Click += new System.EventHandler(this.BtnZeroAllClick);
            // 
            // btnZeroZ
            // 
            this.btnZeroZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZeroZ.BackColor = System.Drawing.Color.Silver;
            this.btnZeroZ.Location = new System.Drawing.Point(8, 140);
            this.btnZeroZ.Name = "btnZeroZ";
            this.btnZeroZ.Size = new System.Drawing.Size(50, 37);
            this.btnZeroZ.TabIndex = 49;
            this.btnZeroZ.Text = "Z";
            this.btnZeroZ.UseVisualStyleBackColor = false;
            this.btnZeroZ.Click += new System.EventHandler(this.BtnZeroZClick);
            // 
            // btnZeroY
            // 
            this.btnZeroY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZeroY.BackColor = System.Drawing.Color.Silver;
            this.btnZeroY.Location = new System.Drawing.Point(8, 77);
            this.btnZeroY.Name = "btnZeroY";
            this.btnZeroY.Size = new System.Drawing.Size(50, 35);
            this.btnZeroY.TabIndex = 48;
            this.btnZeroY.Text = "Y";
            this.btnZeroY.UseVisualStyleBackColor = false;
            this.btnZeroY.Click += new System.EventHandler(this.BtnZeroYClick);
            // 
            // btnZeroX
            // 
            this.btnZeroX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZeroX.BackColor = System.Drawing.Color.Silver;
            this.btnZeroX.Location = new System.Drawing.Point(8, 14);
            this.btnZeroX.Name = "btnZeroX";
            this.btnZeroX.Size = new System.Drawing.Size(50, 37);
            this.btnZeroX.TabIndex = 47;
            this.btnZeroX.Text = "X";
            this.btnZeroX.UseVisualStyleBackColor = false;
            this.btnZeroX.Click += new System.EventHandler(this.BtnZeroXClick);
            // 
            // Zdisplay
            // 
            this.Zdisplay.ArrayCount = 7;
            this.Zdisplay.ColorBackground = System.Drawing.Color.Gray;
            this.Zdisplay.ColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Zdisplay.ColorLight = System.Drawing.Color.Gold;
            this.Zdisplay.DecimalShow = true;
            this.Zdisplay.ElementPadding = new System.Windows.Forms.Padding(4);
            this.Zdisplay.ElementWidth = 10;
            this.Zdisplay.ItalicFactor = -0.1F;
            this.Zdisplay.Location = new System.Drawing.Point(73, 140);
            this.Zdisplay.Name = "Zdisplay";
            this.Zdisplay.Size = new System.Drawing.Size(240, 57);
            this.Zdisplay.TabIndex = 2;
            this.Zdisplay.TabStop = false;
            this.Zdisplay.Value = "000.000";
            // 
            // Ydisplay
            // 
            this.Ydisplay.ArrayCount = 7;
            this.Ydisplay.ColorBackground = System.Drawing.Color.Gray;
            this.Ydisplay.ColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Ydisplay.ColorLight = System.Drawing.Color.Gold;
            this.Ydisplay.DecimalShow = true;
            this.Ydisplay.ElementPadding = new System.Windows.Forms.Padding(4);
            this.Ydisplay.ElementWidth = 10;
            this.Ydisplay.ItalicFactor = -0.1F;
            this.Ydisplay.Location = new System.Drawing.Point(73, 77);
            this.Ydisplay.Name = "Ydisplay";
            this.Ydisplay.Size = new System.Drawing.Size(240, 57);
            this.Ydisplay.TabIndex = 1;
            this.Ydisplay.TabStop = false;
            this.Ydisplay.Value = "000.000";
            this.Ydisplay.Load += new System.EventHandler(this.YdisplayLoad);
            // 
            // Xdisplay
            // 
            this.Xdisplay.ArrayCount = 7;
            this.Xdisplay.ColorBackground = System.Drawing.Color.Gray;
            this.Xdisplay.ColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Xdisplay.ColorLight = System.Drawing.Color.Gold;
            this.Xdisplay.DecimalShow = true;
            this.Xdisplay.ElementPadding = new System.Windows.Forms.Padding(4);
            this.Xdisplay.ElementWidth = 10;
            this.Xdisplay.ItalicFactor = -0.1F;
            this.Xdisplay.Location = new System.Drawing.Point(73, 14);
            this.Xdisplay.Name = "Xdisplay";
            this.Xdisplay.Size = new System.Drawing.Size(240, 57);
            this.Xdisplay.TabIndex = 0;
            this.Xdisplay.TabStop = false;
            this.Xdisplay.Value = "000.000";
            // 
            // customPanel5
            // 
            this.customPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customPanel5.BackColor2 = System.Drawing.Color.Gray;
            this.customPanel5.BorderColor = System.Drawing.Color.Gold;
            this.customPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel5.BorderWidth = 2;
            this.customPanel5.Controls.Add(this.tabControl1);
            this.customPanel5.Curvature = 8;
            this.customPanel5.ForeColor = System.Drawing.Color.Black;
            this.customPanel5.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel5.Location = new System.Drawing.Point(445, 305);
            this.customPanel5.Name = "customPanel5";
            this.customPanel5.Size = new System.Drawing.Size(327, 220);
            this.customPanel5.TabIndex = 47;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.AutoPage);
            this.tabControl1.Controls.Add(this.jogPage);
            this.tabControl1.Controls.Add(this.MDIpage);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(11, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 193);
            this.tabControl1.TabIndex = 37;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
            // 
            // AutoPage
            // 
            this.AutoPage.BackColor = System.Drawing.Color.Gray;
            this.AutoPage.Controls.Add(this.lblFeedOverride);
            this.AutoPage.Controls.Add(this.btnCancel);
            this.AutoPage.Controls.Add(this.lbKnob1);
            this.AutoPage.Controls.Add(this.btnRun);
            this.AutoPage.Controls.Add(this.label4);
            this.AutoPage.Controls.Add(this.btnFeedHold);
            this.AutoPage.Location = new System.Drawing.Point(4, 25);
            this.AutoPage.Name = "AutoPage";
            this.AutoPage.Padding = new System.Windows.Forms.Padding(3);
            this.AutoPage.Size = new System.Drawing.Size(297, 164);
            this.AutoPage.TabIndex = 0;
            this.AutoPage.Text = "Auto";
            // 
            // lblFeedOverride
            // 
            this.lblFeedOverride.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFeedOverride.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFeedOverride.Location = new System.Drawing.Point(207, 137);
            this.lblFeedOverride.Name = "lblFeedOverride";
            this.lblFeedOverride.Size = new System.Drawing.Size(51, 18);
            this.lblFeedOverride.TabIndex = 29;
            this.lblFeedOverride.Text = "100%";
            this.lblFeedOverride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Coral;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(13, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 49);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Abort";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // lbKnob1
            // 
            this.lbKnob1.BackColor = System.Drawing.Color.Transparent;
            this.lbKnob1.IndicatorColor = System.Drawing.Color.Gold;
            this.lbKnob1.IndicatorOffset = 10F;
            this.lbKnob1.KnobColor = System.Drawing.Color.DimGray;
            this.lbKnob1.Location = new System.Drawing.Point(191, 42);
            this.lbKnob1.MaxValue = 150F;
            this.lbKnob1.MinValue = 50F;
            this.lbKnob1.Name = "lbKnob1";
            this.lbKnob1.Renderer = null;
            this.lbKnob1.ScaleColor = System.Drawing.Color.Gray;
            this.lbKnob1.Size = new System.Drawing.Size(85, 92);
            this.lbKnob1.StepValue = 1F;
            this.lbKnob1.Style = CPOL.Knobs.LBKnob.KnobStyle.Circular;
            this.lbKnob1.TabIndex = 27;
            this.lbKnob1.Value = 0F;
            this.lbKnob1.KnobChangeValue += new CPOL.Knobs.KnobChangeValue(this.LbKnob1KnobChangeValue);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Enabled = false;
            this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRun.FlatAppearance.BorderSize = 2;
            this.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnRun.Location = new System.Drawing.Point(13, 18);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 49);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(188, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Feed rate override";
            // 
            // btnFeedHold
            // 
            this.btnFeedHold.BackColor = System.Drawing.Color.Khaki;
            this.btnFeedHold.Enabled = false;
            this.btnFeedHold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnFeedHold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnFeedHold.Location = new System.Drawing.Point(94, 18);
            this.btnFeedHold.Name = "btnFeedHold";
            this.btnFeedHold.Size = new System.Drawing.Size(75, 49);
            this.btnFeedHold.TabIndex = 10;
            this.btnFeedHold.Text = "Feed Hold";
            this.btnFeedHold.UseVisualStyleBackColor = false;
            this.btnFeedHold.Click += new System.EventHandler(this.BtnFeedHoldClick);
            // 
            // jogPage
            // 
            this.jogPage.BackColor = System.Drawing.Color.Gray;
            this.jogPage.Controls.Add(this.label3);
            this.jogPage.Controls.Add(this.cbJogSpeed);
            this.jogPage.Controls.Add(this.btnZminus);
            this.jogPage.Controls.Add(this.btnYminus);
            this.jogPage.Controls.Add(this.btnXminus);
            this.jogPage.Controls.Add(this.btnZplus);
            this.jogPage.Controls.Add(this.btnYplus);
            this.jogPage.Controls.Add(this.btnXplus);
            this.jogPage.Location = new System.Drawing.Point(4, 25);
            this.jogPage.Name = "jogPage";
            this.jogPage.Padding = new System.Windows.Forms.Padding(3);
            this.jogPage.Size = new System.Drawing.Size(297, 164);
            this.jogPage.TabIndex = 1;
            this.jogPage.Text = "Jog";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(184, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Jog Speed";
            // 
            // cbJogSpeed
            // 
            this.cbJogSpeed.FormattingEnabled = true;
            this.cbJogSpeed.Location = new System.Drawing.Point(184, 10);
            this.cbJogSpeed.Name = "cbJogSpeed";
            this.cbJogSpeed.Size = new System.Drawing.Size(97, 21);
            this.cbJogSpeed.TabIndex = 17;
            // 
            // btnZminus
            // 
            this.btnZminus.BackColor = System.Drawing.Color.Khaki;
            this.btnZminus.Location = new System.Drawing.Point(94, 112);
            this.btnZminus.Name = "btnZminus";
            this.btnZminus.Size = new System.Drawing.Size(75, 49);
            this.btnZminus.TabIndex = 16;
            this.btnZminus.Text = "Z-";
            this.btnZminus.UseVisualStyleBackColor = false;
            this.btnZminus.Click += new System.EventHandler(this.BtnZminusClick);
            // 
            // btnYminus
            // 
            this.btnYminus.BackColor = System.Drawing.Color.Khaki;
            this.btnYminus.Location = new System.Drawing.Point(94, 60);
            this.btnYminus.Name = "btnYminus";
            this.btnYminus.Size = new System.Drawing.Size(75, 49);
            this.btnYminus.TabIndex = 15;
            this.btnYminus.Text = "Y-";
            this.btnYminus.UseVisualStyleBackColor = false;
            this.btnYminus.Click += new System.EventHandler(this.BtnYminusClick);
            // 
            // btnXminus
            // 
            this.btnXminus.BackColor = System.Drawing.Color.Khaki;
            this.btnXminus.Location = new System.Drawing.Point(94, 9);
            this.btnXminus.Name = "btnXminus";
            this.btnXminus.Size = new System.Drawing.Size(75, 49);
            this.btnXminus.TabIndex = 14;
            this.btnXminus.Text = "X-";
            this.btnXminus.UseVisualStyleBackColor = false;
            this.btnXminus.Click += new System.EventHandler(this.BtnXminusClick);
            // 
            // btnZplus
            // 
            this.btnZplus.BackColor = System.Drawing.Color.Khaki;
            this.btnZplus.Location = new System.Drawing.Point(13, 112);
            this.btnZplus.Name = "btnZplus";
            this.btnZplus.Size = new System.Drawing.Size(75, 49);
            this.btnZplus.TabIndex = 13;
            this.btnZplus.Text = "Z+";
            this.btnZplus.UseVisualStyleBackColor = false;
            this.btnZplus.Click += new System.EventHandler(this.BtnZplusClick);
            // 
            // btnYplus
            // 
            this.btnYplus.BackColor = System.Drawing.Color.Khaki;
            this.btnYplus.Location = new System.Drawing.Point(13, 60);
            this.btnYplus.Name = "btnYplus";
            this.btnYplus.Size = new System.Drawing.Size(75, 49);
            this.btnYplus.TabIndex = 12;
            this.btnYplus.Text = "Y+";
            this.btnYplus.UseVisualStyleBackColor = false;
            this.btnYplus.Click += new System.EventHandler(this.BtnYplusClick);
            // 
            // btnXplus
            // 
            this.btnXplus.BackColor = System.Drawing.Color.Khaki;
            this.btnXplus.Location = new System.Drawing.Point(13, 9);
            this.btnXplus.Name = "btnXplus";
            this.btnXplus.Size = new System.Drawing.Size(75, 49);
            this.btnXplus.TabIndex = 11;
            this.btnXplus.Text = "X+";
            this.btnXplus.UseVisualStyleBackColor = false;
            this.btnXplus.Click += new System.EventHandler(this.BtnXplusClick);
            // 
            // MDIpage
            // 
            this.MDIpage.BackColor = System.Drawing.Color.Gray;
            this.MDIpage.Controls.Add(this.label2);
            this.MDIpage.Controls.Add(this.cbMDIHistory);
            this.MDIpage.Controls.Add(this.label7);
            this.MDIpage.Controls.Add(this.tbMDICommand);
            this.MDIpage.Controls.Add(this.btnMDIExecute);
            this.MDIpage.Location = new System.Drawing.Point(4, 25);
            this.MDIpage.Name = "MDIpage";
            this.MDIpage.Padding = new System.Windows.Forms.Padding(3);
            this.MDIpage.Size = new System.Drawing.Size(297, 164);
            this.MDIpage.TabIndex = 2;
            this.MDIpage.Text = "MDI";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "History";
            // 
            // cbMDIHistory
            // 
            this.cbMDIHistory.FormattingEnabled = true;
            this.cbMDIHistory.Location = new System.Drawing.Point(21, 64);
            this.cbMDIHistory.Name = "cbMDIHistory";
            this.cbMDIHistory.Size = new System.Drawing.Size(219, 21);
            this.cbMDIHistory.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(21, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 11);
            this.label7.TabIndex = 25;
            this.label7.Text = "Command";
            // 
            // tbMDICommand
            // 
            this.tbMDICommand.Location = new System.Drawing.Point(21, 24);
            this.tbMDICommand.Name = "tbMDICommand";
            this.tbMDICommand.Size = new System.Drawing.Size(219, 20);
            this.tbMDICommand.TabIndex = 13;
            // 
            // btnMDIExecute
            // 
            this.btnMDIExecute.BackColor = System.Drawing.Color.Khaki;
            this.btnMDIExecute.Location = new System.Drawing.Point(21, 107);
            this.btnMDIExecute.Name = "btnMDIExecute";
            this.btnMDIExecute.Size = new System.Drawing.Size(75, 34);
            this.btnMDIExecute.TabIndex = 12;
            this.btnMDIExecute.Text = "Execute";
            this.btnMDIExecute.UseVisualStyleBackColor = false;
            this.btnMDIExecute.Click += new System.EventHandler(this.BtnMDIExecuteClick);
            // 
            // customPanel8
            // 
            this.customPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel8.BackColor = System.Drawing.Color.Gray;
            this.customPanel8.BackColor2 = System.Drawing.Color.Gray;
            this.customPanel8.BorderColor = System.Drawing.Color.Gold;
            this.customPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel8.BorderWidth = 2;
            this.customPanel8.Controls.Add(this.lblGcodeMode);
            this.customPanel8.Controls.Add(this.listBoxGcode);
            this.customPanel8.Curvature = 8;
            this.customPanel8.ForeColor = System.Drawing.Color.Black;
            this.customPanel8.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel8.Location = new System.Drawing.Point(9, 331);
            this.customPanel8.Name = "customPanel8";
            this.customPanel8.Size = new System.Drawing.Size(330, 194);
            this.customPanel8.TabIndex = 44;
            // 
            // lblGcodeMode
            // 
            this.lblGcodeMode.AutoSize = true;
            this.lblGcodeMode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGcodeMode.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblGcodeMode.Location = new System.Drawing.Point(7, 7);
            this.lblGcodeMode.Name = "lblGcodeMode";
            this.lblGcodeMode.Size = new System.Drawing.Size(43, 13);
            this.lblGcodeMode.TabIndex = 3;
            this.lblGcodeMode.Text = "Gcode";
            // 
            // listBoxGcode
            // 
            this.listBoxGcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxGcode.BackColor = System.Drawing.Color.Gray;
            this.listBoxGcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxGcode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGcode.FormattingEnabled = true;
            this.listBoxGcode.ItemHeight = 14;
            this.listBoxGcode.Location = new System.Drawing.Point(9, 25);
            this.listBoxGcode.Name = "listBoxGcode";
            this.listBoxGcode.Size = new System.Drawing.Size(312, 154);
            this.listBoxGcode.TabIndex = 25;
            this.listBoxGcode.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.BackColor = System.Drawing.Color.Gray;
            this.pnlControl.BackColor2 = System.Drawing.Color.Gray;
            this.pnlControl.BorderColor = System.Drawing.Color.Gold;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.BorderWidth = 2;
            this.pnlControl.Controls.Add(this.btnDisconnect);
            this.pnlControl.Controls.Add(this.btnLoad);
            this.pnlControl.Controls.Add(this.btnConnect);
            this.pnlControl.Controls.Add(this.btnReset);
            this.pnlControl.Curvature = 8;
            this.pnlControl.ForeColor = System.Drawing.Color.Black;
            this.pnlControl.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.pnlControl.Location = new System.Drawing.Point(345, 331);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(94, 194);
            this.pnlControl.TabIndex = 43;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.BackColor = System.Drawing.Color.Silver;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(9, 74);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 31);
            this.btnDisconnect.TabIndex = 40;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnectClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.Khaki;
            this.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnLoad.Location = new System.Drawing.Point(9, 8);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 32);
            this.btnLoad.TabIndex = 39;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.Silver;
            this.btnConnect.Location = new System.Drawing.Point(9, 42);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 31);
            this.btnConnect.TabIndex = 24;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Coral;
            this.btnReset.Enabled = false;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(9, 152);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 31);
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // customPanel2
            // 
            this.customPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel2.BackColor = System.Drawing.Color.DimGray;
            this.customPanel2.BackColor2 = System.Drawing.Color.Silver;
            this.customPanel2.BorderColor = System.Drawing.Color.Gold;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 2;
            this.customPanel2.Controls.Add(this.btnSettings);
            this.customPanel2.Controls.Add(this.btnAbout);
            this.customPanel2.Controls.Add(this.lblVersion);
            this.customPanel2.Curvature = 4;
            this.customPanel2.ForeColor = System.Drawing.Color.Black;
            this.customPanel2.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
            this.customPanel2.Location = new System.Drawing.Point(445, 6);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(327, 29);
            this.customPanel2.TabIndex = 42;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Khaki;
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.Image = global::CNCInfusion.Properties.Resources.cog;
            this.btnSettings.Location = new System.Drawing.Point(281, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(22, 22);
            this.btnSettings.TabIndex = 54;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Khaki;
            this.btnAbout.ForeColor = System.Drawing.Color.Black;
            this.btnAbout.Image = global::CNCInfusion.Properties.Resources.information;
            this.btnAbout.Location = new System.Drawing.Point(302, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(22, 22);
            this.btnAbout.TabIndex = 53;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.BtnAboutClick);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(3, 6);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(183, 17);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "CNCInfusion: Grbl GUI";
            // 
            // frmViewer
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.customPanel4);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.customPanel5);
            this.Controls.Add(this.customPanel8);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.customPanel2);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(68, 66);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "CNCInfusion: Grbl GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewerFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmViewerFormClosed);
            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.ResizeEnd += new System.EventHandler(this.frmViewer_ResizeEnd);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.rmbView.ResumeLayout(false);
            this.customPanel4.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.customPanel5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.AutoPage.ResumeLayout(false);
            this.jogPage.ResumeLayout(false);
            this.MDIpage.ResumeLayout(false);
            this.MDIpage.PerformLayout();
            this.customPanel8.ResumeLayout(false);
            this.customPanel8.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.RadioButton rbMachine;
        private System.Windows.Forms.RadioButton rbWorld;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblGcodeMode;
        private Utility.Panel.CustomPanel pnlControl;
        private System.Windows.Forms.ComboBox cbJogSpeed;
        private System.Windows.Forms.ComboBox cbMDIHistory;
        private System.Windows.Forms.TextBox tbMDICommand;
        private System.Windows.Forms.Button btnCompleted;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblFeedOverride;
        private System.Windows.Forms.Timer timerStatusQuery;
        private DmitryBrant.CustomControls.SevenSegmentArray Xdisplay;
        private DmitryBrant.CustomControls.SevenSegmentArray Zdisplay;
        private DmitryBrant.CustomControls.SevenSegmentArray Ydisplay;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        private System.Windows.Forms.ToolStripStatusLabel lblTX;
        private System.Windows.Forms.ToolStripStatusLabel lblRX;
        private System.Windows.Forms.ToolStripStatusLabel lblMode;
        private System.Windows.Forms.Button btnToolFilter;
        private System.Windows.Forms.Button btnRapidPoints;
        private System.Windows.Forms.Button btnAxisLines;
        private System.Windows.Forms.Button btnAxisIndicator;
        private System.Windows.Forms.Button btnRapidLines;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnZminus;
        private System.Windows.Forms.Button btnYminus;
        private System.Windows.Forms.Button btnXminus;
        private System.Windows.Forms.Button btnZplus;
        private System.Windows.Forms.Button btnYplus;
        private System.Windows.Forms.Button btnXplus;
        private System.Windows.Forms.Button btnMDIExecute;
        private System.Windows.Forms.TabPage AutoPage;
        private System.Windows.Forms.TabPage jogPage;
        private System.Windows.Forms.TabPage MDIpage;
        private System.Windows.Forms.Button btnFeedHold;
        private System.Windows.Forms.Button btnZeroZ;
        private System.Windows.Forms.Button btnZeroY;
        private System.Windows.Forms.Button btnZeroX;
        private System.Windows.Forms.Button btnZeroAll;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.ToolStripComboBox cbxComPort;
        private System.Windows.Forms.ListBox listBoxGcode;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnISO;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private CPOL.Knobs.LBKnob lbKnob1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Utility.Panel.CustomPanel customPanel5;
        private Utility.Panel.CustomPanel customPanel4;
        private Utility.Panel.CustomPanel customPanel1;
        private Utility.Panel.CustomPanel customPanel8;
        private Utility.Panel.CustomPanel customPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;

        #endregion

        public System.Windows.Forms.ToolTip CodeTip;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel lblStatus;
        internal System.Windows.Forms.ToolStripStatusLabel Coordinates;
        internal System.Windows.Forms.ToolStripProgressBar Progress;
        internal System.Windows.Forms.ContextMenuStrip rmbView;
        internal System.Windows.Forms.ToolStripMenuItem mnuFit;
        internal System.Windows.Forms.ToolStripMenuItem mnuFence;
        internal System.Windows.Forms.ToolStripMenuItem mnuPan;
        internal System.Windows.Forms.ToolStripMenuItem mnuRotate;
        internal System.Windows.Forms.ToolStripMenuItem mnuZoom;
        internal System.Windows.Forms.ToolStripMenuItem mnuSelect;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal MacGen.MG_CS_BasicViewer MG_Viewer1;
        
        

        

        

        
        void YdisplayLoad(object sender, System.EventArgs e)
        {
        	
        }
    }
}


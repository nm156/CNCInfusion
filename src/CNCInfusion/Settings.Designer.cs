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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSetSettings = new System.Windows.Forms.Button();
			this.btnReadSettings = new System.Windows.Forms.Button();
			this.pnlSettings = new Utility.Panel.CustomPanel();
			this.trackbarUpdateInterval = new System.Windows.Forms.TrackBar();
			this.customPanel1 = new Utility.Panel.CustomPanel();
			this.lblUpdate = new System.Windows.Forms.Label();
			this.rbStatusUpdate = new System.Windows.Forms.RadioButton();
			this.customPanel2 = new Utility.Panel.CustomPanel();
			lblUpdateInterval = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.pnlSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackbarUpdateInterval)).BeginInit();
			this.customPanel1.SuspendLayout();
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
									this.Column2});
			this.dataGridView1.Location = new System.Drawing.Point(112, 12);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.ShowEditingIcon = false;
			this.dataGridView1.Size = new System.Drawing.Size(362, 214);
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView1CellValidating);
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
			this.Column2.HeaderText = "Value";
			this.Column2.Name = "Column2";
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
			this.pnlSettings.Location = new System.Drawing.Point(12, 12);
			this.pnlSettings.Name = "pnlSettings";
			this.pnlSettings.Size = new System.Drawing.Size(94, 213);
			this.pnlSettings.TabIndex = 44;
			// 
			// trackbarUpdateInterval
			// 
			this.trackbarUpdateInterval.AutoSize = false;
			this.trackbarUpdateInterval.BackColor = System.Drawing.Color.Gray;
			this.trackbarUpdateInterval.LargeChange = 50;
			this.trackbarUpdateInterval.Location = new System.Drawing.Point(9, 34);
			this.trackbarUpdateInterval.Maximum = 500;
			this.trackbarUpdateInterval.Minimum = 50;
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
			this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
			this.customPanel1.Location = new System.Drawing.Point(12, 232);
			this.customPanel1.Name = "customPanel1";
			this.customPanel1.Size = new System.Drawing.Size(139, 118);
			this.customPanel1.TabIndex = 46;
			// 
			// lblUpdate
			// 
			this.lblUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUpdate.ForeColor = System.Drawing.Color.Gainsboro;
			this.lblUpdate.Location = new System.Drawing.Point(9, 67);
			this.lblUpdate.Name = "lblUpdate";
			this.lblUpdate.Size = new System.Drawing.Size(118, 18);
			this.lblUpdate.TabIndex = 48;
			this.lblUpdate.Text = "5 updates / second";
			this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rbStatusUpdate
			// 
			this.rbStatusUpdate.AutoCheck = false;
			this.rbStatusUpdate.Location = new System.Drawing.Point(9, 88);
			this.rbStatusUpdate.Name = "rbStatusUpdate";
			this.rbStatusUpdate.Size = new System.Drawing.Size(75, 24);
			this.rbStatusUpdate.TabIndex = 47;
			this.rbStatusUpdate.Text = "Enabled";
			this.rbStatusUpdate.UseVisualStyleBackColor = true;
			this.rbStatusUpdate.Click += new System.EventHandler(this.RbStatusUpdateClick);
			// 
			// customPanel2
			// 
			this.customPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.customPanel2.BackColor = System.Drawing.Color.Gray;
			this.customPanel2.BackColor2 = System.Drawing.Color.Gray;
			this.customPanel2.BorderColor = System.Drawing.Color.Gold;
			this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.customPanel2.BorderWidth = 2;
			this.customPanel2.Curvature = 8;
			this.customPanel2.ForeColor = System.Drawing.Color.Black;
			this.customPanel2.GradientMode = Utility.Panel.LinearGradientMode.Vertical;
			this.customPanel2.Location = new System.Drawing.Point(157, 232);
			this.customPanel2.Name = "customPanel2";
			this.customPanel2.Size = new System.Drawing.Size(317, 118);
			this.customPanel2.TabIndex = 47;
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(484, 362);
			this.Controls.Add(this.customPanel2);
			this.Controls.Add(this.customPanel1);
			this.Controls.Add(this.pnlSettings);
			this.Controls.Add(this.dataGridView1);
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "Settings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Shown += new System.EventHandler(this.SettingsShown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.pnlSettings.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackbarUpdateInterval)).EndInit();
			this.customPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private Utility.Panel.CustomPanel pnlSettings;
		private System.Windows.Forms.Label lblUpdate;
		private System.Windows.Forms.TrackBar trackbarUpdateInterval;
		private System.Windows.Forms.RadioButton rbStatusUpdate;
		private Utility.Panel.CustomPanel customPanel2;
		private Utility.Panel.CustomPanel customPanel1;
		private System.Windows.Forms.Button btnReadSettings;
		private System.Windows.Forms.Button btnSetSettings;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Function;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}

/*
 * Created by SharpDevelop.
 * User: ${USER}
 * Date: ${DATE}
 * Time: ${TIME}
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CNCInfusion
{
	partial class about : System.Windows.Forms.Form
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
			this.lbInfo = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.lbVersion = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbInfo
			// 
			this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbInfo.FormattingEnabled = true;
			this.lbInfo.ItemHeight = 14;
			this.lbInfo.Location = new System.Drawing.Point(12, 58);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(485, 70);
			this.lbInfo.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(509, 32);
			this.panel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Window;
			this.label1.Location = new System.Drawing.Point(10, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(251, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "CNCInfusion ";
			// 
			// lbVersion
			// 
			this.lbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbVersion.Location = new System.Drawing.Point(10, 38);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(161, 17);
			this.lbVersion.TabIndex = 3;
			this.lbVersion.Text = "Version";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(12, 293);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(62, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 14;
			this.listBox1.Items.AddRange(new object[] {
									"Grbl CNC was assembled using many components from code project",
									"and other internet sources.  ",
									"",
									"2012 Paul D. Fincato",
									"Code Project Open License",
									"",
									"",
									"Credit to original authors of components used in this application",
									"",
									"G codebackplot",
									"--------------",
									"Jason Titcomb",
									"http://www.codeproject.com/Articles/17424/CNC-Graphical-Backplotter",
									"Code Project Open License",
									"",
									"7 segment",
									"---------",
									"Dmitry Brant",
									"http://dmitrybrant.com",
									"This component is free for personal use.",
									" ",
									"Custom Panel",
									"------------",
									"Mark Jackson",
									"http://www.codeproject.com/Articles/7641/Customising-the-NET-Panel-control",
									"Code Project Open License",
									"",
									"Knob",
									"----",
									"Luca Bonotto",
									"http://www.codeproject.com/Articles/36116/Industrial-Controls-2",
									"Code Project Open License",
									"",
									"Icons",
									"-----",
									"Mark James",
									"http://www.famfamfam.com/lab/icons/silk/",
									"Creative Commons Attribution 3.0 License",
									"",
									"Joystick",
									"--------",
									"Mark Harris",
									"Interfacing with a Joystick using C#",
									"http://www.codeproject.com/Articles/16704/Interfacing-with-a-Joystick-using-C",
									" ",
									"",
									"Kudos to the Grbl innovators for a great project!",
									"",
									"https://github.com/grbl/grbl"});
			this.listBox1.Location = new System.Drawing.Point(12, 142);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(485, 144);
			this.listBox1.TabIndex = 13;
			// 
			// about
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 331);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "about";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox lbInfo;
		
		void RichTextBox1TextChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}

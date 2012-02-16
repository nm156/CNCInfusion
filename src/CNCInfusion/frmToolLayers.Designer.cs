namespace CSharpBasicViewerApp
{
    partial class frmToolLayers
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
            this.btnDone = new System.Windows.Forms.Button();
            this.tvTools = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDone.Location = new System.Drawing.Point(21, 172);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(61, 26);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // tvTools
            // 
            this.tvTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTools.CheckBoxes = true;
            this.tvTools.Location = new System.Drawing.Point(0, 0);
            this.tvTools.Name = "tvTools";
            this.tvTools.ShowLines = false;
            this.tvTools.ShowPlusMinus = false;
            this.tvTools.ShowRootLines = false;
            this.tvTools.Size = new System.Drawing.Size(102, 166);
            this.tvTools.TabIndex = 2;
            this.tvTools.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvTools_AfterCheck);
            this.tvTools.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTools_BeforeSelect);
            // 
            // frmToolLayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDone;
            this.ClientSize = new System.Drawing.Size(102, 199);
            this.ControlBox = false;
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.tvTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmToolLayers";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnDone;
        internal System.Windows.Forms.TreeView tvTools;


    }
}
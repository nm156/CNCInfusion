namespace CSharpBasicViewerApp;

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
        btnDone = new System.Windows.Forms.Button();
        tvTools = new System.Windows.Forms.TreeView();
        SuspendLayout();
        // 
        // btnDone
        // 
        btnDone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnDone.Location = new System.Drawing.Point(24, 262);
        btnDone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnDone.Name = "btnDone";
        btnDone.Size = new System.Drawing.Size(114, 30);
        btnDone.TabIndex = 3;
        btnDone.Text = "Done";
        btnDone.UseVisualStyleBackColor = true;
        btnDone.Click += btnDone_Click;
        // 
        // tvTools
        // 
        tvTools.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        tvTools.CheckBoxes = true;
        tvTools.Location = new System.Drawing.Point(0, 0);
        tvTools.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        tvTools.Name = "tvTools";
        tvTools.ShowLines = false;
        tvTools.ShowPlusMinus = false;
        tvTools.ShowRootLines = false;
        tvTools.Size = new System.Drawing.Size(161, 255);
        tvTools.TabIndex = 2;
        tvTools.AfterCheck += tvTools_AfterCheck;
        tvTools.BeforeSelect += tvTools_BeforeSelect;
        // 
        // frmToolLayers
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        CancelButton = btnDone;
        ClientSize = new System.Drawing.Size(162, 294);
        ControlBox = false;
        Controls.Add(btnDone);
        Controls.Add(tvTools);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        Name = "frmToolLayers";
        ResumeLayout(false);
    }

    #endregion

    internal System.Windows.Forms.Button btnDone;
    internal System.Windows.Forms.TreeView tvTools;


}
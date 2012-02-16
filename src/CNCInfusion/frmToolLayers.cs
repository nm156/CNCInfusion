using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpBasicViewerApp
{
    public partial class frmToolLayers : Form
    {
        public frmToolLayers()
        {
            InitializeComponent();
        }

        private void tvTools_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return;
            ((clsToolLayer)e.Node.Tag).Hidden = !e.Node.Checked;
        }

        private void tvTools_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

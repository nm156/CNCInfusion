using System;
using System.Windows.Forms;

namespace CSharpBasicViewerApp;

public partial class frmToolLayers : Form
{
    public frmToolLayers()
    {
        InitializeComponent();
    }

    private void tvTools_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Action == TreeViewAction.Unknown)
        {
            return;
        } ((ClsToolLayer)e.Node.Tag).Hidden = !e.Node.Checked;
    }

    private void tvTools_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        e.Cancel = true;
    }

    private void btnDone_Click(object sender, EventArgs e)
    {
        Close();
    }
}

using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace CNCInfusion;

[SupportedOSPlatform("windows")]
internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        _ = Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.SetDefaultFont(new Font("Segoe UI", 9, FontStyle.Regular));
        Application.Run(new frmViewer());
    }
}

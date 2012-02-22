/*
 * Created by SharpDevelop.
 * User: PAUL_FINCATO
 * Date: 12/19/2006
 * Time: 2:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CNCInfusion
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class about
	{
		public about()
		{
			InitializeComponent();
			
			System.Reflection.Assembly asm;
			System.Reflection.AssemblyName asn;
			asm = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.ExecutablePath);
			asn = asm.GetName();
			lbVersion.Text = "Version: " + asn.Version.ToString();

			foreach (System.Reflection.AssemblyName s in asm.GetReferencedAssemblies())  {
            	lbInfo.Items.Add(s.Name + " [" + s.Version.ToString() + "]");
            }
		}
	
	}
}

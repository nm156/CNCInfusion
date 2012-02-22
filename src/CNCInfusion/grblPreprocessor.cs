/*
 * Created by SharpDevelop.
 * User: pdf
 * Date: 2/17/2012
 * Time: 10:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

/* 
  Excerpt from Grbl source:
  
  Intentionally not supported:

  - Canned cycles
  - Tool radius compensation
  - A,B,C-axes
  - Multiple coordinate systems
  - Evaluation of expressions
  - Variables
  - Multiple home locations
  - Probing
  - Override control

   group 0 = {G10, G28, G30, G92.1, G92.2, G92.3} (Non modal G-codes)
   group 8 = {M7, M8, M9} coolant (special case: M7 and M8 may be active at the same time)
   group 9 = {M48, M49} enable/disable feed and speed override switches
   group 12 = {G54, G55, G56, G57, G58, G59, G59.1, G59.2, G59.3} coordinate system selection
   group 13 = {G61, G61.1, G64} path control mode
*/

// Attempt to only allow Grbl specific gcode
// case statements are explicitly supported codes

namespace CNCInfusion
{
public partial class frmViewer : Form	
{
	private bool GrblPreprocess(string line)
	{
		const string pattern = "[A-Z]([-+]?[0-9]*[\\.,]?[0-9]*)";
		double arg;
		
		Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
		MatchCollection matches = rgx.Matches(line);
		
		if (matches.Count > 0)	{
			foreach (Match match in matches) {
				arg = double.Parse(match.Value.Substring(1));
				switch(match.Value[0]) {
					case 'G':
						// explicitly supported G codes
						switch((int)arg) {
							case 0: 	// MOTION_MODE_SEEK
							case 1:		// MOTION_MODE_LINEAR
							case 2: 	// MOTION_MODE_CW_ARC
							case 3: 	// MOTION_MODE_CCW_ARC
							case 4: 	// DWELL
							case 17:	// select_plane(X_AXIS, Y_AXIS, Z_AXIS); 
							case 18: 	// select_plane(X_AXIS, Z_AXIS, Y_AXIS)
							case 19:	// select_plane(Y_AXIS, Z_AXIS, X_AXIS)
							case 20:	// INCHES
							case 21:	// METRIC
							case 28: 	// GO_HOME
							case 53: 	// absolute_override
							case 80:    // MOTION_MODE_CANCEL    
							case 90: 	// absolute_mode ON
							case 91: 	// absolute_mode OFF
							case 92:    // COORDINATE_OFFSET  
							case 93: 	// inverse_feed_rate ON
							case 94: 	// inverse_feed_rate OFF
								break;
							default:
								// any other G code
								return false;
						}
						break;
					// explicitly supported M codes
					case 'M':
						switch((int)arg) {
							case 0:		// PROGRAM_FLOW_PAUSED
							case 1:		// PROGRAM_FLOW_OPT_PAUSED
							case 2:		// PROGRAM_FLOW_COMPLETED
							case 3:		// spindle_direction = 1
							case 4:		// spindle_direction = -1
							case 5:		// spindle_direction = 0
							case 6:		// TOOL CHANGE (Not supported by Grbl by caught by CNCInfusion)
							case 30:	// PROGRAM_FLOW_COMPLETED
							case 60:	// PROGRAM_FLOW_PAUSED
								break;
							default:
								// any other M code
								return false;
						}
						break;
					// supported codes with any argument
					case 'T':	// TOOL
					case 'F':	// FEEDRATE
					case 'S':	// SPINDLE SPEED
					case 'I':	// ARC
					case 'J':	// ARC
					case 'K':   // ??
					case 'P':   // ??
					case 'R':   // ?? ARC/HELIX?
					case 'X':	// AXIS
					case 'Y':	// AXIS
					case 'Z':	// AXIS
						break;
					default:
						return false;
				}
			}
		}
		return true;
	}
}
	
}


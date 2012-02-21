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
		if (matches.Count > 0)
		{
			foreach (Match match in matches) {
				arg = double.Parse(match.Value.Substring(1));
				switch(match.Value[0]) {
					case 'G':
						// explicitly supported G codes
						switch((int)arg) {
							case 0: 
							case 1:
							case 2: 
							case 3: 
							case 4: 
							case 17: 
							case 18: 
							case 19:
							case 20:
							case 21:
							case 28: 
							case 30: 
							case 53: 
							case 80:       
							case 90: 
							case 91: 
							case 92:      
							case 93: 
							case 94: 
								break;
							default:
								// any other G code
								return false;
						}
						break;
					// explicitly supported M codes
					case 'M':
						switch((int)arg) {
							case 0:
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 30:
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
					//case 'K': // ??
					//case 'P': // ??
					//case 'R': // ??
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

/*
  Excerpt from Grbl source:
 
  
// Executes one line of 0-terminated G-Code. The line is assumed to contain only uppercase
// characters and signed floating point values (no whitespace). Comments and block delete
// characters have been removed.
uint8_t gc_execute_line(char *line) 
{
  uint8_t char_counter = 0;  
  char letter;
  double value;
  double unit_converted_value;
  double inverse_feed_rate = -1; // negative inverse_feed_rate means no inverse_feed_rate specified
  uint8_t radius_mode = false;
  
  uint8_t absolute_override = false;          // 1 = absolute motion for this block only {G53} 
  uint8_t next_action = NEXT_ACTION_DEFAULT;  // The action that will be taken by the parsed line 
  
  double target[3], offset[3];  
  
  double p = 0, r = 0;
  int int_value;

  gc.status_code = STATUS_OK;
  
  // Pass 1: Commands
  while(next_statement(&letter, &value, line, &char_counter)) {
    int_value = trunc(value);
    switch(letter) {
      case 'G':
        switch(int_value) {
          case 0: gc.motion_mode = MOTION_MODE_SEEK; break;
          case 1: gc.motion_mode = MOTION_MODE_LINEAR; break;
          case 2: gc.motion_mode = MOTION_MODE_CW_ARC; break;
          case 3: gc.motion_mode = MOTION_MODE_CCW_ARC; break;
          case 4: next_action = NEXT_ACTION_DWELL; break;
          case 17: select_plane(X_AXIS, Y_AXIS, Z_AXIS); break;
          case 18: select_plane(X_AXIS, Z_AXIS, Y_AXIS); break;
          case 19: select_plane(Y_AXIS, Z_AXIS, X_AXIS); break;
          case 20: gc.inches_mode = true; break;
          case 21: gc.inches_mode = false; break;
          case 28: case 30: next_action = NEXT_ACTION_GO_HOME; break;
          case 53: absolute_override = true; break;
          case 80: gc.motion_mode = MOTION_MODE_CANCEL; break;        
          case 90: gc.absolute_mode = true; break;
          case 91: gc.absolute_mode = false; break;
          case 92: next_action = NEXT_ACTION_SET_COORDINATE_OFFSET; break;        
          case 93: gc.inverse_feed_rate_mode = true; break;
          case 94: gc.inverse_feed_rate_mode = false; break;
          default: FAIL(STATUS_UNSUPPORTED_STATEMENT);
        }
        break;
      case 'M':
        switch(int_value) {
          case 0: case 60: gc.program_flow = PROGRAM_FLOW_PAUSED; break; // Program pause
          case 1: gc.program_flow = PROGRAM_FLOW_OPT_PAUSED; break; // Program pause with optional stop on
          case 2: case 30: gc.program_flow = PROGRAM_FLOW_COMPLETED; break; // Program end and reset 
          case 3: gc.spindle_direction = 1; break;
          case 4: gc.spindle_direction = -1; break;
          case 5: gc.spindle_direction = 0; break;
          default: FAIL(STATUS_UNSUPPORTED_STATEMENT);
        }            
        break;
      case 'T': gc.tool = trunc(value); break;
    }
    if(gc.status_code) { break; }
  }
  
  // If there were any errors parsing this line, we will return right away with the bad news
  if (gc.status_code) { return(gc.status_code); }

  char_counter = 0;
  clear_vector(target);
  clear_vector(offset);
  memcpy(target, gc.position, sizeof(target)); // i.e. target = gc.position

  // Pass 2: Parameters
  while(next_statement(&letter, &value, line, &char_counter)) {
    int_value = trunc(value);
    unit_converted_value = to_millimeters(value);
    switch(letter) {
      case 'F': 
        if (unit_converted_value <= 0) { FAIL(STATUS_BAD_NUMBER_FORMAT); } // Must be greater than zero
        if (gc.inverse_feed_rate_mode) {
          inverse_feed_rate = unit_converted_value; // seconds per motion for this motion only
        } else {          
          if (gc.motion_mode == MOTION_MODE_SEEK) {
            gc.seek_rate = unit_converted_value;
          } else {
            gc.feed_rate = unit_converted_value; // millimeters per minute
          }
        }
        break;
      case 'I': case 'J': case 'K': offset[letter-'I'] = unit_converted_value; break;
      case 'P': p = value; break;
      case 'R': r = unit_converted_value; radius_mode = true; break;
      case 'S': gc.spindle_speed = value; break;
      case 'X': case 'Y': case 'Z':
        if (gc.absolute_mode || absolute_override) {
          target[letter - 'X'] = unit_converted_value;
        } else {
          target[letter - 'X'] += unit_converted_value;
        }
        break;
    }
  }
*/
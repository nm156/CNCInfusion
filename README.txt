What this attempts to be:

A Windows GUI frontend written in C# to control flow of gcode to an
Arduino based Grbl Gcode processor (https://github.com/grbl/grbl)

I have just concentrated on basic functionality for hobby use. My CNC exposure
has been limited to my home built mill, so I am not familiar with most
of the G codes for anything much more than basic motion and spindle control. 

It should be obvious that I am not a professional coder.  If you are, please help
correct and enhance all of my "mis-features".

This was created using:

SharpDevelop 3.2 
http://www.icsharpcode.net/opensource/sd/

targetting .NET 2.0 framework
http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=19

See credits.txt for additional information about the components used

This version assumes Grbl edge (Grbl 0.7d) which uses '?' to report status and 
status is returned in this format :

// Grbl edge status update looks like this:  (Feb 2012)
//MPos:[0.00,0.00,0.00],WPos:[0.00,0.00,0.00]

The Status Update Interval in the settings form will enable reporting and the interval

CNCInfusion has only been tested with this Grbl version (and only with a 'scope), although I suspect it should
work on any version if status updates remain disabled.

HISTORY:
// 0.1.0.0 - initial version
// 0.1.1.0 - feed hold / soft reset 
// 0.1.2.0 - restructuring of serial comm code
//             - known problem with feedhold/cyclestart
// 0.1.3.0 - fixed feedhold/cyclestart problem caused by ok response confusion
//             - known problem ocassionally with re-running after abort 
// 0.1.4.0 - modified delegates for use in threads (created at startup)
//             - starting to create preprocessor that only accepts Grbl gcode
//             - fixed status update interval problem
//             - fixed re-run after abort problem (added lock in commreceive)
//             - added timers for RX and TX indicators
//             - added basic preprocessor for grbl code, now
//               need to coordinate this with what is
//               actually loaded and displayed in the backplotter

FEATURES:

Hardware (DTR) Reset in Settings
Software Reset (0x18) on main form
Feed Hold / Cycle start
Zero Axes - Untested

INCOMPLETE FEATURES:

Status reporting - GRbl is undergoing heavy development in this area. What is
currently there is mostly a placeholder as a proof of concept but is functional

Supported gcodes - The backplotter is robust and supports many more than Grbl.
When Grbl does not recognize a code, it flags it as an error and provides the
opportunity to cancel. A preprocessor in in the works...

Feed Override - Grbl work in progress
JOG - Not yet coded, GUI components in place
MDI - Not yet coded, GUI components in place 
Status of modal gcodes - Maybe some indicators?


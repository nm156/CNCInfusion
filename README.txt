What this attempts to be:

A Windows GUI frontend written in C# to control flow of gcode to an
Arduino based Grbl Gcode processor (https://github.com/grbl/grbl)

I have just concentrated on basic functionality for hobby use. My CNC exposure
has been limited to my home built mill, so I am not familiar with most
of the G codes for anything much more than basic motion and spindle control. 

It should be obvious that I am not a professional coder.  If you are, please help
correct and enhance all of my "mis-features".

This was created using SharpDevelop 3.2 targetting .NET 2.0 framework

This version assumes Grbl edge (Grbl 0.7d) which uses '?' to report status and 
status is returned in this format :

// Grbl edge status update looks like this:  (Feb 2012)
//MPos:[0.00,0.00,0.00],WPos:[0.00,0.00,0.00]

The Status Update Interval in the settings form will enable reporting and the interval

CNCInfusion has only been tested with this Grbl version (and only with a 'scope), although I suspect it should
work on any version if status updates remain disabled.

NEW FEATUERES:

Hardware (DTR) Reset in Settings
Software Reset (0x18) on main form

INCOMPLETE FEATURES:

Status reporting - GRbl is undergoing heavy development in this area. What is
currently there is mostly a placeholder as a proof of concept

Supported gcodes - The backplotter is robust and supports many more than Grbl.
When Grbl does not recognize a code, it flags it as an error and provides the
opportunity to cancel. It would be better to preprocess the Grbl file and flag
unsupported codes before runtime? (BtnRunClick() function)

Feed Override - Grbl work in progress

JOG - Not yet coded, GUI components in place - how to acccomplish?

MDI - Not yet coded, GUI components in place - how to acccomplish?

No ESTOP - This should be a hardware function, RESET is only intended to reinit GRbl

Zero Axes - Need some help here

Status of modal gcodes - Maybe some indicators?


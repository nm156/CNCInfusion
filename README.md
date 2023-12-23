# CNCInfusion

**NOTICE:** This project is currently under development and is only recommended for air cutting in a controlled environment!

## Overview

CNCInfusion is a Windows GUI frontend written in C# designed to control the flow of G-code to an Arduino-based Grbl G-code processor ([Grbl GitHub](https://github.com/grbl/grbl)).

### Features

- **Basic Functionality:** Concentrates on essential functionality for hobby use.
- **User-Friendly GUI:** Windows-based graphical user interface for easy interaction.
- **Compatibility:** Primarily tested with Grbl edge (Grbl 0.7d) using '?' for status reporting.
- **Development Environment:** Originally created using Visual C# 2010 Express (as of version 0.1.7.0).
- **Target Framework:** Updated to .NET 8, removing the dependency on .NET 2.0 framework.
- **Graphics Library Update:** Native DirectX replaced with managed SharpDX.
- **Project Structure:** Converted to SDK style for improved organization.

## Development Information

- **Limited G-code Exposure:** The developer's CNC exposure is based on a home-built mill, focusing on basic motion and spindle control.
- **Coding Disclaimer:** Acknowledges that the developer is not a professional coder. Encourages contributions for correcting and enhancing features.

## Environment

- **Development Tools:** Visual C# 2010 Express (as of version 0.1.7.0).
- **Target Framework:** [.NET 8](http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=19).
- **Components:** See CREDITS.txt for additional information about the components used.

## Status Update

- **Grbl Edge Status Update:** Assumes Grbl edge (Grbl 0.7d) with status updates in the format:
  ```
  // Grbl edge status update looks like this: (Feb 2012)
  // MPos:[0.00,0.00,0.00],WPos:[0.00,0.00,0.00]
  ```
- **Testing:** CNCInfusion has been tested with Grbl edge but is expected to work with other versions if status updates remain disabled.

## History

# Changelog

### [0.1.0.0] 
- Initial Release
- Initial version of CNCInfusion.

### [0.1.1.0]
- Added feed hold and soft reset functionality.

### [0.1.2.0]
- Restructured serial communication code.
- Identified known issue with feedhold/cyclestart.

### [0.1.3.0]
- Fixed feedhold/cyclestart problem caused by ok response confusion.
- Addressed occasional re-running issues after abort.

### [0.1.4.0]
- Modified delegates for use in threads (created at startup).
- Started creating a preprocessor that only accepts Grbl G-code.
- Fixed status update interval problem.
- Addressed re-run after abort problem (added lock in commreceive).
- Added timers for RX and TX indicators.
- Implemented basic preprocessor for Grbl code displayed in the backplotter.

### [0.1.5.0]
- Grbl preprocessor modifications (needs more thorough testing).
- Changes to settings form, introducing more options.
- Initial code to support joystick.

### [0.1.6.0]
- Implemented error checking to detect Grbl when opening the serial port.
- Added machine/world toggle on display.
- Utilized regex for parsing Grbl status report.

### [0.1.7.0]
- Switched to Visual C# Express 2010 due to issues with SharpDevelop 3.2.

### [0.1.8.0]
- Updated to .NET 8.
- Updated to SharpDX 2.6.3.
- Converted to SDK style project.
- Updated to Visual Studio 2022 Community Edition.

## To-Do List

- **Reporting:** Grbl reporting of status is undergoing development.
- **MDI, JOG, Zero Axes:** Incomplete features yet to be coded.
- **Joystick/Joypad Integration:** Issues on X64 Win7 development box.
- **Load/Save Settings, Color Preferences:** Planned features for future updates.

## Known Problems

- **Feedhold Abort Stability:** Abort when feedhold is active sometimes causes loss of sync with Grbl. Hard reset of Grbl from Settings page restores stability.

## Features

### Implemented Features

- **Hardware (DTR) Reset:** Available in Settings.
- **Software Reset:** Triggered by pressing 0x18 on the main form.
- **Feed Hold / Cycle Start:** Allows manual control during operation.

### Incomplete Features

- **Status Reporting:** Placeholder for proof of concept; undergoing heavy development.
- **Feed Override:** Work in progress in Grbl.
- **JOG, MDI:** GUI components in place but not yet coded.
- **Modal Gcode Status:** Potential indicators for modal gcodes.

--- 
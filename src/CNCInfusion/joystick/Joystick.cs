/******************************************************************************
 * C# Joystick Library - Copyright (c) 2006 Mark Harris - MarkH@rris.com.au
 ******************************************************************************
 * You may use this library in your application, however please do give credit
 * to me for writing it and supplying it. If you modify this library you must
 * leave this notice at the top of this file. I'd love to see any changes you
 * do make, so please email them to me :)
 *****************************************************************************/
using SharpDX.DirectInput;
using System;
using System.Diagnostics;

namespace CNCInfusion.joystick;

/// <summary>
/// Class to interface with a joystick device.
/// </summary>
public class MyJoystick
{
    private Device joystickDevice;
    private JoystickState state;
    private Joystick joystick;

    /// <summary>
    /// Number of axes on the joystick.
    /// </summary>
    public int AxisCount { get; private set; }

    public int ButtonCount { get; private set; }

    /// <summary>
    /// The first axis on the joystick.
    /// </summary>
    public int AxisA { get; private set; }

    /// <summary>
    /// The second axis on the joystick.
    /// </summary>
    public int AxisB { get; private set; }

    /// <summary>
    /// The third axis on the joystick.
    /// </summary>
    public int AxisC { get; private set; }

    /// <summary>
    /// The fourth axis on the joystick.
    /// </summary>
    public int AxisD { get; private set; }

    /// <summary>
    /// The fifth axis on the joystick.
    /// </summary>
    public int AxisE { get; private set; }

    /// <summary>
    /// The sixth axis on the joystick.
    /// </summary>
    public int AxisF { get; private set; }
    private readonly nint hWnd;

    /// <summary>
    /// Array of buttons availiable on the joystick. This also includes PoV hats.
    /// </summary>
    public bool[] Buttons { get; private set; }

    private string[] systemJoysticks;

    /// <summary>
    /// Constructor for the class.
    /// </summary>
    /// <param name="window_handle">Handle of the window which the joystick will be "attached" to.</param>
    public MyJoystick(nint window_handle)
    {
        hWnd = window_handle;
        AxisA = -1;
        AxisB = -1;
        AxisC = -1;
        AxisD = -1;
        AxisE = -1;
        AxisF = -1;
        AxisCount = 0;
    }

    private void Poll()
    {



        try
        {
            // Poll the joystick
            joystick.Poll();

            // Get the buffered data 
            state = joystick.GetCurrentState();
        }
        catch (Exception err)
        {
            // we probably lost connection to the joystick
            // was it unplugged or locked by another application?
            Debug.WriteLine("Poll()");
            Debug.WriteLine(err.Message);
            Debug.WriteLine(err.StackTrace);
        }
    }

    /// <summary>
    /// Retrieves a list of joysticks attached to the computer.
    /// </summary>
    /// <example>
    /// [C#]
    /// <code>
    /// JoystickInterface.Joystick jst = new JoystickInterface.Joystick(this.Handle);
    /// string[] sticks = jst.FindJoysticks();
    /// </code>
    /// </example>
    /// <returns>A list of joysticks as an array of strings.</returns>
    public string[] FindJoysticks()
    {
        systemJoysticks = null;

        try
        {
            // Initialize DirectInput
            DirectInput directInput = new();

            // Find a Joystick Guid
            Guid joystickGuid = Guid.Empty;

            foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                }
            }

            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                _ = Console.ReadKey();
                Environment.Exit(1);
            }

            joystickDevice = new Joystick(directInput, joystickGuid);

        }
        catch (Exception err)
        {
            Debug.WriteLine("FindJoysticks()");
            Debug.WriteLine(err.Message);
            Debug.WriteLine(err.StackTrace);
        }

        return systemJoysticks;
    }

    /// <summary>
    /// Acquire the named joystick. You can find this joystick through the <see cref="FindJoysticks"/> method.
    /// </summary>
    /// <param name="name">Name of the joystick.</param>
    /// <returns>The success of the connection.</returns>
    public bool AcquireJoystick(string name)
    {
        try
        {
            // Initialize DirectInput
            DirectInput directInput = new();

            // Find a Joystick Guid
            Guid joystickGuid = Guid.Empty;

            foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                }
            }

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                _ = Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            Joystick joystick = new(directInput, joystickGuid);

            // Set the buffer size
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            this.joystick = joystick;
            // How many axes?
            // Find the capabilities of the joystick
            Capabilities cps = joystickDevice.Capabilities;
            Debug.WriteLine("Joystick Axis: " + cps.AxeCount);
            Debug.WriteLine("Joystick Buttons: " + cps.ButtonCount);

            AxisCount = cps.AxeCount;
            ButtonCount = cps.ButtonCount;

            UpdateStatus();
        }
        catch (Exception err)
        {
            Debug.WriteLine("FindJoysticks()");
            Debug.WriteLine(err.Message);
            Debug.WriteLine(err.StackTrace);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Unaquire a joystick releasing it back to the system.
    /// </summary>
    public void ReleaseJoystick()
    {
        joystickDevice.Unacquire();
    }

    /// <summary>
    /// Update the properties of button and axis positions.
    /// </summary>
    public void UpdateStatus()
    {
        Poll();

        int[] extraAxis = state.Sliders;
        //Rz Rx X Y Axis1 Axis2
        AxisA = state.RotationZ;
        AxisB = state.RotationX;
        AxisC = state.X;
        AxisD = state.Y;
        AxisE = extraAxis[0];
        AxisF = extraAxis[1];

        // not using buttons, so don't take the tiny amount of time it takes to get/parse

        Buttons = state.Buttons;


    }
}

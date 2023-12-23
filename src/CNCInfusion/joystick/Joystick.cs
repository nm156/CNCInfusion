/******************************************************************************
 * C# Joystick Library - Copyright (c) 2006 Mark Harris - MarkH@rris.com.au
 ******************************************************************************
 * You may use this library in your application, however please do give credit
 * to me for writing it and supplying it. If you modify this library you must
 * leave this notice at the top of this file. I'd love to see any changes you
 * do make, so please email them to me :)
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using SharpDX.DirectInput;
using System.Diagnostics;

namespace JoystickInterface;

/// <summary>
/// Class to interface with a joystick device.
/// </summary>
public class MyJoystick
{
    private Device joystickDevice;
    private JoystickState state;
    private Joystick joystick;

    private int buttonCount;
    private int axisCount;
    /// <summary>
    /// Number of axes on the joystick.
    /// </summary>
    public int AxisCount
    {
        get { return axisCount; }
    }

    public int ButtonCount
    {
        get { return buttonCount; }
    }

    private int axisA;
    /// <summary>
    /// The first axis on the joystick.
    /// </summary>
    public int AxisA
    {
        get { return axisA; }
    }

    private int axisB;
    /// <summary>
    /// The second axis on the joystick.
    /// </summary>
    public int AxisB
    {
        get { return axisB; }
    }

    private int axisC;
    /// <summary>
    /// The third axis on the joystick.
    /// </summary>
    public int AxisC
    {
        get { return axisC; }
    }

    private int axisD;
    /// <summary>
    /// The fourth axis on the joystick.
    /// </summary>
    public int AxisD
    {
        get { return axisD; }
    }

    private int axisE;
    /// <summary>
    /// The fifth axis on the joystick.
    /// </summary>
    public int AxisE
    {
        get { return axisE; }
    }

    private int axisF;
    /// <summary>
    /// The sixth axis on the joystick.
    /// </summary>
    public int AxisF
    {
        get { return axisF; }
    }
    private readonly IntPtr hWnd;

    private bool[] buttons;
    /// <summary>
    /// Array of buttons availiable on the joystick. This also includes PoV hats.
    /// </summary>
    public bool[] Buttons
    {
        get { return buttons; }
    }

    private string[] systemJoysticks;

    /// <summary>
    /// Constructor for the class.
    /// </summary>
    /// <param name="window_handle">Handle of the window which the joystick will be "attached" to.</param>
    public MyJoystick(IntPtr window_handle)
    {
        hWnd = window_handle;
        axisA = -1;
        axisB = -1;
        axisC = -1;
        axisD = -1;
        axisE = -1;
        axisF = -1;
        axisCount = 0;
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
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            this.joystickDevice = new Joystick(directInput, joystickGuid);

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
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            // Set the buffer size
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            this.joystick = joystick;
            // How many axes?
            // Find the capabilities of the joystick
            var cps = joystickDevice.Capabilities;
            Debug.WriteLine("Joystick Axis: " + cps.AxeCount);
            Debug.WriteLine("Joystick Buttons: " + cps.ButtonCount);

            axisCount = cps.AxeCount;
            buttonCount = cps.ButtonCount;

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
        axisA = state.RotationZ;
        axisB = state.RotationX;
        axisC = state.X;
        axisD = state.Y;
        axisE = extraAxis[0];
        axisF = extraAxis[1];

        // not using buttons, so don't take the tiny amount of time it takes to get/parse

        buttons = state.Buttons;


    }
}

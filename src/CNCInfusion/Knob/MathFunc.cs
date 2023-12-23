/*
 * Creato da SharpDevelop.
 * Utente: lucabonotto
 * Data: 03/04/2008
 * Ora: 15.01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace CNCInfusion.Knob;

/// <summary>
/// Mathematic Functions
/// </summary>
public class LBMath : object
{
    public static float GetRadian(float val)
    {
        return (float)(val * Math.PI / 180);
    }
}

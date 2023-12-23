/*
 * Creato da SharpDevelop.
 * Utente: lucabonotto
 * Data: 03/04/2008
 * Ora: 14.34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace CNCInfusion.Knob;

/// <summary>
/// Manager for color
/// </summary>
public class LBColorManager : object
{
    public static double BlendColour(double fg, double bg, double alpha)
    {
        double result = bg + (alpha * (fg - bg));
        if (result < 0.0)
        {
            result = 0.0;
        }

        if (result > 255)
        {
            result = 255;
        }

        return result;
    }

    public static Color StepColor(Color clr, int alpha)
    {
        if (alpha == 100)
        {
            return clr;
        }

        byte a = clr.A;
        byte r = clr.R;
        byte g = clr.G;
        byte b = clr.B;
        _ = Math.Min(alpha, 200);
        int _alpha = Math.Max(alpha, 0);
        double ialpha = (double)(_alpha - 100.0) / 100.0;

        float bg;
        if (ialpha > 100)
        {
            // blend with white
            bg = 255.0F;
            ialpha = 1.0F - ialpha;  // 0 = transparent fg; 1 = opaque fg
        }
        else
        {
            // blend with black
            bg = 0.0F;
            ialpha = 1.0F + ialpha;  // 0 = transparent fg; 1 = opaque fg
        }

        r = (byte)BlendColour(r, bg, ialpha);
        g = (byte)BlendColour(g, bg, ialpha);
        b = (byte)BlendColour(b, bg, ialpha);

        return Color.FromArgb(a, r, g, b);
    }
};

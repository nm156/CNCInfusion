/*
 * Creato da SharpDevelop.
 * Utente: lucabonotto
 * Data: 07/04/2008
 * Ora: 14.42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using CPOL.Knobs;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CNCInfusion.Knob;

/// <summary>
/// Base class for the renderers of the knob
/// </summary>
public class LBKnobRenderer
{
    #region Variables
    /// <summary>
    /// Control to render
    /// </summary>
    #endregion

    #region Properies
    public LBKnob Knob { set; get; } = null;
    #endregion

    #region Virtual method
    /// <summary>
    /// Draw the background of the control
    /// </summary>
    /// <param name="Gr"></param>
    /// <param name="rc"></param>
    /// <returns></returns>
    public virtual bool DrawBackground(Graphics Gr, RectangleF rc)
    {
        if (Knob == null)
        {
            return false;
        }

        Color c = Knob.BackColor;
        SolidBrush br = new(c);
        Pen pen = new(c);

        Rectangle _rcTmp = new(0, 0, Knob.Width, Knob.Height);
        Gr.DrawRectangle(pen, _rcTmp);
        Gr.FillRectangle(br, rc);

        br.Dispose();
        pen.Dispose();

        return true;
    }

    /// <summary>
    /// Draw the scale of the control
    /// </summary>
    /// <param name="Gr"></param>
    /// <param name="rc"></param>
    /// <returns></returns>
    public virtual bool DrawScale(Graphics Gr, RectangleF rc)
    {
        if (Knob == null)
        {
            return false;
        }

        Color cKnob = Knob.ScaleColor;
        Color cKnobDark = LBColorManager.StepColor(cKnob, 60);

        LinearGradientBrush br = new(rc, cKnobDark, cKnob, 45);

        Gr.FillEllipse(br, rc);

        br.Dispose();

        return true;
    }

    /// <summary>
    /// Draw the knob of the control
    /// </summary>
    /// <param name="Gr"></param>
    /// <param name="rc"></param>
    /// <returns></returns>
    public virtual bool DrawKnob(Graphics Gr, RectangleF rc)
    {
        if (Knob == null)
        {
            return false;
        }

        Color cKnob = Knob.KnobColor;
        Color cKnobDark = LBColorManager.StepColor(cKnob, 60);

        LinearGradientBrush br = new(rc, cKnob, cKnobDark, 45);

        Gr.FillEllipse(br, rc);

        br.Dispose();

        return true;
    }

    public virtual bool DrawKnobIndicator(Graphics Gr, RectangleF rc, PointF pos)
    {
        if (Knob == null)
        {
            return false;
        }

        RectangleF _rc = rc;
        _rc.X = pos.X - 4;
        _rc.Y = pos.Y - 4;
        _rc.Width = 8;
        _rc.Height = 8;

        Color cKnob = Knob.IndicatorColor;
        Color cKnobDark = LBColorManager.StepColor(cKnob, 60);

        LinearGradientBrush br = new(_rc, cKnobDark, cKnob, 45);

        Gr.FillEllipse(br, _rc);

        br.Dispose();

        return true;
    }
    #endregion
}

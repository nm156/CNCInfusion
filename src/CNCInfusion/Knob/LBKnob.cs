/*
 * Creato da SharpDevelop.
 * Utente: lucabonotto
 * Data: 05/04/2008
 * Ora: 13.35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


// http://69.10.233.10/KB/cs/industrial_controls.aspx
// Code Project Open License

using CNCInfusion.Knob;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CPOL.Knobs;

/// <summary>
/// Description of LBKnob.
/// </summary>
public partial class LBKnob : UserControl
{
    #region Enumerators
    public enum KnobStyle
    {
        Circular = 0,
    }
    #endregion

    #region Properties variables
    private float minValue = 0.0F;
    private float maxValue = 1.0F;
    private float stepValue = 0.1F;
    private float currValue = 0.0F;
    private KnobStyle style = KnobStyle.Circular;
    private LBKnobRenderer renderer = null;
    private Color scaleColor = Color.Green;
    private Color knobColor = Color.Black;
    private Color indicatorColor = Color.Red;
    private float indicatorOffset = 10F;
    #endregion

    #region Class variables
    private RectangleF drawRect;
    private RectangleF rectScale;
    private RectangleF rectKnob;
    private float drawRatio;
    private readonly LBKnobRenderer defaultRenderer = null;
    private bool isKnobRotating = false;
    private PointF knobCenter;
    private PointF knobIndicatorPos;
    #endregion

    #region Constructor
    public LBKnob()
    {
        InitializeComponent();

        // Set the styles for drawing
        SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.ResizeRedraw |
            ControlStyles.DoubleBuffer |
            ControlStyles.SupportsTransparentBackColor,
            true);

        // Transparent background
        BackColor = Color.Transparent;

        defaultRenderer = new LBKnobRenderer
        {
            Knob = this
        };

        CalculateDimensions();
    }
    #endregion

    #region Properties
    [
        Category("Knob"),
        Description("Minimum value of the knob")
    ]
    public float MinValue
    {
        set
        {
            minValue = value;
            Invalidate();
        }
        get => minValue;
    }

    [
        Category("Knob"),
        Description("Maximum value of the knob")
    ]
    public float MaxValue
    {
        set
        {
            maxValue = value;
            Invalidate();
        }
        get => maxValue;
    }

    [
        Category("Knob"),
        Description("Step value of the knob")
    ]
    public float StepValue
    {
        set
        {
            stepValue = value;
            Invalidate();
        }
        get => stepValue;
    }

    [
        Category("Knob"),
        Description("Current value of the knob")
    ]
    public float Value
    {
        set
        {
            if (value != currValue)
            {
                currValue = value;
                knobIndicatorPos = GetPositionFromValue(currValue);
                Invalidate();

                LBKnobEventArgs e = new()
                {
                    Value = currValue
                };
                OnKnobChangeValue(e);
            }
        }
        get => currValue;
    }

    [
        Category("Knob"),
        Description("Style of the knob")
    ]
    public KnobStyle Style
    {
        set
        {
            style = value;
            Invalidate();
        }
        get => style;
    }

    [
        Category("Knob"),
        Description("Color of the knob")
    ]
    public Color KnobColor
    {
        set
        {
            knobColor = value;
            Invalidate();
        }
        get => knobColor;
    }

    [
        Category("Knob"),
        Description("Color of the scale")
    ]
    public Color ScaleColor
    {
        set
        {
            scaleColor = value;
            Invalidate();
        }
        get => scaleColor;
    }

    [
        Category("Knob"),
        Description("Color of the indicator")
    ]
    public Color IndicatorColor
    {
        set
        {
            indicatorColor = value;
            Invalidate();
        }
        get => indicatorColor;
    }

    [
        Category("Knob"),
        Description("Offset of the indicator from the kob border")
    ]
    public float IndicatorOffset
    {
        set
        {
            indicatorOffset = value;
            CalculateDimensions();
            Invalidate();
        }
        get => indicatorOffset;
    }

    [Browsable(false)]
    public LBKnobRenderer Renderer
    {
        get => renderer;
        set
        {
            renderer = value;
            if (renderer != null)
            {
                renderer.Knob = this;
            }

            Invalidate();
        }
    }

    [Browsable(false)]
    public PointF KnobCenter => knobCenter;
    #endregion

    #region Events delegates

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        bool blResult = true;

        /// <summary>
        /// Specified WM_KEYDOWN enumeration value.
        /// </summary>
        const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// Specified WM_SYSKEYDOWN enumeration value.
        /// </summary>
        const int WM_SYSKEYDOWN = 0x0104;

        float val = Value;

        if (msg.Msg is WM_KEYDOWN or WM_SYSKEYDOWN)
        {
            switch (keyData)
            {
                case Keys.Up:
                    val += StepValue;
                    if (val <= MaxValue)
                    {
                        Value = val;
                    }

                    break;

                case Keys.Down:
                    val -= StepValue;
                    if (val >= MinValue)
                    {
                        Value = val;
                    }

                    break;

                case Keys.PageUp:
                    if (val < MaxValue)
                    {
                        val += StepValue * 10;
                        Value = val;
                    }
                    break;

                case Keys.PageDown:
                    if (val > MinValue)
                    {
                        val -= StepValue * 10;
                        Value = val;
                    }
                    break;

                case Keys.Home:
                    Value = MinValue;
                    break;

                case Keys.End:
                    Value = MaxValue;
                    break;

                default:
                    blResult = base.ProcessCmdKey(ref msg, keyData);
                    break;
            }
        }

        return blResult;
    }

    [System.ComponentModel.EditorBrowsableAttribute()]
    protected override void OnClick(EventArgs e)
    {
        _ = Focus();
        Invalidate();
        base.OnClick(e);
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
        isKnobRotating = false;

        if (rectKnob.Contains(e.Location) == false)
        {
            return;
        }

        float val = GetValueFromPosition(e.Location);
        if (val != Value)
        {
            Value = val;
            Invalidate();
        }
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        if (rectKnob.Contains(e.Location) == false)
        {
            return;
        }

        isKnobRotating = true;

        _ = Focus();
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (isKnobRotating == false)
        {
            return;
        }

        float val = GetValueFromPosition(e.Location);
        if (val != Value)
        {
            Value = val;
            Invalidate();
        }
    }

    // pdf - added mouse handler
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        int delta = e.Delta;
        float val = Value;

        if (delta > 0)
        {
            val += StepValue;
            if (val <= MaxValue)
            {
                Value++;
            }
        }
        else
        {
            val -= StepValue;
            if (val >= MinValue)
            {
                Value--;
            }
        }
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        float val = Value;

        switch (e.KeyCode)
        {
            case Keys.Up:
                val = Value + StepValue;
                break;

            case Keys.Down:
                val = Value - StepValue;
                break;
        }

        if (val < MinValue)
        {
            val = MinValue;
        }

        if (val > MaxValue)
        {
            val = MaxValue;
        }

        Value = val;
    }


    [System.ComponentModel.EditorBrowsableAttribute()]
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);

        CalculateDimensions();

        Invalidate();
    }

    [System.ComponentModel.EditorBrowsableAttribute()]
    protected override void OnPaint(PaintEventArgs e)
    {
        RectangleF _rc = new(0, 0, Width, Height);
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (Renderer == null)
        {
            _ = defaultRenderer.DrawBackground(e.Graphics, _rc);
            _ = defaultRenderer.DrawScale(e.Graphics, rectScale);
            _ = defaultRenderer.DrawKnob(e.Graphics, rectKnob);
            _ = defaultRenderer.DrawKnobIndicator(e.Graphics, rectKnob, knobIndicatorPos);
            return;
        }

        _ = Renderer.DrawBackground(e.Graphics, _rc);
        _ = Renderer.DrawScale(e.Graphics, rectScale);
        _ = Renderer.DrawKnob(e.Graphics, rectKnob);
        _ = Renderer.DrawKnobIndicator(e.Graphics, rectKnob, knobIndicatorPos);
    }
    #endregion

    #region Virtual functions		
    protected virtual void CalculateDimensions()
    {
        // Rectangle
        float x, y, w, h;
        x = 0;
        y = 0;
        w = Size.Width;
        h = Size.Height;

        // Calculate ratio
        drawRatio = Math.Min(w, h) / 200;
        if (drawRatio == 0.0)
        {
            drawRatio = 1;
        }

        // Draw rectangle
        drawRect.X = x;
        drawRect.Y = y;
        drawRect.Width = w - 2;
        drawRect.Height = h - 2;

        if (w < h)
        {
            drawRect.Height = w;
        }
        else if (w > h)
        {
            drawRect.Width = h;
        }

        if (drawRect.Width < 10)
        {
            drawRect.Width = 10;
        }

        if (drawRect.Height < 10)
        {
            drawRect.Height = 10;
        }

        rectScale = drawRect;
        rectKnob = drawRect;
        rectKnob.Inflate(-20 * drawRatio, -20 * drawRatio);

        knobCenter.X = rectKnob.Left + (rectKnob.Width * 0.5F);
        knobCenter.Y = rectKnob.Top + (rectKnob.Height * 0.5F);

        knobIndicatorPos = GetPositionFromValue(Value);
    }

    public virtual float GetValueFromPosition(PointF position)
    {
        float v = 0.0F;

        PointF center = KnobCenter;

        float degree;
        if (position.X <= center.X)
        {
            degree = (center.Y - position.Y) / (center.X - position.X);
            degree = (float)Math.Atan(degree);
            degree = (float)(180F + (degree * (180F / Math.PI)) + 0F);
            v = degree * (MaxValue - MinValue) / 180F;
        }
        else
        {
            if (position.X > center.X)
            {
                degree = (position.Y - center.Y) / (position.X - center.X);
                degree = (float)Math.Atan(degree);
                degree = (float)(degree * (180F / Math.PI));
                v = degree * (MaxValue - MinValue) / 180F;
            }
        }

        if (v > MaxValue)
        {
            v = MaxValue;
        }

        if (v < MinValue)
        {
            v = MinValue;
        }

        return v;
    }

    public virtual PointF GetPositionFromValue(float val)
    {
        PointF pos = new(0.0F, 0.0F);

        // Elimina la divisione per 0
        if ((MaxValue - MinValue) == 0)
        {
            return pos;
        }

        _ = IndicatorOffset * drawRatio;

        float degree = 360F * val / (MaxValue - MinValue);
        degree = (degree - 90) * (float)Math.PI / 180F;

        pos.X = (int)((Math.Cos(degree) * ((rectKnob.Width * 0.5F) - indicatorOffset)) + rectKnob.X + (rectKnob.Width * 0.5F));
        pos.Y = (int)((Math.Sin(degree) * ((rectKnob.Width * 0.5F) - indicatorOffset)) + rectKnob.Y + (rectKnob.Height * 0.5F));

        return pos;
    }

    #endregion

    #region Fire events
    public event KnobChangeValue KnobChangeValue;
    protected virtual void OnKnobChangeValue(LBKnobEventArgs e)
    {
        KnobChangeValue?.Invoke(this, e);
    }
    #endregion
}

#region Classes for event and event delagates args

#region Event args class
/// <summary>
/// Class for events delegates
/// </summary>
public class LBKnobEventArgs : EventArgs
{
    public LBKnobEventArgs()
    {
    }

    public float Value { get; set; }
}
#endregion

#region Delegates
public delegate void KnobChangeValue(object sender, LBKnobEventArgs e);
#endregion

#endregion

using System;

namespace CNCInfusion.CustomPanel;


[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
public class CustomPanel : System.Windows.Forms.Panel
{
    // Fields
    private System.Drawing.Color _BackColour1 = System.Drawing.SystemColors.Window;
    private System.Drawing.Color _BackColour2 = System.Drawing.SystemColors.Window;
    private LinearGradientMode _GradientMode = LinearGradientMode.None;
    private System.Windows.Forms.BorderStyle _BorderStyle = System.Windows.Forms.BorderStyle.None;
    private System.Drawing.Color _BorderColour = System.Drawing.SystemColors.WindowFrame;
    private int _BorderWidth = 1;
    private int _Curvature = 0;
    // Properties
    //   Shadow the Backcolor property so that the base class will still render with a transparent backcolor
    private CornerCurveMode _CurveMode = CornerCurveMode.All;

    [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), "Window"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The primary background color used to display text and graphics in the control.")]
    public new System.Drawing.Color BackColor
    {
        get => _BackColour1;
        set
        {
            _BackColour1 = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), "Window"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The secondary background color used to paint the control.")]
    public System.Drawing.Color BackColor2
    {
        get => _BackColour2;
        set
        {
            _BackColour2 = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(LinearGradientMode), "None"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The gradient direction used to paint the control.")]
    public LinearGradientMode GradientMode
    {
        get => _GradientMode;
        set
        {
            _GradientMode = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(System.Windows.Forms.BorderStyle), "None"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The border style used to paint the control.")]
    public new System.Windows.Forms.BorderStyle BorderStyle
    {
        get => _BorderStyle;
        set
        {
            _BorderStyle = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), "WindowFrame"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The border color used to paint the control.")]
    public System.Drawing.Color BorderColor
    {
        get => _BorderColour;
        set
        {
            _BorderColour = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(int), "1"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The width of the border used to paint the control.")]
    public int BorderWidth
    {
        get => _BorderWidth;
        set
        {
            _BorderWidth = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(int), "0"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The radius of the curve used to paint the corners of the control.")]
    public int Curvature
    {
        get => _Curvature;
        set
        {
            _Curvature = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    [System.ComponentModel.DefaultValue(typeof(CornerCurveMode), "All"), System.ComponentModel.Category("Appearance"), System.ComponentModel.Description("The style of the curves to be drawn on the control.")]
    public CornerCurveMode CurveMode
    {
        get => _CurveMode;
        set
        {
            _CurveMode = value;
            if (DesignMode == true)
            {
                Invalidate();
            }
        }
    }

    private int adjustedCurve
    {
        get
        {
            int curve = 0;
            if (!(_CurveMode == CornerCurveMode.None))
            {
                curve = _Curvature > ClientRectangle.Width / 2 ? DoubleToInt(ClientRectangle.Width / 2) : _Curvature;
                if (curve > ClientRectangle.Height / 2)
                {
                    curve = DoubleToInt(ClientRectangle.Height / 2);
                }
            }
            return curve;
        }
    }

    public CustomPanel() : base()
    {
        // pdf - to show progress on program startup
        //SSA.Splash.Update(String.Format("initializing {0}...", SSA.Splash.GlobalCounter++));
        SetDefaultControlStyles();
        customInitialisation();
    }

    private void SetDefaultControlStyles()
    {
        SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);

        // was false
        SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);

        SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
        SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
        SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
    }

    private void customInitialisation()
    {
        SuspendLayout();
        base.BackColor = System.Drawing.Color.Transparent;
        BorderStyle = System.Windows.Forms.BorderStyle.None;
        ResumeLayout(false);
    }

    protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
    {
        base.OnPaintBackground(pevent);
        pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        System.Drawing.Drawing2D.GraphicsPath graphPath;
        graphPath = GetPath();
        //	Create Gradient Brush (Cannot be width or height 0)
        System.Drawing.Drawing2D.LinearGradientBrush filler;
        System.Drawing.Rectangle rect = ClientRectangle;
        if (ClientRectangle.Width == 0)
        {
            rect.Width += 1;
        }
        if (ClientRectangle.Height == 0)
        {
            rect.Height += 1;
        }
        filler = _GradientMode == LinearGradientMode.None
            ? new System.Drawing.Drawing2D.LinearGradientBrush(rect, _BackColour1, _BackColour1, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
            : new System.Drawing.Drawing2D.LinearGradientBrush(rect, _BackColour1, _BackColour2, (System.Drawing.Drawing2D.LinearGradientMode)_GradientMode);
        pevent.Graphics.FillPath(filler, graphPath);
        filler.Dispose();
        if (_BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
        {
            System.Drawing.Pen borderPen = new(_BorderColour, _BorderWidth);
            pevent.Graphics.DrawPath(borderPen, graphPath);
            borderPen.Dispose();
        }
        else if (_BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
        {
            DrawBorder3D(pevent.Graphics, ClientRectangle);
        }
        else if (_BorderStyle == System.Windows.Forms.BorderStyle.None)
        {
        }
        filler.Dispose();
        graphPath.Dispose();
    }

    protected System.Drawing.Drawing2D.GraphicsPath GetPath()
    {
        System.Drawing.Drawing2D.GraphicsPath graphPath = new();
        if (_BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
        {
            graphPath.AddRectangle(ClientRectangle);
        }
        else
        {
            try
            {
                int curve = 0;
                System.Drawing.Rectangle rect = ClientRectangle;
                int offset = 0;
                if (_BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
                {
                    if (_BorderWidth > 1)
                    {
                        offset = DoubleToInt(BorderWidth / 2);
                    }
                    curve = adjustedCurve;
                }
                else if (_BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
                {
                }
                else if (_BorderStyle == System.Windows.Forms.BorderStyle.None)
                {
                    curve = adjustedCurve;
                }
                if (curve == 0)
                {
                    graphPath.AddRectangle(System.Drawing.Rectangle.Inflate(rect, -offset, -offset));
                }
                else
                {
                    int rectWidth = rect.Width - 1 - offset;
                    int rectHeight = rect.Height - 1 - offset;
                    int curveWidth = (_CurveMode & CornerCurveMode.TopRight) != 0 ? curve * 2 : 1;
                    graphPath.AddArc(rectWidth - curveWidth, offset, curveWidth, curveWidth, 270, 90);
                    curveWidth = (_CurveMode & CornerCurveMode.BottomRight) != 0 ? curve * 2 : 1;
                    graphPath.AddArc(rectWidth - curveWidth, rectHeight - curveWidth, curveWidth, curveWidth, 0, 90);
                    curveWidth = (_CurveMode & CornerCurveMode.BottomLeft) != 0 ? curve * 2 : 1;
                    graphPath.AddArc(offset, rectHeight - curveWidth, curveWidth, curveWidth, 90, 90);
                    curveWidth = (_CurveMode & CornerCurveMode.TopLeft) != 0 ? curve * 2 : 1;
                    graphPath.AddArc(offset, offset, curveWidth, curveWidth, 180, 90);
                    graphPath.CloseFigure();
                }
            }
            catch (Exception)
            {
                graphPath.AddRectangle(ClientRectangle);
            }
        }
        return graphPath;
    }

    public static void DrawBorder3D(System.Drawing.Graphics graphics, System.Drawing.Rectangle rectangle)
    {
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
        graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Y);
        graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.X, rectangle.Height - 1);
        graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, rectangle.Y + 1);
        graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.X + 1, rectangle.Height - 1);
        graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.X + 1, rectangle.Height - 2, rectangle.Width - 2, rectangle.Height - 2);
        graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.Width - 2, rectangle.Y + 1, rectangle.Width - 2, rectangle.Height - 2);
        graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.X, rectangle.Height - 1, rectangle.Width - 1, rectangle.Height - 1);
        graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.Width - 1, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
    }

    public static int DoubleToInt(double value)
    {
        return decimal.ToInt32(decimal.Floor(decimal.Parse(value.ToString())));
    }
}
/// <summary> 
/// Custom rectangle 
/// </summary> 
/// <remarks> 
/// Copyright © MacGen Programming 2006 
/// Jason Titcomb 
/// www.CncEdit.com 
/// </remarks> 
using System.Drawing;
public class clsCadRect
{
    private float mX;
    public float X
    {
        get => mX;
        set
        {
            mX = value;
            Left = mX;
            Right = Left + mWidth;
        }
    }
    private float my;
    public float Y
    {
        get => my;
        set
        {
            my = value;
            Top = my + mHeight;
            Bottom = my;
        }
    }

    public float Left { get; private set; }
    public float Right { get; private set; }
    private float mWidth;
    public float Width
    {
        get => mWidth;
        set
        {
            mWidth = value;
            Right = Left + mWidth;
        }
    }
    private float mHeight;
    public float Height
    {
        get => mHeight;
        set
        {
            mHeight = value;
            Top = my + mHeight;
        }
    }

    public float Top { get; private set; }
    public float Bottom { get; private set; }

    public clsCadRect()
    {
        X = 0;
        Y = 0;
        Width = 0;
        Height = 0;
    }

    public clsCadRect(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
    public bool IntersectsLine(PointF p1, PointF p2)
    {
        return IntersectsLine(p1.X, p1.Y, p2.X, p2.Y);
    }

    public bool Contains(float x, float y)
    {
        return x > Left & x < Right & y > Bottom & y < Top;
    }

    public bool IntersectsLine(float x1, float y1, float x2, float y2)
    {
        //Trivial test inside 
        if (Contains(x1, y1) | Contains(x2, y2))
        {
            return true;
        }
        //Trivial test outside 
        if (x1 < Left & x2 < Left)
        {
            return false;
        }
        else if (x1 > Right & x2 > Right)
        {
            return false;
        }
        else if (y1 < Bottom & y2 < Bottom)
        {
            return false;
        }
        else if (y1 > Top & y2 > Top)
        {
            return false;
        }

        //Trivial test vertical or horizontal 
        if (x1 == x2)
        {
            return true;
        }
        if (y1 == y2)
        {
            return true;
        }

        float slope = (y2 - y1) / (x2 - x1);
        float Yintercept = y1 - (slope * x1);

        //Left edge 
        float iptX = Left;
        float iptY = (slope * iptX) + Yintercept;
        if (iptY > Bottom & iptY < Top)
        {
            return true;
        }

        //Right edge 
        _ = Right;
        if (iptY > Bottom & iptY < Top)
        {
            return true;
        }

        //Top edge 
        iptY = Top;
        iptX = (iptY - Yintercept) / slope;
        if (iptX > Left & iptX < Right)
        {
            return true;
        }

        //Bottom edge 
        iptY = Bottom;
        iptX = (iptY - Yintercept) / slope;
        return iptX > Left & iptX < Right;
    }
}
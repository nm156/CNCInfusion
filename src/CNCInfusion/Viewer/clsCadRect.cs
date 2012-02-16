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
        get { return mX; }
        set
        {
            mX = value;
            mLeft = mX;
            mRight = mLeft + mWidth;
        }
    }
    private float my;
    public float Y
    {
        get { return my; }
        set
        {
            my = value;
            mTop = my + mHeight;
            mBottom = my;
        }
    }
    private float mLeft;
    public float Left
    {
        get { return mLeft; }
    }
    private float mRight;
    public float Right
    {
        get { return mRight; }
    }
    private float mWidth;
    public float Width
    {
        get { return mWidth; }
        set
        {
            mWidth = value;
            mRight = mLeft + mWidth;
        }
    }
    private float mHeight;
    public float Height
    {
        get { return mHeight; }
        set
        {
            mHeight = value;
            mTop = my + mHeight;
        }
    }
    private float mTop;
    public float Top
    {
        get { return mTop; }
    }
    private float mBottom;
    public float Bottom
    {
        get { return mBottom; }
    }

    public clsCadRect()
    {
        X = 0;
        Y = 0;
        Width = 0;
        Height = 0;
    }

    public clsCadRect(float x, float y, float width, float height)
    {
        this.X = x;
        this.Y = y;
        this.Width = width;
        this.Height = height;
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
        if (this.Contains(x1, y1) | this.Contains(x2, y2))
        {
            return true;
        }
        //Trivial test outside 
        if (x1 < this.Left & x2 < this.Left)
        {
            return false;
        }
        else if (x1 > this.Right & x2 > this.Right)
        {
            return false;
        }
        else if (y1 < this.Bottom & y2 < this.Bottom)
        {
            return false;
        }
        else if (y1 > this.Top & y2 > this.Top)
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
        float iptX = 0;
        float iptY = 0;

        //Left edge 
        iptX = this.Left;
        iptY = (slope * iptX) + Yintercept;
        if (iptY > this.Bottom & iptY < this.Top)
        {
            return true;
        }

        //Right edge 
        iptX = this.Right;
        if (iptY > this.Bottom & iptY < this.Top)
        {
            return true;
        }

        //Top edge 
        iptY = this.Top;
        iptX = ((iptY - Yintercept) / slope);
        if (iptX > this.Left & iptX < this.Right)
        {
            return true;
        }

        //Bottom edge 
        iptY = this.Bottom;
        iptX = ((iptY - Yintercept) / slope);
        if (iptX > this.Left & iptX < this.Right)
        {
            return true;
        }
        return false;
    }
}
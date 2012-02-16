using System.Drawing;
public class clsToolLayer
{
    public System.Drawing.Color Color;
    public float Number;
    public bool Hidden;

    public clsToolLayer(float number, Color color)
    {
        this.Number = number;
        this.Color = color;
        this.Hidden = false;
    }
}
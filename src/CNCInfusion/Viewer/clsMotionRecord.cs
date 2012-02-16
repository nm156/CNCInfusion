using System.Drawing;
namespace MacGen
{
    public class clsMotionRecord
    {
        public string Codestring;
        //cnc codeline 
        public MacGen.Motion MotionType;
        //point,arc,line etc.... 
        public int Linenumber;
        //line number of CNC file 
        public float Xold;
        public float Yold;
        public float Zold;
        public float Xpos;
        public float Ypos;
        public float Zpos;
        public float Rpoint;
        public float Rad;
        public float Sang;
        public float Eang;
        public float Xcentr;
        public float Ycentr;
        public float Zcentr;
        public Color DrawClr;
        public float Tool;
        public float Speed;
        public float Feed;
        public bool BeginProfile;
        public bool Rotate;
        public float OldRotaryPos;
        public float NewRotaryPos;
        public int RotaryDir;
        public int WrkPlane;
        public float DrillClear;
        public bool Inview;
    }
}
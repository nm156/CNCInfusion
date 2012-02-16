using MacGen;
public class clsMachine
{
    //Store all settings in this class 
    public string Name;    //file name 
    public string Description;    //file name 
    public string ProgramId;    public string Subcall;
    //call sub 
    public string SubRepeats;
    public string SubReturn;    //return from sub 
    public string Endmain;    //End of main program 
    public string BlockSkip;    //do not process lines that start with this 
    public string Comments;    //Comments 
    public MachineType MachineType;    //lathe ,mill etc.. 
    public bool LatheMinus;    //this is for minus lathes 
    public bool HelixPitch;    //helix check box setting 
    public bool AbsArcCenter;    //Arc center chkbox 
    public int Precision;    //output precision 0.0001 
    public string Searchstring;    //a string that determines the setup record 
    public string[] Drills = new string[10];    //10 drilling cycles 0 index is the cancel code 
    public string[] ReturnLevel = new string[2];
    public string DrillRapid;
    public string Rapid;
    public string Linear;
    public string CCArc;
    public string CWArc;
    public string Incremental;
    public string Absolute;
    public string XYplane;
    public string XZplane;
    public string YZplane;
    public float[] ViewAngles = new float[3];    //Store pitch,roll,yaw 
    public string Rotary;    //Rotary axis code ABC 
    public RotaryDirection RotaryDir;    //+1 or -1 
    public Axis RotaryAxis;    //XYZ 
    public RotaryMotionType RotaryType;
    public int RotPrecision;    //output precision 0.0001 
    public float[] ViewShift = new float[3];    //Shift the view for viewing 

    public clsMachine(string name)
    {
        this.Name = name;
    }
    public clsMachine()
    {
    }
}
using System;
internal struct Address
{
    private char mLabel;
    public char Label
    {
        get { return mLabel; }
        set { 
            mLabel = value;
            Letter = (clsProcessor.letters)Enum.Parse(typeof(clsProcessor.letters), mLabel.ToString());
        }
    }
    public float Value;
    public string StringValue;
    public clsProcessor.letters Letter;
    public bool Matches(Address a)
    {
        return (a.Letter == this.Letter) & (a.Value == this.Value);
    }
}

internal class clsMotion
{
    public Address[] Drills = new Address[10];    //G81,G82 
    public Address[] ReturnLevel = new Address[2];    //G98,G99 
    public Address DrillRapid;    //R 
    public Address Rapid;    //G00 
    public Address Linear;    //G01 
    public Address CCArc;    //G03 
    public Address CWArc;    //G02 
    public Address Inc;    //G91 
    public Address Abs;    //G90 
    public Address[] Plane = new Address[3];    //G18,18,19 
    public Address Rotary;    //A B C 
    public Address SubCall;    //M98 
    public Address SubReturn;    //M99 
}
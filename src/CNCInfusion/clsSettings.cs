using System.Collections.Generic; 
using System.IO;
using System.Xml;
using MacGen;
using System;
using System.Windows.Forms;
/// <summary> 
/// Reads and writes settings to disk. 
/// </summary> 
/// <remarks> 
/// Copyright © MacGen Programming 2006 
/// Jason Titcomb 
/// www.CncEdit.com 
/// </remarks> 
public class clsSettings 
{ 
    private List<clsMachine> mMachines = new List<clsMachine>(); 
    public clsMachine Machine; 
    private const string DATEXTENSION = ".xml"; 
    private string mDatFolder; 
    public event MachineLoadedEventHandler MachineLoaded; 
    public delegate void MachineLoadedEventHandler(clsMachine m); 
    public event MachineAddedEventHandler MachineAdded; 
    public delegate void MachineAddedEventHandler(clsMachine m); 
    public event MachineDeletedEventHandler MachineDeleted; 
    public delegate void MachineDeletedEventHandler(string name); 
    public event MachineMatchedEventHandler MachineMatched; 
    public delegate void MachineMatchedEventHandler(clsMachine m); 
    public event MachineActivatedEventHandler MachineActivated; 
    public delegate void MachineActivatedEventHandler(clsMachine m); 
    public event MachinesClearedEventHandler MachinesCleared; 
    public delegate void MachinesClearedEventHandler(); 
    
    #region "Singleton" 
    private static clsSettings mInstance; 
    //PRIVATE constructor can only be called from this class 
    private clsSettings() 
    { 
    } 
    /// <summary> 
    /// Static method for creating the single instance of the Constructor 
    /// </summary> 
    public static clsSettings Instance() 
    { 
        // initialize if not already done 
        if (mInstance == null) { 
            mInstance = new clsSettings(); 
        } 
        // return the initialized instance of the Singleton Class 
        return mInstance; 
    } 
    //Instance 
    #endregion 
    /// <summary> 
    /// Sets or gets the folder containing the data files 
    /// </summary> 
    public string DatFolder { 
        get { return mDatFolder; } 
        set { 
            if (value.EndsWith("\\")) { 
                mDatFolder = value; 
            } 
            else { 
                mDatFolder = value + "\\"; 
            } 
        } 
    } 
    
    /// <summary> 
    /// Sets or gets the name of the current machine 
    /// </summary> 
    public string MachineName { 
        get { return Machine.Name; } 
        set { 
            foreach (clsMachine m in this.mMachines) { 
                if (string.Compare(value, m.Name, true) == 0) { 
                    Machine = m; 
                    if (MachineActivated != null) { 
                        MachineActivated(m); 
                    } 
                    return; 
                } 
            } 
        } 
    } 
     
    public void LoadMachine(string sName) 
    { 
        XmlReaderSettings settings = new XmlReaderSettings(); 
        int r = 0; 
        Machine = new clsMachine(); 
        { 
            settings.IgnoreWhitespace = true; 
            settings.IgnoreComments = true; 
            settings.IgnoreProcessingInstructions = true; 
            settings.ProhibitDtd = true; 
            settings.CloseInput = true; 
        } 
        using (XmlReader xReader = XmlReader.Create(sName, settings)) { 
            { 
                xReader.MoveToContent(); 
                xReader.ReadToDescendant("Name"); 
                Machine.Name = xReader.ReadElementContentAsString(); 
                Machine.Description = xReader.ReadElementContentAsString();
                Machine.AbsArcCenter = bool.Parse(xReader.ReadElementContentAsString());
                Machine.LatheMinus = bool.Parse(xReader.ReadElementContentAsString());
                Machine.HelixPitch = bool.Parse(xReader.ReadElementContentAsString()); 
                Machine.BlockSkip = xReader.ReadElementContentAsString(); 
                Machine.Comments = xReader.ReadElementContentAsString(); 
                Machine.Endmain = xReader.ReadElementContentAsString(); 
                Machine.MachineType = (MachineType)Enum.Parse(typeof(MachineType), xReader.ReadElementContentAsString()); 
                Machine.RotaryAxis = (Axis)Enum.Parse(typeof(Axis), xReader.ReadElementContentAsString()); 
                Machine.RotaryDir = (RotaryDirection)Enum.Parse(typeof(RotaryDirection), xReader.ReadElementContentAsString()); 
                Machine.Precision = int.Parse(xReader.ReadElementContentAsString()); 
                Machine.ProgramId = xReader.ReadElementContentAsString(); 
                Machine.SubReturn = xReader.ReadElementContentAsString(); 
                Machine.RotPrecision = int.Parse(xReader.ReadElementContentAsString()); 
                Machine.RotaryType = (RotaryMotionType)Enum.Parse(typeof(RotaryMotionType), xReader.ReadElementContentAsString()); 
                Machine.Searchstring = xReader.ReadElementContentAsString(); 
                for (r = 0; r <= Machine.ViewAngles.Length - 1; r++) { 
                    Machine.ViewAngles[r] = float.Parse(xReader.ReadElementContentAsString()); 
                } 
                for (r = 0; r <= Machine.ViewShift.Length - 1; r++) { 
                    Machine.ViewShift[r] = float.Parse(xReader.ReadElementContentAsString()); 
                } 
                Machine.Absolute = xReader.ReadElementContentAsString(); 
                Machine.Incremental = xReader.ReadElementContentAsString(); 
                Machine.CCArc = xReader.ReadElementContentAsString(); 
                Machine.CWArc = xReader.ReadElementContentAsString(); 
                Machine.DrillRapid = xReader.ReadElementContentAsString(); 
                for (r = 0; r <= Machine.Drills.Length - 1; r++) { 
                    Machine.Drills[r] = xReader.ReadElementContentAsString(); 
                } 
                Machine.Linear = xReader.ReadElementContentAsString(); 
                Machine.Rapid = xReader.ReadElementContentAsString(); 
                Machine.ReturnLevel[0] = xReader.ReadElementContentAsString(); 
                Machine.ReturnLevel[1] = xReader.ReadElementContentAsString(); 
                Machine.Rotary = xReader.ReadElementContentAsString(); 
                Machine.XYplane = xReader.ReadElementContentAsString(); 
                Machine.XZplane = xReader.ReadElementContentAsString(); 
                Machine.YZplane = xReader.ReadElementContentAsString(); 
                Machine.Subcall = xReader.ReadElementContentAsString(); 
                Machine.SubRepeats = xReader.ReadElementContentAsString(); 
            } 
        } 
        mMachines.Add(Machine); 
        if (MachineLoaded != null) { 
            MachineLoaded(Machine); 
        } 
    } 
    
    public void SaveMachine(clsMachine MySetup) 
    { 
        string sName = DatFolder + MySetup.Name + DATEXTENSION; 
        XmlWriterSettings xSettings = new XmlWriterSettings(); 
        int r = 0; 
        xSettings.Indent = true; 
        xSettings.CheckCharacters = false; 
        xSettings.CloseOutput = true; 
        using (XmlWriter xWriter = XmlWriter.Create(sName, xSettings)) { 
            { 
                xWriter.WriteStartDocument(true); 
                xWriter.WriteStartElement("Machine"); 
                xWriter.WriteElementString("Name", MySetup.Name); 
                xWriter.WriteElementString("Description", MySetup.Description); 
                xWriter.WriteElementString("AbsArcCenter", MySetup.AbsArcCenter.ToString()); 
                xWriter.WriteElementString("LatheMinus", MySetup.LatheMinus.ToString()); 
                xWriter.WriteElementString("HelixPitch", MySetup.HelixPitch.ToString()); 
                xWriter.WriteElementString("BlockSkip", MySetup.BlockSkip); 
                xWriter.WriteElementString("Comments", MySetup.Comments); 
                xWriter.WriteElementString("Endmain", MySetup.Endmain.ToString()); 
                xWriter.WriteElementString("MachineType", MySetup.MachineType.ToString()); 
                xWriter.WriteElementString("RotaryAxis", MySetup.RotaryAxis.ToString()); 
                xWriter.WriteElementString("RotaryDir", MySetup.RotaryDir.ToString()); 
                xWriter.WriteElementString("Precision", MySetup.Precision.ToString()); 
                xWriter.WriteElementString("ProgramId", MySetup.ProgramId); 
                xWriter.WriteElementString("SubReturn", MySetup.SubReturn); 
                xWriter.WriteElementString("RotPrecision", MySetup.RotPrecision.ToString()); 
                xWriter.WriteElementString("RotaryType", MySetup.RotaryType.ToString()); 
                xWriter.WriteElementString("Searchstring", MySetup.Searchstring); 
                for (r = 0; r <= 2; r++) { 
                    xWriter.WriteElementString("ViewAngles_" + r.ToString(), MySetup.ViewAngles[r].ToString()); 
                } 
                for (r = 0; r <= 2; r++) { 
                    xWriter.WriteElementString("ViewShift_" + r.ToString(), MySetup.ViewShift[r].ToString()); 
                } 
                xWriter.WriteElementString("Absolute", MySetup.Absolute); 
                xWriter.WriteElementString("Incremental", MySetup.Incremental); 
                xWriter.WriteElementString("CCArc", MySetup.CCArc); 
                xWriter.WriteElementString("CWArc", MySetup.CWArc); 
                xWriter.WriteElementString("DrillRapid", MySetup.DrillRapid); 
                for (r = 0; r <= MySetup.Drills.Length - 1; r++) { 
                    xWriter.WriteElementString("Drills_" + r.ToString(), MySetup.Drills[r]); 
                } 
                xWriter.WriteElementString("Linear", MySetup.Linear); 
                xWriter.WriteElementString("Rapid", MySetup.Rapid); 
                xWriter.WriteElementString("ReturnLevel_0", MySetup.ReturnLevel[0]); 
                xWriter.WriteElementString("ReturnLevel_1", MySetup.ReturnLevel[1]); 
                xWriter.WriteElementString("Rotary", MySetup.Rotary); 
                xWriter.WriteElementString("XYplane", MySetup.XYplane); 
                xWriter.WriteElementString("XZplane", MySetup.XZplane); 
                xWriter.WriteElementString("YZplane", MySetup.YZplane); 
                xWriter.WriteElementString("Subcall", MySetup.Subcall); 
                xWriter.WriteElementString("SubRepeats", MySetup.SubRepeats); 
                xWriter.WriteEndElement(); 
                //Machine 
            } 
        } 
    } 
    
    public void DeleteMachine(string name) 
    { 
        string fileToDelete = DatFolder + name + DATEXTENSION; 
        if (System.IO.File.Exists(fileToDelete)) { 
            System.IO.File.Delete(fileToDelete); 
            mMachines.Remove(Machine); 
            if (MachineDeleted != null) { 
                MachineDeleted(name); 
            } 
        } 
    } 
    
    public void AddMachine(clsMachine m) 
    { 
        mMachines.Add(m); 
        Machine = m; 
        if (MachineAdded != null) { 
            MachineAdded(m); 
        } 
    } 
    
    public void RenameMachine(string newName, bool copy) 
    { 
        string newFile = DatFolder + newName + DATEXTENSION; 
        string thisFile = DatFolder + Machine.Name + DATEXTENSION; 
        
        if (copy) { 
            Machine.Name = newName; 
            SaveMachine(Machine); 
        } 
        else { 
            System.IO.File.Delete(thisFile); 
            Machine.Name = newName; 
            SaveMachine(Machine); 
        } 
    } 
    
    public void LoadAllMachines() 
    { 
        mMachines.Clear(); 
        if (MachinesCleared != null) { 
            MachinesCleared(); 
        } 
        string[] fls = System.IO.Directory.GetFiles(DatFolder, "*" + DATEXTENSION); 
        foreach (string f in fls) { 
            LoadMachine(f); 
        } 
    } 
    
    public void LoadAllMachines(string sDatFolder) 
    { 
        DatFolder = sDatFolder; 
        LoadAllMachines(); 
    } 
    
    //Loads the combo with names 
    public void LoadComboWithMachines(ref ComboBox cbo) 
    { 
        cbo.BeginUpdate(); 
        cbo.Items.Clear(); 
        foreach (clsMachine m in this.mMachines) { 
            cbo.Items.Add(m.Name); 
        } 
        cbo.EndUpdate(); 
    } 
    
    public void MatchMachineToFile(string sFullfile) 
    { 
        int ln = 0; 
        System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
        string sTemp = null; 
        System.IO.StreamReader fileReader = default(System.IO.StreamReader); 
        
        if (mMachines.Count == 0) { 
            Machine = null; 
            return; 
        } 
        //Open CNC file and get 50 lines of text 
        fileReader = new System.IO.StreamReader(sFullfile);
        while (fileReader.Peek() >= 0) { 
            if (ln >= 50) break;
            sb.Append(fileReader.ReadLine()); 
            ln += 1; 
        } 
        fileReader.Close(); 
        sTemp = sb.ToString(); 
        foreach (clsMachine m in mMachines) { 
            if (sTemp.Contains(m.Searchstring)) { 
                Machine = m; 
                if (MachineMatched != null) { 
                    MachineMatched(Machine); 
                } 
                return; 
            } 
        } 
    } 
} 
using CNCInfusion.Viewer;
using MacGen;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/// <summary> 
/// Processes the cnc file and loads the graphics records. 
/// </summary> 
/// <remarks> 
/// Copyright © MacGen Programming 2006 
/// Jason Titcomb 
/// www.CncEdit.com 
/// </remarks> 
internal class clsProcessor
{
    private readonly int[] mColors16 = [-16777216,
        -8388608,
        -16744448,
        -8355840,
        -16777088,
        -8388480,
        -16744320,
        -4144960,
        -8355712,
        -65536,
        -16711936,
        -256,
        -16776961,
        -12525360,
        -65281,
        -1];

    private Regex mRegSubs;
    private Regex mRegWords;

    private string mCodefile;    //the input file 
    private Motion mPlane;
    private float mDrillClear;
    private int mCurrentColor;
    private readonly System.Collections.Specialized.StringCollection mSubFiles = [];

    private float mInitialZBeforeDrill;
    private string mEndmain;    //M30 
    private string mSubcall;    //M98 
    private string mSubRepeats;    //L 
    //private int mSubFileNumber;
    private string mCommentMatch;
    private float mSang;
    private float mRad;
    private float mEang;
    private float mYcentr;
    private float mXcentr;
    private float mZcentr;
    private float mJ;
    private float mI;
    private float mK;
    private float mYpos;
    private float mXpos;
    private float mZpos;
    private float mPrevY;
    private float mPrevX;
    private float mPrevZ;
    private float mPrevABC;
    private float mABC;
    private int mRotDir;
    private bool mRotating;
    private float mRpoint;
    private Motion mDrillReturnMode;    //G98,G99 
    private float mArcRad;
    private float mFeed;
    private float mSpeed;
    private float mTool;
    private float mPrevTool;
    private Motion mMode;
    private bool mAbsolute;
    private string mCodeText;
    private int mTotalLines;
    private int mTotalBites;
    private readonly clsMotion mMotion = new();
    private Address mCurAddress;
    private bool mNewProfile;
    private ClsMotionRecord mGrfxRec;
    private System.Collections.Generic.List<ClsMotionRecord> mGfxRecs;
    public clsMachine mCurMachine;
    private const float ONE_RADIAN = (float)(Math.PI * 2);
    public enum LETTERS
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        ANY
    }
    private readonly bool[] mBlockAddresses = new bool[27];
    public event OnAddBlockEventHandler OnAddBlock;
    public delegate void OnAddBlockEventHandler(int value, int max);
    public event OnToolChangedEventHandler OnToolChanged;
    public delegate void OnToolChangedEventHandler(float tool);

    #region "Singleton"
    private static clsProcessor mInstance;
    //PRIVATE constructor can only be called from this class 
    private clsProcessor()
    {
    }
    /// <summary> 
    /// Static method for creating the single instance of the Constructor 
    /// </summary> 
    public static clsProcessor Instance()
    {
        // initialize if not already done 
        mInstance ??= new clsProcessor();
        // return the initialized instance of the Singleton Class 
        return mInstance;
    }
    //Instance 
    #endregion

    private class clsProg
    {
        public bool Main;
        public string Label;
        public int Value;
        public int Index;
        public string Contents;
        public int TimesCalled = 0;
    }

    private readonly System.Collections.Generic.List<clsProg> mNcProgs = [];

    private void Arc_Center()
    {
        float centerVector = 0;
        float side_opposite;
        float meanX;
        float meanY;
        float quarterArc;
        switch (mPlane)
        {
            case Motion.XY_PLN:
                //This is for an arc or helix that uses an R insdead of I,J,K, 

                //Radius move with R 
                if (mBlockAddresses[(int)LETTERS.R] & (mMode > Motion.LINE))
                {
                    quarterArc = (float)(Math.PI / 2);
                    //|------- Calculate arc center position -------| 

                    //A "-R" is used to specify big arc 
                    if (mArcRad < 0)
                    {
                        quarterArc = -quarterArc; //Total angle > 180 deg 
                    }
                    //Total angle is always <180 if "+R" 

                    //this is a full arc 
                    if (mPrevX == mXpos & mPrevY == mYpos)
                    {
                        quarterArc = 0;
                    }

                    mRad = System.Math.Abs(mArcRad); //calculate side opposite 'hypotenuse 
                    side_opposite = (float)System.Math.Abs(Math.Pow(mRad, 2) - Math.Pow(MG_CS_BasicViewer.VectorLength(mPrevX, mPrevY, 0, mXpos, mYpos, 0) / 2, 2));
                    side_opposite = (float)System.Math.Sqrt(side_opposite);
                    //find mid point of start and end of arc start and end points 
                    meanX = (mPrevX + mXpos) / 2;
                    meanY = (mPrevY + mYpos) / 2;

                    if (mMode == Motion.CCARC)
                    {
                        centerVector = MG_CS_BasicViewer.AngleFromPoint(mXpos - mPrevX, mYpos - mPrevY, false) - quarterArc;
                        if (centerVector < 0)
                        {
                            centerVector = ONE_RADIAN + centerVector;
                        }
                    }


                    if (mMode == Motion.CWARC)
                    {
                        centerVector = MG_CS_BasicViewer.AngleFromPoint(mXpos - mPrevX, mYpos - mPrevY, false) + quarterArc;
                        if (centerVector > ONE_RADIAN)
                        {
                            centerVector -= ONE_RADIAN;
                        }
                    }


                    mXcentr = (float)(meanX - (side_opposite * System.Math.Cos(centerVector)));
                    mYcentr = (float)(meanY - (side_opposite * System.Math.Sin(centerVector)));

                    //Calculate start and end angle 
                    mSang = MG_CS_BasicViewer.AngleFromPoint(mPrevX - mXcentr, mPrevY - mYcentr, false);
                    mEang = MG_CS_BasicViewer.AngleFromPoint(mXpos - mXcentr, mYpos - mYcentr, false);
                }
                else
                {

                    if (mCurMachine.AbsArcCenter)
                    {
                        mI -= mPrevX;
                        mJ -= mPrevY;
                    }

                    mRad = (float)System.Math.Sqrt(Math.Pow(mI, 2) + Math.Pow(mJ, 2));
                    //calculate rad 
                    mXcentr = mPrevX + mI;
                    //Arc origins 
                    mYcentr = mPrevY + mJ;
                    mZcentr = mPrevZ + mK;
                    mSang = MG_CS_BasicViewer.AngleFromPoint(mPrevX - mXcentr, mPrevY - mYcentr, false);
                    mEang = MG_CS_BasicViewer.AngleFromPoint(mXpos - mXcentr, mYpos - mYcentr, false);
                }


                break;
            //InStr(codeline, "R") 

            case Motion.XZ_PLN:
                //This is for an arc or helix that uses an R insdead of I,J,K, 

                //Radius move with R 
                if (mBlockAddresses[(int)LETTERS.R] & mMode > Motion.LINE)
                {
                    quarterArc = (float)(Math.PI / 2);
                    //|------- Calculate arc center position -------| 

                    //A "-R" is used to specify big arc 
                    if (mArcRad < 0)
                    {
                        quarterArc = -quarterArc;
                        //Total angle > 180 deg 
                    }
                    //Total angle is always <180 if "+R" 

                    //this is a full arc 
                    if (mPrevX == mXpos & mPrevZ == mZpos)
                    {
                        quarterArc = 0;
                    }

                    mRad = System.Math.Abs(mArcRad);
                    //calculate side opposite 'hypotenuse 
                    side_opposite = (float)System.Math.Abs(Math.Pow(mRad, 2) - Math.Pow(MG_CS_BasicViewer.VectorLength(mPrevX, mPrevZ, 0, mXpos, mZpos, 0) / 2, 2));
                    side_opposite = (float)System.Math.Sqrt(side_opposite);
                    //find mid point of start and end of arc start and end points 
                    meanX = (mPrevX + mXpos) / 2;
                    meanY = (mPrevZ + mZpos) / 2;

                    if (mMode == Motion.CCARC)
                    {
                        centerVector = MG_CS_BasicViewer.AngleFromPoint(mXpos - mPrevX, mZpos - mPrevZ, false) - quarterArc;
                        if (centerVector < 0)
                        {
                            centerVector = ONE_RADIAN + centerVector;
                        }
                    }


                    if (mMode == Motion.CWARC)
                    {
                        centerVector = MG_CS_BasicViewer.AngleFromPoint(mXpos - mPrevX, mZpos - mPrevZ, false) + quarterArc;
                        if (centerVector > ONE_RADIAN)
                        {
                            centerVector -= ONE_RADIAN;
                        }
                    }


                    mXcentr = (float)(meanX - (side_opposite * System.Math.Cos(centerVector)));
                    mZcentr = (float)(meanY - (side_opposite * System.Math.Sin(centerVector)));

                    //Calculate start and end angle 
                    mSang = MG_CS_BasicViewer.AngleFromPoint(mPrevX - mXcentr, mPrevZ - mZcentr, false);
                    mEang = MG_CS_BasicViewer.AngleFromPoint(mXpos - mXcentr, mZpos - mZcentr, false);
                }
                else
                {

                    if (mCurMachine.AbsArcCenter)
                    {
                        mI -= mPrevX;
                        mK -= mPrevZ;
                    }

                    mRad = (float)System.Math.Sqrt(Math.Pow(mI, 2) + Math.Pow(mK, 2));
                    //calculate rad 
                    mXcentr = mPrevX + mI;
                    mYcentr = mPrevY + mJ;
                    //Arc origins 
                    mZcentr = mPrevZ + mK;

                    mSang = MG_CS_BasicViewer.AngleFromPoint(mPrevX - mXcentr, mPrevZ - mZcentr, false);
                    mEang = MG_CS_BasicViewer.AngleFromPoint(mXpos - mXcentr, mZpos - mZcentr, false);
                }


                break;
            //InStr(codeline, "R") 

            case Motion.YZ_PLN:
                //This is for an arc or helix that uses an R insdead of I,J,K, 

                //Radius move with R 
                if (mBlockAddresses[(int)LETTERS.R] & mMode > Motion.LINE)
                {
                    quarterArc = (float)(Math.PI / 2);
                    //|------- Calculate arc center position -------| 

                    //A "-R" is used to specify big arc 
                    if (mArcRad < 0)
                    {
                        quarterArc = -quarterArc;
                        //Total angle > 180 deg 
                    }
                    //Total angle is always <180 if "+R" 

                    //this is a full arc 
                    if (mPrevY == mYpos & mPrevZ == mZpos)
                    {
                        quarterArc = 0;
                    }

                    mRad = System.Math.Abs(mArcRad);
                    //calculate side opposite 'hypotenuse 
                    side_opposite = (float)System.Math.Abs(Math.Pow(mRad, 2) - Math.Pow(MG_CS_BasicViewer.VectorLength(mPrevY, mPrevZ, 0, mYpos, mZpos, 0) / 2, 2));
                    side_opposite = (float)System.Math.Sqrt(side_opposite);
                    //find mid point of start and end of arc start and end points 
                    meanX = (mPrevY + mYpos) / 2;
                    meanY = (mPrevZ + mZpos) / 2;

                    if (mMode == Motion.CCARC)
                    {
                        centerVector = MG_CS_BasicViewer.AngleFromPoint(mYpos - mPrevY, mZpos - mPrevZ, false) - quarterArc;
                        if (centerVector < 0)
                        {
                            centerVector = ONE_RADIAN + centerVector;
                        }
                    }


                    if (mMode == Motion.CWARC)
                    {
                        centerVector = MG_CS_BasicViewer.AngleFromPoint(mYpos - mPrevY, mZpos - mPrevZ, false) + quarterArc;
                        if (centerVector > ONE_RADIAN)
                        {
                            centerVector -= ONE_RADIAN;
                        }
                    }


                    mYcentr = (float)(meanX - (side_opposite * System.Math.Cos(centerVector)));
                    mZcentr = (float)(meanY - (side_opposite * System.Math.Sin(centerVector)));

                    //Calculate start and end angle 
                    mSang = MG_CS_BasicViewer.AngleFromPoint(mPrevY - mYcentr, mPrevZ - mZcentr, false);
                    mEang = MG_CS_BasicViewer.AngleFromPoint(mYpos - mYcentr, mZpos - mZcentr, false);
                }
                else
                {

                    if (mCurMachine.AbsArcCenter)
                    {
                        mJ -= mPrevY;
                        mK -= mPrevZ;
                    }

                    mRad = (float)System.Math.Sqrt(Math.Pow(mJ, 2) + Math.Pow(mK, 2));
                    //calculate rad 
                    mXcentr = mPrevX + mI;
                    mYcentr = mPrevY + mJ;
                    //Arc origins 
                    mZcentr = mPrevZ + mK;

                    mSang = MG_CS_BasicViewer.AngleFromPoint(mPrevY - mYcentr, mPrevZ - mZcentr, false);
                    mEang = MG_CS_BasicViewer.AngleFromPoint(mYpos - mYcentr, mZpos - mZcentr, false);
                }


                break;
                //InStr(codeline, "R") 

        }

    }

    private void AddMotionRecord()
    {
        mGrfxRec = new ClsMotionRecord();
        {
            mGrfxRec.BeginProfile = mNewProfile;
            mGrfxRec.WrkPlane = (int)mPlane;
            mGrfxRec.Tool = mTool;
            mGrfxRec.DrawClr = Color16(mCurrentColor);
            mGrfxRec.Yold = mPrevY + mCurMachine.ViewShift[1];
            mGrfxRec.Ycentr = mYcentr + mCurMachine.ViewShift[1];
            mGrfxRec.Ypos = mYpos + mCurMachine.ViewShift[1];

            mGrfxRec.Codestring = mCodeText;
            mGrfxRec.MotionType = mMode;
            mGrfxRec.Rpoint = mRpoint + mCurMachine.ViewShift[2];
            mGrfxRec.DrillClear = mDrillClear;
            mGrfxRec.Xold = mPrevX + mCurMachine.ViewShift[0];
            mGrfxRec.Xpos = mXpos + mCurMachine.ViewShift[0];
            mGrfxRec.Rad = mRad;
            mGrfxRec.Xcentr = mXcentr + mCurMachine.ViewShift[0];

            mGrfxRec.Zold = mPrevZ + mCurMachine.ViewShift[2];
            mGrfxRec.Zpos = mZpos + mCurMachine.ViewShift[2];
            mGrfxRec.Zcentr = mZcentr + mCurMachine.ViewShift[2];

            mGrfxRec.Rotate = mRotating;
            mGrfxRec.NewRotaryPos = mABC;
            mGrfxRec.OldRotaryPos = mPrevABC;
            mGrfxRec.RotaryDir = mRotDir;
            // * mcurmachine.nRotaryDir 

            mGrfxRec.Speed = mSpeed;
            mGrfxRec.Feed = mFeed;
            mGrfxRec.Sang = mSang;
            mGrfxRec.Eang = mEang;
        }
        mGfxRecs.Add(mGrfxRec);
    }

    private float FormatAxis(string sVal, int precision)
    {
        //decimal place 
        if (sVal.Contains("."))
        {
            return float.Parse(sVal);
        }
        else
        {
            return (float)(float.Parse(sVal) * Math.Pow(10, -precision));//convert a number from a 4 place 
        }
    }

    // modified to take first argument as a preprocessed buffer, instead of filename
    public void ProcessFile(string ncFile, List<ClsMotionRecord> gfxRecs)
    {
        mGfxRecs = gfxRecs;
        mCodefile = ncFile;
        {
            mMotion.SubCall.Label = mCurMachine.Subcall[0];
            mMotion.SubCall.Value = int.Parse(mCurMachine.Subcall[1..]);

            mMotion.SubReturn.Label = mCurMachine.SubReturn[0];
            mMotion.SubReturn.Value = int.Parse(mCurMachine.SubReturn[1..]);

            mMotion.Abs.Label = mCurMachine.Absolute[0];
            mMotion.Abs.Value = int.Parse(mCurMachine.Absolute[1..]);
            mMotion.CCArc.Label = mCurMachine.CCArc[0];
            mMotion.CCArc.Value = int.Parse(mCurMachine.CCArc[1..]);
            mMotion.CWArc.Label = mCurMachine.CWArc[0];
            mMotion.CWArc.Value = int.Parse(mCurMachine.CWArc[1..]);

            mMotion.Inc.Label = mCurMachine.Incremental[0];
            mMotion.Inc.Value = int.Parse(mCurMachine.Incremental[1..]);

            mMotion.Linear.Label = mCurMachine.Linear[0];
            mMotion.Linear.Value = int.Parse(mCurMachine.Linear[1..]);

            mMotion.Rapid.Label = mCurMachine.Rapid[0];
            mMotion.Rapid.Value = int.Parse(mCurMachine.Rapid[1..]);

            mMotion.Rotary.Label = mCurMachine.Rotary[0];
            mMotion.Rotary.Value = 0;

            mMotion.DrillRapid.Label = mCurMachine.DrillRapid[0];
            mMotion.DrillRapid.Value = 0;

            mMotion.Plane[0].Label = mCurMachine.XYplane[0];
            mMotion.Plane[0].Value = int.Parse(mCurMachine.XYplane[1..]);
            mMotion.Plane[1].Label = mCurMachine.XZplane[0];
            mMotion.Plane[1].Value = int.Parse(mCurMachine.XZplane[1..]);
            mMotion.Plane[2].Label = mCurMachine.YZplane[0];
            mMotion.Plane[2].Value = int.Parse(mCurMachine.YZplane[1..]);

            mMotion.ReturnLevel[0].Label = mCurMachine.ReturnLevel[0][0];
            mMotion.ReturnLevel[0].Value = int.Parse(mCurMachine.ReturnLevel[0][1..]);
            mMotion.ReturnLevel[1].Label = mCurMachine.ReturnLevel[1][0];
            mMotion.ReturnLevel[1].Value = int.Parse(mCurMachine.ReturnLevel[1][1..]);

            for (int r = 0; r <= mMotion.Drills.Length - 1; r++)
            {
                if (mCurMachine.Drills[r].Length > 2)
                {
                    mMotion.Drills[r].Label = mCurMachine.Drills[r][0];
                    mMotion.Drills[r].Value = int.Parse(mCurMachine.Drills[r][1..]);
                }
            }
        }


        //Reset all positions. 
        mGfxRecs.Clear();
        mCurrentColor = 0;
        mPrevTool = -1;
        mXpos = 0;
        mYpos = 0;
        mZpos = 0;
        mPrevX = 0;
        mPrevY = 0;
        mPrevZ = 0;
        mPrevABC = 0;
        mABC = 0;
        mRpoint = 0;
        mSpeed = 0;
        mFeed = 0;
        mDrillClear = 0;
        mInitialZBeforeDrill = 0;
        mRotDir = 1;
        mAbsolute = true;
        mMode = Motion.RAPID;
        mDrillReturnMode = Motion.I_PLN;

        if (mCurMachine.MachineType == MachineType.MILL)
        {
            mPlane = Motion.XY_PLN; //Mill 
        }
        else
        {
            mPlane = Motion.XZ_PLN;//Lathe 
        }

        mEndmain = mCurMachine.Endmain.Trim();
        mSubcall = mCurMachine.Subcall.Trim();
        mSubRepeats = mCurMachine.SubRepeats.Trim();
        string sFileContents = FilterJunk(ncFile);

        mNcProgs.Clear();
        int lastIndex = -1;
        clsProg p;
        foreach (Match m in mRegSubs.Matches(sFileContents))
        {
            if (mCurMachine.ProgramId.Contains(m.Value[0].ToString()))
            {
                int thisIndex = m.Index;
                //Each program 
                if (lastIndex > -1)
                {
                    mNcProgs[^1].Contents = sFileContents[lastIndex..thisIndex].TrimEnd();
                    if (mNcProgs[^1].Contents.Contains(mCurMachine.Endmain))
                    {
                        mNcProgs[^1].Main = true;
                    }
                }
                p = new clsProg
                {
                    Main = false,
                    Index = thisIndex,
                    Label = char.ToUpper(m.Value[0]).ToString(),
                    Value = int.Parse(m.Groups[1].Value)
                };
                mNcProgs.Add(p);
                lastIndex = m.Index;
            }
        }

        mTotalLines = 1;
        if (mNcProgs.Count == 0)
        {
            //Just add all the text we found in the file 
            p = new clsProg
            {
                Main = true,
                Index = 0,
                Label = "MAIN",
                Value = 0,
                Contents = sFileContents
            };
            mNcProgs.Add(p);
            mTotalBites = sFileContents.Length;
            ProcessSubWords(p);
        }
        else
        {
            mNcProgs[^1].Contents = sFileContents[lastIndex..].TrimEnd();
            if (mNcProgs[^1].Contents.Contains(mCurMachine.Endmain))
            {
                mNcProgs[^1].Main = true;
            }
            foreach (clsProg pr in mNcProgs)
            {
                mTotalBites = pr.Contents.Length;
                ProcessSubWords(pr);
            }
        }
    }

    private clsProg FindSubByValue(int val)
    {
        foreach (clsProg p in mNcProgs)
        {
            if (p.Value == val)
            {
                return p;
            }
        }
        return null;
    }

    private void ProcessSubWords(clsProg p)
    {
        p.TimesCalled += 1;
        int lastIndex = 0;
        foreach (Match ncWord in mRegWords.Matches(p.Contents))
        {
            //Each word 
            //Is this a newline 
            if (ncWord.Value == "\n")
            {
                mTotalLines += 1;
                mCodeText = p.Contents.Substring(lastIndex, ncWord.Index - lastIndex - 1);
                CreateGcodeBlock();
                OnAddBlock?.Invoke(ncWord.Index, mTotalBites);
                Array.Clear(mBlockAddresses, 0, 26);
                lastIndex = ncWord.Index + 1;
            }
            else if (MatchIsComment(ncWord))
            {
                //Comment 
                mTotalLines += ncWord.Value.Split('\n').Length - 1;
            }
            else if (mCurMachine.BlockSkip.Contains(ncWord.Value[0].ToString()))
            {
                //Blockskip. 
                mTotalLines += 1;
            }
            else
            {
                //Word 
                mCurAddress.Label = char.ToUpper(ncWord.Value[0]);
                mCurAddress.StringValue = ncWord.Groups[1].Value;
                mCurAddress.Value = float.Parse(ncWord.Groups[1].Value);
                if (mCurAddress.Matches(mMotion.SubCall))
                {
                    //M98 P. Use the next word value as the sub name 
                    clsProg retProg = FindSubByValue(int.Parse(ncWord.NextMatch().Groups[1].Value));
                    if (retProg != null)
                    {
                        if (retProg.TimesCalled > 100)
                        {
                            return;//Prevent infinite loop 
                        }

                        ProcessSubWords(retProg);//Call this subagain 
                    }
                }
                else
                {
                    EvaluateWord();
                }
            }
        }
    }

    private void CreateGcodeBlock()
    {
        if (!mBlockAddresses[(int)LETTERS.ANY])
        {
            return;
        }

        if (mBlockAddresses[(int)LETTERS.X])
        {
            if (mAbsolute == false)
            {
                mXpos += mPrevX;
            }
            if (mCurMachine.MachineType == MachineType.LATHEDIA)
            {
                mXpos /= 2;
            }
        }
        if (mBlockAddresses[(int)LETTERS.Y])
        {
            if (mAbsolute == false)
            {
                mYpos += mPrevY;
            }
        }
        if (mBlockAddresses[(int)LETTERS.Z])
        {
            if (mAbsolute == false)
            {
                mZpos += mPrevZ;
            }
        }

        if (mBlockAddresses[(int)mMotion.Rotary.Letter] == true)
        {
            mRotating = true;
            //0>360 sign determines dir 
            if (mCurMachine.RotaryType == RotaryMotionType.BMC)
            {
                if (mAbsolute == false)
                {
                    mABC += mPrevABC;
                }
            }
            //like CAD 
            else
            {
                if (mAbsolute == false)
                {
                    mRotDir = System.Math.Sign(mABC);
                    mABC += mPrevABC;
                }
                else
                {
                    //In a scale that runs from zero to 360 
                    //we determine the direction based on the shortest distance. 
                    if (Math.Abs(mABC % ONE_RADIAN) > Math.PI & Math.Abs(mPrevABC % ONE_RADIAN) < Math.PI)
                    {
                        mPrevABC += ONE_RADIAN;
                    }
                    else if (Math.Abs(mABC % ONE_RADIAN) < Math.PI & Math.Abs(mPrevABC % ONE_RADIAN) > Math.PI)
                    {
                        mPrevABC -= ONE_RADIAN;
                    }

                    mRotDir = mABC < mPrevABC ? -1 : 1;
                }
            }
        }


        //Arc clockwise------------------- 
        if (mMode == Motion.CWARC)
        {
            Arc_Center();
            //Calculate arc center 
            if (mSang <= mEang)
            {
                mSang += ONE_RADIAN;
            }

            //re-calculate zpos if helix using k for pitch 
            if (mK > 0 & mPlane == Motion.XY_PLN)
            {
                if (mSang == mEang)
                {
                    mZpos += mK;
                }
                else
                {
                    mZpos += mK * System.Math.Abs(mSang - mEang) / ONE_RADIAN;
                }
            }
        }


        //Arc anti-clockwise-------------- 
        if (mMode == Motion.CCARC)
        {
            Arc_Center();
            //Calculate arc center 
            if (mEang <= mSang)
            {
                mEang += ONE_RADIAN;
            }
            //re-calculate zpos if helix using k for pitch 
            if (mK > 0 & mPlane == Motion.XY_PLN)
            {
                if (mSang == mEang)
                {
                    mZpos += mK;
                }
                else
                {
                    mZpos += mK * System.Math.Abs(mSang - mEang) / ONE_RADIAN;
                }
            }
        }

        if (mPrevTool != mTool)
        {
            mNewProfile = true;
            if (mCurrentColor == 0)
            {
                mCurrentColor = 9;
            }
            mCurrentColor++;
            if (mCurrentColor > 15)
            {
                mCurrentColor = 1;
            }
            OnToolChanged?.Invoke(mTool);
        }

        if ((static_CreateGcodeBlock_mPrevMode == Motion.RAPID & mMode > Motion.RAPID) | (static_CreateGcodeBlock_mPrevMode > Motion.RAPID & mMode == Motion.RAPID))
        {
            mNewProfile = true;
        }

        if (mMode > Motion.RAPID)
        {
            mInitialZBeforeDrill = mZpos;
        }

        //Create the graphics record here 
        AddMotionRecord();

        //Reset some values 
        static_CreateGcodeBlock_mPrevMode = Motion.RAPID;
        mPrevTool = mTool;
        mRotating = false;
        mPrevABC = mABC;
        //Lval = 0 
        mI = 0;
        mJ = 0;
        mK = 0;

        //Stores last position 
        mPrevX = mXpos;
        mPrevY = mYpos;
        mPrevZ = mZpos;
    }

    private static MacGen.Motion static_CreateGcodeBlock_mPrevMode = Motion.RAPID;

    private void EvaluateWord()
    {
        mBlockAddresses[(int)mCurAddress.Letter] = true;
        switch (mCurAddress.Letter)
        {
            case LETTERS.X:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mXpos = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                break;
            case LETTERS.Y:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mYpos = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                break;
            case LETTERS.Z:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mZpos = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                break;
            case LETTERS.I:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mI = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                if (mCurMachine.MachineType == MachineType.LATHEDIA)
                {
                    if (mCurMachine.AbsArcCenter)
                    {
                        mI /= 2;
                    }
                }
                break;
            case LETTERS.J:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mJ = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                break;
            case LETTERS.K:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mK = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                break;
            case LETTERS.R:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mRpoint = FormatAxis(mCurAddress.StringValue, mCurMachine.Precision);
                mArcRad = mRpoint;
                break;
            case LETTERS.S:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mSpeed = mCurAddress.Value;
                break;
            case LETTERS.F:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mFeed = mCurAddress.Value;
                break;
            case LETTERS.T:
                mBlockAddresses[(int)LETTERS.ANY] = true;
                mTool = mCurAddress.Value;
                break;
            default:
                if (mBlockAddresses[(int)mMotion.Rotary.Letter] == true)
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mABC = FormatAxis(mCurAddress.StringValue, mCurMachine.RotPrecision) * 0.01745329f;
                    //Convert to radians 
                    //check for -0 
                    if (mCurAddress.StringValue.StartsWith("-"))
                    {
                        mRotDir = -1;
                        //CCW 
                    }
                    break;
                }

                //Absolute positioning 
                if (mCurAddress.Matches(mMotion.Abs))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mAbsolute = true;
                }
                //Incremental positioning 
                else if (mCurAddress.Matches(mMotion.Inc))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mAbsolute = false;
                }
                else if (mCurAddress.Matches(mMotion.Rapid))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mMode = Motion.RAPID;
                }
                else if (mCurAddress.Matches(mMotion.Linear))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mMode = Motion.LINE;
                }
                //Arc clockwise 
                else if (mCurAddress.Matches(mMotion.CWArc))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mMode = mPlane == Motion.XZ_PLN ? Motion.CCARC : Motion.CWARC;
                }
                //Arc anti-clockwise 
                else if (mCurAddress.Matches(mMotion.CCArc))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mMode = mPlane == Motion.XZ_PLN ? Motion.CWARC : Motion.CCARC;
                }
                //Drill cancel found 
                else if (mCurAddress.Matches(mMotion.Drills[0]))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mMode = Motion.RAPID;
                    mZpos = mDrillReturnMode == Motion.I_PLN ? mInitialZBeforeDrill : mRpoint;
                }
                else if (mCurAddress.Matches(mMotion.ReturnLevel[0]))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mDrillReturnMode = Motion.I_PLN;
                    if (mMode > Motion.CCARC)
                    {
                        mMode = (int)Motion.HOLE_I + mDrillReturnMode;
                    }
                }
                else if (mCurAddress.Matches(mMotion.ReturnLevel[1]))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mDrillReturnMode = Motion.R_PLN;
                    if (mMode > Motion.CCARC)
                    {
                        mMode = (int)Motion.HOLE_I + mDrillReturnMode;
                    }
                }
                //Plane Change G17 
                else if (mCurAddress.Matches(mMotion.Plane[0]))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mPlane = Motion.XY_PLN;
                }
                //Plane Change G18 
                else if (mCurAddress.Matches(mMotion.Plane[1]))
                {
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                    mPlane = Motion.XZ_PLN;
                }
                //Plane Change G19 
                else if (mCurAddress.Matches(mMotion.Plane[2]))
                {
                    mPlane = Motion.YZ_PLN;
                    mBlockAddresses[(int)LETTERS.ANY] = true;
                }
                else
                {
                    int r;
                    //Cycle through all 10 drilling cycles 
                    for (r = 1; r <= mMotion.Drills.Length - 1; r++)
                    {
                        //NOT an empty field 
                        if (mMotion.Drills[r].Value != 0.0f)
                        {
                            if (mCurAddress.Matches(mMotion.Drills[r]))
                            {
                                mMode = (int)Motion.HOLE_I + mDrillReturnMode;
                                //Drill cycle found 
                                if (mMode == Motion.HOLE_I)
                                {
                                    mDrillClear = mInitialZBeforeDrill;
                                }
                                if (mMode == Motion.HOLE_R)
                                {
                                    mDrillClear = mRpoint;
                                }
                                mBlockAddresses[(int)LETTERS.ANY] = true;
                                break; // TODO: might not be correct. Was : Exit For 
                            }
                        }
                    }
                }

                break;
        }
    }

    internal bool MatchIsComment(Match m)
    {
        return m.Groups["Comment"].Success;
    }

    public void Init(clsMachine machineSetup)
    {

        {
            mCurMachine = machineSetup;
            const string REG_NCWORDS = "[A-Z]([-+]?[0-9]*[\\.,]?[0-9]*)";

            if (machineSetup == null)
            {
                return;
            }

            string skipChars = "";
            foreach (char c in mCurMachine.BlockSkip.ToCharArray())
            {
                skipChars += Regex.Escape(c.ToString());
            }

            BuildCommentMatch();

            mRegWords = new Regex(InsertCommment() + "[" + skipChars + "][0-9]?|\\n|" + REG_NCWORDS, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //[:\$O]+([0-9]+) This will return the label and value of each program. 
            string progId = Regex.Escape(mCurMachine.ProgramId);
            mRegSubs = new Regex(InsertCommment() + "[" + progId + "]([0-9]+)", RegexOptions.Compiled);
        }
    }

    private string InsertCommment()
    {
        return mCommentMatch.Length > 0 ? mCommentMatch + "|" : "";
    }

    private void BuildCommentMatch()
    {
        string STR_EOL = "\r?";
        mCommentMatch = "";
        string commentSetting = mCurMachine.Comments;
        //Legacy support 
        if (commentSetting.Contains("(*)") | commentSetting.Contains("()"))
        {
            mCommentMatch = "\\([^()]*\\)";
        }

        if (commentSetting.Contains("{}"))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += "{[^{}]*}";
        }
        if (commentSetting.Contains("[]"))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += "\\[[[]]*\\]";
        }
        if (commentSetting.Contains("<>"))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += "\\<[<>]*\\>";
        }

        if (commentSetting.Contains("\"\""))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += "\".*\"";
        }

        //Single characters 
        if (commentSetting.Contains(";"))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += ";.*" + STR_EOL;
        }
        if (commentSetting.Contains(":"))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += ":.*" + STR_EOL;
        }
        if (commentSetting.Contains("'"))
        {
            if (mCommentMatch.Length > 0)
            {
                mCommentMatch += "|";
            }

            mCommentMatch += "'.*" + STR_EOL;
        }

        if (mCommentMatch.Length > 0)
        {
            mCommentMatch = "(?<Comment>" + mCommentMatch + ")";
        }
    }

    public string FilterJunk(string sText)
    {
        return Regex.Replace(sText, "\x0A\x0A|\x0D\x0D|[\x00-\x09]|[\x0E-\x1F]|[\x7F-\xFF]", "", RegexOptions.Compiled);
    }

    private System.Drawing.Color Color16(int i)
    {
        return System.Drawing.Color.FromArgb(mColors16[i]);
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace MacGen
{
     public enum Motion
    {
        RAPID = 0,
        LINE = 1,
        CWARC = 2,
        CCARC = 3,
        HOLE_I = 4,
        HOLE_R = 5,
        XY_PLN = 0,
        XZ_PLN = 1,
        YZ_PLN = 2,
        I_PLN = 0,
        R_PLN = 1
    }

    public enum MachineType
    {
        LATHEDIA = 0,
        LATHERAD = 1,
        MILL = 2
    }

    public enum Axis
    {
        Z = 0,
        Y = 1,
        X = 2
    }

    public enum RotaryDirection
    {
        CW = 1,
        CCW = -1
    }

    public enum RotaryMotionType
    {
        BMC = 0,
        CAD = 1
    } /// <summary> 
    /// CNC Viewer 
    /// </summary> 
    /// <remarks> 
    /// Copyright © MacGen Programming 2006 
    /// Jason Titcomb 
    /// www.CncEdit.com 
    /// </remarks> 
    public partial class MG_CS_BasicViewer : UserControl
    {
        //public members 
        public static Dictionary<float, clsToolLayer> ToolLayers = new Dictionary<float, clsToolLayer>();
        public static List<MG_CS_BasicViewer> Siblings = new List<MG_CS_BasicViewer>();
        public static List<clsMotionRecord> MotionBlocks = new List<clsMotionRecord>();
        public enum ManipMode
        {
            NONE,
            FENCE,
            PAN,
            ZOOM,
            ROTATE,
            SELECTION
        }
        //public delegate void AfterViewManipEventHandler(ManipMode mode, RectangleF viewRect);
        //public event AfterViewManipEventHandler AfterViewManip;

        //public delegate void OnStatusEventHandler(string msg, int index, int max);
        //public static event OnStatusEventHandler OnStatus;
       
        public delegate void OnSelectionEventHandler(List<clsMotionRecord> hits);
        public static event OnSelectionEventHandler OnSelection;
        
        public delegate void MouseLocationEventHandler(float x, float y);
        public static event MouseLocationEventHandler MouseLocation;
        
        
        //private members 
        private const int INT_MAXHITS = 64;
        private const float ONE_RADIAN = (float)(Math.PI * 2);
        private const float PI_S = (float)(Math.PI);
        private float mPixelF;
        private float mBlipSize;
        private float mSinPitch;
        private float mSinYaw;
        private float mSinRoll;
        private float mCosPitch;
        private float mCosYaw;
        private float mCosRoll;
        private float mCosRot;
        private float mSinRot;
        //private bool mBackStep;
        private Motion mCurMotion;
        private Color mCurColor;
        private float mLongside = 2.0f;
        private PointF mLastPos;
        private clsMotionRecord mCurGfxRec;
        private int mGfxIndex;

        private float[] mExtentX = new float[2];
        private float[] mExtentY = new float[2];

        private List<PointF> mPoints = new List<PointF>();
        private List<clsDisplayList> mSelectionHitLists = new List<clsDisplayList>();
        private List<clsMotionRecord> mSelectionHits = new List<clsMotionRecord>();
        private List<clsDisplayList> mDisplayLists = new List<clsDisplayList>();
        private List<clsDisplayList> mWcsDisplayLists = new List<clsDisplayList>();
        private bool mMouseDownAndMoving;
        private Point mMouseDownPt;
        private Point mLastPt;

        private System.Drawing.Drawing2D.Matrix mMtxDraw = new System.Drawing.Drawing2D.Matrix();
        private System.Drawing.Drawing2D.Matrix mMtxWCS = new System.Drawing.Drawing2D.Matrix();
        private System.Drawing.Drawing2D.Matrix mMtxFeedback = new System.Drawing.Drawing2D.Matrix();
        private System.Drawing.Drawing2D.Matrix mMtxGeo = new System.Drawing.Drawing2D.Matrix();
        private RectangleF mViewRect = new RectangleF();
        private Rectangle mClientRect = new Rectangle();
        private RectangleF mSelectionRect = new RectangleF(0, 0, 0, 0);
        private Rectangle mSelectionPixRect = new Rectangle(0, 0, 4, 4);
        private PointF mViewportCenter = new PointF();
        private float mScaleToReal = 1.0f;
        private PointF[] mMousePtF = new PointF[3];

        private Pen mCurPen = new Pen(Color.Blue, 0);
        private Pen mWCSPen = new Pen(Color.Blue, 0);
        private float[] mRapidDashStyle = new float[] { 0.1f, 0.1f };
        private float[] mAxisDashStyle = new float[] { 0.05f, 0.2f };

        private BufferedGraphicsContext mContext;
        private BufferedGraphics mGfxBuff;
        private Graphics mGfx; 

        public MG_CS_BasicViewer()
        {
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call. 
            Siblings.Add(this);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            // Retrieves the BufferedGraphicsContext for the current application domain. 
            mContext = BufferedGraphicsManager.Current; 

        }

            /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
         protected override void Dispose(bool disposing)
        {
            Siblings.Remove(this);
            if (disposing && components != null)
            {
                components.Dispose();
            }
            if (mGfxBuff != null)
            {
                mGfxBuff.Dispose();
            }
            if (mMtxDraw != null)
            {
                mMtxDraw.Dispose();
            }
            if (mCurPen != null)
            {
                mCurPen.Dispose();
            }
            if (mWCSPen != null)
            {
                mWCSPen.Dispose();
            }
            base.Dispose(disposing);
        }
            
       
        
        #region "Properties"
        private static bool mDynamicViewManipulation = false;
        [Description("Determines if the graphics are redrawn during view manipulation."), Category("Custom"), DefaultValue(false)]
        public bool DynamicViewManipulation
        {
            get { return mDynamicViewManipulation; }
            set { mDynamicViewManipulation = value; }
        }

        private static ManipMode mViewManipMode = ManipMode.NONE;
        [Description("Sets or gets the view manipulation mode"), Category("Custom"), DefaultValue(ManipMode.NONE)]
        public ManipMode ViewManipMode
        {
            get { return mViewManipMode; }
            set
            {
                mViewManipMode = value;
                foreach (MG_CS_BasicViewer Sibling in MG_CS_BasicViewer.Siblings)
                {
                    switch (mViewManipMode)
                    {
                        case ManipMode.PAN:
                            Sibling.Cursor = Cursors.SizeAll;
                            break;
                        case ManipMode.FENCE:
                            Sibling.Cursor = Cursors.Cross;
                            break;
                        case ManipMode.NONE:
                            Sibling.Cursor = Cursors.Default;
                            break;
                        case ManipMode.ROTATE:
                            Sibling.Cursor = Cursors.SizeNESW;
                            break;
                        case ManipMode.SELECTION:
                            Sibling.Cursor = Cursors.Hand;
                            break;
                        case ManipMode.ZOOM:
                            Sibling.Cursor = Cursors.SizeNS;
                            break;
                    }
                }
            }
        }

        private static float mAxisIndicatorScale = 1f;
        [Description("Sets or gets the scale if the axis indicator"), Category("Custom"), DefaultValue(1f)]
        public float AxisIndicatorScale
        {
            get { return mAxisIndicatorScale; }
            set { mAxisIndicatorScale = value; }
        }
        
        private static bool mDrawAxisLines = true;
        [Description("Draw axis lines"), Category("Custom"), DefaultValue(true)]
        public bool DrawAxisLines
        {
            get { return mDrawAxisLines; }
            set { mDrawAxisLines = value; }
        }

        private static bool mDrawAxisIndicator = true;
        [Description("Draw wcs XYZ indicator"), Category("Custom"), DefaultValue(true)]
        public bool DrawAxisIndicator
        {
            get { return mDrawAxisIndicator; }
            set { mDrawAxisIndicator = value; }
        }

        private static bool mDrawRapidLines = true;
        [Description("Draw raid tool motion lines"), Category("Custom"), DefaultValue(true)]
        public bool DrawRapidLines
        {
            get { return mDrawRapidLines; }
            set { mDrawRapidLines = value; }
        }

        private static bool mDrawRapidPoints = true;
        [Description("Draw raid tool motion points"), Category("Custom"), DefaultValue(true)]
        public bool DrawRapidPoints
        {
            get { return mDrawRapidPoints; }
            set { mDrawRapidPoints = value; }
        }

        private static Axis mArcAxis = Axis.Z;
        [Description("Sets or gets the plane that arcs will be drawn on"), Category("Custom"), DefaultValue(Axis.Z)]
        public Axis ArcAxis
        {
            get { return mArcAxis; }
            set { mArcAxis = value; }
        }
        private static RotaryMotionType mRotaryType = RotaryMotionType.CAD;
        [Description("Sets or gets the way that fourth axis motion is interpreted"), Category("Custom"), DefaultValue(RotaryMotionType.CAD)]
        public RotaryMotionType RotaryType
        {
            get { return mRotaryType; }
            set { mRotaryType = value; }
        }

        private static Axis mRotaryPlane = Axis.X;
        [Description("Sets or gets the plane that the fourth axis rotates on"), Category("Custom"), DefaultValue(Axis.X)]
        public Axis RotaryPlane
        {
            get { return mRotaryPlane; }
            set { mRotaryPlane = value; }
        }

        private static int mRotaryDirInt;
        private static RotaryDirection mRotaryDirection = MacGen.RotaryDirection.CW;
        [Description("Sets or gets the direction of the fourth axis"), Category("Custom"), DefaultValue(MacGen.RotaryDirection.CW)]
        public RotaryDirection RotaryDirection
        {
            get { return mRotaryDirection; }
            set { 
                mRotaryDirection = value;
                mRotaryDirInt = (int)value;
            }
        }

        private float mPitch = 0;
        [Description("Sets or gets the X axis rotation"), Category("Custom"), DefaultValue(0)]
        public float Pitch
        {
            get { return mPitch * (180 / PI_S); }
            set
            {
                mPitch = value * (PI_S / 180);
                CalcAngle();
            }
        }

        private float mRoll = 0;
        [Description("Sets or gets the Y axis rotation"), Category("Custom"), DefaultValue(0)]
        public float Roll
        {
            get { return mRoll * (180 / PI_S); }
            set
            {
                mRoll = value * (PI_S / 180);
                CalcAngle();
            }
        }

        private float mYaw = 0;
        [Description("Sets or gets the Z axis rotation"), Category("Custom"), DefaultValue(0)]
        public float Yaw
        {
            get { return mYaw * (180 / PI_S); }
            set
            {
                mYaw = value * (PI_S / 180);
                CalcAngle();
            }
        }

        private float mRotary = 0;
        [Description("Sets or gets the fourth axis position"), Category("Custom"), DefaultValue(0)]
        public float FourthAxis
        {
            get { return mRotary; }
            set
            {
                mRotary = value * (-mRotaryDirInt);
                CalcAngle();
            }
        }

        private float mSegAngle = ONE_RADIAN / 16;
        //angle of circular segments 
        [Description("Sets the quality of arcs. >=16 AND <=720"), Category("Custom"), DefaultValue(16)]
        public int ArcSegmentCount
        {
            set
            {
                //Set min and max values 
                if (value < 16) value = 16;
                if (value > 720) value = 720;
                mSegAngle = ONE_RADIAN / value;
            }
        }

        private static int mBreakPoint;
        [Browsable(false)]
        public int BreakPoint
        {
            get { return mBreakPoint; }
            set
            {
                if (value == 0)
                {
                    mBreakPoint = MotionBlocks.Count - 1;
                }
                else
                {
                    if (value > MotionBlocks.Count)
                    {
                        mBreakPoint = MotionBlocks.Count - 1;
                    }
                    else
                    {
                        mBreakPoint = value;
                    }
                }
            }
        }

        #endregion 
  
        private void CalcAngle()
        {
            mCosRot = (float)System.Math.Cos(mRotary);
            mSinRot = (float)System.Math.Sin(mRotary);
            mSinYaw = (float)System.Math.Sin(mYaw);
            mCosYaw = (float)System.Math.Cos(mYaw);
            mSinRoll = (float)System.Math.Sin(mRoll);
            mCosRoll = (float)System.Math.Cos(mRoll);
            mSinPitch = (float)System.Math.Sin(mPitch);
            mCosPitch = (float)System.Math.Cos(mPitch);
        }

        private void MG_BasicViewer_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Math.Sign(e.Delta) == -1)
            {
                ZoomScene(1.1f);
            }
            else
            {
                ZoomScene(0.9f);
            }
            CreateDisplayListsAndDraw();
        }

        private void MG_BasicViewer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Make a note that we "have the mouse". 
            mMouseDownAndMoving = true;
            switch (ViewManipMode)
            {
                case ManipMode.FENCE:
                case ManipMode.ROTATE:
                    break;
                //ClearDisplayList() 
                case ManipMode.SELECTION:
                    if (mSelectionHits.Count > 0)
                    {
                        if (OnSelection != null)
                        {
                            OnSelection(mSelectionHits);
                        }
                    }

                    break;
            }
            // Reset last. 
            mLastPt.X = -1;
            mLastPt.Y = -1;
            // Store the "starting point" for this rubber-band rectangle. 
            mMouseDownPt.X = e.X;
            mMouseDownPt.Y = e.Y;
        }

        private void MG_BasicViewer_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point ptCurrent = default(Point);
            ptCurrent.X = e.X;
            ptCurrent.Y = e.Y;
            //Set the real coordinates of the mouse. 
            //When the button whent down 
            mMousePtF[0].X = mMouseDownPt.X;
            mMousePtF[0].Y = mMouseDownPt.Y;
            //The current location 
            mMousePtF[1].X = e.X;
            mMousePtF[1].Y = e.Y;
            //The last location 
            mMousePtF[2].X = static_MG_BasicViewer_MouseMove_Xold;
            mMousePtF[2].Y = static_MG_BasicViewer_MouseMove_Yold;
            //Transform the points 
            mMtxFeedback.TransformPoints(mMousePtF);
            if (MouseLocation != null)
            {
                MouseLocation(mMousePtF[1].X, mMousePtF[1].Y);
            }

            switch (ViewManipMode)
            {
                case ManipMode.FENCE:
                    if ((mMouseDownAndMoving))
                    {
                        // Erase. 
                        if ((mLastPt.X != -1))
                        {
                            DrawWinMouseRect(mMouseDownPt, mLastPt);
                        }
                        // Draw new rectangle. 
                        DrawWinMouseRect(mMouseDownPt, ptCurrent);
                    }

                    break;
                case ManipMode.PAN:
                    if ((mMouseDownAndMoving))
                    {
                        if (mDynamicViewManipulation)
                        {
                            PanScene((mMousePtF[1].X - mMousePtF[2].X), mMousePtF[1].Y - mMousePtF[2].Y);
                            CreateDisplayListsAndDraw();
                        }
                        else
                        {
                            if ((mLastPt.X != -1))
                            {
                                DrawWinMouseLine(mMouseDownPt, mLastPt);
                            }
                            DrawWinMouseLine(mMouseDownPt, ptCurrent);
                        }
                    }

                    break;
                case ManipMode.ROTATE:
                    if (mMouseDownAndMoving)
                    {
                        Pitch += (int)(-Math.Sign(static_MG_BasicViewer_MouseMove_Yold - e.Y));
                        Roll += (int)(-Math.Sign(static_MG_BasicViewer_MouseMove_Xold - e.X));
                        if (mDynamicViewManipulation)
                        {
                            CreateDisplayListsAndDraw();
                        }
                        else
                        {
                            DrawWcsOnlyToBuffer();
                        }
                    }

                    break;
                case ManipMode.ZOOM:
                    if ((mMouseDownAndMoving))
                    {
                        float zFact = 0;
                        if (e.Y > mMouseDownPt.Y)
                        {
                            zFact = (float)(1 + ((e.Y - static_MG_BasicViewer_MouseMove_Yold) / this.Height));
                        }
                        else
                        {
                            zFact = 1 / (float)(1 + (Math.Abs(e.Y - static_MG_BasicViewer_MouseMove_Yold) / this.Height));
                        }
                        ZoomScene(zFact);
                        if (mDynamicViewManipulation)
                        {
                            CreateDisplayListsAndDraw();
                        }
                    }

                    break;
                case ManipMode.SELECTION:
                    //Get a small selection viewport for selection. 
                    mSelectionRect.X = mMousePtF[1].X - mPixelF * mSelectionPixRect.Width / 2f;
                    mSelectionRect.Y = mMousePtF[1].Y - mPixelF * mSelectionPixRect.Height / 2f;
                    mSelectionRect.Width = mPixelF * mSelectionPixRect.Width;
                    mSelectionRect.Height = mPixelF * mSelectionPixRect.Height;
                    GetSelectionHits(mSelectionRect);
                    DrawSelectionOverlay();
                    break;
            }
            // Update last point. 
            mLastPt = ptCurrent;
            static_MG_BasicViewer_MouseMove_Xold = e.X;
            static_MG_BasicViewer_MouseMove_Yold = e.Y;

        }
        static float static_MG_BasicViewer_MouseMove_Yold = 0;
        static float static_MG_BasicViewer_MouseMove_Xold = 0;

        private void MG_BasicViewer_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Set internal flag to know we no longer "have the mouse". 
            mMouseDownAndMoving = false;
            // Set flags to know that there is no "previous" line to reverse. 
            mLastPt.X = -1;
            mLastPt.Y = -1;
            if (mMouseDownPt.X == e.X | mMouseDownPt.Y == e.Y) return;
            switch (ViewManipMode)
            {
                case ManipMode.PAN:
                    if (!mDynamicViewManipulation)
                    {
                        PanScene((mMousePtF[1].X - mMousePtF[0].X), mMousePtF[1].Y - mMousePtF[0].Y);
                        CreateDisplayListsAndDraw();
                    }

                    break;
                case ManipMode.ROTATE:
                    if (!mDynamicViewManipulation)
                    {
                        CreateDisplayListsAndDraw();
                    }

                    break;
                case ManipMode.FENCE:
                    // If we have drawn previously, draw again in that spot to remove the lines. 
                    if (mMouseDownAndMoving & (mLastPt.X != -1))
                    {
                        DrawWinMouseRect(mMouseDownPt, mLastPt);
                    }

                    WindowViewport(mMousePtF[0].X, mMousePtF[0].Y, mMousePtF[1].X, mMousePtF[1].Y);
                    CreateDisplayListsAndDraw();
                    break;
                case ManipMode.ZOOM:
                    if (!mDynamicViewManipulation)
                    {
                        CreateDisplayListsAndDraw();
                    }

                    break;
            }

        }


        // Convert and Normalize the points and draw the reversible frame. 
        private void DrawWinMouseRect(Point p1, Point p2)
        {
            Rectangle rc = default(Rectangle);
            // Convert the points to screen coordinates. 
            p1 = PointToScreen(p1);
            p2 = PointToScreen(p2);
            // Normalize the rectangle. 
            if ((p1.X < p2.X))
            {
                rc.X = p1.X;
                rc.Width = p2.X - p1.X;
            }
            else
            {
                rc.X = p2.X;
                rc.Width = p1.X - p2.X;
            }
            if ((p1.Y < p2.Y))
            {
                rc.Y = p1.Y;
                rc.Height = p2.Y - p1.Y;
            }
            else
            {
                rc.Y = p2.Y;
                rc.Height = p1.Y - p2.Y;
            }
            // Draw the reversible frame. 
            ControlPaint.DrawReversibleFrame(rc, Color.White, FrameStyle.Dashed);
        }

        private void DrawWinMouseLine(Point p1, Point p2)
        {
            // Convert the points to screen coordinates. 
            p1 = PointToScreen(p1);
            p2 = PointToScreen(p2);
            // Draw the reversible line. 
            ControlPaint.DrawReversibleLine(p1, p2, Color.White);
        }

        public void ZoomScene(float zoomFactor)
        {
            if (Math.Abs(mViewRect.Width * zoomFactor) < 0.01)
            {
                return;
            }
            if (Math.Abs(mViewRect.Width * zoomFactor) > 1000)
            {
                return;
            }

            float newWid = mViewRect.Width * zoomFactor;
            float newHt = mViewRect.Height * zoomFactor;

            mViewRect.X += (mViewRect.Width - newWid) / 2;
            mViewRect.Y += (mViewRect.Height - newHt) / 2;
            mViewRect.Width = newWid;
            mViewRect.Height = newHt;
            SetViewMatrix();
        }

        private void PanScene(float deltaX, float deltaY)
        {
            mViewRect.X -= deltaX;
            mViewRect.Y -= deltaY;
            mViewportCenter.X -= deltaX;
            mViewportCenter.Y -= deltaY;
            SetViewMatrix();
        }

        public void WindowViewport(float X1, float Y1, float X2, float Y2)
        {
            float temp = 0;

            //convert window from right to left 
            if ((X1 > X2))
            {
                temp = X2;
                X2 = X1;
                X1 = temp;
            }

            //convert window from bottom to top 
            if ((Y1 > Y2))
            {
                temp = Y2;
                Y2 = Y1;
                Y1 = temp;
            }

            if (Math.Abs(X2 - X1) < 0.01)
            {
                return;
            }
            if (Math.Abs(Y2 - Y1) > 1000)
            {
                return;
            }

            mViewRect.X = X1;
            mViewRect.Y = Y1;
            mViewRect.Width = X2 - X1;
            mViewRect.Height = Y2 - Y1;
            AdjustAspect();
        }

        private void SetBufferContext()
        {
            if (mGfxBuff != null)
            {
                mGfxBuff.Dispose();
                mGfxBuff = null;
            }
            // Retrieves the BufferedGraphicsContext for the 
            // current application domain. 
            mContext = BufferedGraphicsManager.Current;

            // Sets the maximum size for the primary graphics buffer 
            mContext.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

            // Allocates a graphics buffer the size of this control 
            mGfxBuff = mContext.Allocate(CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
            mGfx = mGfxBuff.Graphics;

        }

        /// <summary> 
        /// Sets the matrix required to draw to the specified view 
        /// </summary> 
        private void SetViewMatrix()
        {
            if (float.IsInfinity(mViewRect.Width) | float.IsInfinity(mViewRect.Height)) return;
            if (mViewRect.Width == 0 | mViewRect.Height == 0) return;

            //The ratio between the actual size of the screen and the size of the graphics. 
            mScaleToReal = (mClientRect.Width / mGfx.DpiX) / mViewRect.Width;

            mMtxDraw.Reset();
            mMtxDraw.Scale(mScaleToReal, mScaleToReal);
            mMtxDraw.Translate(-mViewportCenter.X, mViewportCenter.Y);
            mMtxDraw.Translate((mViewRect.Width / 2f), (mViewRect.Height / 2f));
            mMtxDraw.Scale(1, -1);
            //Flip the Y 


            //The matrix for the triad is the same as the other geometry but without the scale 
            mMtxWCS.Reset();
            mMtxWCS.Multiply(mMtxDraw);
            mMtxWCS.Scale(1 / mScaleToReal, 1 / mScaleToReal);

            mPixelF = ((1 / mGfx.DpiX) / mScaleToReal);
            mBlipSize = (mPixelF * 3f);

            SetFeedbackMatrix();
        }

        /// <summary> 
        /// Adjusts the aspect of the view to match the window aspect 
        /// </summary> 
        private void AdjustAspect()
        {

            if (mGfx.DpiX == 0) return;
            if (float.IsInfinity(mViewRect.Width) | float.IsInfinity(mViewRect.Height)) return;

            mViewportCenter.X = mViewRect.X + (mViewRect.Width / 2);
            mViewportCenter.Y = mViewRect.Y + (mViewRect.Height / 2);

            //Square up the viewport 
            mLongside = Math.Max(mViewRect.Width, mViewRect.Height);
            mViewRect.Width = mLongside;
            mViewRect.Height = mLongside;

            float aspectRatio = (float)mClientRect.Width / mClientRect.Height;
            //Adjust the viewport aspect to match the screen aspect 
            //Wide or square screen 
            if (aspectRatio >= 1.0)
            {
                //left 
                mViewRect.X = mViewportCenter.X - (mLongside * aspectRatio * 0.5f);
                //width 
                mViewRect.Width = mLongside * aspectRatio;
                //top 
                mViewRect.Y = mViewportCenter.Y - (mLongside * 0.5f);
                //height 
                mViewRect.Height = mLongside;
            }
            //Tall screen 
            else
            {
                //Left 
                mViewRect.X = mViewportCenter.X - (mLongside * 0.5f);
                //width 
                mViewRect.Width = mLongside;
                //top 
                mViewRect.Y = mViewportCenter.Y - ((mLongside / aspectRatio) * 0.5f);
                //height 
                mViewRect.Height = (mLongside / aspectRatio);
            }
            SetViewMatrix();
        }

        private void SetFeedbackMatrix()
        {
            mMtxFeedback.Reset();
            mMtxFeedback.Scale(mGfx.DpiX, mGfx.DpiY);
            mMtxFeedback.Multiply(mMtxDraw);
            mMtxFeedback.Invert();
        }

        private void DrawListsToGraphics(ref Graphics g)
        {
            if (mGfxBuff == null) return;
            mCurPen.Width = -1;
            {
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.PageUnit = GraphicsUnit.Inch;
                g.ResetTransform();
                g.MultiplyTransform(mMtxWCS);
                //Draw the axis indicator and axis lines 
                foreach (clsDisplayList p in mWcsDisplayLists)
                {
                    if (p.Rapid)
                    {
                        mWCSPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        mWCSPen.DashPattern = mAxisDashStyle;
                    }
                    else
                    {
                        mWCSPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    }
                    mWCSPen.Color = p.Color;
                    g.DrawLines(mWCSPen, p.Points);
                }
                g.ResetTransform();

                //Now draw the toolpath 
                mRapidDashStyle[0] = 0.05f / mScaleToReal;
                mRapidDashStyle[1] = 0.05f / mScaleToReal;
                g.MultiplyTransform(mMtxDraw);
                foreach (clsDisplayList p in mDisplayLists)
                {
                    if (!p.InView)
                    {
                        continue;
                    }
                    if (p.Rapid)
                    {
                        mCurPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        mCurPen.DashPattern = mRapidDashStyle;
                    }
                    else
                    {
                        mCurPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    }
                    mCurPen.Color = p.Color;
                    LineFixUp(ref p.Points);
                    g.DrawLines(mCurPen, p.Points);
                }
            }
        }

        //I hate this! 
        //A problem exists where if the line is extended beyond the screen and it is at a sight angle 
        //then it will not display completly. 
        //This seems to fix the problem without too much extra processing. 
        private void LineFixUp(ref PointF[] pts)
        {
            if (pts.Length == 2)
            {
                if (Math.Sqrt((Math.Pow((pts[0].X - pts[1].X), 2)) + (Math.Pow((pts[0].Y - pts[1].Y), 2))) > this.mViewRect.Width)
                {
                    if (Math.Abs(pts[0].X - pts[1].X) < 0.001)
                    {
                        pts[0].X = (pts[0].X + pts[1].X) / 2;
                        pts[1].X = pts[0].X;
                        return;
                    }

                    if (Math.Abs(pts[0].Y - pts[1].Y) < 0.001)
                    {
                        pts[0].Y = (pts[0].Y + pts[1].Y) / 2;
                        pts[1].Y = pts[0].Y;
                        return;
                    }
                }
            }
        }

        private void DrawWcsOnlyToBuffer()
        {
            if (mGfxBuff == null) return;
            CreateWcs();
            {
                mGfx.Clear(this.BackColor);
                mGfx.PageUnit = GraphicsUnit.Inch;
                mGfx.ResetTransform();
                mGfx.MultiplyTransform(mMtxWCS);
                mGfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //Draw the axis indicator and axis lines 
                foreach (clsDisplayList p in mWcsDisplayLists)
                {
                    if (p.Rapid)
                    {
                        mWCSPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        mWCSPen.DashPattern = mAxisDashStyle;
                    }
                    else
                    {
                        mWCSPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    }
                    mWCSPen.Color = p.Color;
                    mGfx.DrawLines(mWCSPen, p.Points);
                }
            }
            mGfxBuff.Render();
        }

        private void DrawSelectionOverlay()
        {
            //Draw the buffer 
            if ((mGfxBuff != null))
            {
                mGfxBuff.Render();
            }

            //Draw the selection overlay. 
            mCurPen.Width = ((1 / mGfx.DpiX) / mScaleToReal) * 4;
            mCurPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PageUnit = GraphicsUnit.Inch;
                g.ResetTransform();
                g.MultiplyTransform(mMtxDraw);
                foreach (clsDisplayList p in mSelectionHitLists)
                {
                    mCurPen.Color = p.Color;
                    if (p.Rapid)
                    {
                        mCurPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    }
                    else
                    {
                        mCurPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    }
                    g.DrawLines(mCurPen, p.Points);
                }
            }

            mCurPen.EndCap = 0;
        }

        private void MG_BasicViewer_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if ((mGfxBuff != null))
            {
                mGfxBuff.Render();
            }
        }

        public void Init()
        {
            SetBufferContext();
            mClientRect = ClientRectangle;

            ArcSegmentCount = 16;
            WindowViewport(-2f, -2f, 2f, 2f);

            SetViewMatrix();
            DrawWcsOnlyToBuffer();
        }

        private void MG_BasicViewer_SizeChanged(object sender, System.EventArgs e)
        {
            Init();
        }

        #region "Graphics"
        private void PolyCircle(float Xctr, float Yctr, float Zctr, float Xe, float Xs, float Ye, float Ys, float Ze, float Zs, float r,
        float Startang,  float Endang, int ArcDir, Motion Wplane)
        {

            int s = 0;
            //counter 
            int sngSegments = 0;
            // number of angular segments 
            float helixSeg = 0;
            float sngAngle = 0;
            float sngTotalAngle = 0;

            sngTotalAngle = System.Math.Abs(Startang - Endang);
            sngSegments = (int)(sngTotalAngle / mSegAngle);
            //Re-calculate angle increment 
            sngAngle = (ArcDir * (sngTotalAngle / sngSegments));
            LineEnd4D(Xs, Ys, Zs);
            mPoints.Clear();
            switch (Wplane)
            {
                case Motion.XY_PLN:
                    helixSeg = (Ze - Zs) / sngSegments;
                    for (s = 1; s <= sngSegments; s++)
                    {
                        LineEnd4D((float)Xctr + (float)(r * System.Math.Cos((s * sngAngle) + Startang)), (float)Yctr + (float)(r * System.Math.Sin((s * sngAngle) + Startang)), Zs + helixSeg * s);
                    }

                    break;

                case Motion.XZ_PLN:
                    helixSeg = (Ye - Ys) / sngSegments;
                    for (s = 1; s <= sngSegments; s++)
                    {
                        LineEnd4D((float)Xctr + (float)(r * System.Math.Cos((s * sngAngle) + Startang)), Ys + helixSeg * s, (float)Zctr + (float)(r * System.Math.Sin((s * sngAngle) + Startang)));
                    }

                    break;

                case Motion.YZ_PLN:
                    helixSeg = (Xe - Xs) / sngSegments;
                    for (s = 1; s <= sngSegments; s++)
                    {
                        LineEnd4D(Xs + helixSeg * s, (float)Yctr + (float)(r * System.Math.Cos((s * sngAngle) + Startang)), (float)Zctr + (float)(r * System.Math.Sin((s * sngAngle) + Startang)));
                    }

                    break;

            }
            LineEnd4D(Xe, Ye, Ze);
        }

        private void RotaryCircle(float Xe, float Xs, float Ye, float Ys, float Ze, float Zs, float Startang, float Endang, float ArcDir)
        {
            int s = 0;
            //counter 
            int rotSegs = 0;
            // number of angular segments 
            float axisSeg1 = 0;
            float axisSeg3 = 0;
            float angle = 0;
            float totalAngle = 0;
            float radFromAxis = 0;

            //Like BMC 
            if (RotaryType == RotaryMotionType.BMC)
            {
                if (ArcDir == -1)
                {
                    Endang = (Endang - ONE_RADIAN);
                }
                else
                {
                    //take long way 
                    if (ArcDir == 1 & Endang < Startang)
                    {
                        Endang = ONE_RADIAN + Endang;
                    }
                }
            }
            totalAngle = (Endang - Startang);
            rotSegs = (int)System.Math.Abs(totalAngle / mSegAngle);

            switch (RotaryPlane)
            {
                case Axis.X:
                    //X 

                    Startang = (Startang + AngleFromPoint(Zs, Ys, false) * mRotaryDirInt) * mRotaryDirInt;
                    Endang = (Endang + AngleFromPoint(Zs, Ys, false) * mRotaryDirInt) * mRotaryDirInt;

                    //Re-calculate angle increment 
                    angle = (totalAngle / rotSegs) * mRotaryDirInt;
                    axisSeg1 = (Xe - Xs) / rotSegs;
                    axisSeg3 = (Ze - Zs) / rotSegs;

                    radFromAxis = VectorLength(0, Ys, Zs, 0, 0, 0);
                    LineEnd3D(Xs, (float)(radFromAxis * System.Math.Sin(Startang)), (float)(radFromAxis * System.Math.Cos(Startang)));
                    mPoints.Clear();
                    for (s = 1; s <= rotSegs; s++)
                    {
                        radFromAxis = VectorLength(0, Ys, Zs + (axisSeg3 * s), 0, 0, 0);
                        LineEnd3D(Xs + (axisSeg1 * s), (float)(radFromAxis * System.Math.Sin((s * angle) + Startang)), (float)((radFromAxis * System.Math.Cos((s * angle) + Startang))));
                    }

                    break;
                case Axis.Y:
                    Startang = (Startang - AngleFromPoint(Zs, Xs, false) * mRotaryDirInt) * -mRotaryDirInt;
                    Endang = (Endang - AngleFromPoint(Zs, Xs, false) * mRotaryDirInt) * -mRotaryDirInt;

                    //Re-calculate angle increment 
                    angle = (totalAngle / rotSegs) * -mRotaryDirInt;
                    axisSeg1 = (Ye - Ys) / rotSegs;
                    axisSeg3 = (Ze - Zs) / rotSegs;
                    //Debug.Print Segments 
                    radFromAxis = VectorLength(Xs, 0, Zs, 0, 0, 0);
                    LineEnd3D((float)(radFromAxis * System.Math.Sin(Startang)), Ys, (float)(radFromAxis * System.Math.Cos(Startang)));
                    mPoints.Clear();
                    for (s = 1; s <= rotSegs; s++)
                    {
                        radFromAxis = VectorLength(Xs, 0, Zs + (axisSeg3 * s), 0, 0, 0);
                        LineEnd3D((float)(radFromAxis * System.Math.Sin((s * angle) + Startang)), Ys + (axisSeg1 * s), (float)(radFromAxis * System.Math.Cos((s * angle) + Startang)));
                    }

                    break;
                case Axis.Z:
                    break;
                //Not implemented 
            }
            LineEnd4D(Xe, Ye, Ze);
        }

        private void Line3D(float Xs, float Ys, float Zs, float Xe, float Ye, float Ze)
        {
            float yawXs = 0;
            float yawYs = 0;
            float rollZs = 0;
            float yawXe = 0;
            float yawYe = 0;
            float rollZe = 0;
            float temp = 0;

            switch (RotaryPlane)
            {
                case Axis.X:
                    //x 
                    //X-axis start pre-rotate 
                    temp = (mCosRot * Ys) - (mSinRot * Zs);
                    Zs = (mSinRot * Ys) + (mCosRot * Zs);
                    Ys = temp;
                    //end pre-rotate 
                    temp = (mCosRot * Ye) - (mSinRot * Ze);
                    Ze = (mSinRot * Ye) + (mCosRot * Ze);
                    Ye = temp;
                    break;
                case Axis.Y:
                    //y 
                    //Y-axis start pre-rotate 
                    temp = (mCosRot * Zs) - (mSinRot * Xs);
                    Xs = (mCosRot * Xs) + (mSinRot * Zs);
                    Zs = temp;
                    //end 
                    temp = (mCosRot * Ze) - (mSinRot * Xe);
                    Xe = (mCosRot * Xe) + (mSinRot * Ze);
                    Ze = temp;
                    break;
                case Axis.Z:
                    //z 
                    //Z-axis start pre-rotate 
                    temp = (mCosRot * Xs) - (mSinRot * Ys);
                    Xs = (mSinRot * Xs) + (mCosRot * Ys);
                    Ys = temp;
                    //end pre-rotate 
                    temp = (mCosRot * Xe) - (mSinRot * Ye);
                    Xe = (mSinRot * Xe) + (mCosRot * Ye);
                    Ye = temp;
                    break;

            }

            //Start 
            //=========================== 
            //Z twist 
            yawXs = (mCosYaw * Xs) - (mSinYaw * Ys);
            yawYs = (mSinYaw * Xs) + (mCosYaw * Ys);

            //Y twist 
            rollZs = (mCosRoll * Zs) - (mSinRoll * yawXs);
            yawXs = (mCosRoll * yawXs) + (mSinRoll * Zs);
            //New X 

            //X twist 
            yawYs = (mCosPitch * yawYs) - (mSinPitch * rollZs);
            //New Y 

            //End 
            //=========================== 
            //Z twist 
            yawXe = (mCosYaw * Xe) - (mSinYaw * Ye);
            yawYe = (mSinYaw * Xe) + (mCosYaw * Ye);
            //Y twist 

            rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe);
            yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze);
            //New X 
            //X twist 
            yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe);
            //New Y 
            Line(yawXs, yawYs, yawXe, yawYe);
        }

        public static float VectorLength(float X1, float Y1, float Z1, float x2, float y2, float Z2)
        {
            return (float)System.Math.Sqrt((Math.Pow((X1 - x2), 2)) + (Math.Pow((Y1 - y2), 2)) + (Math.Pow((Z1 - Z2), 2)));
        }

        public static float AngleFromPoint(float x, float y, bool deg)
        {
            float theta = 0;
            // Quadrant 1 
            if (x > 0 & y > 0)
            {
                theta = (float)System.Math.Atan(y / x);
            }
            // Quadrant 2 
            else if (x < 0 & y > 0)
            {
                theta = (float)(System.Math.Atan(y / x) + Math.PI);
            }
            // Quadrant 3 
            else if (x < 0 & y < 0)
            {
                theta = (float)(System.Math.Atan(y / x) + Math.PI);
            }
            // Quadrant 4 
            else if (x > 0 & y < 0)
            {
                theta = (float)(System.Math.Atan(y / x) + 2 * Math.PI);
            }

            // Exceptions for points landing on an axis 
            //0 
            if (x > 0 & y == 0)
            {
                theta = 0;
            }
            //90 
            else if (x == 0 & y > 0)
            {
                theta = (float)Math.PI / 2;
            }
            //180 
            else if (x < 0 & y == 0)
            {
                theta = (float)Math.PI;
            }
            //270 
            else if (x == 0 & y < 0)
            {
                theta = (float)(3 * (Math.PI / 2));
            }

            // if you want the angle in degrees use this conversion 
            if (deg)
            {
                theta = (float)(theta * (180 / Math.PI));
            }
            return theta;

        }

        private void LineEnd4D(float Xe, float Ye, float Ze)
        {
            float yawXe = 0;
            float yawYe = 0;
            float rollZe = 0;
            float temp = 0;

            switch (RotaryPlane)
            {
                case Axis.X:
                    //x 
                    //X-axis start pre-rotate 
                    //end pre-rotate 
                    temp = (mCosRot * Ye) - (mSinRot * Ze);
                    Ze = (mSinRot * Ye) + (mCosRot * Ze);
                    Ye = temp;
                    break;
                case Axis.Y:
                    //y 
                    //Y-axis start pre-rotate 
                    //end 
                    temp = (mCosRot * Ze) - (mSinRot * Xe);
                    Xe = (mCosRot * Xe) + (mSinRot * Ze);
                    Ze = temp;
                    break;
                case Axis.Z:
                    //z 
                    //Z-axis start pre-rotate 
                    //end pre-rotate 
                    temp = (mCosRot * Xe) - (mSinRot * Ye);
                    Xe = (mSinRot * Xe) + (mCosRot * Ye);
                    Ye = temp;
                    break;
            }

            //End 
            //=========================== 
            //Z twist 
            yawXe = (mCosYaw * Xe) - (mSinYaw * Ye);
            yawYe = (mSinYaw * Xe) + (mCosYaw * Ye);
            //Y twist 
            rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe);
            yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze);
            //New X 
            //X twist 
            yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe);
            //New Y 
            LineEnd(yawXe, yawYe);

        }

        private void LineEnd3D(float Xe, float Ye, float Ze)
        {
            float yawXe = 0;
            float yawYe = 0;
            float rollZe = 0;
            //End 
            //=========================== 
            //Z twist 
            yawXe = (mCosYaw * Xe) - (mSinYaw * Ye);
            yawYe = (mSinYaw * Xe) + (mCosYaw * Ye);
            //Y twist 
            rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe);
            yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze);
            //New X 
            //X twist 
            yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe);
            //New Y 
            LineEnd(yawXe, yawYe);
        }

        private void DrawEachElmt()
        {
            float xleg = 0;
            float yleg = 0;
            float zleg = 0;
            int xdir = 0;
            int ydir = 0;
            int zdir = 0;
            float xleg1 = 0;
            float yleg1 = 0;
            float zleg1 = 0;
            float xleg2 = 0;
            float yleg2 = 0;
            float zleg2 = 0;

            //Create a display list using any existing points 
            if (MG_CS_BasicViewer.ToolLayers.ContainsKey(mCurGfxRec.Tool))
            {
                if (MG_CS_BasicViewer.ToolLayers[mCurGfxRec.Tool].Hidden)
                {
                    LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Zpos);
                    mPoints.Clear();
                    return;
                }
            }

            mCurColor = mCurGfxRec.DrawClr;
            mCurMotion = mCurGfxRec.MotionType;

            if (mCurGfxRec.Rotate)
            {
                this.FourthAxis = mCurGfxRec.NewRotaryPos;
                this.ArcSegmentCount = (int)((mCurGfxRec.Zpos / mLongside) * 90);
            }

            switch (mCurMotion)
            {
                case Motion.RAPID:
                    if (DrawRapidLines)
                    {
                        if (mCurGfxRec.Rotate)
                        {
                            RotaryCircle(mCurGfxRec.Xpos, mCurGfxRec.Xold, mCurGfxRec.Ypos, mCurGfxRec.Yold, mCurGfxRec.Zpos, mCurGfxRec.Zold, mCurGfxRec.OldRotaryPos, mCurGfxRec.NewRotaryPos, mCurGfxRec.RotaryDir);
                        }
                        else
                        {
                            xdir = System.Math.Sign(mCurGfxRec.Xpos - mCurGfxRec.Xold);
                            ydir = System.Math.Sign(mCurGfxRec.Ypos - mCurGfxRec.Yold);
                            zdir = System.Math.Sign(mCurGfxRec.Zpos - mCurGfxRec.Zold);

                            xleg = System.Math.Abs(mCurGfxRec.Xpos - mCurGfxRec.Xold);
                            yleg = System.Math.Abs(mCurGfxRec.Ypos - mCurGfxRec.Yold);
                            zleg = System.Math.Abs(mCurGfxRec.Zpos - mCurGfxRec.Zold);

                            if (xleg <= yleg & yleg <= zleg)
                            {
                                xleg1 = mCurGfxRec.Xpos;
                                yleg1 = mCurGfxRec.Yold + xleg * ydir;
                                zleg1 = mCurGfxRec.Zold + xleg * zdir;
                                xleg2 = mCurGfxRec.Xpos;
                                yleg2 = mCurGfxRec.Ypos;
                                zleg2 = mCurGfxRec.Zold + yleg * zdir;
                            }
                            else if (xleg <= zleg & zleg <= yleg)
                            {
                                xleg1 = mCurGfxRec.Xpos;
                                yleg1 = mCurGfxRec.Yold + xleg * ydir;
                                zleg1 = mCurGfxRec.Zold + xleg * zdir;
                                xleg2 = mCurGfxRec.Xpos;
                                yleg2 = mCurGfxRec.Yold + zleg * ydir;
                                zleg2 = mCurGfxRec.Zpos;
                            }
                            else if (zleg <= yleg & yleg <= xleg)
                            {
                                xleg1 = mCurGfxRec.Xold + zleg * xdir;
                                yleg1 = mCurGfxRec.Yold + zleg * ydir;
                                zleg1 = mCurGfxRec.Zpos;
                                xleg2 = mCurGfxRec.Xold + yleg * xdir;
                                yleg2 = mCurGfxRec.Ypos;
                                zleg2 = mCurGfxRec.Zpos;
                            }
                            else if (zleg <= xleg & xleg <= yleg)
                            {
                                xleg1 = mCurGfxRec.Xold + zleg * xdir;
                                yleg1 = mCurGfxRec.Yold + zleg * ydir;
                                zleg1 = mCurGfxRec.Zpos;
                                xleg2 = mCurGfxRec.Xpos;
                                yleg2 = mCurGfxRec.Yold + xleg * ydir;
                                zleg2 = mCurGfxRec.Zpos;
                            }
                            else if (yleg <= zleg & zleg <= xleg)
                            {
                                xleg1 = mCurGfxRec.Xold + yleg * xdir;
                                yleg1 = mCurGfxRec.Ypos;
                                zleg1 = mCurGfxRec.Zold + yleg * zdir;
                                xleg2 = mCurGfxRec.Xold + zleg * xdir;
                                yleg2 = mCurGfxRec.Ypos;
                                zleg2 = mCurGfxRec.Zpos;
                            }
                            else if (yleg <= xleg & xleg <= zleg)
                            {
                                xleg1 = mCurGfxRec.Xold + yleg * xdir;
                                yleg1 = mCurGfxRec.Ypos;
                                zleg1 = mCurGfxRec.Zold + yleg * zdir;
                                xleg2 = mCurGfxRec.Xpos;
                                yleg2 = mCurGfxRec.Ypos;
                                zleg2 = mCurGfxRec.Zold + xleg * zdir;
                            }
                            LineEnd3D(xleg1, yleg1, zleg1);
                            LineEnd4D(xleg2, yleg2, zleg2);
                            LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Zpos);
                        }
                    }

                    CreateDisplayList(true);
                    //Draw any existing lines 
                    //Draw a rapid blip if required 
                    if (DrawRapidPoints)
                    {
                        //Set the last point 
                        LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Zpos);
                        mPoints.Clear();
                        //mCurMotion = Motion.LINE 
                        DrawBlip(mLastPos);
                        CreateDisplayList(false);
                        mCurMotion = mCurGfxRec.MotionType;
                    }

                    break;

                case Motion.HOLE_I:
                case Motion.HOLE_R:
                    if (DrawRapidLines)
                    {

                        //The direction 
                        xdir = System.Math.Sign(mCurGfxRec.Xpos - mCurGfxRec.Xold);
                        ydir = System.Math.Sign(mCurGfxRec.Ypos - mCurGfxRec.Yold);

                        xleg = System.Math.Abs(mCurGfxRec.Xpos - mCurGfxRec.Xold);
                        yleg = System.Math.Abs(mCurGfxRec.Ypos - mCurGfxRec.Yold);

                        //A rotary move is on the drill cycle line 
                        if (mCurGfxRec.Rotate)
                        {
                            //Return to inital Z 
                            if (mCurGfxRec.MotionType == Motion.HOLE_I)
                            {
                                RotaryCircle(mCurGfxRec.Xpos, mCurGfxRec.Xold, mCurGfxRec.Ypos, mCurGfxRec.Yold, mCurGfxRec.DrillClear, mCurGfxRec.DrillClear, mCurGfxRec.OldRotaryPos, mCurGfxRec.NewRotaryPos, mCurGfxRec.RotaryDir);
                            }

                            else
                            {
                                RotaryCircle(mCurGfxRec.Xpos, mCurGfxRec.Xold, mCurGfxRec.Ypos, mCurGfxRec.Yold, mCurGfxRec.Rpoint, mCurGfxRec.Rpoint, mCurGfxRec.OldRotaryPos, mCurGfxRec.NewRotaryPos, mCurGfxRec.RotaryDir);
                            }
                            LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Rpoint);
                        }
                        else
                        {

                            if (xleg <= yleg)
                            {
                                //The first end point 
                                //Move in the direction of each axis by the length of the shortest axis 
                                xleg1 = mCurGfxRec.Xold + xleg * xdir;
                                yleg1 = mCurGfxRec.Yold + xleg * ydir;
                            }

                            if (xleg >= yleg)
                            {
                                //The first end point 
                                //Move in the direction of each axis by the length of the shortest axis 
                                xleg1 = mCurGfxRec.Xold + yleg * xdir;
                                yleg1 = mCurGfxRec.Yold + yleg * ydir;
                            }
                            //Dog-leg hole positioning 
                            //Return to inital Z 
                            if (mCurGfxRec.MotionType == Motion.HOLE_I)
                            {
                                //Dog-leg 
                                Line3D(mCurGfxRec.Xold, mCurGfxRec.Yold, mCurGfxRec.DrillClear, xleg1, yleg1, mCurGfxRec.DrillClear);
                                LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.DrillClear);
                                LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Rpoint);
                            }
                            else
                            {
                                Line3D(mCurGfxRec.Xold, mCurGfxRec.Yold, mCurGfxRec.Zold, mCurGfxRec.Xold, mCurGfxRec.Yold, mCurGfxRec.Rpoint);
                                LineEnd4D(xleg1, yleg1, mCurGfxRec.Rpoint);
                                LineEnd4D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Rpoint);
                            }
                        }
                    }


                    CreateDisplayList(true);
                    //Draw any existing lines 
                    //Draw the hole line 
                    Line3D(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Rpoint, mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Zpos);

                    //Draw a small circle 
                    if (DrawRapidPoints)
                    {
                        CreateDisplayList(false);
                        //Draw any existing lines 
                        ArcSegmentCount = 8;
                        PolyCircle(mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Zpos, mCurGfxRec.Xpos + mBlipSize, mCurGfxRec.Xpos + mBlipSize, mCurGfxRec.Ypos, mCurGfxRec.Ypos, mCurGfxRec.Zpos, mCurGfxRec.Zpos, mBlipSize,0.0f, ONE_RADIAN, (int)-1,MacGen.Motion.CCARC);
                    }

                    break;

                case Motion.LINE:
                    if (mCurGfxRec.Rotate)
                    {
                        RotaryCircle(mCurGfxRec.Xpos, mCurGfxRec.Xold, mCurGfxRec.Ypos, mCurGfxRec.Yold, mCurGfxRec.Zpos, mCurGfxRec.Zold, mCurGfxRec.OldRotaryPos, mCurGfxRec.NewRotaryPos, mCurGfxRec.RotaryDir);
                    }
                    else
                    {
                        Line3D(mCurGfxRec.Xold, mCurGfxRec.Yold, mCurGfxRec.Zold, mCurGfxRec.Xpos, mCurGfxRec.Ypos, mCurGfxRec.Zpos);
                    }

                    break;
                case Motion.CCARC:
                    ArcSegmentCount = (int)((mCurGfxRec.Rad / mLongside) * 360);
                    PolyCircle(mCurGfxRec.Xcentr, mCurGfxRec.Ycentr, mCurGfxRec.Zcentr, mCurGfxRec.Xpos, mCurGfxRec.Xold, mCurGfxRec.Ypos, mCurGfxRec.Yold, mCurGfxRec.Zpos, mCurGfxRec.Zold, mCurGfxRec.Rad,
                    mCurGfxRec.Sang, mCurGfxRec.Eang, 1,(Motion)mCurGfxRec.WrkPlane);
                    break;
                case Motion.CWARC:
                    ArcSegmentCount = (int)((mCurGfxRec.Rad / mLongside) * 360);
                    PolyCircle(mCurGfxRec.Xcentr, mCurGfxRec.Ycentr, mCurGfxRec.Zcentr, mCurGfxRec.Xpos, mCurGfxRec.Xold, mCurGfxRec.Ypos, mCurGfxRec.Yold, mCurGfxRec.Zpos, mCurGfxRec.Zold, mCurGfxRec.Rad,
                    mCurGfxRec.Sang, mCurGfxRec.Eang, -1, (Motion)mCurGfxRec.WrkPlane);
                    break;
            }
            CreateDisplayList(false);
        }

        //Draw un-rotated rectangle as a rapid point indication. 
        private void DrawBlip(PointF p)
        {
            mPoints.Clear();
            Line(p.X - mBlipSize, p.Y - mBlipSize, p.X + mBlipSize, p.Y - mBlipSize);
            LineEnd(p.X + mBlipSize, p.Y + mBlipSize);
            LineEnd(p.X - mBlipSize, p.Y + mBlipSize);
            LineEnd(p.X - mBlipSize, p.Y - mBlipSize);
        }

        public void Redraw(bool allSiblings)
        {
            if (allSiblings)
            {
                foreach (MG_CS_BasicViewer sib in MG_CS_BasicViewer.Siblings)
                {
                    if (sib.ParentForm.Name == this.ParentForm.Name)
                    {
                        sib.CreateDisplayListsAndDraw();
                    }
                }
            }
            else
            {
                CreateDisplayListsAndDraw();
            }
        }

        public void FindExtents()
        {
            if (!Visible) return;
            if (MotionBlocks.Count == 0) return;

            mExtentX[0] = float.MaxValue;
            mExtentX[1] = float.MinValue;
            mExtentY[0] = float.MaxValue;
            mExtentY[1] = float.MinValue;

            bool drawRapidPointsStatus = DrawRapidPoints;
            DrawRapidPoints = false;
            //Disable rapid points for speed 
            CreateDisplayLists();
            DrawRapidPoints = drawRapidPointsStatus;
            if (MotionBlocks.Count > 0)
            {
                foreach (clsDisplayList l in mDisplayLists)
                {
                    foreach (PointF p in l.Points)
                    {
                        mExtentX[0] = Math.Min(mExtentX[0], p.X);
                        mExtentX[1] = Math.Max(mExtentX[1], p.X);
                        mExtentY[0] = Math.Min(mExtentY[0], p.Y);
                        mExtentY[1] = Math.Max(mExtentY[1], p.Y);
                    }
                }
            }
            else
            {
                mExtentX[0] = -1f;
                mExtentX[1] = 1f;
                mExtentY[0] = -1f;
                mExtentY[1] = 1f;
            }

            mViewRect.X = mExtentX[0];
            mViewRect.Width = mExtentX[1] - mExtentX[0];
            mViewRect.Y = mExtentY[0];
            mViewRect.Height = mExtentY[1] - mExtentY[0];
            if (float.IsNegativeInfinity(mViewRect.Width)) return;
            if (float.IsNegativeInfinity(mViewRect.Height)) return;
            mViewRect.Inflate(mViewRect.Width * 0.01f, mViewRect.Height * 0.01f);

            AdjustAspect();
            CreateDisplayListsAndDraw();
        }

        private void CreateDisplayLists()
        {
            mDisplayLists.Clear();
            mPoints.Clear();

            mLastPos.X = 0;
            mLastPos.Y = 0;
            
            if( mBreakPoint > MotionBlocks.Count-1)
            	mBreakPoint = MotionBlocks.Count-1;	
            
            for (mGfxIndex = 0; mGfxIndex <= mBreakPoint; mGfxIndex++)
            {
                mCurGfxRec = MotionBlocks[mGfxIndex];
                DrawEachElmt();
                //Draws geometry 
            }
        }

        private void DrawDisplayLists()
        {
            CreateWcs();
            SetInViewStatus(this.mViewRect);
            mGfx.Clear(this.BackColor);
            DrawListsToGraphics(ref mGfx);
            mGfxBuff.Render();
        }

        private void CreateDisplayListsAndDraw()
        {
            CreateDisplayLists();
            DrawDisplayLists();
        }

        private void CreateWcs()
        {
            if (!Visible) return;

            mWcsDisplayLists.Clear();
            mPoints.Clear();
            FourthAxis = 0;
            if (DrawAxisLines)
            {
                mCurMotion = Motion.RAPID;
                //Y axis line 
                Line3D(0, 0, 0, 0, -mLongside * 10, 0);
                this.CreateWcsPath(Color.Gray);
                Line3D(0, 0, 0, 0, mLongside * 10, 0);
                this.CreateWcsPath(Color.Gray);

                //X axis line 
                Line3D(0, 0, 0, mLongside * 10, 0, 0);
                this.CreateWcsPath(Color.Gray);
                Line3D(0, 0, 0, -mLongside * 10, 0, 0);
                this.CreateWcsPath(Color.Gray);

                //Z Axis line 
                Line3D(0, 0, 0, 0, 0, mLongside * 10);
                this.CreateWcsPath(Color.Gray);
                Line3D(0, 0, 0, 0, 0, -mLongside * 10);
                this.CreateWcsPath(Color.Gray);
            }

            if (DrawAxisIndicator)
            {
                //Axis indicators 
                mCurMotion = Motion.LINE;
                //X indicator 
                Line3D(0f, 0f, 0f, 1f, 0f, 0f);
                Line3D(1f, 0f, 0f, 0.9f, 0.05f, 0f);
                Line3D(1f, 0f, 0f, 0.9f, -0.05f, 0f);
                CreateWcsPath(Color.DarkKhaki);
                //Draw the letter X 
                Line3D(0.7f, 0.1f, 0f, 0.9f, 0.4f, 0f);
                CreateWcsPath(Color.DarkKhaki);
                Line3D(0.9f, 0.1f, 0f, 0.7f, 0.4f, 0f);
                CreateWcsPath(Color.DarkKhaki);

                //Y indicator 
                Line3D(0f, 0f, 0f, 0f, 1f, 0f);
                CreateWcsPath(Color.DarkGreen);
                Line3D(0f, 1f, 0f, -0.05f, 0.9f, 0f);
                CreateWcsPath(Color.DarkGreen);
                Line3D(0, 1f, 0f, 0.05f, 0.9f, 0f);
                CreateWcsPath(Color.DarkGreen);
                //Draw the letter Y 
                Line3D(-0.2f, 0.7f, 0f, -0.2f, 0.85f, 0f);
                CreateWcsPath(Color.DarkGreen);
                Line3D(-0.2f, 0.85f, 0f, -0.3f, 1f, 0f);
                CreateWcsPath(Color.DarkGreen);
                Line3D(-0.2f, 0.85f, 0f, -0.1f, 1f, 0f);
                CreateWcsPath(Color.DarkGreen);

                //Z indicator 
                Line3D(0f, 0f, 0f, 0f, 0f, 1f);
                Line3D(0f, 0f, 1f, 0.1f, 0f, 0.8f);
                CreateWcsPath(Color.DarkRed);

                PolyCircle(0f, 0f, 0f, 0.1f, 0.1f, 0f, 0f, 0.8f, 0.8f, 0.1f,0f, ONE_RADIAN, 1, Motion.XY_PLN);
                CreateWcsPath(Color.DarkRed);

                //Draw the letter Z 
                Line3D(-0.2f, 0f, 0.7f, -0.4f, 0f, 0.7f);
                Line3D(-0.2f, 0f, 0.95f, -0.4f, 0f, 0.95f);
                Line3D(-0.2f, 0f, 0.95f, -0.4f, 0f, 0.7f);
                CreateWcsPath(Color.DarkRed);
            }
        }

        public void GatherTools()
        {
            float lastTool = 0;
            ToolLayers.Clear();
            foreach (clsMotionRecord blk in MotionBlocks)
            {
                if (lastTool != blk.Tool)
                {
                    lastTool = blk.Tool;
                    if (!ToolLayers.ContainsKey(blk.Tool))
                    {
                        ToolLayers.Add(blk.Tool, new clsToolLayer(blk.Tool, blk.DrawClr));
                    }
                }
            }
        }

        //Returns the number of hits inside the referenced rectangle. 
        private void GetSelectionHits(RectangleF rect)
        {
            int maxHits = 0;
            clsCadRect cadRect = new clsCadRect(rect.X, rect.Y, rect.Width, rect.Height);
            mSelectionHits.Clear();
            mSelectionHitLists.Clear();
            if (MotionBlocks.Count > 0)
            {
                foreach (clsDisplayList l in mDisplayLists)
                {
                    if (l.InView)
                    {
                        //Iterate in sets of 2 
                        for (int r = 0; r <= l.Points.Length - 2; r++)
                        {
                            if (maxHits >= INT_MAXHITS) return;
                            if (cadRect.IntersectsLine(l.Points[r], l.Points[r + 1]))
                            {
                                mSelectionHits.Add(MotionBlocks[l.ParentIndex]);
                                mSelectionHitLists.Add(l);
                                maxHits += 1;
                                break; // TODO: might not be correct. Was : Exit For 
                            }
                        }
                    }
                }
            }
        }

        private void SetInViewStatus(RectangleF rect)
        {
            clsCadRect cadRect = new clsCadRect(rect.X, rect.Y, rect.Width, rect.Height);
            foreach (clsDisplayList l in mDisplayLists)
            {
                //Iterate in sets of 2 
                for (int r = 0; r <= l.Points.Length - 2; r++)
                {
                    l.InView = false;
                    if (cadRect.IntersectsLine(l.Points[r], l.Points[r + 1]))
                    {
                        l.InView = true;
                        break; 
                    }
                }
            }
        }


        private void ClearDisplayList()
        {
            mDisplayLists.Clear();
            mPoints.Clear();
        }

        private void CreateDisplayList(bool rapid)
        {
            clsDisplayList p = new clsDisplayList();
            if ((mPoints.Count < 2)) return;
            {
                p.Color = mCurColor;
                p.Rapid = rapid;
                p.ParentIndex = mGfxIndex;
                p.Points = mPoints.ToArray();
            }
            mDisplayLists.Add(p);
            mPoints.Clear();
        }

        //Axis lines 
        private void CreateWcsPath(Color clr)
        {
            clsDisplayList p = new clsDisplayList();
            if ((mPoints.Count < 2)) return;
            {
                p.Color = clr;
                p.Rapid = (mCurMotion == Motion.RAPID);
                p.Points = mPoints.ToArray();
            }
            mWcsDisplayLists.Add(p);
            mPoints.Clear();
        }

        private void LineEnd(float x2, float y2)
        {
            if (mLastPos.X != x2 & mLastPos.Y != y2)
            {
                mPoints.Add(mLastPos);
            }
            mPoints.Add(new PointF(x2, y2));
            mLastPos.X = x2;
            mLastPos.Y = y2;
        }

        private void Line(float x1, float y1, float x2, float y2)
        {
            mPoints.Add(new PointF(x1, y1));
            mPoints.Add(new PointF(x2, y2));
            mLastPos.X = x2;
            mLastPos.Y = y2;
        }

        #endregion

        private void MG_BasicViewer_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible == false)
            {
                //Reclaim a little memory 
                this.mDisplayLists.Clear();
            }
        }

        private void MG_CS_BasicViewer_SizeChanged(object sender, EventArgs e)
        {
            this.Init();
        } 
    }
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace EmrColorComboBox
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	/// 


	public class ColorComboBox : System.Windows.Forms.ComboBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public ColorComboBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ColorComboBox
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
			this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Size = new System.Drawing.Size(120, 24);
			this.EnabledChanged += new System.EventHandler(this.ColorComboBox_EnabledChanged);
			this.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
			this.MouseEnter += new System.EventHandler(this.ColorComboBox_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.ColorComboBox_MouseLeave);
			this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorComboBox_DrawItem);

		}
		#endregion



		[Browsable(false)]
		[Category("Property")]			
		public Color SelectedColor
		{
			get  
			{ 
				return this.resultCol;
			}
			set 
			{
				this.resultCol = value;
				int i=0;
				for (i=0;i<this.Items.Count-1;i++)
				{
					if(i>=141) break;
					if(c[i].Name == this.resultCol.Name)
					{
						this.SelectedIndex = i;
						break;
					}
				}
				if(i==141)
				{					
					this.colDlg = false;
					this.otherCol = value;
					if(this.SelectedIndex!=i) this.SelectedIndex = i;
					else this.ColorComboBox_SelectedIndexChanged(this,null);
				}			
			}
		}


		[Browsable(true)]
		[DefaultValue(1)]
		[Category("Property")]
		[Description("The color of control when the appearance set to Skinned.")]
		public Color ControlColor
		{
			get  
			{ 
				return this.cColor;
			}
			set 
			{				
				if(this.Enabled)
					this.cColor = value;
				else
					this.cColor = SystemColors.ControlDark;

				this.bColor = value;
				this.Refresh();
			}
		}


		[Browsable(true)]
		[Category("Property")]
		[Description("Determines if the control display skinned or standard.")]
		public ControlView Appearance
		{
			get  
			{ 
				return this.app;
			}
			set 
			{				
				this.app = value;
				this.Refresh();
			}
		}


		[Browsable(true)]
		[Category("Property")]
		[Description("A VS.Net(C#) dll control by Amir Yousefi (ampiroid@hotmail.com).")]
		public string About
		{
			get
			{
                return "A VS.Net(C#) dll control by Amir Yousefi (ampiroid@hotmail.com).";
			}
		}



		public enum ControlView: int 
		{
			Standard = 0,
			Skinned = 1,
		} 


		
		private bool colDlg = true;
		private ControlView app = ControlView.Skinned;
		private Color otherCol = Color.White;
		private Color resultCol = Color.White;
		private Color cColor = SystemColors.ActiveCaption;
		private Color bColor = SystemColors.ActiveCaption;
		private Color[] c = new Color[141]
		{	
			#region Colors
			Color.Black,
			Color.DimGray,
			Color.Gray,
			Color.DarkGray,
			Color.Silver,
			Color.LightGray,
			Color.Gainsboro,
			Color.WhiteSmoke,
			Color.White,
			Color.Transparent,
			Color.Snow,
			Color.RosyBrown,
			Color.Red,
			Color.Maroon,
			Color.LightCoral,
			Color.IndianRed,
			Color.Firebrick,
			Color.DarkRed,
			Color.Brown,
			Color.MistyRose,
			Color.Salmon,
			Color.Tomato,
			Color.DarkSalmon,
			Color.Coral,
			Color.OrangeRed,
			Color.LightSalmon,
			Color.Sienna,
			Color.SeaShell,
			Color.SaddleBrown,
			Color.Chocolate,
			Color.SandyBrown,
			Color.PeachPuff,
			Color.Peru,
			Color.Linen,
			Color.Bisque,
			Color.DarkOrange,
			Color.BurlyWood,
			Color.Tan,
			Color.AntiqueWhite,
			Color.NavajoWhite,
			Color.BlanchedAlmond,
			Color.PapayaWhip,
			Color.Moccasin,
			Color.Orange,
			Color.Wheat,
			Color.OldLace,
			Color.FloralWhite,
			Color.DarkGoldenrod,
			Color.Goldenrod,
			Color.Cornsilk,
			Color.Gold,
			Color.LemonChiffon,
			Color.Khaki,
			Color.PaleGoldenrod,
			Color.DarkKhaki,
			Color.Yellow,
			Color.Olive,
			Color.LightYellow,
			Color.Beige,
			Color.LightGoldenrodYellow,
			Color.Ivory,
			Color.Violet,
			Color.Thistle,
			Color.Purple,
			Color.Plum,
			Color.Magenta,
			Color.Fuchsia,
			Color.DarkMagenta,
			Color.Orchid,
			Color.MediumVioletRed,
			Color.DeepPink,
			Color.HotPink,
			Color.LavenderBlush,
			Color.PaleVioletRed,
			Color.Crimson,
			Color.Pink,
			Color.LightPink,
			Color.OliveDrab,
			Color.YellowGreen,
			Color.DarkOliveGreen,
			Color.GreenYellow,
			Color.Chartreuse,
			Color.LawnGreen,
			Color.DarkSeaGreen,
			Color.Lime,
			Color.LightGreen,
			Color.PaleGreen,
			Color.Honeydew,
			Color.Green,
			Color.ForestGreen,
			Color.DarkGreen,
			Color.LimeGreen,
			Color.SeaGreen,
			Color.MediumSeaGreen,
			Color.SpringGreen,
			Color.MintCream,
			Color.MediumSpringGreen,
			Color.MediumAquamarine,
			Color.Aquamarine,
			Color.Turquoise,
			Color.LightSeaGreen,
			Color.MediumTurquoise,
			Color.Aqua,
			Color.Teal,
			Color.LightCyan,
			Color.DarkSlateGray,
			Color.DarkCyan,
			Color.Cyan,
			Color.PaleTurquoise,
			Color.Azure,
			Color.DarkTurquoise,
			Color.CadetBlue,
			Color.PowderBlue,
			Color.LightBlue,
			Color.DeepSkyBlue,
			Color.SkyBlue,
			Color.LightSkyBlue,
			Color.SteelBlue,
			Color.AliceBlue,
			Color.DodgerBlue,
			Color.LightSlateGray,
			Color.SlateGray,
			Color.LightSteelBlue,
			Color.CornflowerBlue,
			Color.RoyalBlue,
			Color.DarkBlue,
			Color.Blue,
			Color.Navy,
			Color.GhostWhite,
			Color.MidnightBlue,
			Color.MediumBlue,
			Color.Lavender,
			Color.SlateBlue,
			Color.DarkSlateBlue,
			Color.MediumSlateBlue,
			Color.MediumPurple,
			Color.BlueViolet,
			Color.Indigo,
			Color.DarkOrchid,
			Color.DarkViolet,
			Color.MediumOrchid,
			#endregion
		};

		private void DrawCombo(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			
			Graphics g = e.Graphics;
			Rectangle rd = e.Bounds;			
			
			int rr = this.cColor.R;
			int gg = this.cColor.G;
			int bb = this.cColor.B;
			Color cll = Color.White;
			Color cl = Color.FromArgb(rr+(255-rr)*2/3,gg+(255-gg)*2/3,bb+(255-bb)*2/3);
			Color cc = Color.FromArgb(rr+(255-rr)*1/3,gg+(255-gg)*1/3,bb+(255-bb)*1/3);
			Color cd = Color.FromArgb(rr,gg,bb);
			Color cdd = Color.FromArgb(rr*2/3,gg*2/3,bb*2/3);
			
			LinearGradientBrush br = new LinearGradientBrush(new Rectangle(e.Bounds.Left-1,e.Bounds.Top-1,e.Bounds.Width+4,e.Bounds.Height+4),cd,cll,65f); 

			if ( e.Index >= 0 ) 
			{
				//				Console.WriteLine(e.State.ToString());
				if ( e.State == ( DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.White) , rd);
					e.DrawFocusRectangle();
				}
				else
				{
					if(this.app == ControlView.Skinned)
					{
						e.Graphics.FillRectangle(br , rd);
						br = new LinearGradientBrush(e.Bounds,cc,cll,65f); 
						rd.Width=e.Bounds.Width-2;
						rd.Height=e.Bounds.Height-2;
						rd.X=e.Bounds.X+1;
						rd.Y=e.Bounds.Y+1;
						e.Graphics.FillRectangle(br , rd);
						e.DrawFocusRectangle();
					}
					else
					{
						e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight) , rd);
						e.DrawFocusRectangle();
					}
				}
			}			

			rd.Width = 20;
			rd.Height = this.ItemHeight-5;
			rd.X = 4;
			rd.Y += 1;

			if (e.Index >= 0 && e.Index<141 ) 
			{
				g.FillRectangle(new SolidBrush(c[e.Index]),rd);
				g.DrawRectangle(new Pen(Color.Black),rd);
				if(e.State == ( DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || this.app == ControlView.Skinned)
					g.DrawString(c[e.Index].Name,this.Font,new SolidBrush(Color.Black),rd.Width+5,rd.Top-1);
				else
					g.DrawString(c[e.Index].Name,this.Font,new SolidBrush(SystemColors.HighlightText),rd.Width+5,rd.Top-1);
			}
			else if (e.Index == 141) 
			{
				g.FillRectangle(new SolidBrush(otherCol),rd);
				g.DrawRectangle(new Pen(Color.Black),rd);
				if(e.State == ( DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || this.app == ControlView.Skinned)
					g.DrawString("Other",this.Font,new SolidBrush(Color.Black),rd.Width+5,rd.Top-1);
				else
					g.DrawString("Other",this.Font,new SolidBrush(SystemColors.HighlightText),rd.Width+5,rd.Top-1);
			}
			if(this.app == ControlView.Skinned)
			{
				Graphics gr = this.CreateGraphics();
				gr.DrawRectangle(new Pen(cd),0,0,this.Width-1,this.Height-1);
				gr.DrawRectangle(new Pen(cl),1,1,this.Width-3,this.Height-3);
				gr.FillRectangle(new SolidBrush(cll),this.Width-this.Height+1,2,this.Height-3,this.Height-4);

				br = new LinearGradientBrush(new Rectangle(this.Width-this.Height+1,2,this.Height,this.Height),cl,cd,45f); 
				gr.FillRectangle(br,this.Width-this.Height+2,3,this.Height-5,this.Height-6);

				br = new LinearGradientBrush(new Rectangle(this.Width-this.Height+1,2,this.Height,this.Height),cll,cc,45f); 
				gr.FillRectangle(br,this.Width-this.Height+3,4,this.Height-7,this.Height-8);

				gr.FillRectangle(new SolidBrush(cll),this.Width-this.Height+2,3,1,1);
				gr.FillRectangle(new SolidBrush(cll),this.Width-this.Height+2,3+this.Height-7,1,1);
				gr.FillRectangle(new SolidBrush(cll),this.Width-this.Height+2+this.Height-6,3,1,1);
				gr.FillRectangle(new SolidBrush(cl),this.Width-this.Height+2+this.Height-6,3+this.Height-7,1,1);
			
				gr.DrawLine(new Pen(cd,1),(this.Width-this.Height/2)-4,this.Height/2-1,(this.Width-this.Height/2)-1,this.Height/2+2);
				gr.DrawLine(new Pen(cd,1),(this.Width-this.Height/2)-1,this.Height/2+2,(this.Width-this.Height/2)+2,this.Height/2-1);
				gr.DrawLine(new Pen(cc,1),(this.Width-this.Height/2)-4,this.Height/2-0,(this.Width-this.Height/2)-1,this.Height/2+3);
				gr.DrawLine(new Pen(cc,1),(this.Width-this.Height/2)-1,this.Height/2+3,(this.Width-this.Height/2)+2,this.Height/2-0);
				gr.DrawLine(new Pen(cl,1),(this.Width-this.Height/2)-4,this.Height/2+1,(this.Width-this.Height/2)-1,this.Height/2+4);
				gr.DrawLine(new Pen(cl,1),(this.Width-this.Height/2)-1,this.Height/2+4,(this.Width-this.Height/2)+2,this.Height/2+1);
			}

			br.Dispose();
			
			
			//gr.DrawRectangle(new Pen(cd),this.Width-this.Height-2,3,15,this.Height-7);
			//			int i = int.Parse(this.Parent.Text);
			//			this.Parent.Text = (i+1).ToString();
		}
		private void ColorComboBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			if(this.Items.Count<141)
			{
				if(this.Height<21) this.Height=21;
				if(this.ItemHeight<15) this.ItemHeight=15;
				for (int j=this.Items.Count;j<141;j++)
					this.Items.Add(c[j].Name);
				this.Items.Add("Other");

				int i = 0;
				for (i=0;i<this.Items.Count-1;i++)
				{
					if(c[i].Name == this.resultCol.Name)
					{
						this.SelectedIndex = i;
						break;
					}
				}
				if(i==141)
				{					
					this.colDlg = false;
					this.SelectedIndex = i;
				}	
			}
			DrawCombo(sender,e);
			
		}

		private void ColorComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.SelectedIndex==141)
				{
					if(this.colDlg)
					{
						ColorDialog cDlg = new ColorDialog();					
						cDlg.FullOpen = true;
						cDlg.ShowDialog();
						otherCol = cDlg.Color ;
						resultCol = cDlg.Color ;						
					}
					else
					{
						this.colDlg = true;
						this.Refresh();
					}
				}
				else resultCol = c[this.SelectedIndex];
				
			}
			catch
			{
				//MessageBox.Show("ERRR");
			}

		}

		private void ColorComboBox_MouseEnter(object sender, System.EventArgs e)
		{
			Graphics gr = this.CreateGraphics();
			gr.FillRectangle(new SolidBrush(Color.FromArgb(90,255,255,255)),this.Width-this.Height+2,3,this.Height-5,this.Height-6);	
		}

		private void ColorComboBox_MouseLeave(object sender, System.EventArgs e)
		{
			this.Invalidate(new Rectangle(this.Width-this.Height+2,3,this.Height-5,this.Height-6));
			this.Update();		
		}

		private void ColorComboBox_EnabledChanged(object sender, System.EventArgs e)
		{
			if(this.Enabled)
				this.cColor = this.bColor;
			else
				this.cColor = SystemColors.ControlDark;
			
		}
		
	}
}

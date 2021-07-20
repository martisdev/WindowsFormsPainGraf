using System;
using System.Windows.Forms;
using System.Drawing;

namespace Draw_Graphics
{
    public enum Type_graf
    {
        PAINT_TRIANGLE = 0,
        PAINT_CIRCLE = 1,
        PAINT_RECTANGLE = 2,
        PAINT_TEXT = 3
    }

    internal struct PanelPaint
    {
        public Panel Panell;
        public Type_graf TypeGraf;
        public Graphics gr_graphics;
        public int Indx;
        public Boolean OnFocus;
        public String StrName;
        public Color ColorBack;
        public Boolean Visible;
    }
    
    abstract  class PaintG

    {
        public PanelPaint PanelPropietats;
        Point Oldpoint;
        Size OldSize;

        /// <summary>
        /// Objecte del Panell
        /// </summary>
        /// <param name="B_color">Color de fons del panell</param>
        /// <param name="Name">Nom de panell</param>
        public PaintG(Color B_color, string Name)
        {
            PanelPropietats = new PanelPaint()
            {
                /*Panell = my_panel,*/
                Panell = new Panel(),
                ColorBack = B_color,
                StrName = Name,
                Visible = true
            };

            
            PanelPropietats.Panell.Anchor = ((AnchorStyles)
                                            ((((AnchorStyles.Top 
                                            | AnchorStyles.Bottom) 
                                            | AnchorStyles.Left) 
                                            | AnchorStyles.Right)));
            PanelPropietats.Panell.Visible = true;            
            PanelPropietats.Panell.Name = Name;
            BackColor = PanelPropietats.ColorBack;            
            PanelPropietats.Panell.Resize += new System.EventHandler(this.my_panel_Resize);
            PanelPropietats.Panell.DoubleClick += new System.EventHandler(this.pmy_panel_DoubleClick);
        }

        /// <summary>
        /// Consulta si el panell esta visible (No minimitzat)
        /// </summary>
        public Panel Panell
        {
            get
            {
                return PanelPropietats.Panell;
            }
        }
        public void pmy_panel_DoubleClick(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        /// <summary>
        /// Estableix o consulta el nom de l'objecte
        /// </summary>
        public Color BackColor
        {
            get
            {
                return PanelPropietats.ColorBack;
            }
            set
            {
                PanelPropietats.ColorBack = value;                
            }
        }

        /// <summary>
        /// Consulta el nom de l'objetce
        /// </summary>
        public String Name
        {
            get
            {
                return PanelPropietats.StrName;
            }            
        }

        /// <summary>
        /// estableix o consulta si l'objecte té el focus
        /// </summary>
        public Boolean Focus
        {
            get
            {
                return PanelPropietats.OnFocus;
            }
            set
            {
                PanelPropietats.OnFocus = value;
                if (PanelPropietats.OnFocus == true)
                {
                    PanelPropietats.Panell.BorderStyle = BorderStyle.FixedSingle;                    
                }
                else
                {
                    PanelPropietats.Panell.BorderStyle = BorderStyle.None ;                    
                }
                Draw();
            }
        }

        /// <summary>
        /// Estableix o consulta la visibilitat del panell
        /// </summary>
        public Boolean Visible
        {
            get
            {
                return PanelPropietats.Visible;
            }
            set
            {
                PanelPropietats.Visible  = value;
                if (PanelPropietats.Visible == true)
                {              
                    PanelPropietats.Panell.Location = Oldpoint;
                    PanelPropietats.Panell.Size = OldSize;
                    Draw();
                }
                else
                {                 
                    Oldpoint = PanelPropietats.Panell.Location;
                    OldSize = PanelPropietats.Panell.Size;
                    PanelPropietats.Panell.Location = new Point(Oldpoint.X, 10);
                    PanelPropietats.Panell.Size = new Size(20, 10);
                }                
            }
        }

        /// <summary>
        /// Consulta el tipus de gràfic
        /// </summary>
        public Type_graf TypeOfGraffic
        {
            get {
                return PanelPropietats.TypeGraf;
            }
            /*set
            {
                PanelPropietats.TypeGraf = value;
            }*/
        }

        /// <summary>
        /// Idemtificador a la matriu
        /// </summary>
        public int Index
        {
            get
            {
                return PanelPropietats.Indx;
            }
            set
            {
                PanelPropietats.Indx = value;
            }
        }

        /// <summary>
        /// Estableix o consulta la posició del panell
        /// </summary>
        public Point Location
        {
            get
            {
                return PanelPropietats.Panell.Location;
            }
            set
            {
                PanelPropietats.Panell.Location = value;
                Draw();
            }
        }

        /// <summary>
        /// Estableix o consulta la mida del planell
        /// </summary>
        public Size Size
        {
            get
            {
                return PanelPropietats.Panell.Size;
            }
            set
            {
                PanelPropietats.Panell.Size = value;
                Draw();
            }
        }

        /// <summary>
        /// Funcion prèvies a esborrar el panell.
        /// </summary>
        public void Delete()
        {
            PanelPropietats.Panell.Resize -= this.my_panel_Resize;
        }

        /// <summary>
        /// Event per redimensionar els panells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void my_panel_Resize(object sender, EventArgs e)
        {
            ///Resize panel  
            Control Ctl = (Control)(sender);
            Size Sz = new Size(Ctl.Width, Ctl.Height);
            Size = Sz;
            //PanelPropietats.Panell.Size = Sz;
            Draw();
        }

        /// <summary>
        /// Ganxo per cridar a la funció de les classes filles.
        /// </summary>
        public abstract void Draw();
  
    }
    /// <summary>
    /// Clase secundaria que hereda les característiques generals de PaintG.
    /// Aquí especifiquem dibuixar un triangle i els seus paràmetres concrets
    /// </summary>
    class TriangleG : PaintG
    {
        Pen pen_draw;

        /// <summary>
        /// Dibuixem un triangle
        /// </summary>
        /// <param name="P_pen"></param>        
        /// <param name="B_color">Color de fons</param>
        public  TriangleG(Pen P_pen,  Color B_color,string Name) :base( B_color, Name)            
        {
            PanelPropietats.TypeGraf = Type_graf.PAINT_TRIANGLE;
            pen_draw = P_pen;
        }

        /// <summary>
        /// Dibuixa el triangle
        /// </summary>
        public override void Draw()
        {
            PanelPropietats.gr_graphics = PanelPropietats.Panell.CreateGraphics();
            PanelPropietats.gr_graphics.Clear(PanelPropietats.ColorBack);
            Point[] pnt = new Point[3];
            
            pnt[0].X = Size.Width / 2;
            pnt[0].Y = 10;

            pnt[1].X = Size.Width - 10;
            pnt[1].Y = Size.Height - 10;

            pnt[2].X = 10;
            pnt[2].Y = Size.Height - 10;

            PanelPropietats.gr_graphics.DrawPolygon(pen_draw, pnt);
        }        
    }

    /// <summary>
    /// Clase secundaria que hereda les característiques generals de PaintG.
    /// Aquí especifiquem dibuixar un cercle i els seus paràmetres concrets
    /// </summary>
    class CercleG : PaintG
    {

        /// <summary>
        /// Dibuixem un cercle
        /// </summary>        
        /// <param name="B_color">Color de fons</param>
        /// /// <param name="Name">Nom de l'objecte</param>
        public CercleG(  Color B_color, string Name) : base( B_color,Name)
        {
            PanelPropietats.TypeGraf = Type_graf.PAINT_CIRCLE ;
            
        }

        /// <summary>
        /// Dibuixa el cercle
        /// </summary>
        public override  void Draw()
        {
            PanelPropietats.gr_graphics = PanelPropietats.Panell.CreateGraphics();
            PanelPropietats.gr_graphics.Clear(PanelPropietats.ColorBack);
            int centerX = Size.Width / 2;
            int centerY = Size.Height / 2;
            int p_radius = 5 ;
            if (Size.Width < Size.Height)
            {
                p_radius = Size.Width / 3;
            }
            else if (Size.Width > Size.Height)
            {
                p_radius = Size.Height / 3;
            }

            SolidBrush my_brush = new SolidBrush(Color.Black);
            PanelPropietats.gr_graphics.FillEllipse(my_brush, centerX - p_radius, centerY - p_radius,
                                    p_radius + p_radius, p_radius + p_radius);
        }
    }

    /// <summary>
    /// Clase secundaria que hereda les característiques generals de PaintG.
    /// Aquí especifiquem dibuixar un rectangle i els seus paràmetres concrets
    /// </summary>
    class RectangleG : PaintG
    {
        Pen pen_draw;
        /// <summary>
        /// Dibuixem un rectàngle
        /// </summary>
        /// <param name="P_pen">Pen específic per pintar el rectangle</param>        
        /// <param name="B_color">Color de fons</param>
        /// /// /// <param name="Name">Nom de l'objecte</param>
        public RectangleG(Pen P_pen,  Color B_color, string Name) : base( B_color, Name)
        {
            PanelPropietats.gr_graphics = PanelPropietats.Panell.CreateGraphics();
            PanelPropietats.TypeGraf = Type_graf.PAINT_RECTANGLE ;
            pen_draw = P_pen;
        }

        /// <summary>
        /// Dibuixa el rectàngle
        /// </summary>
        public override  void Draw()
        {
            PanelPropietats.gr_graphics = PanelPropietats.Panell.CreateGraphics();
            PanelPropietats.gr_graphics.Clear(PanelPropietats.ColorBack);
            Rectangle rect = new Rectangle(10, 10, Size.Width - 20, Size.Height - 20);
            PanelPropietats.gr_graphics.DrawRectangle(pen_draw, rect);
        }
    }


    /// <summary>
    /// Clase secundaria que hereda les característiques generals de PaintG.
    /// Aquí especifiquem dibuixar un text i els seus paràmetres concrets
    /// </summary>
    class TextG : PaintG
    {
        String Local_text = "";

        /// <summary>
        /// Dibuixem un Text
        /// </summary>
        /// <param name="Text">Text a mostrar</param>        
        /// <param name="B_color">Color de fons</param>
        /// /// <param name="Name">Nom del Panell</param>
        public TextG(string Text,  Color B_color, string Name) : base( B_color, Name)
        {
            PanelPropietats.gr_graphics = PanelPropietats.Panell.CreateGraphics();
            PanelPropietats.TypeGraf = Type_graf.PAINT_TEXT ;
            Local_text = Text;
        }

        /// <summary>
        /// Dibuixa el rectàngle
        /// </summary>
        public override  void Draw()
        {
            PanelPropietats.gr_graphics = PanelPropietats.Panell.CreateGraphics();
            PanelPropietats.gr_graphics.Clear(PanelPropietats.ColorBack);
            string drawString = Local_text;
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = Size.Width - (Size.Width - 10);
            float y = 50.0F;
            PanelPropietats.gr_graphics.DrawString(drawString, drawFont, drawBrush, x, y);
        }

        /// <summary>
        /// Establim o consultem el text.
        /// </summary>
        public string Text
        {
            get
            {
                return Local_text;
            }
            set
            {
                Local_text = value;
            }
        }
    }

}

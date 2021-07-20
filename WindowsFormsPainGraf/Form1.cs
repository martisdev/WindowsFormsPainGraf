/* 
    Autor:      Martí Soler 
    Correu:     martisolerchiva@gmail.com
    Telèfon:    686 298 198
    Data:       16/11/2020
    Propósit:   Tal com m'heu demanat, en aquest projecte us ensenyo com pintar una figura
                geomètrica en un panell. incorporant diferentes funcionalitats, tals com:
                - Dibuixar triangle, cercle,  rectangle o text.
                - Maximitzar el panell centrat al form. desmarcant-la en podem afegir varis.
                - Moure panell.
                - Esborrar panell.
                - Pintar més d'un panell.
                
    Altres:     Si ho creieu convenient podeu veure una mostra del meu treball a  https://github.com/martisdev   

    Gràcies per tot.
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using Draw_Graphics;
using System.Security.Cryptography;
using System.Text;
namespace WindowsFormsPainGraf
{
    
    public partial class FormMain : Form 
    {
        PaintG[] GraphicCollection;
        Type_graf ActualForma = Type_graf.PAINT_TRIANGLE;
        Color ActualBackColor = Color.Orange;
        bool Moving = false;
        FormTools frmTool = new FormTools();

        public FormMain()
        {
            InitializeComponent();            
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
                        
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                Control My_parent = (Control)sender;
                Type tp = My_parent.GetType();
                if (tp.Equals(typeof(Panel)))
                {
                    this.toolStripSeparator2.Visible = true ;
                    this.MnuChildEsborrar.Visible = true;
                    this.MnuMourePanel.Visible = true;
                }
                else
                {
                    this.toolStripSeparator2.Visible = false ;
                    this.MnuChildEsborrar.Visible = false;
                    this.MnuMourePanel.Visible = false;
                }
                MnuMain.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            else
            {
                //Moure el panell
                if (GraphicCollection == null) { return; }
                if (Moving ==true)
                {
                    Point My_point = this.PointToClient(Cursor.Position);
                    for (int i = 0; i < GraphicCollection.Length; i++)
                    {
                        if (GraphicCollection[i].Focus == true)
                        {
                            GraphicCollection[i].Location = My_point;
                        }

                    }
                }
                
            }

        }
        
        private void MnuChildPintaForma_Click(object sender, EventArgs e)
        {
            if (this.mnuChildOnlyOnePanel.Checked == true)
            {
                //Delete Panels
            }


            int MargeX = (this.PointToClient(System.Windows.Forms.Cursor.Position).X) * 2;
            int MargeY = (this.PointToClient(System.Windows.Forms.Cursor.Position).Y) * 2;
            Size My_size;
            if (mnuChildOnlyOnePanel.Checked == true)
            {
                My_size = new Size(this.Width - MargeX, this.Height - MargeY);
            }
            else
            {
                My_size = new Size(this.Width / 3, this.Height / 3);
            }
            if (My_size.Width < 0)
            {
                MessageBox.Show("No es podrà mostrar el panell (desmarqui Maximitzar Amplada)", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (My_size.Height < 0)
            {
                MessageBox.Show("No es podrà mostrar el panell (desmarqui Maximitzar Amplada)", "Error", MessageBoxButtons.OK);
                return;
            }

            NewPanel(My_size);

        }

        private void NewPanel(Size Sz)
        {            
            string NameHash = GetHash(DateTime.Now.ToString());            

            if (GraphicCollection == null)
            {
                Array.Resize(ref GraphicCollection, 1);
            }
            else
            {
                Array.Resize(ref GraphicCollection, GraphicCollection.Length + 1);
            }

            Pen my_pen = new Pen(Color.Black, 4);
            switch (ActualForma)
            {
                case Type_graf.PAINT_TRIANGLE:                    
                    GraphicCollection[GraphicCollection.Length - 1] = new TriangleG(my_pen,  ActualBackColor, NameHash);
                    break;
                case Type_graf.PAINT_CIRCLE:                    
                    GraphicCollection[GraphicCollection.Length - 1] = new CercleG(  ActualBackColor, NameHash);
                    break;
                case Type_graf.PAINT_RECTANGLE:                    
                    GraphicCollection[GraphicCollection.Length - 1] = new RectangleG(my_pen,  ActualBackColor, NameHash);
                    break;
                case Type_graf.PAINT_TEXT:
                    string drawString = "Autor:      Martí Soler " + Environment.NewLine +
                                        "Correu:     martisolerchiva @gmail.com" + Environment.NewLine +
                                        "Telèfon:    686 298 198";
                    GraphicCollection[GraphicCollection.Length - 1] = new TextG(drawString, ActualBackColor,NameHash);
                    break;
            }
            //Posicionem el Panell
            GraphicCollection[GraphicCollection.Length - 1].Size= Sz;            
            Point my_point = this.PointToClient(Cursor.Position);
            GraphicCollection[GraphicCollection.Length - 1].Location = my_point;

            //E
            this.Controls.Add(GraphicCollection[GraphicCollection.Length - 1].Panell);
            GraphicCollection[GraphicCollection.Length - 1].Index = this.Controls.IndexOf(GraphicCollection[GraphicCollection.Length - 1].Panell);
            
            //Relacionem events
            GraphicCollection[GraphicCollection.Length - 1].Panell.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            GraphicCollection[GraphicCollection.Length - 1].Panell.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);            
                        
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            // estableix panell actual.
            if (GraphicCollection == null) { return; }
            for (int i = 0; i < GraphicCollection.Length; i++)
            {
                Panel My_Panel = (Panel)(sender);
                if (GraphicCollection[i].Name == My_Panel.Name)
                {
                    GraphicCollection[i].Focus = true;
                    frmTool.labelNom.Text = GraphicCollection[i].Name;
                    switch (GraphicCollection[i].TypeOfGraffic)
                    {
                        case Type_graf.PAINT_CIRCLE:
                            frmTool.labelTipus.Text = "Cercle";
                            break;
                        case Type_graf.PAINT_RECTANGLE:
                            frmTool.labelTipus.Text = "Rectange";
                            break;
                        case Type_graf.PAINT_TRIANGLE :
                            frmTool.labelTipus.Text = "Triangle";
                            break;
                        case Type_graf.PAINT_TEXT :
                            frmTool.labelTipus.Text = "Text";
                            break;
                    }
                    frmTool.checkBoxVisible.Checked = GraphicCollection[i].Visible;
                    frmTool.labelColor.BackColor= GraphicCollection[i].BackColor;

                }
                else
                {
                    GraphicCollection[i].Focus = false;
                }
            }                        
        }
        

        /// <summary>
        /// Esborrem tots els panells
        /// </summary>
        /// <param name="sender">L'objecte que genera l'event</param>
        /// <param name="e">L'event en qüestió</param>
        private void MnuChildEsborrar_Click(object sender, EventArgs e)
        {
            //Delete all panels
            if (GraphicCollection == null) { return; }

            for (int i = 0; i < GraphicCollection.Length; i++)
            {
                if (GraphicCollection[i].Focus == true)
                {
                    GraphicCollection[i].Delete();
                    int IndxPanel = this.Controls.IndexOf(GraphicCollection[i].Panell);
                    DeletePanel(IndxPanel);
                    break;
                }
            }
    
        }

        private void DeletePanel(int Indx)
        {

            PaintG[] tempGrafCollect= null;            
            for (int i = 0; i < GraphicCollection.Length; i++)
            {
                if (i != Indx)
                {
                    if (tempGrafCollect == null)
                    {
                        Array.Resize(ref tempGrafCollect, 1);
                    }
                    else
                    {
                        Array.Resize(ref tempGrafCollect, tempGrafCollect.Length + 1);
                    }
                    tempGrafCollect[tempGrafCollect.Length -1] = GraphicCollection[i];
                    
                    break;
                }
            }
            
            this.Controls.RemoveAt(Indx);            
            GraphicCollection = tempGrafCollect;
            frmTool.labelNom.Text = "";
            frmTool.labelTipus.Text = "";
            frmTool.checkBoxVisible.Checked = false;
            frmTool.labelColor.BackColor = Color.White;
        }


        /// <summary>
        /// Iniciem la funció de moure el panell que tenim a sota.
        /// </summary>
        /// <param name="sender">L'objecte que genera l'event</param>
        /// <param name="e">L'event en qüestió</param>
        private void MnuMourePanel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Marqui el punt on vols desplaçar el panell", "Informació", MessageBoxButtons.OK);
            //this.Cursor = System.Windows.Forms.Cursors.Hand;
            // moure panell
            ToolStripMenuItem item = (ToolStripMenuItem)(sender);
            item.Checked = !item.Checked;
            Moving = item.Checked;
            if(Moving== true)
            {
                this.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }

        /// <summary>
        /// Amb aquesta opció maximitzem el tamany del panell. Si es volen dibuixar més d'un s'ha de desactivar.
        /// </summary>
        /// <param name="sender">L'objecte que genera l'event</param>
        /// <param name="e">Event</param>
        private void mnuChildOnlyOnePanel_Click(object sender, EventArgs e)
        {
            // Esborra panell
            mnuChildOnlyOnePanel.Checked = !mnuChildOnlyOnePanel.Checked;            
        }

        /// <summary>
        /// Canvia el tipus de figura geomètrica a dibuixar.
        /// </summary>
        /// <param name="sender">L'objecte que genera l'event</param>
        /// <param name="e">Event</param>
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (object obj in mnuForma.DropDownItems)
            {
                if (obj.GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    ToolStripMenuItem subMenu = (ToolStripMenuItem)obj;
                    subMenu.Checked = false;                
                }
            }
            ToolStripMenuItem item = (ToolStripMenuItem)(sender);
            item.Checked = !item.Checked;
            switch(item.Text)
            {
                case "Triangle": ActualForma = Type_graf.PAINT_TRIANGLE; break;
                case "Cercle": ActualForma = Type_graf.PAINT_CIRCLE; break;
                case "Rectangle": ActualForma = Type_graf.PAINT_RECTANGLE; break;
                case "Crèdits":ActualForma = Type_graf.PAINT_TEXT; break;
            }            
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            foreach (object obj in mnuMainColor.DropDownItems)
            {
                if (obj.GetType().Equals(typeof(ToolStripMenuItem)))
                {
                    ToolStripMenuItem subMenu = (ToolStripMenuItem)obj;
                    subMenu.Checked = false;
                }
            }
            ToolStripMenuItem item = (ToolStripMenuItem)(sender);
            item.Checked = !item.Checked;
            switch(item.Text)
            {
                case "Taronja": ActualBackColor = Color.Orange; break;
                case "Groc": ActualBackColor = Color.Yellow; break;
                case "Roig": ActualBackColor = Color.Red; break;
            }
        }

        static string GetHash(string rawData)
        {            
            using (SHA256 sha256Hash = SHA256.Create())
            {         
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));         
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void my_panel_Resize(object sender, EventArgs e)
        {
            ///Resize panel            
            if (GraphicCollection == null) { return; }
            for (int i = 0; i < GraphicCollection.Length; i++)
            {
                Panel My_Panel = (Panel)(sender);
                if (GraphicCollection[i].Name == My_Panel.Name)
                {
                    GraphicCollection[i].Size = My_Panel.Size;
                    return;
                }                                
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
            frmTool.Show();
            Point p = this.Location;
            frmTool.Location = new Point(p.X - 160, p.Y);
        }

        private void FormMain_LocationChanged(object sender, EventArgs e)
        {
            Point p = this.Location;
            frmTool.Location = new Point(p.X - 160, p.Y);
        }

        private void mnuTools_Click(object sender, EventArgs e)
        {
            frmTool.Show();
        }
        
    }
}

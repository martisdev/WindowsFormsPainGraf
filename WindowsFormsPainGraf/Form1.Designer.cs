namespace WindowsFormsPainGraf
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.MnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuChildPintaTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForma = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTriangel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCercle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColor = new System.Windows.Forms.ToolStripMenuItem();
            this.grocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuMourePanel = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuChildEsborrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChildOnlyOnePanel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuMain
            // 
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuChildPintaTriangle,
            this.mnuForma,
            this.mnuMainColor,
            this.toolStripSeparator2,
            this.MnuMourePanel,
            this.MnuChildEsborrar,
            this.toolStripSeparator1,
            this.mnuChildOnlyOnePanel,
            this.mnuTools});
            this.MnuMain.Name = "MnuMain";
            this.MnuMain.Size = new System.Drawing.Size(286, 170);
            // 
            // MnuChildPintaTriangle
            // 
            this.MnuChildPintaTriangle.Name = "MnuChildPintaTriangle";
            this.MnuChildPintaTriangle.Size = new System.Drawing.Size(285, 22);
            this.MnuChildPintaTriangle.Text = "Pinta una forma geomètrica";
            this.MnuChildPintaTriangle.Click += new System.EventHandler(this.MnuChildPintaForma_Click);
            // 
            // mnuForma
            // 
            this.mnuForma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTriangel,
            this.mnuCercle,
            this.mnuRectangle,
            this.mnuCredits});
            this.mnuForma.Name = "mnuForma";
            this.mnuForma.Size = new System.Drawing.Size(285, 22);
            this.mnuForma.Text = "Forma a dibuixar";
            // 
            // mnuTriangel
            // 
            this.mnuTriangel.Checked = true;
            this.mnuTriangel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuTriangel.Name = "mnuTriangel";
            this.mnuTriangel.Size = new System.Drawing.Size(126, 22);
            this.mnuTriangel.Text = "Triangle";
            this.mnuTriangel.Click += new System.EventHandler(this.TriangleToolStripMenuItem_Click);
            // 
            // mnuCercle
            // 
            this.mnuCercle.Name = "mnuCercle";
            this.mnuCercle.Size = new System.Drawing.Size(126, 22);
            this.mnuCercle.Text = "Cercle";
            this.mnuCercle.Click += new System.EventHandler(this.TriangleToolStripMenuItem_Click);
            // 
            // mnuRectangle
            // 
            this.mnuRectangle.Name = "mnuRectangle";
            this.mnuRectangle.Size = new System.Drawing.Size(126, 22);
            this.mnuRectangle.Text = "Rectangle";
            this.mnuRectangle.Click += new System.EventHandler(this.TriangleToolStripMenuItem_Click);
            // 
            // mnuCredits
            // 
            this.mnuCredits.Name = "mnuCredits";
            this.mnuCredits.Size = new System.Drawing.Size(126, 22);
            this.mnuCredits.Text = "Crèdits";
            this.mnuCredits.Click += new System.EventHandler(this.TriangleToolStripMenuItem_Click);
            // 
            // mnuMainColor
            // 
            this.mnuMainColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColor,
            this.grocToolStripMenuItem,
            this.roigToolStripMenuItem});
            this.mnuMainColor.Name = "mnuMainColor";
            this.mnuMainColor.Size = new System.Drawing.Size(285, 22);
            this.mnuMainColor.Text = "Color de fons";
            // 
            // mnuColor
            // 
            this.mnuColor.Checked = true;
            this.mnuColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuColor.Name = "mnuColor";
            this.mnuColor.Size = new System.Drawing.Size(112, 22);
            this.mnuColor.Text = "Taronja";
            this.mnuColor.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // grocToolStripMenuItem
            // 
            this.grocToolStripMenuItem.Name = "grocToolStripMenuItem";
            this.grocToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.grocToolStripMenuItem.Text = "Groc";
            this.grocToolStripMenuItem.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // roigToolStripMenuItem
            // 
            this.roigToolStripMenuItem.Name = "roigToolStripMenuItem";
            this.roigToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.roigToolStripMenuItem.Text = "Roig";
            this.roigToolStripMenuItem.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(282, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // MnuMourePanel
            // 
            this.MnuMourePanel.Name = "MnuMourePanel";
            this.MnuMourePanel.Size = new System.Drawing.Size(285, 22);
            this.MnuMourePanel.Text = "Moure panell";
            this.MnuMourePanel.Click += new System.EventHandler(this.MnuMourePanel_Click);
            // 
            // MnuChildEsborrar
            // 
            this.MnuChildEsborrar.Name = "MnuChildEsborrar";
            this.MnuChildEsborrar.Size = new System.Drawing.Size(285, 22);
            this.MnuChildEsborrar.Text = "Esborrar panell";
            this.MnuChildEsborrar.Click += new System.EventHandler(this.MnuChildEsborrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(282, 6);
            // 
            // mnuChildOnlyOnePanel
            // 
            this.mnuChildOnlyOnePanel.Name = "mnuChildOnlyOnePanel";
            this.mnuChildOnlyOnePanel.Size = new System.Drawing.Size(285, 22);
            this.mnuChildOnlyOnePanel.Text = "Només un panell (maximitzar Amplada)";
            this.mnuChildOnlyOnePanel.Click += new System.EventHandler(this.mnuChildOnlyOnePanel_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(285, 22);
            this.mnuTools.Text = "Mostra Barra d\'eines";
            this.mnuTools.Click += new System.EventHandler(this.mnuTools_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pinta objectes a la pantalla";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.LocationChanged += new System.EventHandler(this.FormMain_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MnuMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem MnuChildPintaTriangle;
        private System.Windows.Forms.ToolStripMenuItem MnuChildEsborrar;
        private System.Windows.Forms.ToolStripMenuItem MnuMourePanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuChildOnlyOnePanel;
        private System.Windows.Forms.ToolStripMenuItem mnuForma;
        private System.Windows.Forms.ToolStripMenuItem mnuTriangel;
        private System.Windows.Forms.ToolStripMenuItem mnuCercle;
        private System.Windows.Forms.ToolStripMenuItem mnuRectangle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuCredits;
        private System.Windows.Forms.ToolStripMenuItem mnuMainColor;
        private System.Windows.Forms.ToolStripMenuItem mnuColor;
        private System.Windows.Forms.ToolStripMenuItem grocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
    }
}


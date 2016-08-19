namespace PaintDistribuidoCAO
{
    partial class frmDibujo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDibujo));
            this.picLienzo = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbAbrir = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDibujarLinea = new System.Windows.Forms.ToolStripButton();
            this.tsbDibujarCuadrado = new System.Windows.Forms.ToolStripButton();
            this.tsbDibujarCirculo = new System.Windows.Forms.ToolStripButton();
            this.tsbGrosor = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbmn1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmn2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmn3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmn4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbmn5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbColorBorde = new System.Windows.Forms.ToolStripButton();
            this.tsbColorRelleno = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAyuda = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLienzo
            // 
            this.picLienzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLienzo.BackColor = System.Drawing.Color.White;
            this.picLienzo.Location = new System.Drawing.Point(0, 28);
            this.picLienzo.Name = "picLienzo";
            this.picLienzo.Size = new System.Drawing.Size(580, 348);
            this.picLienzo.TabIndex = 0;
            this.picLienzo.TabStop = false;
            this.picLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseDown);
            this.picLienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbAbrir,
            this.tsbGuardar,
            this.toolStripSeparator,
            this.tsbDibujarLinea,
            this.tsbDibujarCuadrado,
            this.tsbDibujarCirculo,
            this.tsbGrosor,
            this.tsbColorBorde,
            this.tsbColorRelleno,
            this.toolStripSeparator1,
            this.tsbAyuda});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(580, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "&Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbAbrir
            // 
            this.tsbAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbrir.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbrir.Image")));
            this.tsbAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbrir.Name = "tsbAbrir";
            this.tsbAbrir.Size = new System.Drawing.Size(23, 22);
            this.tsbAbrir.Text = "&Abrir";
            this.tsbAbrir.Click += new System.EventHandler(this.tsbAbrir_Click);
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(23, 22);
            this.tsbGuardar.Text = "&Guardar";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDibujarLinea
            // 
            this.tsbDibujarLinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDibujarLinea.Image = ((System.Drawing.Image)(resources.GetObject("tsbDibujarLinea.Image")));
            this.tsbDibujarLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDibujarLinea.Name = "tsbDibujarLinea";
            this.tsbDibujarLinea.Size = new System.Drawing.Size(23, 22);
            this.tsbDibujarLinea.Text = "Linea";
            this.tsbDibujarLinea.Click += new System.EventHandler(this.tsbDibujarLinea_Click);
            // 
            // tsbDibujarCuadrado
            // 
            this.tsbDibujarCuadrado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDibujarCuadrado.Image = ((System.Drawing.Image)(resources.GetObject("tsbDibujarCuadrado.Image")));
            this.tsbDibujarCuadrado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDibujarCuadrado.Name = "tsbDibujarCuadrado";
            this.tsbDibujarCuadrado.Size = new System.Drawing.Size(23, 22);
            this.tsbDibujarCuadrado.Text = "Cuadrado";
            this.tsbDibujarCuadrado.Click += new System.EventHandler(this.tsbDibujarCuadrado_Click);
            // 
            // tsbDibujarCirculo
            // 
            this.tsbDibujarCirculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDibujarCirculo.Image = ((System.Drawing.Image)(resources.GetObject("tsbDibujarCirculo.Image")));
            this.tsbDibujarCirculo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDibujarCirculo.Name = "tsbDibujarCirculo";
            this.tsbDibujarCirculo.Size = new System.Drawing.Size(23, 22);
            this.tsbDibujarCirculo.Text = "Círculo";
            this.tsbDibujarCirculo.Click += new System.EventHandler(this.tsbDibujarCirculo_Click);
            // 
            // tsbGrosor
            // 
            this.tsbGrosor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbmn1,
            this.tsbmn2,
            this.tsbmn3,
            this.tsbmn4,
            this.tsbmn5});
            this.tsbGrosor.Image = ((System.Drawing.Image)(resources.GetObject("tsbGrosor.Image")));
            this.tsbGrosor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGrosor.Name = "tsbGrosor";
            this.tsbGrosor.Size = new System.Drawing.Size(74, 22);
            this.tsbGrosor.Text = "Grosor";
            // 
            // tsbmn1
            // 
            this.tsbmn1.Name = "tsbmn1";
            this.tsbmn1.Size = new System.Drawing.Size(89, 22);
            this.tsbmn1.Text = "1";
            this.tsbmn1.Click += new System.EventHandler(this.tsbmn1_Click);
            // 
            // tsbmn2
            // 
            this.tsbmn2.Name = "tsbmn2";
            this.tsbmn2.Size = new System.Drawing.Size(89, 22);
            this.tsbmn2.Text = "1.5";
            this.tsbmn2.Click += new System.EventHandler(this.tsbmn2_Click);
            // 
            // tsbmn3
            // 
            this.tsbmn3.Name = "tsbmn3";
            this.tsbmn3.Size = new System.Drawing.Size(89, 22);
            this.tsbmn3.Text = "2";
            this.tsbmn3.Click += new System.EventHandler(this.tsbmn3_Click);
            // 
            // tsbmn4
            // 
            this.tsbmn4.Name = "tsbmn4";
            this.tsbmn4.Size = new System.Drawing.Size(89, 22);
            this.tsbmn4.Text = "2.5";
            this.tsbmn4.Click += new System.EventHandler(this.tsbmn4_Click);
            // 
            // tsbmn5
            // 
            this.tsbmn5.Name = "tsbmn5";
            this.tsbmn5.Size = new System.Drawing.Size(89, 22);
            this.tsbmn5.Text = "3";
            this.tsbmn5.Click += new System.EventHandler(this.tsbmn5_Click);
            // 
            // tsbColorBorde
            // 
            this.tsbColorBorde.Image = ((System.Drawing.Image)(resources.GetObject("tsbColorBorde.Image")));
            this.tsbColorBorde.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColorBorde.Name = "tsbColorBorde";
            this.tsbColorBorde.Size = new System.Drawing.Size(90, 22);
            this.tsbColorBorde.Text = "Color Borde";
            this.tsbColorBorde.Click += new System.EventHandler(this.tsbColorBorde_Click);
            // 
            // tsbColorRelleno
            // 
            this.tsbColorRelleno.Image = ((System.Drawing.Image)(resources.GetObject("tsbColorRelleno.Image")));
            this.tsbColorRelleno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColorRelleno.Name = "tsbColorRelleno";
            this.tsbColorRelleno.Size = new System.Drawing.Size(98, 22);
            this.tsbColorRelleno.Text = "Color Relleno";
            this.tsbColorRelleno.Click += new System.EventHandler(this.tsbColorRelleno_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAyuda
            // 
            this.tsbAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAyuda.Image = ((System.Drawing.Image)(resources.GetObject("tsbAyuda.Image")));
            this.tsbAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAyuda.Name = "tsbAyuda";
            this.tsbAyuda.Size = new System.Drawing.Size(23, 22);
            this.tsbAyuda.Text = "Ay&uda";
            // 
            // frmDibujo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 376);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.picLienzo);
            this.Name = "frmDibujo";
            this.Text = "Paint Programa Para Dibujar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDibujo_FormClosed);
            this.Load += new System.EventHandler(this.frmDibujo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLienzo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbAbrir;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbAyuda;
        private System.Windows.Forms.ToolStripButton tsbDibujarCuadrado;
        private System.Windows.Forms.ToolStripButton tsbDibujarCirculo;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripSplitButton tsbGrosor;
        private System.Windows.Forms.ToolStripMenuItem tsbmn1;
        private System.Windows.Forms.ToolStripMenuItem tsbmn2;
        private System.Windows.Forms.ToolStripMenuItem tsbmn3;
        private System.Windows.Forms.ToolStripMenuItem tsbmn4;
        private System.Windows.Forms.ToolStripMenuItem tsbmn5;
        private System.Windows.Forms.ToolStripButton tsbColorBorde;
        private System.Windows.Forms.ToolStripButton tsbColorRelleno;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDibujarLinea;
    }
}


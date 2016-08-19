namespace PaintDistribuidoCAO
{
    partial class frmLienzosCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbLienzosCliente = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbLienzosCliente
            // 
            this.cmbLienzosCliente.FormattingEnabled = true;
            this.cmbLienzosCliente.Location = new System.Drawing.Point(23, 24);
            this.cmbLienzosCliente.Name = "cmbLienzosCliente";
            this.cmbLienzosCliente.Size = new System.Drawing.Size(285, 21);
            this.cmbLienzosCliente.TabIndex = 0;
            this.cmbLienzosCliente.SelectedIndexChanged += new System.EventHandler(this.cmbLienzosCliente_SelectedIndexChanged);
            // 
            // frmLienzosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 280);
            this.Controls.Add(this.cmbLienzosCliente);
            this.Name = "frmLienzosCliente";
            this.Text = "Lista Lienzos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLienzosCliente_FormClosed);
            this.Load += new System.EventHandler(this.frmLienzosCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLienzosCliente;
    }
}
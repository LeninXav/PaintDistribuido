// CRISTIAN FABRICIO ESPINOSA GUALOTUÑA - LENIN XAVIER VELASTEGUI ALMEIDA
// APLICACIONES DISTRIBUÍDAS
// 22/11/2013
// PROYECTO 02 APLICACIONES DISTRIBUIDAS
// PAINT DISTRIBUIDO USANDO CAO

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaPaint;

namespace PaintDistribuidoCAO
{
    public partial class frmLienzosCliente : Form
    {
        // Creo una variable nombre que me servirá para el poder ver el nombre de cada uno de los lienzos
        private string nombre;
        // Creo una variable contrasenia que me servirá para el poder abrir de cada uno de los lienzos de acuerdo al ID de cada
        // Cliente que tenga sus lienzos
        private string contrasenia;

        private bool comprobacion;

        // Constructor del formulario que me aceptará la contrasenia del cliente que tenga el lienzo un nombre
        public frmLienzosCliente(string contrasenia, string nombre)
        {
            InitializeComponent();
            // Inicio los argumentos con el nombre y la contrasenia
            this.nombre = nombre;
            this.contrasenia = contrasenia;
        }

        // Evento Loas del formulario
        private void frmLienzosCliente_Load(object sender, EventArgs e)
        {
            comprobacion = false;
            // Creo un nuevo lienzo BDD el cual me permirita obtner la lista de lienzos creados 
            // por determinado usuario
            LienzoBDD usuario = new LienzoBDD();
            // Creo una lista de lienzos de acuerdo a la contrasenia de cada usuario ya que un cliente puede tener mas de 1
            // Lienzo(Dibujo)
            List<string> lista = usuario.ObtenerLienzos(contrasenia);
            // Limpio los items del combobox para actualizar
            cmbLienzosCliente.Items.Clear();
            // Se añade un item que es Nuevo el cual será para un nuevo lienzo en blanco de cada Cliente
            cmbLienzosCliente.Items.Add("Nuevo");
            // Hago un lazo for para añadir los lienzos creados por el Cliente y poder mostrar en el combo box
            foreach (string nombreLienzo in lista)
                // Se añade al combobox cada uno de los lienzos que tiene cada cliente
                cmbLienzosCliente.Items.Add(nombreLienzo);
            frmLoginUsuario.ActiveForm.WindowState = FormWindowState.Minimized;
            frmLoginUsuario.ActiveForm.Visible = true;
        }

        // Evento que se generará al momento de hacer click en uno de los items del combobox
        private void cmbLienzosCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            comprobacion = true;
            // Cierro el actual formulario
            this.Close();
            this.Dispose();
            // Cargo el lienzo seleccionado en el combobox, mediante el item seleccionado, la contrasenia y el nombre respectivo
            // del lienzo
            frmDibujo dibujo = new frmDibujo(cmbLienzosCliente.SelectedItem.ToString(), contrasenia, nombre);
            // Cargo el formulario en modo show
            dibujo.Show();
        }

        private void frmLienzosCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(comprobacion.ToString());
            if (comprobacion == false)
            {
                frmLoginUsuario.ActiveForm.WindowState = FormWindowState.Normal;
                frmLoginUsuario.ActiveForm.Visible = false;
                frmLoginUsuario.ActiveForm.StartPosition = FormStartPosition.CenterScreen;
            }
        }

    }
}

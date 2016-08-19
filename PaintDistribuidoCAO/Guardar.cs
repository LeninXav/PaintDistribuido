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

namespace PaintDistribuidoCAO
{
    public partial class Guardar : Form
    {
        public Guardar()
        {
            InitializeComponent();
        }
        //Creamos un constructor en el cual se le pasa el nombre del archivo modificado
        public Guardar(string nombre)
        {
            InitializeComponent();
            nombreArchivo = nombre;
        }

        // Creo una variable nombreArchivo que me permitirá guardar el arhivo con un nombre específico
        public string nombreArchivo;

        // Evento Load del formulario Guardar
        private void Guardar_Load(object sender, EventArgs e)
        {
            //comparamos si el nombre del archivo es nulo o sino se coloca el nombre del archivo
            if (nombreArchivo.Equals("Nuevo"))
            {
                // Al momento de cargar el formulario por defecto en el txtNombre me aparece por default Dibujo
                txtNombre.Text = "Dibujo";
            }
            else
                txtNombre.Text = nombreArchivo;
        }

        // Evento click del botón Aceptar que ocurrirá al presionar bótón click
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Guardo el archivo con el nombre que el usuario coloque en el textbox
            nombreArchivo = txtNombre.Text;

        }

        // Evento click del botón cancelar, esto ocurrirá al presionar click en el botón mencionado
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Se cierra el formulario en el caso de que presione cancelar
            this.Close();
        }

    }
}

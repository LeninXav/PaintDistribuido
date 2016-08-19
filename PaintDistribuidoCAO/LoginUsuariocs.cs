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
using System.Data.SqlClient;
using System.Runtime.Remoting;
using BibliotecaPaint;


namespace PaintDistribuidoCAO
{
    public partial class frmLoginUsuario : Form
    {
        public frmLoginUsuario()
        {
            InitializeComponent();
        }

        // Evento click del bótón Autentificar que se generará al hacer click
        private void btnAutentificar_Click(object sender, EventArgs e)
        {
            // Creo una variable entera que me servirá para almacenar si existe o no el usuario especificado
            int i = 0;
            // LLamo al Lienzo BDD para poder hacer la consulta a la base de datos y poder verificar si el usuario consta 
            // en la BDD para hacer la parte de autenticación
            LienzoBDD usuario = new LienzoBDD();
            // LLamo al Obtener cliente y este me devuelve si una fila ha sido afectada o no, es decir si el usuario
            // existe o no en la base de datos. La consulta si es válida se carga con 1 sino con 
            i = usuario.ObtenerCliente(txtContrasenia.Text.Trim(), txtUsuario.Text.Trim());
            // Si la consulta se ha dado y el usuario existe en la base da datos        
            if (i == 1)
            {
                // Creo un nuevo formulario ques de Lienzos clientes pero para esto la contrasenia y el usuario el cual
                // Obtengo de los textbox
                frmLienzosCliente lienzos = new frmLienzosCliente(txtContrasenia.Text.Trim(), txtUsuario.Text.Trim());
                // Muestro el form del tipoShow Dialog el cual no me permitirá acceder a otros fromularios a menos de que este se cierre
                lienzos.Show();
            }

            // Caso contrario, Si los textBox tanto Usuario como Contrasenia están vacíos
            else if (txtUsuario.Text != "" && txtContrasenia.Text != "")
            {
                // Creo un cuadro de diálogo y el cual le cargo en un message box que me mostrará en un mensaje si deseo o no agregar 
                // el usuario, y con el ícono de alerta
                DialogResult mensaje = MessageBox.Show("El usuario no existe en la base de datos, ó los datos ingresados están erróneos. \n¿Desea agregar el usuario?"
                    , "USUARIO MAL INGRESADO O NO EXISTE",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // Si presiono el botón Yes entonces
                if (DialogResult.Yes == mensaje)
                    // Cargo a la variable entera i si se agregó o no
                    i = usuario.AgregarCliente(txtUsuario.Text.Trim(), txtContrasenia.Text.Trim());
                // Si i es diferente de 0 es decir si existe el usuario, o se completó la consulta
                if (i != 0)
                {
                    // Envío un mensaje que el usuario ha sido agregado correctamente
                    MessageBox.Show("El usuario ha sido agregado correctamente");
                    // Cargo el nuevo formulario pero me debe aceptar el Usuario y la contrasenia para crear el nuevo form
                    frmLienzosCliente lienzos = new frmLienzosCliente(txtUsuario.Text, txtContrasenia.Text);
                    // Mestro el form
                    lienzos.Show();
                }
            }
            // Caso contrario
            else
                // Muestra el mensaje que no pueden existir campos vacíos
                MessageBox.Show("No pueden existir campos vacios");
        }

        // Evento Load del Formulario
        private void frmLoginUsuario_Load(object sender, EventArgs e)
        {
            // Hago que la conexión sea remota mediante CAO, ya para hacerlo distribuído
            RemotingConfiguration.Configure("PaintDistribuidoCAO.exe.config", false);
        }

        // Evento click del botón cancelar que se producirá al hacer click 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cierro el formulario
            this.Close();
        }


    }
}

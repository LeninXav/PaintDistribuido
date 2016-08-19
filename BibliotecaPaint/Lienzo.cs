// - CRISTIAN FABRICIO ESPINOSA GUALOTUÑA
// - LENIN XAVIER VELASTEGUI ALMEIDA
// APLICACIONES DISTRIBUIDAS
// PROYECTO 02 PAINT DISTRIBUIDO UTILIZANDO CAO
// 19/11/2013

/////////////////////////////////////////////////////////////////////////////
//
// Clase: Lienzo
// Proveedor de servico que nos permitirá manipular el lienzo así como lo que 
// dibujemos en el mismo
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BibliotecaPaint
{
    // Hago que la clase Figura sea serializable para que pueda ser enviado la información
    // por la red
    [Serializable]
    public class Lienzo
    {
        // Creo un arreglo de figuras para poder almacenar las figuras que han sido dibujadas 
        // en el lienzo
        private List<Figura> figuras;
        // Refactorizando para poder setar y obtener las figuras que han sido dibujadas en el lienzo
        public List<Figura> Figuras
        {
            get { return figuras; }
            set { figuras = value; }
        }
        // Creación de un objeto String contrasenia, el cuál me servirá para conocer la contraseña del cliente el cual
        // puede tener varios lienzos guardados 
        private string contrasenia;
        // Refactorización de la contrasenia que me permitirá obtener y setear la constraseña del cliente 
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        // Creación de un objeto String nombre, el cuál me servirá para conocer el nombre del lienzo el cual puede tener
        // varias figuras
        private string nombre;
        // Refactorización del nombre del lienzo que me permitirá obtener y setear el nombre de los lienzos
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // Creación de un objeto Bitmap imagen, el cuál me servirá para hacer el bitmap en el cual vamos a dibujar los lienzos 
        private Bitmap imagen;
        // Refactorización del bitmap que me permitirá obtener y setear bitmaps del Cliente        
        public Bitmap Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        // Constructor de la clase Lienzo que me aceptará un arreglo de figuras para poder enviar esa información
        public Lienzo()
        {
            figuras = new List<Figura>();
        }
    }
}

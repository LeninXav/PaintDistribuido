// - CRISTIAN FABRICIO ESPINOSA GUALOTUÑA
// - LENIN XAVIER VELASTEGUI ALMEIDA
// APLICACIONES DISTRIBUIDAS
// PROYECTO 02 PAINT DISTRIBUIDO UTILIZANDO CAO
// 19/11/2013

/////////////////////////////////////////////////////////////////////////////
//
// Clase: Figura
// Proveedor de servico que nos permitirá obtener las figuras 
// dibujadas en el lienzo
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
    public class Figura
    {
        // Creación de un objeto punto inicial, el cuál me servirá para conocer el punto inicial
        // de las figuras geométricas dibujadas en el lienzo
        private Point inicial;
        // Refactorización del puntoInicial que me permitirá obtener y setear las coordenadas del punto
        // inicial
        public Point Inicial
        {
            get { return inicial; }
            set { inicial = value; }
        }

        // Creación de un objeto punto final, el cuál me servirá para conocer el punto final
        // de las figuras geométricas dibujadas en el lienzo
        private Point final;
        // Refactorización del punto Final que me permitirá obtener y setear las coordenadas del punto
        // final
        public Point Final
        {
            get { return final; }
            set { final = value; }
        }

        // Creación de un objeto color relleno, el cuál me servirá para conocer si la figura dibujada
        // está con relleno y ver el color del relleno
        private Color relleno;
        // Refactorización del color relleno que me permitirá obtener y setear de la figura el color de relleno
        public Color Relleno
        {
            get { return relleno; }
            set { relleno = value; }
        }

        // Creación de un objeto color borde, el cuál me servirá para conocer el color del borde de la figura
        // dibujada
        private Color borde;
        // Refactorización del color borde que me permitirá obtener y setear de la figura el color del borde
        public Color Borde
        {
            get { return borde; }
            set { borde = value; }
        }

        // Creación de un objeto float grosor, el cuál me servirá para conocer el grosor del borde de la figura
        // dibujada
        private float grosor;
        // Refactorización del grosor del borde que me permitirá obtener y setear de la figura el grosor del borde
        public float Grosor
        {
            get { return grosor; }
            set { grosor = value; }
        }

        // Creación de un objeto string tipo, el cuál me servirá para conocer el tipo de figura
        // dibujada
        private string tipo;
        // Refactorización del tipo de figura que me permitirá obtener y setear de la figura su tipo
        // es decir si es un círculo, cuadrado o es una línea.
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        //Constructor de la clase Figura
        public Figura()
        {
            
        }
    }
}

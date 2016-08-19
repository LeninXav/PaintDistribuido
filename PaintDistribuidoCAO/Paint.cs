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
using System.IO;
using System.Drawing.Imaging;
using BibliotecaPaint;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting;

// Enumeraciones para realizar los respectivos dibujos
enum Figuras { Rectangulo, Circulo, Linea}

namespace PaintDistribuidoCAO
{
    public partial class frmDibujo : Form
    {
        // Declaracion de variables para realizar los graficos
        Pen pincel = null;
        Bitmap lienzo;
        Color brocha;
        Figuras dibujo;
        Point inicial;
        Point final;
        bool presionado = false;
        Lienzo graficos;
        Figura disenio;
        string nombreLienzo;
        string contrasenia;
        string usuario;

        // Constructor del formulario que para este necesito el nombre del lienzo, la contraseña y el usuario 
        public frmDibujo(string nombreLienzo, string contrasenia, string usuario)
        {
            // Cargo los componentes con el nombre del Lienzo, contrasenia y usuario 
            InitializeComponent();
            this.nombreLienzo = nombreLienzo;
            this.contrasenia = contrasenia;
            this.usuario = usuario;
        }

        // Al momento de hacer click en el botón Color Borde que me permitirá escoger el color del borde de la figura a realizarse
        // o el color de la línea
        private void tsbColorBorde_Click(object sender, EventArgs e)
        {
            // Cuando escojo un color para el borde y lo selecciono
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Creo un bitmap del color elegido para que el boton del tool strip se me pinte con el color seleccionado
                Bitmap bitmapColor = new Bitmap(15, 15);
                // Creo un objeto graphics que me permitira dibujar el botón
                Graphics grafico = Graphics.FromImage(bitmapColor);
                // LLeno el graphics con el color selccionado en el color dialog
                grafico.FillRectangle(new SolidBrush(colorDialog1.Color), 0, 0, 16, 16);
                // Y cambio la imagen del bótón por el color seleccionado
                tsbColorBorde.Image = new Bitmap(bitmapColor);
                // Libero recursos
                grafico.Dispose();
                bitmapColor.Dispose();
                // Y escojo el pincel para dibujar del color que haya seleccionado
                pincel.Color = colorDialog1.Color;
            }
        }

        // Al momento de hacer click en el botón Color Relleno que me permitirá escoger el color del relleno de la figura a realizarse
        // o el color del relleno de la figura
        private void tsbColorRelleno_Click(object sender, EventArgs e)
        {
            // Cuando escojo un color para el relleno y lo selecciono
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Creo un bitmap del color elegido para que el boton del tool strip se me pinte con el color seleccionado
                Bitmap bitmapColor = new Bitmap(15, 15);
                // Creo un objeto graphics que me permitira dibujar el botón
                Graphics grafico = Graphics.FromImage(bitmapColor);
                // LLeno el graphics con el color selccionado en el color dialog y grafico un rectángulo
                grafico.FillRectangle(new SolidBrush(colorDialog1.Color), 0, 0, 16, 16);
                // Y cambio la imagen del bótón por el color seleccionado
                tsbColorRelleno.Image = new Bitmap(bitmapColor);
                // Libero Recursos
                grafico.Dispose();
                bitmapColor.Dispose();
                // Selecciono el color de la brocha para pintar el relleno con el color seleccionado
                brocha = colorDialog1.Color;
            }
        }

        // Al momento de hacer click en el tool strip buttom de dibujar una linea
        private void tsbDibujarLinea_Click(object sender, EventArgs e)
        {
            // Llamo a dibujar una linea
            dibujo = Figuras.Linea;
        }

        // Evento Mouse Down esto ocurre cunado presiono el mouse (mientras lo tengo presionado)
        private void picLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            // La variable presionado se pone en true es decir que si está presionado el mouse
            presionado = true;
            // Defino un punto inicial tomando las coordenadas X y Y iniciales
            inicial = new Point(e.X, e.Y);
        }

        // Evento Mouse Up esto ocurre cunado suelto el mouse
        private void picLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            // Creo el punto final obteniendo las coordenadas en X y Y
            final = new Point(e.X, e.Y);
            //Hacemos la comprobacion de la posicion del punto final
            if (final.X < inicial.Y || final.Y < inicial.Y)
            {
                //intercambiamos el punto final e inicial para poder graficar correctamente
                Point aux = inicial;
                inicial = final;
                final = aux;
            }
            // Si el presionado está activaso
            if (presionado)
            {
                // Creo un nuevo graphics de lo que quiero que se dibuje en el lienzo
                Graphics grafico = Graphics.FromImage(lienzo);
                // Comienzo hacer un switch para los diferentes dibujos(tipos)
                switch (dibujo)
                {
                    // Caso en el que dibujo un círculo
                    case Figuras.Circulo:
                        grafico.DrawEllipse(pincel, inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                        SinRelleno("Circulo", pincel, inicial, final);
                        // Si la brocha tiene un color distinto de Blanco (no es de color de blanco)
                        if (!brocha.Equals(Color.White))
                        {
                            // Grafico el relleno si lo tiene sino el color por default es blanco 
                            grafico.FillEllipse(new SolidBrush(brocha), inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                            // HAgo el relleno de la figura en este caso Círculo con todos los parámetros necesarios
                            ConRelleno("Circulo", brocha, pincel, inicial, final);
                        }
                        break;
                    // Caso en el que deseo graficar una línea
                    case Figuras.Linea:
                        // Dibujo una linea para lo cual necesito el color del pincel el punto inicial y final
                        grafico.DrawLine(pincel, inicial, final);
                        // Como no se necesita relleo solo cono eso y sus parámetros
                        SinRelleno("Linea", pincel, inicial, final);
                        break;
                    // Caso en el que dibujo un rectángulo
                    case Figuras.Rectangulo:
                        grafico.DrawRectangle(pincel, inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                        SinRelleno("Rectangulo", pincel, inicial, final);
                        // En el caso de dibujar con relleno
                        if (!brocha.Equals(Color.White))
                        {
                            // Hago el relleno con el color de la brocha que haya seleccionado
                            grafico.FillRectangle(new SolidBrush(brocha), inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                            // LLamo a dibujar con relleno con los parámetros necesarios
                            ConRelleno("Rectangulo", brocha, pincel, inicial, final);
                        }
                        break;
                }
                // Cargo lo del picture box en el lienzo
                picLienzo.Image = (Image)lienzo;
                // Libero Recursos
                grafico.Dispose();
            }
            // Se pone la variable presionado false
            presionado = false;
        }

        // Evento que ocurrirá al momento de dibuja un cuadrado
        private void tsbDibujarCuadrado_Click(object sender, EventArgs e)
        {
            // Dibujo el rectángulo
            dibujo = Figuras.Rectangulo;
        }

        // Evento que ocurrirá al momento de dibuja un Círculo
        private void tsbDibujarCirculo_Click(object sender, EventArgs e)
        {
            // Mando a dibujar el círculo
            dibujo = Figuras.Circulo;
        }

        // Evento Load del formulario
        private void frmDibujo_Load(object sender, EventArgs e)
        {
            this.Text = nombreLienzo;
            // Por defecto el pincel está en color negro y de tamaño 1
            pincel = new Pen(Color.Black, 1);
            // Creo un bitmao de 15*15 
            Bitmap bitmapColor = new Bitmap(15, 15);
            // Creo un grafico del tipo Graphics y le cargo el bitmap
            Graphics grafico = Graphics.FromImage(bitmapColor);
            // Dibujo un rectangulo con el color por defecto y la brocha del mismo color por default negro
            grafico.FillRectangle(new SolidBrush(Color.Black), 0, 0, 16, 16);
            // El color de borde por defecto es negro
            tsbColorBorde.Image = new Bitmap(bitmapColor);
            // Brocha por defecto del color blanco           
            brocha = Color.White;
            // Dibujo en el ícono y lo relleno con color blanco
            grafico.FillRectangle(new SolidBrush(Color.White), 0, 0, 16, 16);
            // El botón ColorRelleno lo dibujo como lo puse
            tsbColorRelleno.Image = new Bitmap(bitmapColor);
            // Libero Recursos
            grafico.Dispose();
            bitmapColor.Dispose();
            // Creo un nuevo bitmap con los tamaños del picture box
            lienzo = new Bitmap(picLienzo.Width, picLienzo.Height);
            // Hago un casting a pic lienzo y lo convierto en image
            picLienzo.Image = (Image)lienzo;
            // A gráficos le asigno un nuevo Lienzo
            graficos = new Lienzo();
            // Si el nombre del lienzo es diferente de Nuevo 
            if (!nombreLienzo.Equals("Nuevo"))
            {
                // creo un nuevo objeto del tipo LienzoBDD que me servirá para obtener los lienzos que tiene el cliente
                LienzoBDD usuario = new LienzoBDD();
                // Llamo al métodoObtener lienzo por el nombre del lienzo y su contrasenia del cliente
                graficos.Figuras = usuario.ObtenerLienzo(nombreLienzo, contrasenia);
                // LLamo al método dibujar
                Dibujar();
            }
        }

        // Al momento de seleccionar los diferentes grosores para el borde y las líneas
        // Al hacer esto se modifica el grosor del pincel
        private void tsbmn1_Click(object sender, EventArgs e)
        {
            pincel.Width = 1;
        }

        private void tsbmn2_Click(object sender, EventArgs e)
        {
            pincel.Width = 3;
        }

        private void tsbmn3_Click(object sender, EventArgs e)
        {
            pincel.Width = 5;
        }

        private void tsbmn4_Click(object sender, EventArgs e)
        {
            pincel.Width = 7;
        }

        private void tsbmn5_Click(object sender, EventArgs e)
        {
            pincel.Width = 9;
        }

        // Evento que se producirá al hacer click en el boton guardar
        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            // Creo un nuevo bitmap con el ancho y largo del lienzo
            Bitmap fondo = new Bitmap(lienzo.Width, lienzo.Height);
            // Creo un grafico del tipo Graphics que le ingreso el lienzo
            Graphics g = Graphics.FromImage(fondo);
            // Lo guardo al liezno con el color especificado el ancho el largo y las posiciones
            g.FillRectangle(new SolidBrush(picLienzo.BackColor), 0, 0, lienzo.Width, lienzo.Height);
            // Libero recursos
            g.Dispose();
            // Creo otro grafico que me ingresará el fondo
            Graphics g1 = Graphics.FromImage(fondo);
            // Me permitirá guardar la imagen 
            g1.DrawImage(lienzo, 0, 0);
            // Lo vuelvo a comvertir a bitmap
            lienzo = new Bitmap(fondo);
            // Libero Recursos de los Graphics
            g1.Dispose();
            fondo.Dispose();
            // Creo una variable entera para saber si se guardó o no
            int i = 0;
            // Creo un nuevo Lienzo que me permitirá guardar el lienzo
            BibliotecaPaint.LienzoBDD usuario = new LienzoBDD();
            // Guardar mensaje para poder guardar con el nombre adecuado
            Guardar mensaje = new Guardar(nombreLienzo);
            // Creo un dialog result para aceptar si debo guardarme o no el lienzo
            DialogResult s = mensaje.ShowDialog();
            // Si se acepta guardar 
            if (s == DialogResult.OK)
            {
                if (mensaje.nombreArchivo == nombreLienzo)
                {
                    i = usuario.ActualizarCliente(nombreLienzo, graficos.Figuras);
                }
                else
                {
                    // Guardo al lienzo con el nombre especificado
                    nombreLienzo = mensaje.nombreArchivo;
                    // Compruebo que se ha verificado que se ha guardado el lienzo
                    i = usuario.AgregarLienzo(nombreLienzo, contrasenia, graficos.Figuras);
                }
            }
            // Si la variable es distinta de 0 quiere decir que se ha guardado
            if (i != 0)
                // envío un mensaje que el lienzo se ha agregado
                MessageBox.Show("Lienzo Agregado o Actualizado: " + nombreLienzo);
            this.Text = nombreLienzo;
        }

        // Evento que se producirá al momento de abrir
        private void tsbAbrir_Click(object sender, EventArgs e)
        {
            this.Close();
            
            //// Creo un nuevo O
            //OpenFileDialog s = new OpenFileDialog();
            //s.Filter = "Archivos bitmap|*.bmp";
            //if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    if (s.FileName.Contains(".bmp"))
            //    {
            //        //lienzo = new Bitmap(Image.FromFile(s.FileName));
            //        //picLienzo.Image = (Image)lienzo;
            //        BinaryFormatter formatter = new BinaryFormatter();
            //        Stream stream = File.Open("MyFile.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            //        graficos.Figuras = (List<Figura>)formatter.Deserialize(stream);
            //        stream.Close();
            //        Dibujar();
            //    }
            //}
        }

        // Evento que se generará al momento de hacer click para uni nuevo proyecto
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            //Este messagebox permite hacer una pregunta que si se desea guradar los cambios efectuados
            if (MessageBox.Show("Desea Guardar los cambios efectuados", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                int i = 0;
                // Creo un nuevo Lienzo que me permitirá guardar el lienzo
                BibliotecaPaint.LienzoBDD usuarioGuardar = new LienzoBDD();
                // Guardar mensaje para poder guardar con el nombre adecuado
                Guardar mensaje = new Guardar(nombreLienzo);
                // Creo un dialog result para aceptar si debo guardarme o no el lienzo
                DialogResult s = mensaje.ShowDialog();
                // Si se acepta guardar 
                if (s == DialogResult.OK)
                {
                    if (mensaje.nombreArchivo == nombreLienzo)
                    {
                        i = usuarioGuardar.ActualizarCliente(nombreLienzo, graficos.Figuras);
                    }
                    else
                    {
                        // Guardo al lienzo con el nombre especificado
                        nombreLienzo = mensaje.nombreArchivo;
                        // Compruebo que se ha verificado que se ha guardado el lienzo
                        i = usuarioGuardar.AgregarLienzo(nombreLienzo, contrasenia, graficos.Figuras);
                    }
                }
                // Si la variable es distinta de 0 quiere decir que se ha guardado
                if (i != 0)
                    // envío un mensaje que el lienzo se ha agregado
                    MessageBox.Show("Lienzo Agregado o Actualizado: " + nombreLienzo);
            }
            this.Text = "Nuevo";
            // Creo un nuevo grafico y le cargo el lienzo en blanco
            Graphics grafico = Graphics.FromImage(lienzo);
            // Pongo el color del lienzo en blanco y le cargo con las dimensiones de ancho y largo
            grafico.FillRectangle(new SolidBrush(picLienzo.BackColor), 0, 0, lienzo.Width, lienzo.Height);
            // Libero recursos
            grafico.Dispose();
            // Hago una conversión del lienzo a Image
            picLienzo.Image = (Image)lienzo;
        }

        // Método al momento de poner con relleno
        private void SinRelleno(string tipo, Pen pincel, Point inicial, Point final)
        {
            // Defino todos los parámetros al momento de seleccionar sin relleno
            disenio = new Figura();
            // El borde va a ser del color del pincle
            disenio.Borde = pincel.Color;
            // Defino el grosor del pincle
            disenio.Grosor = pincel.Width;
            // Defino los puntos inicial y final
            disenio.Inicial = inicial;
            disenio.Final = final;
            // el relleno va a ser blanco 
            disenio.Relleno = Color.White;
            // Selecciono que tipo de figura deseo graficar
            disenio.Tipo = tipo;
            // Voy añadiendo las figuras a la lista de figuras
            graficos.Figuras.Add(disenio);
        }

        // Método que se generará al momento de seleccionar con relleno
        private void ConRelleno(string tipo, Color relleno, Pen pincel, Point inicial, Point final)
        {
            // Defino todos los parámetros al momento de graficar con relleno como es el color, grosos, puntos inicial y 
            // el tipo de figura y para añadir a la lista de figuras
            disenio = new Figura();
            disenio.Borde = pincel.Color;
            disenio.Grosor = pincel.Width;
            disenio.Inicial = inicial;
            disenio.Relleno = relleno;
            disenio.Final = final;
            disenio.Tipo = tipo;
            graficos.Figuras.Add(disenio);
        }

        // Método que me permitirá dibujar las diferentes figuras
        private void Dibujar()
        {
            // Hago un objeto del tipo Graphics y lo cargo el lienzo
            Graphics grafico = Graphics.FromImage(lienzo);
            // Lazo for each que me iterará en figuras
            foreach (Figura f in graficos.Figuras)
            {
                // Defino todos los parámetros de la figura borde, grosos, punto inicial, final
                // si es con relleno 
                pincel.Color = f.Borde;
                pincel.Width = f.Grosor;
                inicial = f.Inicial;
                final = f.Final;
                brocha = f.Relleno;
                // Switch para el tipo de figura
                switch (f.Tipo)
                {
                    // En el caso que quiero dibujar circulo
                    case "Circulo":
                        grafico.DrawEllipse(pincel, inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                        // COndición para verificar si es con rellono o no
                        if (!brocha.Equals(Color.White))
                            grafico.FillEllipse(new SolidBrush(brocha), inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                        break;
                    // Caso para dibujar una línea
                    case "Linea":
                        grafico.DrawLine(pincel, inicial, final);
                        break;
                    // Caso para dibujar un rectángulo
                    case "Rectangulo":
                        grafico.DrawRectangle(pincel, inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                        // Condición para verificar si es con rellono o no
                        if (!brocha.Equals(Color.White))
                        {
                            grafico.FillRectangle(new SolidBrush(brocha), inicial.X, inicial.Y, final.X - inicial.X, final.Y - inicial.Y);
                        }
                        break;
                }
            }
            // Hago la conversión del picture a Image
            picLienzo.Image = (Image)lienzo;
            // Libero Recursos
            grafico.Dispose();
        }

        // Evento al momento de cerrar el formulario
        private void frmDibujo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Este messagebox permite hacer una pregunta que si se desea guradar los cambios efectuados
            if (MessageBox.Show("Desea Guardar los cambios efectuados", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                int i = 0;
                // Creo un nuevo Lienzo que me permitirá guardar el lienzo
                BibliotecaPaint.LienzoBDD usuarioGuardar = new LienzoBDD();
                // Guardar mensaje para poder guardar con el nombre adecuado
                Guardar mensaje = new Guardar(nombreLienzo);
                // Creo un dialog result para aceptar si debo guardarme o no el lienzo
                DialogResult s = mensaje.ShowDialog();
                // Si se acepta guardar 
                if (s == DialogResult.OK)
                {
                    if (mensaje.nombreArchivo == nombreLienzo)
                    {
                        i = usuarioGuardar.ActualizarCliente(nombreLienzo, graficos.Figuras);
                    }
                    else
                    {
                        // Guardo al lienzo con el nombre especificado
                        nombreLienzo = mensaje.nombreArchivo;
                        // Compruebo que se ha verificado que se ha guardado el lienzo
                        i = usuarioGuardar.AgregarLienzo(nombreLienzo, contrasenia, graficos.Figuras);
                    }
                }
                // Si la variable es distinta de 0 quiere decir que se ha guardado
                if (i != 0)
                    // envío un mensaje que el lienzo se ha agregado
                    MessageBox.Show("Lienzo Agregado o Actualizado: " + nombreLienzo);
            }
            this.Dispose();
            // Creo un nuevo formulario frmLienzosClientes que me acepta por argumentos contrasnia y usuario
            frmLienzosCliente cliente = new frmLienzosCliente(contrasenia, usuario);
            // Muestro el formulario
            cliente.Show();
        }
    }
}

// CRISTIAN FABRICIO ESPINOSA GUALOTUÑA - LENIN XAVIER VELASTEGUI ALMEIDA
// APLICACIONES DISTRIBUÍDAS
// 22/11/2013
// PROYECTO 02 APLICACIONES DISTRIBUIDAS
// PAINT DISTRIBUIDO USANDO CAO

using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace BibliotecaPaint
{
    public class LienzoBDD : MarshalByRefObject
    {
        // Defino un String estático para la conexión de la base de datos    
        public static string cadenaConexion = "Data Source=Cristian-PC;Initial Catalog=Paint_Proyecto;Integrated Security=True";

        // Método ObtenerCliente que me permitirá obtener el Cliente mediante el idCliente en el formulario LoginUsuario
        public int ObtenerCliente(string idCliente, string nombreCliente)
        {
            //int dato = Convert.ToInt32(idCliente.ToString());
            // Uso en un string la sentencia De SQL para la búsqueda del Cliente mediante
            // el ID
            string sentenciaSql = "SELECT COUNT (*) from Usuario";
            sentenciaSql += " WHERE contrasenia=" +"'"+idCliente+"'";
            sentenciaSql += " AND usuario="+"'"+nombreCliente+"'";
            //MessageBox.Show(sentenciaSql);
            // Hago la conexión a la base de Datos la cual le paso la cadena de consulta
            // y la conexión
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(sentenciaSql, conexion);
            // Creo un Cliente con los datos, y le inicializamos como nulo
            /*string usuarioNombre = null;
            string contrasenia = null;
            string[] cliente = new string[2];*/
            int i = 0;
            // Captura de Excepciones
            try
            {
                // Abro la conexión
                conexion.Open();
                // Creo un SqlReader para leer las filas y lo inicio en null
                //SqlDataReader leer = null;
                // Asigno a la variable el leer que lo que la ejecución de la consulta realizada
                //leer = comando.ExecuteNonQuery;
                
                i = (Int32)comando.ExecuteScalar();
                // Si me leyó la conslta enviada
                /*if (leer.Read())
                {
                    // Creo un nuevo ClienteDetalle con los campos clienteID, NombreCompleto
                    // Contraseña y Correo
                    usuarioNombre = leer["usuario"].ToString().Trim();
                    contrasenia = leer["contrasenia"].ToString().Trim();
                    cliente[0] = usuarioNombre;
                    cliente[1] = contrasenia;
                }*/
            }
            // Captura de la excepción del tipo SQL
            catch (SqlException e)
            {
                //MessageBox.Show(e.ToString());
                // Defino a cliente como null
                i = 0;
            }
            // Esto pasará ocurra o no la excepción
            finally
            {
                // Cierro la conexión
                conexion.Close();
            }
            
            // Me retorna un cliente
            return i;
        }

        // Método ObtenerCliente que me permitirá obtener el Cliente mediante el idCliente en el formulario LoginUsuario
        public List<string> ObtenerLienzos(string idCliente)
        {
            //int dato = Convert.ToInt32(idCliente.ToString());
            // Uso en un string la sentencia De SQL para la búsqueda del Cliente mediante
            // el ID
            string sentenciaSql = "SELECT nombreLienzo from Lienzo";
            sentenciaSql += " WHERE contrasenia=" + "'" + idCliente + "'";

            // Hago la conexión a la base de Datos la cual le paso la cadena de consulta
            // y la conexión
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(sentenciaSql, conexion);
            // Creo un Cliente con los datos, y le inicializamos como nulo
            List<string> lienzos = new List<string>();
            // Captura de Excepciones
            try
            {
                // Abro la conexión
                conexion.Open();
                // Creo un SqlReader para leer las filas y lo inicio en null
                SqlDataReader leer = null;
                // Asigno a la variable el leer que lo que la ejecución de la consulta realizada
                leer = comando.ExecuteReader();
                // Si me leyó la conslta enviada
                while (leer.Read())
                {
                    // Creo un nuevo ClienteDetalle con los campos clienteID, NombreCompleto
                    // Contraseña y Correo
                    lienzos.Add(leer["nombreLienzo"].ToString().Trim());
                }
            }
            // Captura de la excepción del tipo SQL
            catch (SqlException)
            {
                // Defino a cliente como null
                lienzos = null;
            }
            // Esto pasará ocurra o no la excepción
            finally
            {
                // Cierro la conexión
                conexion.Close();
            }

            // Me retorna un cliente
            return lienzos;
        }
        // Método para Agregar un Cliente que toma por argumentos un objeto ClienteDetalle
        public int AgregarCliente(string clienteNombre, string contrasenia)
        {
            // Ingreso la sentencia para realizar la inserción de un usuario en la base de datos
            // Mediate sentencias SQL
            string sentenciaSql = "INSERT INTO Usuario ";
            sentenciaSql += "(usuario, contrasenia) VALUES ('";
            // Añado el Nombre
            sentenciaSql += clienteNombre + "', '";
            // Añado el Password
            sentenciaSql += contrasenia + "')";
            // Esto hago para que me realice la conexión a la Base de Datos y me pueda actualizar
            // Para ello llamo al método EjecutarSentencias
            return EjecutarSentencia(sentenciaSql);
        }


        public int AgregarLienzo(string nombreLienzo, string contrasenia, List<Figura> objetos)
        {
            // Ingreso la sentencia para realizar la inserción de un usuario en la base de datos
            // Mediate sentencias SQL
            byte[] datos = Serializar(objetos);
            string parametro = BitConverter.ToString(datos);
            string sentenciaSql = "INSERT INTO Lienzo";
            sentenciaSql += "(nombreLienzo, contrasenia, datos) VALUES ('";
            // Añado el Nombre
            sentenciaSql += nombreLienzo + "', '";
            // Añado el Password
            sentenciaSql += contrasenia + "', '";
            sentenciaSql += parametro +"')";
            // Esto hago para que me realice la conexión a la Base de Datos y me pueda actualizar
            // Para ello llamo al método EjecutarSentencias
            return EjecutarSentencia(sentenciaSql);
            
        }
        
        // Método que me permite ActualizarCliente y que me acepta como parámetro de entrada un objeto
        // ClienteDetalle
        public int ActualizarCliente(string nombreLienzo, List<Figura> objetos)
        {
            // Ingreso la sentencia para realizar la inserción de un usuario en la base de datos
            // Mediate sentencias SQL
            byte[] datos = Serializar(objetos);
            string parametro = BitConverter.ToString(datos);
            // Ingreso la sentencia para realizar la actualización de un usuario en la base de datos
            // Mediate sentencias SQL 
            string sentenciaSql = "UPDATE Lienzo SET ";
            // Modifico el Nombre del Cliente
            sentenciaSql += "datos='" + parametro + "'";
            // Para llevar el proceso de actualización lo ubico al cliente mediante el clienteId
            sentenciaSql += " WHERE nombreLienzo='" + nombreLienzo + "'";
            // Esto hago para que me realice la conexión a la Base de Datos y me pueda actualizar
            // Para ello llamo al método EjecutarSentencias
            return EjecutarSentencia(sentenciaSql);
        }

        // Método para Eliminar un Cliente o para esto ingreso el ID del cliente
        public List<Figura> ObtenerLienzo(string nombreLienzo, string contrasenia)
        {
            string sentenciaSql = "SELECT datos from Lienzo";
            sentenciaSql += " WHERE contrasenia=" + "'" + contrasenia + "'";
            sentenciaSql += " AND nombreLienzo=" + "'" + nombreLienzo + "'";

            // Hago la conexión a la base de Datos la cual le paso la cadena de consulta
            // y la conexión
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(sentenciaSql, conexion);
            // Creo un Cliente con los datos, y le inicializamos como nulo
            List<Figura> figuras = null;
            // Captura de Excepciones
            try
            {
                // Abro la conexión
                conexion.Open();
                // Creo un SqlReader para leer las filas y lo inicio en null
                SqlDataReader leer = null;
                // Asigno a la variable el leer que lo que la ejecución de la consulta realizada
                leer = comando.ExecuteReader();
                // Si me leyó la conslta enviada
                if (leer.Read())
                {
                    // Creo un nuevo ClienteDetalle con los campos clienteID, NombreCompleto
                    // Contraseña y Correo
                    string datos = leer["datos"].ToString().Trim();
                    string datosValidos = datos.Replace("-",string.Empty);
                    int numeroCaracteres = datosValidos.Length;
                    byte[] bytes = new byte[numeroCaracteres/2];
                    for (int i = 0; i < numeroCaracteres; i += 2)
                        bytes[i / 2] = Convert.ToByte(datosValidos.Substring(i, 2), 16);
                    figuras = (List<Figura>)Deserializar(bytes);

                    /*using (var sr = new StringReader(datosValidos))
                    {
                        for (int i = 0; i < datosValidos.Length; i++)
                            bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
                            MessageBox.Show(bytes[1].ToString());
                    }
                    figuras = (List<Figura>)Deserializar(bytes);
                    */
                }
            }
            // Captura de la excepción del tipo SQL
            catch (SqlException)
            {
                // Defino a cliente como null
                figuras = null;
            }
            // Esto pasará ocurra o no la excepción
            finally
            {
                // Cierro la conexión
                conexion.Close();
            }

            // Me retorna un cliente
            return figuras;
        }

        // Método que me permitirá realizar la conexión a la Base de datos
        // Mediante sentencias SQL
        private int EjecutarSentencia(string sentenciaSql)
        {
            // Realizo una nueva conexion SQL mediante la cadena de conexion
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            // Creo un SQL comando y le ingreso la sentencia que deseo que realice y la conexión
            SqlCommand comando = new SqlCommand(sentenciaSql, conexion);
            // Creo un a variable entera resultado y la inicializo en 0
            int resultado = 0;
            // Captura de Excepciones
            try
            {
                // Abro la conexión
                conexion.Open();
                // Asigno a resultado el número de filas afectadas por la consulta SQL
                resultado = comando.ExecuteNonQuery();
            }
            // Captura de la excepción
            catch (SqlException)
            {
                // Cuando no haya ninguna fila afectada el resultado es 0
                resultado = 0;
            }
            // Finalmente esto pasará ocurra o no la excepción
            finally
            {
                // Cierro la conexión
                conexion.Close();
            }
            // Me retorna el resultado
            return resultado;
        }
        /*
        public string ObtenerDominioActual()
        {
            // Me retorna el dominio actual
            return AppDomain.CurrentDomain.FriendlyName;
        }
        */

        // Método que me retorna un arreglo de bytes y me va a permitir serailizar todas las figuras que tengamos en nuestro
        // Lienzo
        public byte[] Serializar(List<Figura> objSerializable)
        {
            // Vamos a controlar el tiempo de vida de los objetos mediante el uso de Using y creamos una memoria de flujos
            // que me permitirá almacenar de forma binaria la inforamción de las figuras
            using (MemoryStream stream = new MemoryStream())
            {
                // Creo el formato binario para enviar de esta forma a la base de datos y poder enviar como bytes
                BinaryFormatter binario = new BinaryFormatter();
                // Serializo los datos que voy a enviar en este caso el arreglo de figuras
                binario.Serialize(stream, objSerializable);
                // Me retorna el flujo y lo convierto a un arreglo de bytes
                return stream.ToArray();
            }
        }

        // Método que me permitirá deserializar lso objetos que hemos enviado para poder regenerar la imagen(Lienzo) y poder de nuevo
        // obtener
        public object Deserializar(byte[] objDeserializable)
        {
            // Vamos a controlar el tiempo de vida de los objetos mediante el uso de Using y creamos una memoria de flujos
            // que me permitirá almacenar de forma binaria la inforamción de las figuras
            using (MemoryStream stream = new MemoryStream(objDeserializable))
            {
                // Creo el formato binario para enviar de esta forma a la base de datos y poder enviar como bytes
                BinaryFormatter binario = new BinaryFormatter();
                // Comienzo a leer desde la posicion 0 elflujo
                stream.Position = 0;
                // Me retorna todo los datos serializados
                return binario.Deserialize(stream);
            }
        }
    }
}

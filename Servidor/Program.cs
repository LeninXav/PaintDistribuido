// CRISTIAN FABRICIO ESPINOSA GUALOTUÑA - LENIN XAVIER VELASTEGUI ALMEIDA
// APLICACIONES DISTRIBUÍDAS
// 22/11/2013
// PROYECTO 02 APLICACIONES DISTRIBUIDAS
// PAINT DISTRIBUIDO USANDO CAO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using BibliotecaPaint;


namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Utilizando Remoting hago la llamada al Archivo de configuración y en seguridades
            // No coloco nada por el momento xq no tenemos el conocimiento
            RemotingConfiguration.Configure("Servidor.exe.config", false);
            Console.ReadLine();
        }
    }
}

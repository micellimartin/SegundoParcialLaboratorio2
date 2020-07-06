using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{  
    public class ArchivoTxt : Archivo
    {
        /// <summary>
        /// Guarda la informacion de los errores surgidos durante la ejecucion del programa en un archivo.txt
        /// </summary>
        /// <param name="texto">Informacion del error ocurrido</param>
        public static void GuardarEnLog(string texto)
        {
            //Si el archivo existe lo crea, caso contrario le anexa la informacon nueva
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\LOG PARCIAL LABORATORIO 2.txt", true);
            sw.WriteLine(texto);
            sw.Close();
        }
    }
}

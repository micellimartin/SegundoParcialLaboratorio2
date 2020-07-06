using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Archivo
    {
        /// <summary>
        /// Verifica que el archivo exista validando su ruta
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <returns>True si existe, caso contrario false</returns>
        protected bool ValidarArchivo(string path)
        {
            return File.Exists(path);
        }
    }
}

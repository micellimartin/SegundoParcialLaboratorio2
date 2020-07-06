using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    /// <summary>
    /// Extiende la funcionalidad de la clase AchivXml
    /// </summary>
    public static class ExtensionArchivo
    {
        /// <summary>
        /// Generar una copia de el archivo Xml que contiene la lista de docentes
        /// </summary>
        /// <param name="archivo">La clase a extender</param>
        /// <returns>True si tuvo exito, false caso contrario</returns>
        public static bool BackearDocentes(this ArchivoXml<Alumno> archivo)
        {
            bool exito = false;

            //Carpeta que quiero backear
            string pathObjetivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SegundoParcialUtn\\JardinUtn\\Docentes\\Docentes.Xml";
            //Carpeta donde se hara la copia
            string pathDestino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DocentesBackUp.Xml";

            File.Copy(pathObjetivo, pathDestino);

            exito = true;

            return exito;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades
{
     public class ArchivoBin<T> : Archivo, IMetodosArchivos<Alumno>
    {
        /// <summary>
        /// Serializa un alumno en binario en la ruta especificada. Si esta no existe, la crea
        /// </summary>
        /// <param name="alumno">Alumno a serializar</param>
        /// <param name="path">Ruta donde se creara el archivo Xml que contiene al alumno</param>
        /// <returns>True si tuvo exito, false caso conotrario</returns>
        public bool Guardar(Alumno alumno, string path)
        {
            bool exito = false;
            bool flagArchivoCreado = false;

            //Si la ruta no existe, se crea
            if (!(ValidarArchivo(path)))
            {
                FileStream fs = new FileStream(path, FileMode.CreateNew);
                fs.Close();
                flagArchivoCreado = true;
            }

            try
            {
                Stream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter serializdorBin = new BinaryFormatter();
                serializdorBin.Serialize(fs, alumno);
                fs.Close();
                exito = true;

                //Si tuve que crear el archivo porque la ruta era inexistente lanzo una excepcion
                if (flagArchivoCreado)
                {
                    throw new ArchivoCreadoException(path);
                }
            }
            catch (ArchivoCreadoException excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("El siguiente archivo binario fue creado: " + excepcion.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return exito;
        }

        /// <summary>
        /// Deserializa un objeto Alumno almacenada en un archivo binario
        /// </summary>
        /// <param name="path">Ruta del archivo binario que contiene al alumno</param>
        /// <returns>El alumno deserializado</returns>
        public Alumno Leer(string path)
        {
            Alumno retorno = null;

            try
            {
                Stream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter serializdorBin = new BinaryFormatter();
                retorno = (Alumno)serializdorBin.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class ArchivoXml<T> : Archivo, IMetodosArchivos<Alumno>
    {
        /// <summary>
        /// Serializa un alumno en Xml en la ruta especificada. Si esta no existe, la crea
        /// </summary>
        /// <param name="a">Alumno a serializar</param>
        /// <param name="path">Ruta donde se creara el archivo Xml que contiene al alumno</param>
        /// <returns>True si tuvo exito, false caso conotrario</returns>
        public bool Guardar(Alumno a, string path)
        {
            bool guardoConExito = false;
            bool flagArchivoCreado = false;

            //Si la ruta no existe, se crea
            if(!(ValidarArchivo(path)))
            {
                FileStream fs = new FileStream(path, FileMode.CreateNew);
                fs.Close();
                flagArchivoCreado = true;
            }

            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                XmlSerializer serializador = new XmlSerializer(typeof(Alumno));
                serializador.Serialize(writer, a);
                writer.Close();

                guardoConExito = true;

                //Si tuve que crear el archivo porque la ruta era inexistente lanzo una excepcion
                if(flagArchivoCreado)
                {
                    throw new ArchivoCreadoException(path);
                }
            }
            catch (ArchivoCreadoException excepcion)
            {
                //Se registra la informacion de la excepcion en un archivo txt
                ArchivoTxt.GuardarEnLog("El siguiente archivo Xml fue creado: " + excepcion.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return guardoConExito;
        }

        /// <summary>
        /// Deserializa un objeto Alumno almacenada en un archivo Xml
        /// </summary>
        /// <param name="path">Ruta del archivo Xml que contiene al alumno</param>
        /// <returns>El alumno deserializado</returns>
        public Alumno Leer(string path)
        {
            Alumno retorno = null;

            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                XmlSerializer serializador = new XmlSerializer(typeof(Alumno));
                retorno = (Alumno)serializador.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        /// <summary>
        /// Deserializa una lista de objetos Docente contenido en la ruta pasada como parametro
        /// </summary>
        /// <param name="path">Ruta que contiene la lista de docentes</param>
        /// <returns>La lista de docentes deserializada</returns>
        public List<Docente> LeerLista(string path)
        {
            List<Docente> listaDocente = null;           

            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                XmlSerializer serializador = new XmlSerializer(typeof(List<Docente>));
                listaDocente = (List<Docente>)serializador.Deserialize(reader);
                reader.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
            
            return listaDocente;
        }
    }
}

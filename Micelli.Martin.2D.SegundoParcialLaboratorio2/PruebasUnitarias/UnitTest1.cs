using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.IO;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSerializarAlumnoXml()
        {
            //Arrange
            Alumno a = new Alumno("Juan", "Sarmiento", 5, 39123456, "Calle false 123", 1, "7");

            string fecha = DateTime.Now.ToString("dd_MM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".xml";

            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;

            //Act
            serializador.Guardar(a, path);

            //Assert
            Assert.IsTrue(File.Exists(path));          
        }

        [TestMethod]
        public void TestDeserializarAlumnoXml()
        {
            //Arrange
            Alumno a = new Alumno("Pepito", "Peposo", 5, 39123456, "Calle false 123", 1, "7");
            Alumno b = null;

            string fecha = DateTime.Now.ToString("dd_MM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".xml";

            ArchivoXml<Alumno> serializador = new ArchivoXml<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;

            //Act
            //Primero lo serializo y despues lo deserializo
            serializador.Guardar(a, path);
            b = serializador.Leer(path);

            //Assert
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void TestSerializarAlumnoBin()
        {
            //Arrange
            Alumno a = new Alumno("Pedro", "Peralta", 5, 39123456, "Calle false 123", 1, "7");

            string fecha = DateTime.Now.ToString("dd_MM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".bin";

            ArchivoBin<Alumno> serializador = new ArchivoBin<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;

            //Act
            serializador.Guardar(a, path);

            //Assert
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void TestDeserializarAlumnoBin()
        {
            //Arrange
            Alumno a = new Alumno("Romina", "Martinez", 5, 39123456, "Calle false 123", 1, "7");
            Alumno b = null;

            string fecha = DateTime.Now.ToString("dd_MM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".bin";

            ArchivoBin<Alumno> serializador = new ArchivoBin<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;

            //Act
            //Primero serializo y despues deserializo
            serializador.Guardar(a, path);
            b = serializador.Leer(path);

            //Assert
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void TestDeserializarAlumnoBinAtributos()
        {
            //Arrange
            Alumno a = new Alumno("Eduard", "Jimenez", 5, 39123456, "Calle false 123", 1, "7");
            Alumno b = null;

            string fecha = DateTime.Now.ToString("dd_MM_yyyy");
            string nombreArchivo = a.Apellido + "_" + a.Nombre + "_" + fecha + ".bin";

            ArchivoBin<Alumno> serializador = new ArchivoBin<Alumno>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;

            //Act
            //Primero serializo y despues deserializo
            serializador.Guardar(a, path);
            b = serializador.Leer(path);

            //Assert
            Assert.IsTrue(a.IdAlumno == b.IdAlumno);     
            Assert.IsTrue(a.Nombre == b.Nombre);
            Assert.IsTrue(a.Apellido == b.Apellido);
            Assert.IsTrue(a.Edad == b.Edad);
            Assert.IsTrue(a.Dni == b.Dni);
            Assert.IsTrue(a.Direccion == b.Direccion);
            Assert.IsTrue(a.Responsable == b.Responsable);
        }

        [TestMethod]
        public void TestMetodoExtensionBackearDocentes()
        {
            //Arrange
            ArchivoXml<Alumno> instanciaArchivoXml = new ArchivoXml<Alumno>();
            string ubicacionBackUp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DocentesBackUp.Xml";

            //Act
            instanciaArchivoXml.BackearDocentes();

            //Assert
            Assert.IsTrue(File.Exists(ubicacionBackUp));
        }
    }
}

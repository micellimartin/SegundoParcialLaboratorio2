using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Alumno : Persona
    {
        private int idAlumno;
        private string responsable;
        private float notaFinal;

        #region Propiedades

        public int IdAlumno
        {
            get
            {
                return this.idAlumno;
            }
            set
            {
                this.idAlumno = value;
            }
        }

        public string Responsable
        {
            get
            {
                return this.responsable;
            }
            set
            {
                this.responsable = value;
            }
        }

        public float NotaFinal
        {
            get
            {
                return this.notaFinal;
            }
            set
            {
                this.notaFinal = value;
            }
        }

        #endregion

        public Alumno() : base()
        {

        }

        public Alumno(string nombre, string apellido, int edad, int dni, string direccion, int idAlumno, string responsable)
            : base(nombre, apellido, edad, dni, direccion)
        {
            this.idAlumno = idAlumno;
            this.responsable = responsable;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ID: " + this.idAlumno + " - " + this.Nombre + " - " + this.Apellido + " - " +  "Edad: " + this.Edad + " - " + "DNI: " + this.Dni + " - " + "Direccion: " + this.Direccion + " - " + "Responsable: " + this.responsable);

            return sb.ToString();
        }

        public string mostrarAlumno()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ID: " + this.idAlumno + " " + this.Nombre + " " + this.Apellido);

            return sb.ToString();
        }

        public static bool operator ==(Alumno a1, Alumno a2)
        {
            return a1.idAlumno == a2.idAlumno;
        }

        public static bool operator !=(Alumno a1, Alumno a2)
        {
            return (!(a1 == a2));
        }
    }
}

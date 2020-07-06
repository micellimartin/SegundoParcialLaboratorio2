using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evaluacion
    {
        private int idEvaluacion;
        private int idAlumno;
        private int idDocente;
        private int idAula;
        private int nota_1;
        private int nota_2;
        private float notaFinal;
        private string observaciones;

        #region Propiedades

        public int IdEvaluacion
        {
            get
            {
                return this.idEvaluacion;
            }
            set
            {
                this.idEvaluacion = value;
            }
        }

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

        public int IdDocente
        {
            get
            {
                return this.idDocente;
            }
            set
            {
                this.idDocente = value;
            }
        }

        public int IdAula
        {
            get
            {
                return this.idAula;
            }
            set
            {
                this.idAula = value;
            }
        }

        public int Nota_1
        {
            get
            {
                return this.nota_1;
            }
            set
            {
                this.nota_1 = value;
            }
        }

        public int Nota_2
        {
            get
            {
                return this.nota_2;
            }
            set
            {
                this.nota_2 = value;
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

        public string Observaciones
        {
            get
            {
                return this.observaciones;
            }
            set
            {
                this.observaciones = value;
            }
        }

        #endregion

        public Evaluacion()
        {

        }
       
        public Evaluacion(int idEvaluacion, int idAlumno, int idDocente, int idAula, int nota_1, int nota_2, float notaFinal, string observaciones)
        {
            this.idEvaluacion = idEvaluacion;
            this.idAlumno = idAlumno;
            this.idDocente = idDocente;
            this.idAula = idAula;
            this.nota_1 = nota_1;
            this.nota_2 = nota_2;
            this.notaFinal = notaFinal;
            this.observaciones = observaciones;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Evaluacion ID: " + this.idEvaluacion + " - " + "Alumno ID: " + this.idAlumno + " - " + "Docente ID: " + this.IdDocente + " - " + "Aula ID: " + 
                           this.idAula + " - " + "Nota 1: " + this.nota_1 + " - " + "Nota 2:" + this.nota_2 + " - " + "Nota final: " + this.notaFinal + " - " + "Observaciones: " + 
                           this.observaciones);

            return sb.ToString();
        }
    }
}

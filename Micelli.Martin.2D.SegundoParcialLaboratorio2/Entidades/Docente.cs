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
    [Serializable]
    public class Docente : Persona
    {
        private int id;
        private string sexo;
        private string email;

        #region Propiedades 

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Sexo
        {
            get
            {
                return this.sexo;
            }
            set
            {
                this.sexo = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        #endregion

        public Docente() : base()
        {

        }

        public Docente(string nombre, string apellido, int edad, int dni, string direccion, int idDocente, string sexo, string email)
            : base(nombre, apellido, edad, dni, direccion)
        {
            this.id = idDocente;
            this.sexo = sexo;
            this.email = email;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString() + " - " + "ID: " + this.id + " - " + "Sexo: " + this.sexo + " - " + " Email: " + this.email);

            return sb.ToString();
        }

        public string mostrarDocente()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ID: " + this.id + " " + this.Nombre + " " + this.Apellido);

            return sb.ToString();
        }
    }
}

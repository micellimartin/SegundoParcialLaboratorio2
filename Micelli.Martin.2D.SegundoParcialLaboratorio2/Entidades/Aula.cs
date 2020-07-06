using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aula
    {
        private int idAula;
        private string salita;

        #region Propiedades

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

        public string Salita
        {
            get
            {
                return this.salita;
            }
            set
            {
                this.salita = value;
            }
        }

        #endregion

        public Aula()
        {

        }

        public Aula(int idAula, string salita)
        {
            this.idAula = idAula;
            this.salita = salita;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ID: " + this.idAula + " - " + "Salita: " + this.salita);

            return sb.ToString();
        }
    }
}

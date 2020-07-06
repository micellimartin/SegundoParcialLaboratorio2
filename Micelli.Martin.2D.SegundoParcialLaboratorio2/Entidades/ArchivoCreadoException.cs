using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que sera lanzada cuando se cree un archivo
    /// </summary>
    public class ArchivoCreadoException : Exception
    {
        public ArchivoCreadoException(string mensaje) : base(mensaje)
        {

        }
    }
}

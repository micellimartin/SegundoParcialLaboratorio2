using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz generica que establece que metodos tendran que desarrollar las clases que la implementen
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMetodosArchivos<T>
    {
        bool Guardar(T obj, string path);

        T Leer(string path);
    }
}

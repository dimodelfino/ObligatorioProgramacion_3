using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Distribuidora
{
    public interface IActiveRecord <T>
    {
        bool Crear();
        List<T> TraerTodo();           
        T Buscar();
        bool Modificar();
        bool Borrar();
    }
}

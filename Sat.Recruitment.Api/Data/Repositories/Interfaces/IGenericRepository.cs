using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Data.Repositories.Interfaces
{
	public interface IGenericRepository<T> where T : class
    {
        void Agregar(T entidad);
        void Eliminar(string email);
        void Actualizar(T entidad);
        T ObtenerPorEmail(string email);
        IEnumerable<T> Listar();
    }
}

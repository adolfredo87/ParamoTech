using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services.Interfaces
{
	public interface IGenericService<T> where T : class
	{
		void Agregar(T entidad);
		void Eliminar(string email);
		void Actualizar(T entidad);
		T ObtenerPorEmail(string email);
		IEnumerable<T> Listar();
	}
}

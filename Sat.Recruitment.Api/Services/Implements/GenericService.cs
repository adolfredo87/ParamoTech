using Sat.Recruitment.Api.Data.Repositories.Interfaces;
using Sat.Recruitment.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services.Implements
{
	public class GenericService<T> : IGenericService<T> where T : class
	{
		private IGenericRepository<T> genericRepository;

		public GenericService(IGenericRepository<T> _genericRepository) { this.genericRepository = _genericRepository; }

		public void Actualizar(T entidad)
		{
			genericRepository.Actualizar(entidad);
		}

		public void Agregar(T entidad)
		{
			genericRepository.Agregar(entidad);
		}

		public void Eliminar(string email)
		{
			genericRepository.Eliminar(email);
		}

		public T ObtenerPorEmail(string email)
		{
			return genericRepository.ObtenerPorEmail(email);
		}

		public IEnumerable<T> Listar()
		{
			return genericRepository.Listar();
		}
	}
}

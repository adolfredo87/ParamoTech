using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Data.Repositories.Interfaces;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Data.Repositories.Implements
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
		{
            this._db = db;
        }

        public void Actualizar(T entidad)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Agregar(T entidad)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Set<T>().Add(entidad);
                db.SaveChanges();
            }
        }

        public void Eliminar(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var entidad = db.Set<T>().Find(email);
                db.Set<T>().Remove(entidad);
                db.SaveChanges();
            }
        }

        public T ObtenerPorEmail(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Set<T>().Find(email);
            }
        }

        public IEnumerable<T> Listar()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Set<T>().ToList();
            }
        }
    }
}
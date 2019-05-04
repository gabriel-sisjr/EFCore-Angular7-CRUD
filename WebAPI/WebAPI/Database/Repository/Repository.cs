using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Database.Repository
{
    public class Repository<T> where T : class
    {
        private readonly Contexto _contexto;

        public Repository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<T> Insert(T objeto)
        {
            try
            {
                await _contexto.Set<T>().AddAsync(objeto);
                await _contexto.SaveChangesAsync();

                return objeto;
            } catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public async Task<T> Update(T objeto)
        {
            _contexto.Entry(objeto).State = EntityState.Modified;
            try
            {
                await _contexto.SaveChangesAsync();
                return objeto;
            } catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public async Task Remove(T objeto)
        {
            try
            {
                _contexto.Set<T>().Remove(objeto);
                await _contexto.SaveChangesAsync();
            } catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public IQueryable<T> Get() => _contexto.Set<T>().AsNoTracking();

        // Pega o Objeto dentro do objeto.
        public IQueryable<T> Get(string objetoInterno) => _contexto.Set<T>().AsNoTracking().Include(objetoInterno);

        // Checa a existencia.
        public bool Exists(Expression<Func<T, bool>> where) => _contexto.Set<T>().Count(where) > 0 ? true : false;
    }
}

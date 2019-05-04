using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Database.Repository
{
    public class CategoriaRepository : Repository<Categoria>
    {
        public CategoriaRepository(Contexto contexto) : base(contexto) { }

        // Aqui ficará os metodos que diferem do generico, apenas metodos referentes a categoria.
        public Categoria GetById(int id) => Get().SingleOrDefault(c => c.Id == id);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database.Repository;
using WebAPI.Models;

namespace WebAPI.Database.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _repository;

        // Aqui ficará as regras de negocio, validações e etc.
        // Fará a ponte entre o banco e a controller.

        public CategoriaService(Contexto contexto)
        {
            _repository = new CategoriaRepository(contexto);
        }


        public async Task<(bool, string)> Inserir(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                await _repository.Insert(categoria);
                return (true, "Inserido com sucesso!!");
            }
            else
                return (false, "Erro ao inserir!!");
        }

        public async Task<Categoria> Update(Categoria categoria) => await _repository.Update(categoria);

        public async Task<List<Categoria>> GetAll() => await _repository.Get().ToListAsync();

        public Categoria GetById(int id) => _repository.GetById(id);

        public async Task Remove(int id)
        {
            var categoria = _repository.GetById(id);
            await _repository.Remove(categoria);
        }
    }
}

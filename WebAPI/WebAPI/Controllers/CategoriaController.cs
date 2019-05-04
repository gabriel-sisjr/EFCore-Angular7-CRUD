using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Database;
using WebAPI.Database.Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(Contexto contexto)
        {
            _categoriaService = new CategoriaService(contexto);
        }

        // =========== METODOS API ===========
        // GET: api/Categoria
        [HttpGet]
        public async Task<List<Categoria>> Get() => await _categoriaService.GetAll();

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public Categoria Get(int id) => _categoriaService.GetById(id);

        // POST: api/Categoria
        [HttpPost]
        public async Task<bool> Post([FromBody] Categoria categoria)
        {
            bool resposta;
            var notificacao = string.Empty;
            (resposta, notificacao) = await _categoriaService.Inserir(categoria);

            if (!resposta)
                //return BadRequest(JsonConvert.SerializeObject(notificacao));
                return false;
            else
                return true;

        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Categoria categoria) => await _categoriaService.Update(categoria);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) => await _categoriaService.Remove(id);
    }
}

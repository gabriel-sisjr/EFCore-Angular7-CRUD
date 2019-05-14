using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private static List<Entrada> _entradas = new List<Entrada>()
        {
            new Entrada
            {
                Id = 1,
                Nome = "Entrada1",
                Descricao = "Descrição da entrada 1",
                Tipo = "expense",
                Valor = "8,50",
                Data = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                Pago = true,
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "Categoria1",
                    Descricao = "Descrição categoria 1"
                },
                CategoriaId = 1
            },
            new Entrada
            {
                Id = 2,
                Nome = "Entrada2",
                Descricao = "Descrição da entrada 2",
                Tipo = "expense",
                Valor = "10,50",
                Data = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                Pago = false,
                Categoria = new Categoria
                {
                    Id = 2,
                    Nome = "Categoria2",
                    Descricao = "Descrição categoria 2"
                },
                CategoriaId = 2
            },
            new Entrada
            {
                Id = 3,
                Nome = "Entrada3",
                Descricao = "Descrição da entrada 3",
                Tipo = "revenue",
                Valor = "8,50",
                Data = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                Pago = true,
                Categoria = new Categoria
                {
                    Id = 3,
                    Nome = "Categoria3",
                    Descricao = "Descrição categoria 3"
                },
                CategoriaId = 3
            }
        };

        // GET: api/Entrada
        [HttpGet]
        public List<Entrada> Get() => _entradas;

        // GET: api/Entrada/5
        [HttpGet("{id}")]
        public Entrada Get(int id) => _entradas.Find(e => e.Id == id);

        // POST: api/Entrada
        [HttpPost]
        public void Post([FromBody] Entrada entrada) { _entradas.Add(entrada); }

        // PUT: api/Entrada/5
        [HttpPut("{id}")]
        public void Put([FromBody] Entrada entrada)
        {
            var e = _entradas.FirstOrDefault(c => c.Id == entrada.Id);
            e.Id = entrada.Id;
            e.Nome = entrada.Nome;
            e.Descricao = entrada.Descricao;
            e.Tipo = entrada.Tipo;
            e.Valor = entrada.Valor;
            e.Data = entrada.Data;
            e.Pago = entrada.Pago;
            e.Categoria = entrada.Categoria;
            e.CategoriaId = entrada.CategoriaId;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) => _entradas.Remove(_entradas.Find(e => e.Id == id));
    }
}

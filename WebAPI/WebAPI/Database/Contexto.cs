using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Database
{
    public class Contexto : DbContext
    {
        /*
         * Deve criar isso para poder fazer as migrações.
         * : base(options) = passar o context para o construtor da classe pai. Que no caso é DbContext
         */
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        /* 
         * Mapeando as classes para o EntityFrameworkCore
         * DbSet é uma colletion de BD. Por isso esse tipo.
         * Cada propriedade será uma classe a ser mapeada.
        */
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        /* 
         * Classe de Contexto configurada, vai no startup e configura o serviço que se comunicará com o BD.
         * Após configurar a classe de Contexto e o Startup vai no console e faz a migração inicial "Add-Migration Inicial"
         * Feito gerada a migração inicial, precisa atualizar o banco de dados para que as alterações das migrations sejam implementadas.
         */


        /*
         * Aplica as configurações a serem feitas nas configurations das entidades.
         */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(Contexto).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}

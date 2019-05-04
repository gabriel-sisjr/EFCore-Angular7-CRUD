using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Database.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Para personalizar o nome.. Caso não passe, pega o nome da classe por padrão.
            builder.ToTable("tb_categoria");

            builder.HasKey(c => c.Id);

            // String por Default é nulo. O resto não.
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(30)").IsRequired();

            // para trabalhar com enumerable.
            // builder.Property(c => c.Descricao).HasConversion<int>();
            builder.Property(c => c.Descricao).HasColumnType("VARCHAR(50)");

            // Exemplo de passagem de valor padrão.
            // builder.Property(c => c.Data).HasColumnType("DATETIME").HasDefaultValueSql("NOW()").ValueGeneratedOnAddOrUpdate();
        }
    }
}

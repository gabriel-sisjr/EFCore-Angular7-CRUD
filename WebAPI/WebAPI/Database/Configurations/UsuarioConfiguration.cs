using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Database.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Login).HasColumnType("VARCHAR(30)").IsRequired();

            builder.Property(c => c.Senha).HasColumnType("VARCHAR(50)").IsRequired();

            builder.Property(c => c.Email).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}

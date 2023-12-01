using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.Application
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "public");

            builder.HasKey(x => x.Id).HasName("pk_usuario");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Cpf).HasColumnName("cpf");
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
            builder.Property(x => x.Telefone).HasColumnName("telefone");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Cep).HasColumnName("cep");
            builder.Property(x => x.Senha).HasColumnName("senha");
            builder.Property(x => x.Admin).HasColumnName("admin");
            builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");

            // builder.HasMany(x => x.Suportes).WithOne(x => x.Usuario);
            builder.HasMany(x => x.Denuncias).WithOne(x => x.Usuario);
        }
    }
}
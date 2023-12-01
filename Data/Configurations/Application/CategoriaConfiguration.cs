using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.Application
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria", "public");

            builder.HasKey(x => x.Id).HasName("pk_categoria");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.IdCategoriaPai).HasColumnName("id_categoria_pai");

            builder.HasMany(x => x.Denuncias).WithOne(x => x.Categoria);
        }
    }
}
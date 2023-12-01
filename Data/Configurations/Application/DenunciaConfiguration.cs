using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.Application
{
    public class DenunciaConfiguration : IEntityTypeConfiguration<Denuncia>
    {
        public void Configure(EntityTypeBuilder<Denuncia> builder)
        {
            builder.ToTable("denuncia", "public");

            builder.HasKey(x => x.Id).HasName("pk_denuncia");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.Data).HasColumnName("data");
            builder.Property(x => x.Descricao).HasColumnName("descricao");
            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");
            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria");
            builder.Property(x => x.IdBairro).HasColumnName("id_bairro");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Denuncias).HasForeignKey(x => x.IdUsuario);
            builder.HasOne(x => x.Categoria).WithMany(x => x.Denuncias).HasForeignKey(x => x.IdCategoria);
            builder.HasOne(x => x.Bairro).WithMany(x => x.Denuncias).HasForeignKey(x => x.IdBairro);
        }
    }
}
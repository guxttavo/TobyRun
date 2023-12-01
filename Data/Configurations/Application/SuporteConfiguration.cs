using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Configurations.Application
{
    public class SuporteConfiguration : IEntityTypeConfiguration<Suporte>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Suporte> builder)
        {
            builder.ToTable("suporte", "public");

            builder.HasKey(x => x.Id).HasName("pk_suporte");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(x => x.Assunto).HasColumnName("assunto");
            builder.Property(x => x.Descricao).HasColumnName("descricao");
            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Suportes).HasForeignKey("id_usuario");
        }
    }
}
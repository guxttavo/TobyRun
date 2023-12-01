using Core.Models;
using Core.Settings;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(AppSettings appSettings) : base(appSettings, "Application")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Suporte> Suportes { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Denuncia> Denuncias { get; set; }
    }
}
using Core.Interfaces.Repositories;
using Core.Models;

namespace Data.Repositories
{
    public class SuporteRepository 
    {
        private readonly ApplicationDbContext _dbContext;

        public SuporteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Suporte CadastrarSuporte(Suporte suporte)
        {
            // _dbContext.Suporte.Add(suporte);
            // _dbContext.SaveChanges();

            return suporte;
        }
    }
}
using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IDenunciaService
    {
        // Task<List<Bairro>> BuscarBairros();
        // Task<IEnumerable<Categoria>> BuscarCategorias();
        Task<IEnumerable<Categoria>> BuscarSubcategorias();
        Task CadastrarDenuncia(Denuncia denuncia);
        Task<IEnumerable<Denuncia>> BuscarDenuncias();
        Task<IEnumerable<Denuncia>> BuscarDenunciaPorId();
        // Task<Denuncia> QtdDenunciasPorBairroGraficos();
        bool FecharDenuncia(int id);
    }
}
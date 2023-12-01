using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Core.Services
{
    public class DenunciaService : IDenunciaService
    {
        private readonly IDenunciaRepository _denunciaRepository;

        public DenunciaService(IDenunciaRepository denunciaRepository)
        {
            _denunciaRepository = denunciaRepository;
        }
        // public Task<List<Bairro>> BuscarBairros()
        // {
        //     return _denunciaRepository.BuscarBairros();
        // }

        // public Task<IEnumerable<Categoria>> BuscarCategorias()
        // {
        //     return _denunciaRepository.BuscarCategorias();
        // }

        public Task<IEnumerable<Categoria>> BuscarSubcategorias()
        {
            return _denunciaRepository.BuscarSubcategorias();
        }

        public async Task CadastrarDenuncia(Denuncia denuncia)
        {
            Denuncia novaDenuncia = new Denuncia
            {
                IdCategoria = denuncia.IdCategoria,
                IdUsuario = denuncia.IdUsuario,
                IdBairro = denuncia.IdBairro,
                Categoria = new Categoria
                {
                    IdCategoriaPai = denuncia.Categoria.IdCategoriaPai
                },
                Data = denuncia.Data.ToUniversalTime(),
                Descricao = denuncia.Descricao
            };

            await _denunciaRepository.CadastrarDenuncia(novaDenuncia);
        }

        public Task<IEnumerable<Denuncia>> BuscarDenuncias()
        {
            return _denunciaRepository.BuscarDenuncias();
        }

        public bool FecharDenuncia(int id)
        {
            return _denunciaRepository.FecharDenuncia(id);
        }

        public Task<IEnumerable<Denuncia>> BuscarDenunciaPorId()
        {
            throw new NotImplementedException();
        }
    }
}
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DenunciaController : AuthenticatedController
    {
        private readonly IDenunciaService _denunciaService;
        private readonly IDenunciaRepository _denunciaRepository;

        public DenunciaController(IDenunciaService denunciaService, IDenunciaRepository denunciaRepository)
        {
            _denunciaService = denunciaService;
            _denunciaRepository = denunciaRepository;
        }

        public  IActionResult Index()
        {
            IEnumerable<Categoria> categorias =  _denunciaRepository.BuscarCategorias();
            ViewBag.BuscarBairros =  _denunciaRepository.BuscarBairros();

            return View("Index", categorias);
        }

        public async Task<IActionResult> CadastrarDenuncia(int idCategoria, int idBairro, DateTime data, string descricao, int idUsuario = 1)
        {
            // await _denunciaService.CadastrarDenuncia(idSubcategoria, idBairro, data, descricao, idUsuario);
            Denuncia denuncia = new Denuncia
            {
                IdCategoria = idCategoria,
                IdBairro = idBairro,
                Data = data.ToUniversalTime(),
                Descricao = descricao,
                IdUsuario = idUsuario
            };

            await _denunciaRepository.CadastrarDenuncia(denuncia);

            return RedirectToAction("Index");
        }

        // [HttpPost]
        // public IActionResult FecharDenuncia(int id)
        // {
        //     _denunciaService.FecharDenuncia(id);
        //     return RedirectToAction("Index");
        // }
    }
}
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SuporteController : AuthenticatedController
    {
        // public ISuporteRepository _suporteRepository;

        // public SuporteController(ISuporteRepository suporteRepository)
        // {
        //     _suporteRepository = suporteRepository;
        // }

        public ActionResult Index() => View();

        [HttpPost]
        public IActionResult RealizarSuporte(Suporte suporte)
        {
            var novoSuporte = new Suporte
            {
                Assunto = suporte.Assunto,
                Descricao = suporte.Descricao
            };

            // _suporteRepository.CadastrarSuporte(novoSuporte);
            
            return RedirectToAction("Index");
        }
    }
}
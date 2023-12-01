using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class HomeController : AuthenticatedController
{
    private readonly IDenunciaService _denunciaService;
    private readonly IDenunciaRepository _denunciaRepository;

    public HomeController(IDenunciaService denunciaService, IDenunciaRepository denunciaRepository)
    {
        _denunciaService = denunciaService;
        _denunciaRepository = denunciaRepository;
    }
    public async Task<ActionResult> Index()
    {
        IEnumerable<Denuncia> denuncias = await _denunciaService.BuscarDenuncias();
        // ViewBag.BuscarBairros = await _denunciaRepository.BuscarBairros();

        return View("Index", denuncias);
    }

    [HttpGet]
    public IActionResult ViewEditarDenuncia(int id)
    {
        var denunciaSelecionada = _denunciaRepository.BuscarDenuncia(id);
        ViewBag.BuscarBairros = _denunciaRepository.BuscarBairros();
        ViewBag.BuscarCategorias = _denunciaRepository.BuscarCategorias();

        return View("_editar", denunciaSelecionada);
    }


    [HttpPost]
    public IActionResult FecharDenuncia(int id)
    {
        _denunciaRepository.FecharDenuncia(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EditarDenuncia(Denuncia denuncia)
    {
        _denunciaRepository.EditarDenuncia(denuncia);
        return RedirectToAction("Index");
    }
}

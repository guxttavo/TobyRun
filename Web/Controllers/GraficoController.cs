using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GraficoController : AuthenticatedController
    {
        private readonly IDenunciaRepository _denunciaRepository;

        public GraficoController(IDenunciaRepository denunciaRepository)
        {
            _denunciaRepository = denunciaRepository;
        }

        public async Task<IActionResult> Index()
        {
            // ViewBag.QtdDenunciasPorBairroGraficos = await _denunciaRepository.QtdDenunciasPorBairroGraficos();

            return View();
        }

        public async Task<IActionResult> QtdDenunciaPorBairro()
        {
            var dadosGraficos = await _denunciaRepository.QtdDenunciaPorBairro();

            return Ok(dadosGraficos);
        }
        public async Task<IActionResult> QtdDenunciasPorCategoria()
        {
            var dadosCategoriasPorBairro = await _denunciaRepository.QtdDenunciaPorCategoria();

            return Ok(dadosCategoriasPorBairro);
        }
        public async Task<IActionResult> QtdDenunciasPorCategoriaPorBairro()
        {
            var dadosQtdDenunciaCategoriaBairro = await _denunciaRepository.QtdDenunciasPorCategoriaPorBairro();          

            return Ok(dadosQtdDenunciaCategoriaBairro);
        }

    }
}
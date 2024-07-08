using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UneContChallenge.Application.Interfaces;
using UneContChallenge.Application.ViewModels;
using UneContChallenge.Models;

namespace UneContChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotaFiscalAppService _notaFiscalAppService;

        public HomeController(INotaFiscalAppService notaFiscalAppService)
        {
            _notaFiscalAppService = notaFiscalAppService;
        }

        public async Task<IActionResult> Index()
        {
            var dadosIndicadores = await _notaFiscalAppService.ObterDashboardIndicadoresAsync();
            ViewBag.Dados = dadosIndicadores;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObterIndicadoresFiltrado(int ano, int? mes = null, bool trimestral = false)
        {
            var dadosIndicadores = await _notaFiscalAppService.GetDashboardIndicadoresFiltradosAsync(ano, mes, trimestral);

            return Json(dadosIndicadores);
        }

    }
}
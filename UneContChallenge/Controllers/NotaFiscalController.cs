using Microsoft.AspNetCore.Mvc;
using UneContChallenge.Application.Interfaces;
using UneContChallenge.Application.ViewModels;
using UneContChallenge.Presentation.Interfaces;

namespace UneContChallenge.Presentation.Controllers
{
    public class NotaFiscalController : Controller
    {
        private readonly INotaFiscalAppService _notaFiscalAppService;
        private readonly IConvertingFilesAndSavingOnRoot _convertingFilesAndSavingOnRoot;

        public NotaFiscalController(INotaFiscalAppService notaFiscalAppService, IConvertingFilesAndSavingOnRoot convertingFilesAndSavingOnRoot)
        {
            _notaFiscalAppService = notaFiscalAppService;
            _convertingFilesAndSavingOnRoot = convertingFilesAndSavingOnRoot;
        }

        public async Task<IActionResult> Consulta()
        {
            var notas = await _notaFiscalAppService.ObterTodasNotasFiscaisAsync();
            return View(notas);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(NotaFiscalViewModel model)
        {
            var files = Request.Form.Files;
            var caminhos = await _convertingFilesAndSavingOnRoot.ConvertFile(files);
            if (caminhos.Count >= 2)
            {
                model.DocumentoNotaFiscal = caminhos[0];
                model.DocumentoBoletoBancario = caminhos[1];
            }
            await _notaFiscalAppService.CadastrarNotaAsync(model);
            return RedirectToAction("Consulta");
        }

    }
}

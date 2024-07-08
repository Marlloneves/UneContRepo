using UneContChallenge.Application.ViewModels;
using UneContChallenge.Domain.Entities;

namespace UneContChallenge.Application.Interfaces
{
    public interface INotaFiscalAppService
    {
        Task CadastrarNotaAsync(NotaFiscalViewModel model);
        Task AtualizarNotaAsync(NotaFiscalViewModel model);
        Task DeletarNotaAsync(int id);
        Task<List<NotaFiscalViewModel>> ObterTodasNotasFiscaisAsync();
        Task<NotaFiscalViewModel> ObterNotaFiscalPorIdAsync(int id);
        Task<FiltroDashboardIndicadoresViewModel> ObterDashboardIndicadoresAsync();
        Task<FiltroDashboardIndicadoresViewModel> GetDashboardIndicadoresFiltradosAsync(int ano, int? mes = null, bool trimestral = false);
    }
}

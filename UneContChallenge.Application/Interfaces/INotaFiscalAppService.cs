using UneContChallenge.Application.ViewModels;

namespace UneContChallenge.Application.Interfaces
{
    public interface INotaFiscalAppService
    {
        Task CadastrarNotaAsync(NotaFiscalViewModel model);
        Task AtualizarNotaAsync(NotaFiscalViewModel model);
        Task DeletarNotaAsync(int id);
        Task<List<NotaFiscalViewModel>> ObterTodasNotasFiscaisAsync();
        Task<NotaFiscalViewModel> ObterNotaFiscalPorIdAsync(int id);
    }
}

using UneContChallenge.Domain.Entities;

namespace UneContChallenge.Domain.Interfaces.Services
{
    public interface INotaFiscalDomainService : IBaseDomainService<NotaFiscal>
    {
        Task<FiltroDashboardIndicadores> GetDashboardIndicadoresAsync();
        Task<FiltroDashboardIndicadores> GetDashboardIndicadoresFiltradosAsync(int ano, int? mes = null, bool trimestral = false);
        Task<List<DadosMensaisDashboard>> GetMonthlyDataAsync(int ano);
    }
}

using UneContChallenge.Domain.Entities;

namespace UneContChallenge.Domain.Interfaces.Repositories
{
    public interface INotaFiscalRepository : IBaseRepository<NotaFiscal>
    {
        Task<FiltroDashboardIndicadores> GetDashboardIndicadoresAsync();
        Task<FiltroDashboardIndicadores> GetDashboardIndicadoresFiltradosAsync(int ano, int? mes = null, bool trimestral = false);
    }
}

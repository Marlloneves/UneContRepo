using Microsoft.EntityFrameworkCore;
using UneContChallenge.Domain.Entities;
using UneContChallenge.Domain.Interfaces.Repositories;
using UneContChallenge.Infra.Contexts;

namespace UneContChallenge.Infra.Repositories
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
    {
        private readonly DataContexts _dataContexts;

        public NotaFiscalRepository(DataContexts dataContexts) : base(dataContexts)
        {
            _dataContexts = dataContexts;
        }

        public async Task<FiltroDashboardIndicadores> GetDashboardIndicadoresAsync()
        {
            var now = DateTime.Now;
            var result = await _dataContexts.NotaFiscal
                .GroupBy(n => 1)
                .Select(g => new FiltroDashboardIndicadores
                {
                    ValorEmitido = g.Sum(n => n.Valor),
                    ValorPago = g.Where(n => n.DataPagamento != null).Sum(n => n.Valor),
                    ValorSemCobranca = g.Where(n => n.DataCobranca == null).Sum(n => n.Valor),
                    ValorVencer = g.Where(n => n.DataPagamento == null && n.DataEmissao.AddDays(30) >= now).Sum(n => n.Valor),
                    ValorVencido = g.Where(n => n.DataPagamento == null && n.DataEmissao.AddDays(30) < now).Sum(n => n.Valor)
                })
                .FirstOrDefaultAsync();

            return result;
        }


        public async Task<FiltroDashboardIndicadores> GetDashboardIndicadoresFiltradosAsync(int ano, int? mes = null, bool trimestral = false)
        {
            var filteredQuery = ApplyFilters(_dataContexts.NotaFiscal.AsQueryable(), ano, mes, trimestral);

            var result = await filteredQuery
                .GroupBy(n => 1)
                .Select(g => new FiltroDashboardIndicadores
                {
                    ValorEmitido = g.Sum(n => n.Valor),
                    ValorPago = g.Where(n => n.DataPagamento != null).Sum(n => n.Valor),
                    ValorSemCobranca = g.Where(n => n.DataCobranca == null).Sum(n => n.Valor),
                    ValorVencer = g.Where(n => n.DataPagamento == null && n.DataEmissao.AddDays(30) >= DateTime.Now).Sum(n => n.Valor),
                    ValorVencido = g.Where(n => n.DataPagamento == null && n.DataEmissao.AddDays(30) < DateTime.Now).Sum(n => n.Valor)
                })
                .FirstOrDefaultAsync();

            if (result is null)
            {
                result = new FiltroDashboardIndicadores
                {
                    ValorEmitido = 0,
                    ValorPago = 0,
                    ValorSemCobranca = 0,
                    ValorVencer = 0,
                    ValorVencido = 0
                };
            }

            return result;
        }

        private IQueryable<NotaFiscal> ApplyFilters(IQueryable<NotaFiscal> query, int ano, int? mes = null, bool trimestral = false)
        {
            query = query.Where(nf => nf.DataEmissao.Year == ano);

            if (mes.HasValue)
            {
                if (trimestral)
                {
                    int mesFinal = mes.Value + 2;
                    query = query.Where(nf => nf.DataEmissao.Month >= mes.Value && nf.DataEmissao.Month <= mesFinal);
                }
                else
                {
                    query = query.Where(nf => nf.DataEmissao.Month == mes.Value);
                }
            }

            return query;
        }

    }
}

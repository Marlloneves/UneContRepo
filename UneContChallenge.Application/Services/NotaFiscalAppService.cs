using AutoMapper;
using UneContChallenge.Application.Interfaces;
using UneContChallenge.Application.ViewModels;
using UneContChallenge.Domain.Entities;
using UneContChallenge.Domain.Interfaces.Services;

namespace UneContChallenge.Application.Services
{
    public class NotaFiscalAppService : INotaFiscalAppService
    {
        private readonly INotaFiscalDomainService _notaFiscalDomainService;
        private readonly IMapper _mapper;
        public NotaFiscalAppService(INotaFiscalDomainService notaFiscalDomainService, IMapper mapper)
        {
            _notaFiscalDomainService = notaFiscalDomainService;
            _mapper = mapper;
        }

        public async Task CadastrarNotaAsync(NotaFiscalViewModel model)
        {
            var map = _mapper.Map<NotaFiscal>(model);

            await _notaFiscalDomainService.CreateAsync(map);
        }

        public async Task DeletarNotaAsync(int id)
        {
            await _notaFiscalDomainService.DeleteAsync(id);
        }

        public async Task<List<NotaFiscalViewModel>> ObterTodasNotasFiscaisAsync()
        {
            var data = await _notaFiscalDomainService.GetAllAsync();

            return _mapper.Map<List<NotaFiscalViewModel>>(data);
        }

        public async Task<NotaFiscalViewModel> ObterNotaFiscalPorIdAsync(int id)
        {
            var data = await _notaFiscalDomainService.GetByIdAsync(id);

            return _mapper.Map<NotaFiscalViewModel>(data);
        }

        public async Task AtualizarNotaAsync(NotaFiscalViewModel model)
        {
            var map = _mapper.Map<NotaFiscal>(model);

            await _notaFiscalDomainService.UpdateAsync(map);
        }
    }
}

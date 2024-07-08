using AutoMapper;
using UneContChallenge.Application.ViewModels;
using UneContChallenge.Domain.Entities;

namespace UneContChallenge.Application.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap() 
        {
            CreateMap<NotaFiscalViewModel, NotaFiscal>();
            CreateMap<NotaFiscal, NotaFiscalViewModel>();

            CreateMap<FiltroDashboardIndicadoresViewModel, FiltroDashboardIndicadores>();
            CreateMap<FiltroDashboardIndicadores, FiltroDashboardIndicadoresViewModel>();
        }
    }
}

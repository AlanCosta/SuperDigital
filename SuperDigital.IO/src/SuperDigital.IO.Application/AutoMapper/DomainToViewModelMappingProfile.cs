using AutoMapper;
using SuperDigital.IO.Application.ViewModels;
using SuperDigital.IO.Domain.ContaCorrente;

namespace SuperDigital.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ContaCorrente, ContaCorrenteViewModel>();
        }
    }
}

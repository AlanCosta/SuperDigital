using AutoMapper;
using SuperDigital.IO.Application.ViewModels;
using SuperDigital.IO.Domain.ContaCorrente;
using SuperDigital.IO.Domain.ContaCorrente.Commands;

namespace SuperDigital.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContaCorrenteViewModel, RegistrarContaCorrenteCommand>()
                .ConstructUsing(c => new RegistrarContaCorrenteCommand(c.NumeroConta,c.ValorTotalConta));

            CreateMap<ContaCorrenteViewModel, AtualizarContaCorrenteCommand>()
                .ConstructUsing(c => new AtualizarContaCorrenteCommand(c.Id, c.NumeroConta, c.ValorTotalConta));

            CreateMap<LancamentosViewModel, AtualizarValorContaCommand>()
                .ConstructUsing(c => new AtualizarValorContaCommand(c.Id, c.NumeroContaDestino, c.NumeroContaOrigem, c.Valor));

            CreateMap<ContaCorrenteViewModel, ContaCorrente>();

        }
    }
}

using AutoMapper;
using SuperDigital.IO.Application.Interfaces;
using SuperDigital.IO.Application.ViewModels;
using SuperDigital.IO.Domain.ContaCorrente.Commands;
using SuperDigital.IO.Domain.ContaCorrente.Repository;
using SuperDigital.IO.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Application.Services
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private readonly IBus bus;
        private readonly IMapper mapper;
        private readonly IContaCorrenteRepository contaCorrenteRepository;

        public ContaCorrenteAppService(IBus _bus, IMapper _mapper, IContaCorrenteRepository _contaCorrenteRepository)
        {
            bus = _bus;
            mapper = _mapper;
            contaCorrenteRepository = _contaCorrenteRepository;
        }
        public void Atualizar(ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var atualizarContaCorrenteCommand = mapper.Map<AtualizarContaCorrenteCommand>(contaCorrenteViewModel);
            bus.SendCommand(atualizarContaCorrenteCommand);
        }

        public void Dispose()
        {
            contaCorrenteRepository.Dispose();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Lancamentos(LancamentosViewModel lancamentosViewModel)
        {
            var atualizarvalorContaCommand = mapper.Map<AtualizarValorContaCommand>(lancamentosViewModel);
            bus.SendCommand(atualizarvalorContaCommand);
        }

        public ContaCorrenteViewModel ObterPorId(int id)
        {
            return mapper.Map<ContaCorrenteViewModel>(contaCorrenteRepository.ObterPorId(id));
        }

        public IEnumerable<ContaCorrenteViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contaCorrenteRepository.ObterTodos());
        }

        public void Registrar(ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var registroCommand = mapper.Map<RegistrarContaCorrenteCommand>(contaCorrenteViewModel);
            bus.SendCommand(registroCommand);
        }
    }
}

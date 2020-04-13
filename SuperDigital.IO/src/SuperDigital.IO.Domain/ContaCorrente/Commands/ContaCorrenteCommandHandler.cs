using SuperDigital.IO.Domain.CommandHandlers;
using SuperDigital.IO.Domain.ContaCorrente.Events;
using SuperDigital.IO.Domain.ContaCorrente.Repository;
using SuperDigital.IO.Domain.Core.Bus;
using SuperDigital.IO.Domain.Core.Events;
using SuperDigital.IO.Domain.Core.Notifications;
using SuperDigital.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Commands
{
    public class ContaCorrenteCommandHandler : CommandHandler,
        IHandler<RegistrarContaCorrenteCommand>,
        IHandler<AtualizarContaCorrenteCommand>,
        IHandler<AtualizarValorContaCommand>
    {
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        private readonly IBus bus;

        public ContaCorrenteCommandHandler(IContaCorrenteRepository _contaCorrenteRepository, IUnitOfWork uow, IBus _bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, _bus, notifications)
        {
            contaCorrenteRepository = _contaCorrenteRepository;
            bus = _bus;
        }

        public void Handle(RegistrarContaCorrenteCommand message)
        {
            var contaCorrente = ContaCorrente.ContaCorrenteFactory.NovoContaCorrente(message.Id, message.NumeroConta, message.ValorTotalConta);

            if (!ContaCorrenteValida(contaCorrente)) return;

            //Validações de Negocio

            //Persistencia
            contaCorrenteRepository.Adicionar(contaCorrente);

            if (Commit())
            {
                //Notificar processo concluido!
                //evento registrado com sucesso
                bus.RaiseEvent(new ContaCorrenteRegistradoEvent(contaCorrente.Id, contaCorrente.NumeroConta, contaCorrente.ValorTotalConta));
            }
        }

        public void Handle(AtualizarContaCorrenteCommand message)
        {
            var contaAtual = contaCorrenteRepository.ObterPorId(message.Id);




            var contaCorrente = ContaCorrente.ContaCorrenteFactory.NovoContaCorrente(message.Id, message.NumeroConta, message.ValorTotalConta);

            if (!ContaCorrenteValida(contaCorrente)) return;

            contaCorrenteRepository.Atualizar(contaCorrente);

            if (Commit())
            {
                bus.RaiseEvent(new ContaCorrenteAtualizadoEvent(contaCorrente.Id, contaCorrente.NumeroConta, contaCorrente.ValorTotalConta));
            }
        }

        public void Handle(AtualizarValorContaCommand message)
        {
            var contaOrigem = contaCorrenteRepository.ObterPorId(message.NumeroContaOrigem);

            var contaDestino = contaCorrenteRepository.ObterPorId(message.NumeroContaDestino);

            contaOrigem.ValorTotalConta = contaOrigem.ValorTotalConta - message.Valor;
            contaDestino.ValorTotalConta = contaDestino.ValorTotalConta + message.Valor;

            var contaCorrenteOrigem = ContaCorrente.ContaCorrenteFactory.NovoContaCorrente(contaOrigem.Id, contaOrigem.NumeroConta, contaOrigem.ValorTotalConta);
            var contaCorrenteDestino = ContaCorrente.ContaCorrenteFactory.NovoContaCorrente(contaDestino.Id, contaDestino.NumeroConta, contaDestino.ValorTotalConta);

            if (!ContaCorrenteValida(contaCorrenteOrigem)) return;
            if (!ContaCorrenteValida(contaCorrenteDestino)) return;

            contaCorrenteRepository.Atualizar(contaCorrenteOrigem);
            contaCorrenteRepository.Atualizar(contaCorrenteDestino);

            if (Commit())
            {
                bus.RaiseEvent(new ContaCorrenteValorAtualizadoEvent(contaCorrenteOrigem.Id, contaCorrenteOrigem.NumeroContaOrigem, contaCorrenteOrigem.NumeroContaDestino, contaCorrenteOrigem.Valor));
                bus.RaiseEvent(new ContaCorrenteValorAtualizadoEvent(contaCorrenteDestino.Id, contaCorrenteDestino.NumeroContaOrigem, contaCorrenteDestino.NumeroContaDestino, contaCorrenteDestino.Valor));
            }
        }

        private bool ContaCorrenteValida(ContaCorrente contaCorrente)
        {
            if (contaCorrente.EhValido()) return true;

            NotificarValidãcoesErro(contaCorrente.ValidationResult);
            return false;
        }
    }
}

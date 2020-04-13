using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Events
{
    public class ContaCorrenteAtualizadoEvent : BaseContaCorrenteEvent
    {
        public ContaCorrenteAtualizadoEvent(int id, int numeroConta, double valorTotalConta)
        {
            Id = id;
            NumeroConta = numeroConta;
            ValorTotalConta = valorTotalConta;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Commands
{
    public class AtualizarContaCorrenteCommand : BaseContaCorrenteCommand
    {
        public AtualizarContaCorrenteCommand(int id, int numeroConta, double valorTotalConta)
        {
            Id = id;
            NumeroConta = numeroConta;
            ValorTotalConta = valorTotalConta;
        }
    }
}

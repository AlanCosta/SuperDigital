using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Commands
{
    public class RegistrarContaCorrenteCommand : BaseContaCorrenteCommand
    {
        public RegistrarContaCorrenteCommand(int numeroConta, double valorTotalConta)
        {
            NumeroConta = numeroConta;
            ValorTotalConta = valorTotalConta;
        }
    }
}

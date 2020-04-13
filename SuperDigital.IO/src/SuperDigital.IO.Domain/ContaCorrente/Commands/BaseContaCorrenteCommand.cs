using SuperDigital.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Commands
{
    public abstract class BaseContaCorrenteCommand : Command
    {
        public int Id { get; protected set; }
        public int NumeroConta { get; protected set; }
        public double ValorTotalConta { get; protected set; }
        public int NumeroContaDestino { get; protected set; }
        public int NumeroContaOrigem { get; protected set; }
        public double Valor { get; protected set; }
    }
}

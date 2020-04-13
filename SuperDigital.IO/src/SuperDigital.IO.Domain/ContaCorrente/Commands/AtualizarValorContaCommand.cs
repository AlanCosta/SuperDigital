using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Commands
{
    public class AtualizarValorContaCommand : BaseContaCorrenteCommand
    {
        public AtualizarValorContaCommand(int id, int numeroContaDestino, int numeroContaOrigem, double valor)
        {
            Id = id;
            NumeroContaDestino = numeroContaDestino;
            NumeroContaOrigem = numeroContaOrigem;
            Valor = valor;
        }
    }
}

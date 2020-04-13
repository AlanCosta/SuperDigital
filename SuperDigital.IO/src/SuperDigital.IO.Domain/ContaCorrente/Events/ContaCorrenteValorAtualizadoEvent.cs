using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Events
{
    public class ContaCorrenteValorAtualizadoEvent : BaseContaCorrenteEvent
    {
        public ContaCorrenteValorAtualizadoEvent(int id, int numeroContaOrigem, int numeroContaDestino, double valor)
        {
            Id = id;
            NumeroContaOrigem = numeroContaOrigem;
            NumeroContaDestino = numeroContaDestino;
            Valor = valor;
        }
    }
}

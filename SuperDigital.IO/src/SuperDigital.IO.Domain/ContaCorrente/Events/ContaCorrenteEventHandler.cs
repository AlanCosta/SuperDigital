using SuperDigital.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente.Events
{
    public class ContaCorrenteEventHandler :
        IHandler<ContaCorrenteRegistradoEvent>,
        IHandler<ContaCorrenteAtualizadoEvent>,
        IHandler<ContaCorrenteValorAtualizadoEvent>
    {
        public void Handle(ContaCorrenteRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Conta Registrada com Sucesso");
        }

        public void Handle(ContaCorrenteAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Conta Atualizada com Sucesso");
        }

        public void Handle(ContaCorrenteValorAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Conta Atualizada com Sucesso");
        }
    }
}

using SuperDigital.IO.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.IO.Application.Interfaces
{
    public interface IContaCorrenteAppService : IDisposable
    {
        void Registrar(ContaCorrenteViewModel contaCorrenteViewModel);
        IEnumerable<ContaCorrenteViewModel> ObterTodos();
        ContaCorrenteViewModel ObterPorId(int id);
        void Atualizar(ContaCorrenteViewModel contaCorrenteViewModel);
        void Lancamentos(LancamentosViewModel lancamentosViewModel);
        void Excluir(int id);
    }
}

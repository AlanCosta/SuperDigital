using FluentValidation;
using SuperDigital.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperDigital.IO.Domain.ContaCorrente
{
    public class ContaCorrente : Entity<ContaCorrente>
    {
        public ContaCorrente(int numeroConta, double valorTotalConta)
        {
            NumeroConta = numeroConta;
            ValorTotalConta = valorTotalConta;
        }
        private ContaCorrente()
        {
        }

        public int NumeroConta { get; set; }
        public double ValorTotalConta { get; set; }
        [NotMapped]
        public int NumeroContaDestino { get; set; }
        [NotMapped]
        public int NumeroContaOrigem { get; set; }
        public double Valor { get; set; }
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarConta();
            ValidationResult = Validate(this);
        }

        private void ValidarConta()
        {
            RuleFor(c => c.NumeroConta)
               .NotEmpty().WithMessage("A Conta precisa ser preenchida!");
        }

        #endregion

        public static class ContaCorrenteFactory
        {
            public static ContaCorrente NovoContaCorrente(int id, int numeroConta, double valorTotalConta)
            {
                var contaCorrente = new ContaCorrente()
                {
                    Id = id,
                    NumeroConta = numeroConta,
                    ValorTotalConta = valorTotalConta
                };

                return contaCorrente;
            }
        }
    }
}

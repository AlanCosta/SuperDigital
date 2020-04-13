using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperDigital.IO.Application.ViewModels
{
    public class LancamentosViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "A Conta Origem é Requirida")]
        [Display(Name = "Numero da Conta")]
        public int NumeroContaOrigem { get; set; }
        [Required(ErrorMessage = "A Conta Destino é Requirida")]
        [Display(Name = "Numero da Conta")]
        public int NumeroContaDestino { get; set; }
        [Display(Name = "Valor Total da Conta")]
        [Required(ErrorMessage = "Informe o Valor a repassar")]
        public double Valor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperDigital.IO.Application.ViewModels
{
    public class ContaCorrenteViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "A Conta é Requirida")]
        [Display(Name = "Numero da Conta")]
        public int NumeroConta { get; set; }
        [Display(Name = "Valor Total da Conta")]
        public double ValorTotalConta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAtosCapital.Models.ViewModels
{
    public class FormularioCorrecaoParcelasViewModel
    {
        [Required]
        [Display(Name = "CdErp")]
        public int IdPagamentoVenda { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Quantidade de Parcelas")]
        public int QtParcelas { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Porcentagem da Taxa de Administração")]
        public double PrTaxaAdministracao { get; set; }

        public ICollection<TbParcela> Parcelas { get; set; }

        public FormularioCorrecaoParcelasViewModel()
        {
            Parcelas = new List<TbParcela>();
        }
    }
}
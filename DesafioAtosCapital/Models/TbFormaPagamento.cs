using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbFormaPagamento
    {
        public TbFormaPagamento()
        {
            TbPagamentoVenda = new HashSet<TbPagamentoVenda>();
        }

        public int IdFormaPagamento { get; set; }
        public string DsFormaPagamento { get; set; }

        public virtual ICollection<TbPagamentoVenda> TbPagamentoVenda { get; set; }
    }
}

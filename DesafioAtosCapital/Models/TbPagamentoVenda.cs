using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbPagamentoVenda
    {
        public TbPagamentoVenda()
        {
            TbParcela = new HashSet<TbParcela>();
        }

        public int IdPagamentoVenda { get; set; }
        public int IdEmpresa { get; set; }
        public string NrNsu { get; set; }
        public DateTime DtEmissao { get; set; }
        public int? IdBandeira { get; set; }
        public decimal VlPagamento { get; set; }
        public int QtParcelas { get; set; }
        public int IdFormaPagamento { get; set; }

        public virtual TbBandeira IdBandeiraNavigation { get; set; }
        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbFormaPagamento IdFormaPagamentoNavigation { get; set; }
        public virtual ICollection<TbParcela> TbParcela { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbParcela
    {
        public int IdPagamentoVenda { get; set; }
        public int NrParcela { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime DtEmissao { get; set; }
        public DateTime DtVencimento { get; set; }
        public decimal VlParcela { get; set; }
        public decimal VlTaxaAdministracao { get; set; }
        public int IdContaCorrente { get; set; }
        public DateTime? DtPagamento { get; set; }
        public decimal? VlPago { get; set; }
        public int IdStatusParcela { get; set; }
        public int? IdMovimentoBanco { get; set; }

        public virtual TbContaCorrente IdContaCorrenteNavigation { get; set; }
        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbMovimentoBanco IdMovimentoBancoNavigation { get; set; }
        public virtual TbPagamentoVenda IdPagamentoVendaNavigation { get; set; }
        public virtual TbStatusParcela IdStatusParcelaNavigation { get; set; }
    }
}

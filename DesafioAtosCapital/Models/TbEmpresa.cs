using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {
            TbContaCorrente = new HashSet<TbContaCorrente>();
            TbMovimentoBanco = new HashSet<TbMovimentoBanco>();
            TbPagamentoVenda = new HashSet<TbPagamentoVenda>();
            TbParcela = new HashSet<TbParcela>();
        }

        public int IdEmpresa { get; set; }
        public string NrCnpj { get; set; }
        public string DsRazaoSocial { get; set; }
        public string DsFantasia { get; set; }

        public virtual ICollection<TbContaCorrente> TbContaCorrente { get; set; }
        public virtual ICollection<TbMovimentoBanco> TbMovimentoBanco { get; set; }
        public virtual ICollection<TbPagamentoVenda> TbPagamentoVenda { get; set; }
        public virtual ICollection<TbParcela> TbParcela { get; set; }
    }
}

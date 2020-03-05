using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbMovimentoBanco
    {
        public TbMovimentoBanco()
        {
            TbParcela = new HashSet<TbParcela>();
        }

        public int IdMovimentoBanco { get; set; }
        public int IdEmpresa { get; set; }
        public int IdContaCorrente { get; set; }
        public DateTime DtMovimento { get; set; }
        public string NrDocumento { get; set; }
        public string DsMovimento { get; set; }
        public decimal VlMovimento { get; set; }
        public string TpOperacao { get; set; }

        public virtual TbContaCorrente IdContaCorrenteNavigation { get; set; }
        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<TbParcela> TbParcela { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbContaCorrente
    {
        public TbContaCorrente()
        {
            TbMovimentoBanco = new HashSet<TbMovimentoBanco>();
            TbParcela = new HashSet<TbParcela>();
        }

        public int IdContaCorrente { get; set; }
        public int IdEmpresa { get; set; }
        public int IdBanco { get; set; }
        public string DsContaCorrente { get; set; }
        public string NrAgencia { get; set; }
        public string NrConta { get; set; }

        public virtual TbBanco IdBancoNavigation { get; set; }
        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<TbMovimentoBanco> TbMovimentoBanco { get; set; }
        public virtual ICollection<TbParcela> TbParcela { get; set; }
    }
}

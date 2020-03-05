using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbBandeira
    {
        public TbBandeira()
        {
            TbPagamentoVenda = new HashSet<TbPagamentoVenda>();
        }

        public int IdBandeira { get; set; }
        public string DsBandeira { get; set; }

        public virtual ICollection<TbPagamentoVenda> TbPagamentoVenda { get; set; }
    }
}

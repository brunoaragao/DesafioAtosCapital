using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbStatusParcela
    {
        public TbStatusParcela()
        {
            TbParcela = new HashSet<TbParcela>();
        }

        public int IdStatusParcela { get; set; }
        public string DsStatusParcela { get; set; }

        public virtual ICollection<TbParcela> TbParcela { get; set; }
    }
}

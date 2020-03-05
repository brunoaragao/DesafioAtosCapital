using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class TbBanco
    {
        public TbBanco()
        {
            TbContaCorrente = new HashSet<TbContaCorrente>();
        }

        public int IdBanco { get; set; }
        public string CdBanco { get; set; }
        public string NmBanco { get; set; }

        public virtual ICollection<TbContaCorrente> TbContaCorrente { get; set; }
    }
}

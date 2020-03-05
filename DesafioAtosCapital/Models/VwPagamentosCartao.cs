using System;
using System.Collections.Generic;

namespace DesafioAtosCapital.Models
{
    public partial class VwPagamentosCartao
    {
        public string NrCnpj { get; set; }
        public string NrNsu { get; set; }
        public string DtVenda { get; set; }
        public int? CdBandeira { get; set; }
        public string DsBandeira { get; set; }
        public decimal VlVenda { get; set; }
        public int QtParcelas { get; set; }
        public int CdErp { get; set; }
    }
}

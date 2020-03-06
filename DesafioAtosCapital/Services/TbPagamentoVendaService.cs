using DesafioAtosCapital.Data;
using DesafioAtosCapital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAtosCapital.Services
{
    public class TbPagamentoVendaService
    {
        private readonly dbAtosCapitalContext _context;

        public TbPagamentoVendaService(dbAtosCapitalContext context)
        {
            _context = context;
        }

        public async Task<TbPagamentoVenda> EncontrarPorIdAsync(int id)
        {
            return await _context.TbPagamentoVenda
                .Include(pv => pv.IdEmpresaNavigation)
                .Include(pv => pv.IdBandeiraNavigation)
                .Include(pv => pv.IdFormaPagamentoNavigation)
                .Include(pv => pv.TbParcela)
                .FirstOrDefaultAsync(pv => pv.IdPagamentoVenda == id);
        }
    }
}

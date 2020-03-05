using DesafioAtosCapital.Data;
using DesafioAtosCapital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAtosCapital.Services
{
    public class VwPagamentosCartaoService
    {
        private readonly dbAtosCapitalContext _context;

        public VwPagamentosCartaoService(dbAtosCapitalContext context)
        {
            _context = context;
        }

        public async Task<ICollection<VwPagamentosCartao>> ListarTodosAsync()
        {
            return await _context.VwPagamentosCartao.ToListAsync();
        }
    }
}

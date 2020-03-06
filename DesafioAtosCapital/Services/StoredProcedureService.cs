using DesafioAtosCapital.Data;
using DesafioAtosCapital.Models;
using DesafioAtosCapital.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAtosCapital.Services
{
    public class StoredProcedureService
    {
        private readonly dbAtosCapitalContext _context;

        public StoredProcedureService(dbAtosCapitalContext context)
        {
            _context = context;
        }

        public async Task SpCorrigeParcelasAsync(FormularioCorrecaoParcelasViewModel correcao)
        {
            var idPagamentoVenda = new SqlParameter("idPagamentoVenda", correcao.IdPagamentoVenda);
            var qtParcelas = new SqlParameter("qtParcelas", correcao.QtParcelas);
            var prTaxaAdministracao = new SqlParameter("prTaxaAdministracao", correcao.PrTaxaAdministracao);

            await _context.Database.ExecuteSqlRawAsync("EXECUTE SP_Corrige_Parcelas @idPagamentoVenda, @qtParcelas, @prTaxaAdministracao;", idPagamentoVenda, qtParcelas, prTaxaAdministracao);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAtosCapital.Models.ViewModels;
using DesafioAtosCapital.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtosCapital.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly VwPagamentosCartaoService _vwPagamentosCartaoService;
        private readonly TbPagamentoVendaService _tbPagamentoVendaService;
        private readonly StoredProcedureService _storedProcedureService;

        public PagamentosController(
            VwPagamentosCartaoService vwPagamentosCartaoService,
            TbPagamentoVendaService tbPagamentoVendaService,
            StoredProcedureService storedProcedureService)
        {
            _vwPagamentosCartaoService = vwPagamentosCartaoService;
            _tbPagamentoVendaService = tbPagamentoVendaService;
            _storedProcedureService = storedProcedureService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Cartao));
        }

        public async Task<IActionResult> Cartao()
        {
            var model = await _vwPagamentosCartaoService.ListarTodosAsync();
            return View(model);
        }

        public async Task<IActionResult> CorrecaoParcelas(int? id)
        {

            if (!id.HasValue)
            {
                return View();
            }

            var pagamentoVenda = await _tbPagamentoVendaService.EncontrarPorIdAsync(id.Value);
            if (pagamentoVenda == null)
            {
                return NotFound();
            }

            var parcela_1 = pagamentoVenda.TbParcela.FirstOrDefault();

            FormularioCorrecaoParcelasViewModel viewModel = new FormularioCorrecaoParcelasViewModel
            {
                IdPagamentoVenda = pagamentoVenda.IdPagamentoVenda,
                QtParcelas = pagamentoVenda.QtParcelas,
                PrTaxaAdministracao = ((double)(parcela_1.VlTaxaAdministracao / parcela_1.VlParcela)) * 100,
                Parcelas = pagamentoVenda.TbParcela
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CorrecaoParcelas(FormularioCorrecaoParcelasViewModel correcaoParcela)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _storedProcedureService.SpCorrigeParcelasAsync(correcaoParcela);

            return RedirectToAction(nameof(CorrecaoParcelas), new { @id = correcaoParcela.IdPagamentoVenda });
        }
    }
}
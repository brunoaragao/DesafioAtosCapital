using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAtosCapital.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtosCapital.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly VwPagamentosCartaoService _vwPagamentosCartaoService;

        public PagamentosController(VwPagamentosCartaoService vwPagamentosCartaoService)
        {
            _vwPagamentosCartaoService = vwPagamentosCartaoService;
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
    }
}
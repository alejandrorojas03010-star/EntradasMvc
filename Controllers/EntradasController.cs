using EntradasMvc.Models;
using EntradasMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EntradasMvc.Controllers;

public class EntradasController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var viewModel = new CotizacionInputViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calcular(CotizacionInputViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", viewModel);
        }

        var cotizacion = new Cotizacion
        {
            Cliente = viewModel.Cliente,
            Cantidad = viewModel.Cantidad,
            TipoEntrada = viewModel.TipoEntrada
        };

        var resultadoViewModel = new ResultadoCotizacionViewModel
        {
            Cotizacion = cotizacion,
            Evento = "Concierto Web III",
            FechaEvento = new DateTime(2026, 11, 15),
            Mensaje = "Gracias por realizar su cotización."
        };

        return View("Resultado", resultadoViewModel);
    }
}

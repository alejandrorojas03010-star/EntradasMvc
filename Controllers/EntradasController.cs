using EntradasMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntradasMvc.Controllers;

public class EntradasController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var modelo = new Cotizacion();
        return View(modelo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calcular(Cotizacion modelo)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", modelo);
        }

        return View("Resultado", modelo);
    }
}

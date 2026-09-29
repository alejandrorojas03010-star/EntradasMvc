using HeroesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HeroesWeb.Pages.Laboratorio;

public class InscripcionModel : PageModel
{
    [BindProperty]
    public InscripcionMisionInput Inscripcion { get; set; } = new();

    public List<SelectListItem> Ciudades { get; private set; } = new();
    public List<SelectListItem> Misiones { get; private set; } = new();
    public string? Confirmacion { get; private set; }

    public void OnGet(int? misionId)
    {
        CargarOpciones();
        if (misionId is >= 1 and <= 3)
        {
            Inscripcion.MisionId = misionId;
        }
    }

    public IActionResult OnPostInscribir()
    {
        CargarOpciones();

        if (!string.IsNullOrWhiteSpace(Inscripcion.Ciudad)
            && !Ciudades.Any(c => c.Value == Inscripcion.Ciudad))
        {
            ModelState.AddModelError("Inscripcion.Ciudad",
                "Seleccione una ciudad de la lista.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var mision = Misiones.Single(m =>
            m.Value == Inscripcion.MisionId!.Value.ToString());

        Confirmacion = $"Inscripción válida: {Inscripcion.Nombre} — "
            + $"{mision.Text} en {Inscripcion.Ciudad}. "
            + $"Integrantes del equipo: {Inscripcion.Integrantes}. "
            + "Demostración sin guardar en la base de datos.";

        return Page();
    }

    private void CargarOpciones()
    {
        Ciudades = new List<SelectListItem>
        {
            new() { Value = "Metrópolis", Text = "Metrópolis" },
            new() { Value = "Gotham", Text = "Gotham" },
            new() { Value = "Central City", Text = "Central City" }
        };

        Misiones = new List<SelectListItem>
        {
            new() { Value = "1", Text = "Rescate de civiles" },
            new() { Value = "2", Text = "Protección de la ciudad" },
            new() { Value = "3", Text = "Investigación de amenazas" }
        };
    }
}

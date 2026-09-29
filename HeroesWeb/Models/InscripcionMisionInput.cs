using System.ComponentModel.DataAnnotations;

namespace HeroesWeb.Models;

public class InscripcionMisionInput
{
    [Required(ErrorMessage = "Ingrese el nombre del héroe.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    [Display(Name = "Nombre del héroe")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese un correo de contacto.")]
    [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
    [Display(Name = "Correo de contacto")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Seleccione una ciudad.")]
    [Display(Name = "Ciudad de operación")]
    public string Ciudad { get; set; } = string.Empty;

    [Required(ErrorMessage = "Seleccione una misión.")]
    [Range(1, 3, ErrorMessage = "Seleccione una misión válida.")]
    [Display(Name = "Misión")]
    public int? MisionId { get; set; }

    [Required(ErrorMessage = "Ingrese la cantidad de integrantes.")]
    [Range(1, 10, ErrorMessage = "La cantidad debe estar entre 1 y 10.")]
    [Display(Name = "Integrantes del equipo")]
    public int? Integrantes { get; set; }

    [StringLength(250, ErrorMessage = "Use como máximo 250 caracteres.")]
    [Display(Name = "Observaciones")]
    public string? Observaciones { get; set; }
}

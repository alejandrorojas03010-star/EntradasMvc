using System.ComponentModel.DataAnnotations;

namespace EntradasMvc.Models;

public class Cotizacion
{
    [Required(ErrorMessage = "Ingrese el nombre del cliente.")]
    [StringLength(60, MinimumLength = 3,
        ErrorMessage = "El nombre debe tener entre 3 y 60 caracteres.")]
    [Display(Name = "Nombre del cliente")]
    public string Cliente { get; set; } = string.Empty;

    [Range(1, 10, ErrorMessage = "La cantidad debe estar entre 1 y 10.")]
    [Display(Name = "Cantidad de entradas")]
    public int Cantidad { get; set; } = 1;

    public decimal PrecioUnitario => 50m;
    public decimal Subtotal => Cantidad * PrecioUnitario;
    public decimal Descuento => Cantidad >= 5 ? Subtotal * 0.10m : 0m;
    public decimal Total => Subtotal - Descuento;
}

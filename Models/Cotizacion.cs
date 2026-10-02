namespace EntradasMvc.Models;

public class Cotizacion
{
    public string Cliente { get; set; } = string.Empty;

    public int Cantidad { get; set; }

    public string TipoEntrada { get; set; } = string.Empty;

    public decimal PrecioUnitario => 50m;

    public decimal Subtotal => Cantidad * PrecioUnitario;

    public decimal Descuento =>
        Cantidad >= 5 ? Subtotal * 0.10m : 0m;

    public decimal Total => Subtotal - Descuento;
}

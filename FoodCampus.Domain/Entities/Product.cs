namespace FoodCampus.Domain.Entities;

/// <summary>
/// Representa un producto del inventario (UTM Market/FoodCampus).
/// </summary>
public class Product
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
}

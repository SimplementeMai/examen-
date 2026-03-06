namespace FoodCampus.Domain.Entities;

/// <summary>
/// Detalle individual de un platillo dentro de un pedido.
/// </summary>
public class DetallePedido
{
    public int IdDetalle { get; set; }
    
    public int IdPedido { get; set; }
    
    public int IdPlatillo { get; set; }

    /// <summary>
    /// Cantidad de platillos validada con la palabra clave 'field' de C# 14.
    /// </summary>
    public int Cantidad 
    { 
        get; 
        set => field = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "La cantidad debe ser mayor a 0."); 
    }
    
    public decimal Subtotal { get; set; }
}

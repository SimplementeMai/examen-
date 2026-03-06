namespace FoodCampus.Domain.Entities;

/// <summary>
/// Representa una orden realizada por un usuario.
/// </summary>
public class Pedido
{
    public int IdPedido { get; set; }
    
    public int IdUsuario { get; set; }
    
    public DateTime FechaHora { get; set; } = DateTime.Now;

    /// <summary>
    /// Costo de envío validado con la palabra clave 'field' de C# 14.
    /// </summary>
    public decimal CostoEnvio 
    { 
        get; 
        set => field = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "El costo de envío no puede ser negativo."); 
    }

    public List<DetallePedido> Detalles { get; set; } = [];
}

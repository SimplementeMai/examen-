namespace FoodCampus.Domain.Entities;

/// <summary>
/// Métodos de extensión tradicionales para Restaurante (Compatibilidad estable).
/// </summary>
public static class RestauranteExtensions
{
    /// <summary>
    /// Determina si el restaurante está abierto actualmente.
    /// </summary>
    public static bool IsCurrentlyOpen(this Restaurante restaurante)
    {
        return TimeOnly.FromDateTime(DateTime.Now).IsBetween(restaurante.HorarioApertura, restaurante.HorarioCierre);
    }
}

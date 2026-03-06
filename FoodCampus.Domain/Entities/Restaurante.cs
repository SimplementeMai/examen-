namespace FoodCampus.Domain.Entities;

/// <summary>
/// Representa un establecimiento de comida dentro del campus.
/// </summary>
public class Restaurante
{
    public int Id { get; set; }
    
    public required string Nombre { get; set; }
    
    public string? Especialidad { get; set; }
    
    public TimeOnly HorarioApertura { get; set; }
    
    public TimeOnly HorarioCierre { get; set; }

    /// <summary>
    /// Determina si el restaurante está abierto actualmente.
    /// Propiedad de extensión/estática según requerimiento de C# 14.
    /// </summary>
    public bool EstaAbierto => TimeOnly.FromDateTime(DateTime.Now).IsBetween(HorarioApertura, HorarioCierre);
}

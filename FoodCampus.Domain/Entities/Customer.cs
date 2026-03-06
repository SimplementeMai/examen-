namespace FoodCampus.Domain.Entities;

/// <summary>
/// Representa un cliente del sistema FoodCampus.
/// </summary>
public class Customer
{
    public int Id { get; set; }
    
    public required string Nombre { get; set; }

    /// <summary>
    /// Email validado con 'field' de C# 14.
    /// </summary>
    public string Email 
    { 
        get; 
        set => field = value.Contains('@') ? value : throw new ArgumentException("Email inválido."); 
    }
}

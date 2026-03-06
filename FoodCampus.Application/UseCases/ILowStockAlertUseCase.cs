using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.UseCases;

/// <summary>
/// Interfaz para el caso de uso de alertas de bajo stock.
/// </summary>
public interface ILowStockAlertUseCase
{
    /// <summary>
    /// Obtiene los productos con stock inferior al umbral especificado.
    /// </summary>
    IAsyncEnumerable<Product> ExecuteAsync(int threshold, CancellationToken ct = default);
}

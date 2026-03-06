using FoodCampus.Application.UseCases;
using FoodCampus.Domain.Entities;
using System.Runtime.CompilerServices;

namespace FoodCampus.Infrastructure.Repositories;

/// <summary>
/// Implementación asíncrona para el monitoreo de stock bajo.
/// </summary>
public class LowStockAlertUseCaseImpl : ILowStockAlertUseCase
{
    /// <summary>
    /// Simulación de streaming de datos para Native AOT.
    /// </summary>
    public async IAsyncEnumerable<Product> ExecuteAsync(int threshold, [EnumeratorCancellation] CancellationToken ct = default)
    {
        // En un entorno real, esto vendría de un repositorio AOT
        var mockProducts = new List<Product>
        {
            new() { Id = 1, Nombre = "Tacos al Pastor", Stock = 2, Precio = 15.0m },
            new() { Id = 2, Nombre = "Coca Cola 600ml", Stock = 5, Precio = 18.0m }
        };

        foreach (var product in mockProducts.Where(p => p.Stock < threshold))
        {
            await Task.Delay(100, ct); // Simular latencia de DB
            yield return product;
        }
    }
}

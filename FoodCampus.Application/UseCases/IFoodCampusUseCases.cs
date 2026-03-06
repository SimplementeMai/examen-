using FoodCampus.Domain.Entities;

namespace FoodCampus.Application.UseCases;

/// <summary>
/// Contrato para obtener la lista de todos los restaurantes.
/// </summary>
public interface IFetchRestaurantsUseCase
{
    Task<IEnumerable<Restaurante>> ExecuteAsync(CancellationToken ct = default);
}

/// <summary>
/// Contrato para registrar un nuevo pedido maestro.
/// </summary>
public interface IRegisterPedidoUseCase
{
    Task<Pedido> ExecuteAsync(Pedido pedido, CancellationToken ct = default);
}

/// <summary>
/// Criterios de filtrado para ventas.
/// </summary>
public record SaleFilter(DateTime StartDate, DateTime EndDate);

/// <summary>
/// Contrato para consultar ventas por rango de fechas.
/// </summary>
public interface IFetchSalesByFilterUseCase
{
    IAsyncEnumerable<Pedido> ExecuteAsync(SaleFilter filter, CancellationToken ct = default);
}

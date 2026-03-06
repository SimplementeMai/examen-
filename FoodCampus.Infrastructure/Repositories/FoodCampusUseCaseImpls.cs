using FoodCampus.Application.UseCases;
using FoodCampus.Domain.Entities;
using FoodCampus.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FoodCampus.Infrastructure.Repositories;

public class FetchRestaurantsUseCaseImpl(FoodCampusDbContext context) : IFetchRestaurantsUseCase
{
    public async Task<IEnumerable<Restaurante>> ExecuteAsync(CancellationToken ct = default)
    {
        return await context.Restaurantes.AsNoTracking().ToListAsync(ct);
    }
}

public class RegisterPedidoUseCaseImpl(FoodCampusDbContext context) : IRegisterPedidoUseCase
{
    public async Task<Pedido> ExecuteAsync(Pedido pedido, CancellationToken ct = default)
    {
        context.Pedidos.Add(pedido);
        await context.SaveChangesAsync(ct);
        return pedido;
    }
}

public class FetchSalesByFilterUseCaseImpl(FoodCampusDbContext context) : IFetchSalesByFilterUseCase
{
    public async IAsyncEnumerable<Pedido> ExecuteAsync(SaleFilter filter, [EnumeratorCancellation] CancellationToken ct = default)
    {
        var sales = context.Pedidos
            .Where(p => p.FechaHora >= filter.StartDate && p.FechaHora <= filter.EndDate)
            .AsNoTracking()
            .AsAsyncEnumerable();

        await foreach (var sale in sales.WithCancellation(ct))
        {
            yield return sale;
        }
    }
}

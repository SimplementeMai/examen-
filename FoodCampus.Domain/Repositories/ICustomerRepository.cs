using FoodCampus.Domain.Entities;

namespace FoodCampus.Domain.Repositories;

/// <summary>
/// Contrato para el repositorio de Clientes.
/// </summary>
public interface ICustomerRepository
{
    Task<Customer?> GetByEmailAsync(string email, CancellationToken ct = default);
    Task AddAsync(Customer customer, CancellationToken ct = default);
}

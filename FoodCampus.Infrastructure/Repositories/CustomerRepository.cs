using FoodCampus.Domain.Entities;
using FoodCampus.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FoodCampus.Infrastructure.Repositories;

/// <summary>
/// Implementación optimizada para Native AOT usando SqlDataReader manual.
/// </summary>
public class CustomerRepository(string connectionString) : ICustomerRepository
{
    public async Task<Customer?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(ct);
        
        using var command = new SqlCommand("SELECT Id, Nombre, Email FROM Customers WHERE Email = @Email", connection);
        command.Parameters.AddWithValue("@Email", email);
        
        using var reader = await command.ExecuteReaderAsync(ct);
        if (await reader.ReadAsync(ct))
        {
            return new Customer 
            { 
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Email = reader.GetString(2)
            };
        }
        
        return null;
    }

    public async Task AddAsync(Customer customer, CancellationToken ct = default)
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(ct);
        
        using var command = new SqlCommand("INSERT INTO Customers (Nombre, Email) VALUES (@Nombre, @Email)", connection);
        command.Parameters.AddWithValue("@Nombre", customer.Nombre);
        command.Parameters.AddWithValue("@Email", customer.Email);
        
        await command.ExecuteNonQueryAsync(ct);
    }
}

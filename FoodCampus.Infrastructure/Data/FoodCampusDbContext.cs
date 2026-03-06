using FoodCampus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodCampus.Infrastructure.Data;

public class FoodCampusDbContext(DbContextOptions<FoodCampusDbContext> options) : DbContext(options)
{
    public DbSet<Restaurante> Restaurantes => Set<Restaurante>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<DetallePedido> DetallesPedidos => Set<DetallePedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurante>().HasKey(r => r.Id);
        modelBuilder.Entity<Pedido>().HasKey(p => p.IdPedido);
        modelBuilder.Entity<DetallePedido>().HasKey(d => d.IdDetalle);
        
        // Configuraciones de precisión decimal
        modelBuilder.Entity<Pedido>().Property(p => p.CostoEnvio).HasPrecision(19, 4);
        modelBuilder.Entity<DetallePedido>().Property(d => d.Subtotal).HasPrecision(19, 4);
    }
}

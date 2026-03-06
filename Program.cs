using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodCampus;

// ==========================================
// 1. ENTIDADES DE DOMINIO (C# 14 / .NET 10)
// ==========================================

public class Restaurante
{
    [Key]
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Especialidad { get; set; }
    public TimeOnly HorarioApertura { get; set; }
    public TimeOnly HorarioCierre { get; set; }
}

public class Pedido
{
    [Key]
    public int IdPedido { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.Now;

    public decimal CostoEnvio 
    { 
        get; 
        set => field = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Costo no puede ser negativo."); 
    }

    public List<DetallePedido> Detalles { get; set; } = [];
}

public class DetallePedido
{
    [Key]
    public int IdDetalle { get; set; }
    public int IdPedido { get; set; }
    public int IdProducto { get; set; }
    public string? NombreProducto { get; set; }
    
    public int Cantidad 
    { 
        get; 
        set => field = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Cantidad debe ser > 0."); 
    }
    
    public decimal Subtotal { get; set; }
}

public class Product
{
    [Key]
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
}

public class Customer
{
    [Key]
    public int Id { get; set; }
    public required string Nombre { get; set; }
    
    // Validación de Email con 'field' según Tarea 03
    public required string Email 
    { 
        get; 
        set => field = (value.Contains('@') && value.Contains('.')) ? value : throw new ArgumentException("Email inválido."); 
    }
}

// ==========================================
// 2. EXTENSIONES (C# 14)
// ==========================================

public static class RestauranteExtensions
{
    public static bool IsOpen(this Restaurante r) => 
        TimeOnly.FromDateTime(DateTime.Now).IsBetween(r.HorarioApertura, r.HorarioCierre);
}

// ==========================================
// 3. PERSISTENCIA (EF CORE 10)
// ==========================================

public class FoodDbContext : DbContext
{
    public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) { }

    public DbSet<Restaurante> Restaurantes { get; set; } = null!;
    public DbSet<Pedido> Pedidos { get; set; } = null!;
    public DbSet<DetallePedido> DetallesPedidos { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
}

// ==========================================
// 4. CASOS DE USO (Interfaces)
// ==========================================

public interface ILowStockAlertUseCase
{
    IAsyncEnumerable<Product> ExecuteAsync(int threshold, CancellationToken ct = default);
}

public class LowStockAlertUseCaseImpl(FoodDbContext db) : ILowStockAlertUseCase
{
    public async IAsyncEnumerable<Product> ExecuteAsync(int threshold, [EnumeratorCancellation] CancellationToken ct = default)
    {
        var lowStock = db.Products.AsNoTracking().Where(p => p.Stock < threshold).AsAsyncEnumerable();
        await foreach (var p in lowStock.WithCancellation(ct)) yield return p;
    }
}

// ==========================================
// 5. ORQUESTACIÓN (MENÚ CLI)
// ==========================================

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddDbContext<FoodDbContext>(opt => opt.UseInMemoryDatabase("FoodDB"));
        builder.Services.AddScoped<ILowStockAlertUseCase, LowStockAlertUseCaseImpl>();

        using IHost host = builder.Build();

        // Seeding
        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<FoodDbContext>();
            if (!await db.Products.AnyAsync())
            {
                db.Products.AddRange(new List<Product> {
                    new() { Nombre = "Tacos al Pastor", Precio = 45.0m, Stock = 100 },
                    new() { Nombre = "Refresco 600ml", Precio = 18.0m, Stock = 200 }
                });
                db.Restaurantes.Add(new Restaurante { Nombre = "UTM Central", Especialidad = "Mexicana", HorarioApertura = new TimeOnly(7,0), HorarioCierre = new TimeOnly(21,0) });
                db.Customers.Add(new Customer { Nombre = "Mai", Email = "mai@utm.edu.mx" });
                await db.SaveChangesAsync();
            }
        }

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║      FOODCAMPUS - SISTEMA UNIFICADO      ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Catálogo / Restaurantes               ║");
            Console.WriteLine("║ 2. Registrar Cliente                     ║");
            Console.WriteLine("║ 3. Registrar Venta (Maestro-Detalle)     ║");
            Console.WriteLine("║ 4. Historial por Rango de Fechas         ║");
            Console.WriteLine("║ 5. Alertas de Stock                      ║");
            Console.WriteLine("║ 6. Salir                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("\nSeleccione una opción: ");

            var input = Console.ReadLine();
            using var menuScope = host.Services.CreateScope();
            var db = menuScope.ServiceProvider.GetRequiredService<FoodDbContext>();

            try
            {
                switch (input)
                {
                    case "1":
                        var prods = await db.Products.AsNoTracking().ToListAsync();
                        var rests = await db.Restaurantes.AsNoTracking().ToListAsync();
                        
                        Console.WriteLine("\n╔══════════════════════════════════════════╗");
                        Console.WriteLine("║          CATÁLOGO DE PRODUCTOS           ║");
                        Console.WriteLine("╚══════════════════════════════════════════╝");
                        Console.WriteLine($"{"ID",-4} | {"NOMBRE",-25} | {"PRECIO",-10}");
                        Console.WriteLine(new string('-', 44));
                        foreach(var p in prods) Console.WriteLine($"{p.Id,-4} | {p.Nombre,-25} | {p.Precio,10:C2}");

                        Console.WriteLine("\n╔══════════════════════════════════════════╗");
                        Console.WriteLine("║        DIRECTORIO DE RESTAURANTES        ║");
                        Console.WriteLine("╚══════════════════════════════════════════╝");
                        Console.WriteLine($"{"NOMBRE",-25} | {"STATUS",-10}");
                        Console.WriteLine(new string('-', 38));
                        foreach(var r in rests) 
                        {
                            string status = r.IsOpen() ? "ABIERTO" : "CERRADO";
                            Console.ForegroundColor = r.IsOpen() ? ConsoleColor.Green : ConsoleColor.DarkGray;
                            Console.WriteLine($"{r.Nombre,-25} | {status,-10}");
                            Console.ResetColor();
                        }
                        break;

                    case "2":
                        Console.Write("\nNombre Cliente: ");
                        string cNom = Console.ReadLine() ?? "Anon";
                        Console.Write("Email: ");
                        string cEma = Console.ReadLine() ?? "";
                        db.Customers.Add(new Customer { Nombre = cNom, Email = cEma });
                        await db.SaveChangesAsync();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n[ÉXITO] Cliente registrado correctamente.");
                        Console.ResetColor();
                        break;

                    case "3":
                        Console.Write("\nID Cliente: ");
                        int.TryParse(Console.ReadLine(), out int uid);
                        var pedido = new Pedido { IdUsuario = uid, CostoEnvio = 15.0m };
                        while(true)
                        {
                            Console.Write("ID Producto (0 p/finalizar): ");
                            if(!int.TryParse(Console.ReadLine(), out int pid) || pid == 0) break;
                            var p = await db.Products.FindAsync(pid);
                            if(p == null) { Console.WriteLine("(!) No encontrado."); continue; }
                            Console.Write($"Cantidad '{p.Nombre}': ");
                            int.TryParse(Console.ReadLine(), out int cant);
                            pedido.Detalles.Add(new DetallePedido { IdProducto = p.Id, NombreProducto = p.Nombre, Cantidad = cant, Subtotal = cant * p.Precio });
                            p.Stock -= cant;
                        }
                        if(pedido.Detalles.Count > 0) { db.Pedidos.Add(pedido); await db.SaveChangesAsync(); Console.WriteLine("\n[ÉXITO] Venta guardada."); }
                        break;

                    case "4":
                        Console.Write("\nFecha Inicio (yyyy-MM-dd): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime start);
                        Console.Write("Fecha Fin (yyyy-MM-dd): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime end);
                        
                        var ventas = await db.Pedidos.Include(p => p.Detalles)
                            .Where(v => v.FechaHora >= start && v.FechaHora <= end.AddDays(1))
                            .AsNoTracking().ToListAsync();

                        Console.WriteLine($"\n--- REPORTE DE VENTAS ({start:dd/MM} al {end:dd/MM}) ---");
                        foreach(var v in ventas)
                        {
                            Console.WriteLine($"\n╔══ ORDEN #{v.IdPedido} ════════════════════════╗");
                            Console.WriteLine($"║ Cliente: {v.IdUsuario,-4}  Fecha: {v.FechaHora:dd/MM HH:mm} ║");
                            Console.WriteLine("╟──────────────────────────────────────╢");
                            foreach(var d in v.Detalles)
                                Console.WriteLine($"║ > {d.Cantidad}x {d.NombreProducto,-20} {d.Subtotal,8:C2} ║");
                            Console.WriteLine("╟──────────────────────────────────────╢");
                            Console.WriteLine($"║ Envío: {v.CostoEnvio,28:C2} ║");
                            Console.WriteLine($"║ TOTAL: {v.Detalles.Sum(x => x.Subtotal) + v.CostoEnvio,28:C2} ║");
                            Console.WriteLine("╚══════════════════════════════════════╝");
                        }
                        break;

                    case "5":
                        var alert = menuScope.ServiceProvider.GetRequiredService<ILowStockAlertUseCase>();
                        await foreach(var p in alert.ExecuteAsync(10)) Console.WriteLine($"(!) {p.Nombre} | Stock: {p.Stock}");
                        break;

                    case "6":
                        running = false;
                        break;
                }
            }
            catch (Exception ex) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n[ERROR] {ex.Message}"); Console.ResetColor(); }
            if(running) { Console.WriteLine("\nPresiona tecla..."); Console.ReadKey(); }
        }
    }
}

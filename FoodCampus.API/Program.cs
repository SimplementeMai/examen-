using FoodCampus.Domain.Entities;
using FoodCampus.Application.UseCases;
using FoodCampus.Infrastructure.Repositories;
using FoodCampus.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// 🚀 FOODCAMPUS - PUNTO DE ENTRADA (C# 14 / .NET 10)
var builder = Host.CreateApplicationBuilder(args);

// 1. Configuración de Persistencia (EF Core 10)
builder.Services.AddDbContext<FoodCampusDbContext>(options => 
    options.UseInMemoryDatabase("FoodCampus_nwn"));

// 2. Registro de Casos de Uso (Segregación de Interfaces - ISP)
builder.Services.AddScoped<IFetchRestaurantsUseCase, FetchRestaurantsUseCaseImpl>();
builder.Services.AddScoped<IRegisterPedidoUseCase, RegisterPedidoUseCaseImpl>();
builder.Services.AddScoped<IFetchSalesByFilterUseCase, FetchSalesByFilterUseCaseImpl>();
builder.Services.AddScoped<ILowStockAlertUseCase, LowStockAlertUseCaseImpl>();

using IHost host = builder.Build();

bool running = true;
while (running)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔════════════════════════════════════════════╗");
    Console.WriteLine("║        FOODCAMPUS - SENIOR ARCHITECT       ║");
    Console.WriteLine("╠════════════════════════════════════════════╣");
    Console.WriteLine("║ 1. Consultar Catálogo de Restaurantes      ║");
    Console.WriteLine("║ 2. Alertas de Stock Bajo (Market)          ║");
    Console.WriteLine("║ 3. Consultar Historial de Ventas           ║");
    Console.WriteLine("║ 4. Registrar Nuevo Pedido                  ║");
    Console.WriteLine("║ 5. Salir                                   ║");
    Console.WriteLine("╚════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.Write("\nSeleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n[ERROR] Entrada no válida. Use números únicamente.");
        Console.ResetColor();
        Thread.Sleep(1500);
        continue;
    }

    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    try 
    {
        switch (choice)
        {
            case 1:
                var fetchRepo = services.GetRequiredService<IFetchRestaurantsUseCase>();
                var list = await fetchRepo.ExecuteAsync();
                Console.WriteLine("\n--- LISTADO DE RESTAURANTES ---");
                foreach (var r in list)
                    Console.WriteLine($"[ID:{r.Id}] {r.Nombre} | Especialidad: {r.Especialidad} | Horario: {r.HorarioApertura}-{r.HorarioCierre}");
                break;

            case 2:
                var stockAlert = services.GetRequiredService<ILowStockAlertUseCase>();
                Console.Write("\nUmbral de stock crítico: ");
                if (int.TryParse(Console.ReadLine(), out int threshold))
                {
                    Console.WriteLine("\n--- ALERTAS DE INVENTARIO ---");
                    await foreach (var item in stockAlert.ExecuteAsync(threshold))
                        Console.WriteLine($"(!) {item.Nombre} - Stock actual: {item.Stock}");
                }
                break;

            case 3:
                var saleFilter = services.GetRequiredService<IFetchSalesByFilterUseCase>();
                Console.Write("\nFecha Inicio (yyyy-MM-dd): ");
                DateTime.TryParse(Console.ReadLine(), out DateTime start);
                Console.Write("Fecha Fin (yyyy-MM-dd): ");
                DateTime.TryParse(Console.ReadLine(), out DateTime end);
                
                Console.WriteLine("\n--- REPORTE DE VENTAS ---");
                Console.WriteLine($"{"ID",-5} | {"FECHA",-20} | {"TOTAL",-10}");
                Console.WriteLine(new string('-', 40));
                await foreach (var sale in saleFilter.ExecuteAsync(new SaleFilter(start, end)))
                    Console.WriteLine($"{sale.IdPedido,-5} | {sale.FechaHora,-20:yyyy-MM-dd HH:mm} | {sale.CostoEnvio,10:C}");
                break;

            case 5:
                running = false;
                break;

            default:
                Console.WriteLine("\nFuncionalidad bajo mantenimiento...");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[ERROR CRÍTICO] {ex.Message}");
        Console.ResetColor();
    }

    if (running)
    {
        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
        Console.ReadKey();
    }
}

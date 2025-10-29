using VeiculoConsoleApp.Controllers;
using VeiculoConsoleApp.Data;
using VeiculoConsoleApp.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ConsoleSimpleDb;Trusted_Connection=True;";

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

         services.AddTransient<VeiculoController>();
         services.AddTransient<MotoristaController>();

         services.AddTransient<ConsoleUI>();
    })
    .Build();

// Obtém uma instância do controller do provedor de serviços.
var controllerUI = host.Services.GetRequiredService<ConsoleUI>();

controllerUI.MenuPrincipal();



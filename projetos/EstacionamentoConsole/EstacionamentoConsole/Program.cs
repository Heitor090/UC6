using EstacionamentoConsole.Controllers;
using EstacionamentoConsole.Models;
using EstacionamentoConsole.Controllers;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)

    .ConfigureServices((context, services) =>

    {

        services.AddDbContext<EstacionamentoDbContext>(opt =>

            opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EstacionamentoDB;" +
            "Trusted_Connection=True;TrustServerCertificate=True;"));
        services.AddTransient<ClienteCoontroller>();

    })

    .Build();
var clientesControllers = host.Services.GetRequiredService<ClienteCoontroller>();


    bool sair = false;






while (!sair) {
    
 

    Console.WriteLine("==== Sistema de Estacionamento ====");
    Console.WriteLine("1. Listar Clientes");
    Console.WriteLine("2. Adicionar Cliente");
    Console.WriteLine("3. Ver Detalhes do Cliente");
    Console.WriteLine("4. (A FAZER) Gerenciar Veiculos");
    Console.WriteLine("5. (A FAZER) Gerenciar Vagas");
    Console.WriteLine("0. Sair");
    string opcao = Console.ReadLine();

    Console.WriteLine($"Opção escoliha {opcao}");

    switch (opcao)
    {

        case "1":
            clientesControllers.ListarClientes();  
            break;
          
        case "2":
            clientesControllers.AdicionarCliente();
            break;
        case "3":
            clientesControllers.VerDetalhesCliente();
            break;
        case "4":
            Console.WriteLine("Chamou o Gerenciar Veiculos.");
            break;
        case "5":
            Console.WriteLine("Chamou o Gerenciar Vagas.");
            break;
        case "0":
            sair = true;
            break;
        default:
          
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            Console.Clear();
            break;
    }
}



Console.WriteLine("Encerrando o sistema até logo");
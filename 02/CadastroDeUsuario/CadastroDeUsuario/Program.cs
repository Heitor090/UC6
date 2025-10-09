using CadastroDeUsuario.Controller;
using CadastroDeUsuario.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var connection = "Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;";
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connection));

        services.AddTransient<UsuarioController>();

     }).Build();

var usuarioController = host.Services.GetRequiredService<UsuarioController>();

MenuPrincipal();
void MenuPrincipal() 
{
    bool sair = false;
        while (!sair)
    {
        Console.Clear();
        Console.WriteLine("==== Menu Principal ====");
        Console.WriteLine("1. Gereciar Usuários");
        Console.WriteLine("0. Sair");
        string opcao = Console.ReadLine();
        if (opcao == "1")
        {
            MenuUsuarios();
        }
        else if (opcao == "0")
        {
            Console.WriteLine("saindo");
        }
    }

}

void MenuUsuarios()
{
    bool voltar = false;
    while (!voltar)
    {
        Console.Clear();
        Console.WriteLine("==== Gerenciar Usuário ====");
        Console.WriteLine("1. Listar usuário");
        Console.WriteLine("2. Cadastrar Usuário");
        Console.WriteLine("0. Voltar");
        string? opcao = Console.ReadLine();

        switch (opcao) 
        {
            case "1":
                usuarioController.Listar();
                break;
            case "2":
                usuarioController.Adicionar();
                break;
            case "0":
                voltar = true;
                break;

        }
    }
}
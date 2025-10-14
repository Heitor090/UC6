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
        services.AddTransient<ProdutoController>();

     }).Build();

var usuarioController = host.Services.GetRequiredService<UsuarioController>();
var produtoController = host.Services.GetRequiredService<ProdutoController>();
MenuPrincipal();
void MenuPrincipal() 
{
    bool sair = false;
        while (!sair)
    {
        Console.Clear();
        Console.WriteLine("==== Menu Principal ====");
        Console.WriteLine("1. Gereciar Usuários");
        Console.WriteLine("2. Gerenciar Produtos");
        Console.WriteLine("0. Sair");
        string opcao = Console.ReadLine();
        if (opcao == "1")
        {
            MenuUsuarios();
        }
        else if (opcao == "2") 
        {
            MenuProdutos();
        
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
        Console.WriteLine("3. Ver detalhes do Usuario");
        Console.WriteLine("4. rio");
        Console.WriteLine("5. Deletar Usuário");
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
            case "3":
                usuarioController.Detalhes();
                break;
            case "4":
                usuarioController.Detalhes();
                break;
            case "5":
                usuarioController.Remover();
                break;


            case "0":
                voltar = true;
                break;

        }
    }
}
void MenuProdutos() 
{
    bool voltar = false;
    while (!voltar)
    {
        Console.Clear();
        Console.WriteLine("==== Gerenciar produtos ====");
        Console.WriteLine("1. Adicionar Produto");
        Console.WriteLine("2. Listar Produtos");
        Console.WriteLine("3. Ver detalhes Produtos");
        Console.WriteLine("0. Voltar");

        int opcao = int.Parse(Console.ReadLine());



        switch (opcao)
        {
            case 1:
                produtoController.AdicionarProduto();
                break;
            case 2:
                produtoController.ListarProduto();
                break;
            case 3:
                produtoController.DetalhesProdutos();
                break;
            case 0:
                voltar = true;
                break;

        }



    }


    }
using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;

namespace CadastroDeUsuario.Controller;

internal class UsuarioController
{
    private AppDbContext _context;


    public UsuarioController(AppDbContext context)
    {
        _context = context;

    }
    public void Adicionar()
    {
        #region Pedir Dados
        Console.Write("Primeiro Nome: ");
        string primeiroNome = Console.ReadLine();

        Console.Write("Sobrenome: ");
        string sobrenome = Console.ReadLine();

        Console.WriteLine("Data de Nascimento: ");
        DateOnly nascimento = DateOnly.Parse(Console.ReadLine());
        #endregion
        var NovoUsuario = new Usuario()
        {
            DataNascimento = nascimento,
            PrimeiroNome = primeiroNome,
            Sobrenome = sobrenome

        };
        _context.Usuarios.Add(NovoUsuario);
        _context.SaveChanges();

        Console.WriteLine("Usuário Cadastrado");
        Console.ReadKey();
    }
    public void Listar()
    {
        var usuarios = _context.Usuarios.ToList();

        if (usuarios.Count() == 0)
        {
            Console.WriteLine("Nenum usuário cadastrado!");
        }
        else
        {
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.PrimeiroNome}");
            }
        }

        Console.WriteLine("\nPressione qualquer telca para voltar.");
        Console.ReadKey();
    }



    public void Detalhes()
    {

        // Dizer onde estou
        Console.Clear();
        Console.WriteLine("==== Detalhes do Usuário ====");

        // Pedir ID usuario
        Console.WriteLine("Digite o ID do usuário:");
        var idUsuario = int.Parse(Console.ReadLine());

        // Buscar usuario no banco de dados
        var usuario = _context.Usuarios
            .FirstOrDefault(user => user.Id == idUsuario);

        // Se nao encontar, avisar usuario
           
        if (usuario == null)
        {
            Console.WriteLine("\nUsuario não encontrado!");

        }
        
        // Se encontar, mostrar ao usuario
        else
        {
            Console.WriteLine("---- Dados Usuários ----");
            Console.WriteLine($"Id: {usuario.Id}");
            Console.WriteLine($"Nome {usuario.PrimeiroNome}");
            Console.WriteLine($"Sobrenome {usuario.Sobrenome}");
            Console.WriteLine($"Nascimento {usuario.DataNascimento}");
        }

        Console.WriteLine("\nPressione qualuqer tela para voltar.");
        Console.ReadKey();

    }

    public void Remover() 
    
    {
        Console.Clear();
        Console.WriteLine("==== Remover Usuário ====");
        Console.Write("Digite o ID do usuário: ");
        var idUsuario = int.Parse(Console.ReadLine());
        var usuarioParaDeletar = _context.Usuarios
                .FirstOrDefault(user => user.Id == idUsuario);

        // Se não encontrar, avisar o usuário
        if (usuarioParaDeletar == null)
        {
            Console.WriteLine("\nUsuário não encontrado!");
            Console.ReadKey();
            return;
        }
        _context.Usuarios.Remove(usuarioParaDeletar);
        _context.SaveChanges();


        Console.WriteLine("\nPressione qualuqer tela para voltar.");
        Console.ReadKey();

    }
    public void AtualizarUsuario()
    {
        Console.Clear();
        Console.WriteLine("==== Atualizar Usuario ====");
        Console.Write("Digite o ID do USuario: ");
        var idUsuarioInformado = int.Parse(Console.ReadLine());

        var usuarioParaAtualizar = _context.Usuarios
            .FirstOrDefault(user => user.Id == idUsuarioInformado);

        if (usuarioParaAtualizar == null)
        {
            Console.WriteLine("\nUsuário não encontado!");
            Console.ReadKey();
            return;
        }
        Console.WriteLine($"\nEditando novo usuário: {usuarioParaAtualizar.PrimeiroNome}");
        Console.Write("Novo Primeiro Nome:");
        string novoPrimeiroNome = Console.ReadLine();
        Console.Write("Novo Sobrenome: ");
        string novoSobrenomenome = Console.ReadLine();
        Console.Write("Nova data nascimento (AAAA-MM-DD): ");
        DateOnly novaDataNascimento = DateOnly.Parse(Console.ReadLine());


        usuarioParaAtualizar.PrimeiroNome = novoPrimeiroNome;
        usuarioParaAtualizar.Sobrenome = novoSobrenomenome;
        usuarioParaAtualizar.DataNascimento = novaDataNascimento;

        _context.Usuarios.Update(usuarioParaAtualizar);
        _context.SaveChanges();

        Console.WriteLine("\n Usuário atualizado com sucesso!");
        Console.WriteLine("Aperte qualquer tecla para continuar: ");
        Console.ReadKey();
    }



}
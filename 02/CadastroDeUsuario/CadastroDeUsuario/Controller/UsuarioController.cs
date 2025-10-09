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

        if (usuarios.Any())
        {
            Console.WriteLine("Nenhum usuario cadastrado");

        }
        else 
        {
            foreach (var usuario in usuarios) 
            {
                Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.PrimeiroNome} {usuario.Sobrenome}");
            } 
        
        }
        Console.WriteLine("\n Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }
}

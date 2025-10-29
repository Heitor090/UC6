using VeiculoConsoleApp.Data;
using VeiculoConsoleApp.Models;

namespace VeiculoConsoleApp.Controllers
{
    internal class MotoristaController
    {
    
    private readonly AppDbContext _context;


     public MotoristaController(AppDbContext context)
    {
        _context = context;
    }

    public void AdicionarMotorista()
    {
        Console.Clear();
        Console.WriteLine("==== Cadastrar Motorista ====");

        Console.Write("Nome do Motorista: ");
        string NomeMotorista = Console.ReadLine();

        Console.Write("CPF do motorista: ");
        string cpfMotorista = Console.ReadLine();

        var newMotorista = new Motoristas
        {
            Nome = NomeMotorista,
            Cpf = cpfMotorista

        };

        _context.Veiculo.Add(newMotorista);
        _context.SaveChanges();

        Console.WriteLine("\nVeículo adicionado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    public void ListarVeiculos()
    {
        Console.Clear();
        Console.WriteLine("==== Lista de Veículos ====");

        var veiculos = _context.Veiculo.ToList();

        if (!veiculos.Any())
        {
            Console.WriteLine("NENHUM VEÍCULO CADASTRADO!");

        }
        else
        {
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"ID: {veiculo.id} | Modelo: {veiculo.Modelo} | Cor:{veiculo.Cor}");
            }
        }
        Console.WriteLine("\nVeículo adicionado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();

    }

    public void DetalhesVeiculo()
    {
        Console.Clear();
        Console.WriteLine("==== Dtalhes do veículo ====");
        Console.WriteLine("==== Dtalhes do veículo ====");
        Console.Write("Digite o ID do usuário que deseja ver os detalhes: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID INVALIDO!");
        }
        else
        {
            var veiculo = _context.Veiculo.FirstOrDefault(car => car.id == id);
            if (veiculo == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
            }
            else
            {
                Console.WriteLine("\n=== Dados Do Veículo ====");
                Console.WriteLine($"ID: {veiculo.id}");
                Console.WriteLine($"Modelo: {veiculo.Modelo}");
                Console.WriteLine($"Cor: {veiculo.Cor}");

            }
        }


        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();



    }

    public void AtualizarVeiculo()
    {
        Console.Clear();
        Console.WriteLine("==== Atualizar Veículo");
        Console.Write("Digite o ID do veículo: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var VeiculoParaAtualizar = _context.Veiculo.FirstOrDefault(car => car.id == id);
            if (VeiculoParaAtualizar != null)
            {
                Console.WriteLine($"\nEditando veiculo: {VeiculoParaAtualizar.Modelo}");

                Console.Write($"Novo MOdelo({VeiculoParaAtualizar.Modelo}): ");
                string novoModelo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoModelo))
                {
                    VeiculoParaAtualizar.Modelo = novoModelo;
                }


                _context.SaveChanges();
                Console.WriteLine("\nVeículo atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nVeículo não encontrado!");
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    public void RemoverVeiculo()
    {
        Console.Clear();
        Console.WriteLine("--- Remover Usuário ---");
        Console.Write("Digite o ID do usuário que deseja remover: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var VeiculoParaRemover = _context.Veiculo.FirstOrDefault(car => car.id == id);
            if (VeiculoParaRemover != null)
            {
                Console.WriteLine($"ID: {VeiculoParaRemover.id} | Modelo: {VeiculoParaRemover.Modelo}| Cor: {VeiculoParaRemover.Cor}");
                Console.Write("Tem certeza que deseja remover?:");
                string resposta = Console.ReadLine();

                if (resposta.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    _context.Veiculo.Remove(VeiculoParaRemover);
                    _context.SaveChanges();
                    Console.WriteLine("\nVeículo removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nOperação cancelada.");
                }
            }
            else
            {
                Console.WriteLine("\nVeículo não encontrado!");
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();







    }
}
}


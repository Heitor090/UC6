using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoConsole.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EstacionamentoConsole.Controllers
{
    internal class ClienteCoontroller
    {
        EstacionamentoDbContext _context;

        public ClienteCoontroller(EstacionamentoDbContext context)
        {
            _context = context;
        }

        public void ListarClientes()
        {
            Console.Clear();
            var clientes = _context.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}");
            }
            Console.WriteLine("\nPressione qualqe=uer tecla para retornar.");
            Console.ReadKey();
            Console.Clear();
        }

        public void AdicionarCliente()
        {
            Console.Clear();
            Console.WriteLine("==== Adicionaar novo cliente ====");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Telefone (Opicional): ");
            string telefone = Console.ReadLine();


            Cliente c1 = new Cliente(nome, cpf, telefone);
            _context.Clientes.Add(c1);
            _context.SaveChanges();

            Console.WriteLine("Cliente adicionado com sucesso!");
            Console.WriteLine("Aperte Qualquer Tecla Para Continuar");
            Console.ReadKey();
            Console.Clear();
        }
 


    public void VerDetalhesCliente()
        {
            Console.Clear();
            Console.WriteLine("==== Detalhes do Cliente ====");
            Console.Write("digite o ID do Cliente: ");
            var clienteId = int.Parse(Console.ReadLine());

            var cliente = _context.Clientes.FirstOrDefault( cliente => cliente.Id == clienteId);
            if (cliente == null)
                Console.WriteLine("Ciente não encontrado.");

            else
            {
                Console.WriteLine($"ID: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"CPF: {cliente.Cpf}");
                Console.WriteLine($"Telefone: {cliente.Telefone}");

            }
            Console.WriteLine("\nAperte Qualquer Tecla Para Continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
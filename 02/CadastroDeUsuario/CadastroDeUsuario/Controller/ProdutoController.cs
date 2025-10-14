using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuario.Controller
{
    internal class ProdutoController
    {
        private AppDbContext _context;


        public ProdutoController(AppDbContext context)
        {
            _context = context;

        }

        public void AdicionarProduto()
        {
            Console.Clear();
            Console.WriteLine("==== Adicionar Produto =====");
            
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");
            Decimal preco = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Data de Vencimento: ");
            DateOnly datavencinmento = DateOnly.Parse(Console.ReadLine());
            var NovoProduto = new Produto()
            {
                DataVencimento = datavencinmento,
                Nome = nome,
                Preco = preco

            };
            _context.Produtos.Add(NovoProduto);
            _context.SaveChanges();

            Console.WriteLine("Produto Cadastrado");
            Console.ReadKey();

        }

        public void ListarProduto()
        {

            Console.Clear();
            Console.WriteLine("==== Lista de Produtos ====");

            var produtos = _context.Produtos.ToList();

            if (produtos.Count == 0) 
            {
                Console.WriteLine("Sem produtos existentes");

            }
            else 
            {
            
              foreach(var produto in produtos)
                {

                    Console.WriteLine($"Id: {produto.Id} | Nome: {produto.Nome}");
                }
            
            
            }
            Console.WriteLine("\nPressione qualquer telca para voltar.");
            Console.ReadKey();


        }


        

    }
}

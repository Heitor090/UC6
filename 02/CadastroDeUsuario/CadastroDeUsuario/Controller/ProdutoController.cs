using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public void DetalhesProdutos()
        {
            // Dizer onde estou
            Console.Clear();
            Console.WriteLine("==== Detalhes Usuario ====");
            // Pedir ID produto
            Console.WriteLine("Digite o ID do Produto: ");
            var idProduto = int.Parse(Console.ReadLine());
            // Buscar produto no banco de dados
            var produto = _context.Produtos
                .FirstOrDefault(produtos => produtos.Id == idProduto);
            // Se nao encontar, avisar usuario
            if (idProduto == null) 
            {

                Console.WriteLine("\nId não encontrado");
            
            }

            // Se encontar, mostrar ao usuario
            else
            {
                Console.WriteLine("---- Dados Produtos ----");
                Console.WriteLine($"Id: {produto.Id}");
                Console.WriteLine($"Nome {produto.Nome}");
                Console.WriteLine($"Sobrenome {produto.Preco}");
                Console.WriteLine($"Nascimento {produto.DataVencimento}");
            }
            
            Console.WriteLine("\nPressione qualquer telca para voltar.");
            Console.ReadKey();

        }
        public void RemoverProduto()
        {

            Console.Clear();
            Console.WriteLine("==== Remover Produto ====");
            Console.Write("Digite o ID do produto: ");
            var idProduto = int.Parse(Console.ReadLine());
            var produtoParaDeletar = _context.Produtos
                    .FirstOrDefault(product => product.Id == idProduto);

    
            if (produtoParaDeletar == null)
            {
                Console.WriteLine("\nProduto não encontrado!");
                Console.ReadKey();
                return;
            }
            _context.Produtos.Remove(produtoParaDeletar);
            _context.SaveChanges();


            Console.WriteLine("\nPressione qualuqer tela para voltar.");
            Console.ReadKey();


        }
        public void AtualizarProduto()
        {
            Console.Clear();
            Console.WriteLine("==== Atualizar Produto ====");
            Console.Write("Digite o ID do Produto: ");
            var idProdutoInformado = int.Parse(Console.ReadLine());

            var produtoParaAtualizar = _context.Produtos
                .FirstOrDefault(product => product.Id == idProdutoInformado);

            if (produtoParaAtualizar == null)
            {
                Console.WriteLine("\nProduto não encontado!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"\nEditando novo produto: {produtoParaAtualizar.Nome}");
            Console.Write("Novo Nome:");
            string novoNome = Console.ReadLine();
            Console.Write("Novo Preço: ");
            decimal novopreco = decimal.Parse(Console.ReadLine());
            Console.Write("Nova data de vencimento (AAAA-MM-DD): ");
            DateOnly novaDataVencimento = DateOnly.Parse(Console.ReadLine());


            produtoParaAtualizar.Nome = novoNome;
            produtoParaAtualizar.Preco = novopreco;
            produtoParaAtualizar.DataVencimento = novaDataVencimento;


            _context.Produtos.Update(produtoParaAtualizar);
            _context.SaveChanges();

            Console.WriteLine("\n Produto atualizado com sucesso!");
            Console.WriteLine("Aperte qualquer tecla para continuar: ");
            Console.ReadKey();
        }


    }
}

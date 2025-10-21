using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuario.presentation
{
    internal class ConsoleUI

    {
        public ConsoleUI()
        {

        }
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
                Console.WriteLine("4. Atualizar usuário por ID");
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
                        usuarioController.AtualizarUsuario();
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
                Console.WriteLine("4. Atualizar Produtos");
                Console.WriteLine("5. Remover Produto");
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
                    case 4:
                        produtoController.AtualizarProduto();
                        break;
                    case 5:
                        produtoController.RemoverProduto();
                        break;
                    case 0:
                        voltar = true;
                        break;

                }



            }


        }
    }
}

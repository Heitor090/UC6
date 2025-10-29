using VeiculoConsoleApp.Controllers;


namespace VeiculoConsoleApp.Presentation
{

    internal class ConsoleUI
    {
        private VeiculoController _veiculoController;

        public ConsoleUI(VeiculoController veiculoController)
        {
            _veiculoController = veiculoController;
        }

        public void MenuPrincipal()
        {
            bool sair = false;
            while (!sair)
            {

                Console.Clear();
                Console.WriteLine("==== Menu Principal ====");
                Console.WriteLine("1. Gerenciar Veículos");
                Console.WriteLine("0. Sair");
                string opcao = Console.ReadLine();
                if (opcao == "1")
                {
                    MenuVeiculos();
                }
                else if (opcao == "0")
                {
                    sair = true;
                }


                void MenuVeiculos()
                {
                    bool voltar = false;
                    while (!voltar)
                    {
                        Console.Clear();
                        Console.WriteLine("==== Gerenciar Veículos =====");
                        Console.WriteLine("1. Adicionar Veículos");
                        Console.WriteLine("2. Listar Veículos");
                        Console.WriteLine("3. Ver detalhges do veículo");
                        Console.WriteLine("4. Atualizar Veículo");
                        Console.WriteLine("5. Deletar Veículo");
                        Console.WriteLine("0.Sair");

                        string opcao = Console.ReadLine();
                        switch (opcao)
                        {
                            case "1":
                                _veiculoController.AdicionarVeiculo();
                                break;
                            case "2":
                                _veiculoController.ListarVeiculos();
                                break;
                            case "3":
                                _veiculoController.DetalhesVeiculo();
                                break;
                            case "4":
                                _veiculoController.AtualizarVeiculo();
                                break;
                            case "5":
                                _veiculoController.RemoverVeiculo();
                                break;
                            case "0":
                                voltar = true;
                                break;

                        }


                    }
                }



            }
        }
    }
}

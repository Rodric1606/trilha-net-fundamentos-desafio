using DesafioFundamentos.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        // Coloca o encoding para UTF8 para exibir acentuação
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal precoInicial = 0;
        decimal precoPorHora = 0;

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine();
        Console.Write("Digite o preço inicial: ");

        string inputPrecoInicial = Console.ReadLine();

        while(!decimal.TryParse(inputPrecoInicial, out precoInicial))
        {
            Console.WriteLine("Valor inválido. Por favor digite um número para o preço inicial: ");
            Console.Write("Digite o preço inicial: ");
            inputPrecoInicial = Console.ReadLine();
        }
        precoInicial = Convert.ToDecimal(precoInicial.ToString("F2")); 

        Console.Write("Agora digite o preço por hora: ");
        string inputPrecoHora = Console.ReadLine();

        while(!decimal.TryParse(inputPrecoHora, out precoPorHora))
        {
            Console.WriteLine("Valor inválido. Por favor digite um número para o preço por hora");
            Console.Write("Digite o preço por hora: ");
            inputPrecoHora = Console.ReadLine();
        }
        precoPorHora = Convert.ToDecimal(precoPorHora.ToString("F2")); 

          // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
        Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

        string opcao = string.Empty;
        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            //Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                    es.AdicionarVeiculo();
                    break;

                case "2":
                    es.RemoverVeiculo();
                    break;

                case "3":
                    es.ListarVeiculos();
                    break;

                case "4":
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
    }
}
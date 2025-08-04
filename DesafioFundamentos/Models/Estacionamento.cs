using System.Linq.Expressions;
using System.Reflection;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if(veiculos.Any(v => v.Placa == placa.ToUpper()))
            {
                Console.WriteLine("Veiculo já consta no estacionamento");
            }
            else
            {
                veiculos.Add(new Veiculo(placa.ToUpper())); 
            }
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo que você deseja remover: ");
            string placa = Console.ReadLine();

            var veiculoParaRemover = veiculos.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());

            // Verifica se o veículo existe
            if (veiculoParaRemover != null)
            {               
                int horas = 0;
                decimal valorTotal = 0; 

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                horas = Convert.ToInt32(Console.ReadLine());

                valorTotal = precoInicial + (precoPorHora * horas);
               
                veiculos.Remove(veiculoParaRemover);

                Console.WriteLine($"O veículo {veiculoParaRemover.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                veiculos.ForEach(v => Console.WriteLine($"Placa: {v.Placa} "));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.OutputEncoding = Encoding.UTF8; // Define a codificação de saída como UTF-8
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            Console.WriteLine($"Veículo de placa {placa} estacionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.OutputEncoding = Encoding.UTF8; // Define a codificação de saída como UTF-8
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.OutputEncoding = Encoding.UTF8; // Define a codificação de saída como UTF-8
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento(5, 2); // Exemplo de preço inicial e por hora
            bool sair = false;

            while (!sair)
            {
                Console.OutputEncoding = Encoding.UTF8; // Define a codificação de saída como UTF-8
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Adicionar veículo");
                Console.WriteLine("2. Remover veículo");
                Console.WriteLine("3. Listar veículos");
                Console.WriteLine("4. Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        estacionamento.AdicionarVeiculo();
                        break;
                    case 2:
                        estacionamento.RemoverVeiculo();
                        break;
                    case 3:
                        estacionamento.ListarVeiculos();
                        break;
                    case 4:
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}

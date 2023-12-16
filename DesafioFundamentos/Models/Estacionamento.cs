using System.IO.Compression;
using System.Text.RegularExpressions;

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

        public void AdicionarVeiculo(string placa)
        {   //Além de adicionar, valida a placa para o padrão antigo e o padrão Mercosul.
            // Implementado
            string padraoPlaca = "^[a-zA-Z]{3}-?[0-9]{1}[a-zA-Z]{1}[0-9]{2}$|^[a-zA-Z]{3}-?[0-9]{4}$";
            if(Regex.IsMatch(placa, padraoPlaca))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} foi adicionado com sucesso");                                 
            }
            else
            {
                Console.WriteLine($"Placa inválida! Insira uma plana do padrão antigo ou Mercosul.");
            }    
            
        }       

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // Implementado !!
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
              
                // Implementado
                int horas = 0;
                decimal valorTotal = 0; 
                horas = int.Parse(Console.ReadLine());
                valorTotal = precoInicial + (precoPorHora * horas);

                // Implementado
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
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Implementado
                foreach(string item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void AtualizarPlaca(string placa, string novaPlaca)
        {   //atualiza a placa para caso a pessoa tenha digitado errado.
            int index = veiculos.FindIndex(c => c.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if(index != -1)
            {
                veiculos[index] = novaPlaca;
                Console.WriteLine("Placa atualizada com sucesso");
            }
            else
            {
                Console.WriteLine("Placa não encontrada");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetcore
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
    class Program
    {
        // Exercício 1:
        // - Fazer a média de notas dos dois alunos (Zuqui, Bronza) e imprimir no Console.WriteLine();
        // - Imprimir no console para cada aluno
        //      - Nome do aluno
        //      - Caso média maior ou igual 7:
        //          - Passou no ano letivo
        //          - Não passou no ano letivo
        // Requisítos:
        // - Criar um método "CalcularMedia", onde a entrada de parâmetros seja as notas e o retorno seja a média em float
        // - Utilizar For ou Foreach


        // Exercício 2:
        // - Fazer um programa que cadastre pessoas, contendo nome e idade;
        // - Imprimir a media de idade das pessoas
        // - Imprimir o nome e idade da pessoa mais velha
        // - Imprimir o nome e idade da pessoa mais nova
        // - Imprimir a quantidade de pessoas com maior idade
        // Requisítos:
        // - Utilizar List (Avg, Max, Min, Where)
        // - Utilizar Classe Pessoa
        static void Main(string[] args)
        {
            Console.WriteLine("Exercício 1");

            var xNotasZuqui = new List<int>() { 7, 6, 5, 3 };
            var xNotasBronza = new List<int>() { 8, 9, 10, 8 };

            double mediaBronza = CalcularMedia(xNotasBronza);
            double mediaZuqui = CalcularMedia(xNotasZuqui);
           
            Console.WriteLine("Notas do Bronza: " + mediaBronza + " e ele está " + IndicarStatusAprovacao(mediaBronza));
            Console.WriteLine("Notas do Zuqui: " + mediaZuqui + " e ele está " + IndicarStatusAprovacao(mediaZuqui));

            Console.WriteLine("");
            Console.WriteLine("Exercício 2");
            
            var pessoas = new List<Pessoa>();
            pessoas = ObterInformacoesPessoas();

            double somaIdades = 0;            
            int menorIdade = 1000;
            string pessoaMenorIdade = "";
            int maiorIdade = -1;
            string pessoaMaiorIdade = "";
            int qtdMaioridade = 0;

            for (int contadorPessoa = 0; contadorPessoa < 5; contadorPessoa++)
            {
                somaIdades = somaIdades + pessoas[contadorPessoa].Idade;
                if (pessoas[contadorPessoa].Idade < menorIdade) 
                {
                    menorIdade = pessoas[contadorPessoa].Idade;
                    pessoaMenorIdade = pessoas[contadorPessoa].Nome;
                }
                if (pessoas[contadorPessoa].Idade > maiorIdade) 
                {
                    maiorIdade = pessoas[contadorPessoa].Idade;
                    pessoaMaiorIdade = pessoas[contadorPessoa].Nome;
                }
                if (pessoas[contadorPessoa].Idade > 18) 
                    qtdMaioridade++;

            }

            Console.WriteLine("Média das idades: " + (somaIdades / 5) + " anos");
            Console.WriteLine("Menor idade: " + pessoaMenorIdade + " que tem " + menorIdade + " anos");
            Console.WriteLine("Maior idade: " + pessoaMaiorIdade + " que tem " + maiorIdade + " anos");
            Console.WriteLine("Há " + qtdMaioridade + " pessoas que são maiores de idade ");

        }

        static double CalcularMedia(List<int> pValor) => pValor.Average();

        static string IndicarStatusAprovacao(double pMedia)
        {
            if (pMedia >= 7)
            {
                return "APROVADO";
            }
            return "REPROVADO";
        }

        static List<Pessoa> ObterInformacoesPessoas()
        {
            var xRetorno = new List<Pessoa>();            
            for (int contadorPessoa = 1; contadorPessoa < 6; contadorPessoa++)
            {
                Console.WriteLine("Digite o nome da " + contadorPessoa + "ª pessoa:");
                var nome = Console.ReadLine();
                Console.WriteLine("Digite a idade do(a) " + nome);
                var idade = int.Parse(Console.ReadLine());
                xRetorno.Add(new Pessoa
                {
                    Nome = nome, Idade = idade
                });                
            }
            return xRetorno;
        }
    }
}

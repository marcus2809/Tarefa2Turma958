using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tarefa2CS
{
    public class questao1
    {
        static void Main(string[] args)
        {
            int[,] matrizDistancias = FromFile();
            Console.WriteLine("Insira o percurso, separando os valores por espaço:");
            string percursoLido = Console.ReadLine();

            var percurso = percursoLido.Split(' ').Select(int.Parse).ToList();
            percurso = percurso.Select(x => x - 1).ToList();

            int distanciaPercorrida = 0;

            for (int i = 1; i < percurso.Count(); i++)
            {
                distanciaPercorrida += matrizDistancias[percurso[i-1], percurso[i]];
            }

            Console.WriteLine($"A distância percorrida foi {distanciaPercorrida}");
        }   

        public static int[,] FromFile()
        {
            var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var nomeArquivo = "Distancias.txt";

            var caminhoArquivo = Path.Combine(caminhoDesktop, nomeArquivo);

            string[] conteudo = File.ReadAllLines(caminhoArquivo);

            int[,] matrizDistancias = new int[conteudo.Length, conteudo.Length];

            for (int i = 0; i < conteudo.Length; i++)
            {
                string[] distancias = conteudo[i].Split(' ');
                for (int j = 0; j < conteudo.Length; j++)
                {
                    matrizDistancias[i,j] = int.Parse(distancias[j]);
                }
            }

            return matrizDistancias;
        }
    }
}

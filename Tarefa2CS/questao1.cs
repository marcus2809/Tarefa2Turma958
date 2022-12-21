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
            int[,] matrizDistancias = MatrixFromFile("matriz.txt");

            int[] percurso = VectorFromFile("caminho.txt");

            int distanciaPercorrida = 0;

            for (int i = 1; i < percurso.Length; i++)
            {
                distanciaPercorrida += matrizDistancias[percurso[i-1], percurso[i]];
            }

            Console.WriteLine($"A distância percorrida foi {distanciaPercorrida}");
        }
        
        public static string[] ConfigFile(string nomeArquivo)
        {
            var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoArquivo = Path.Combine(caminhoDesktop, nomeArquivo);
            string[] conteudo = File.ReadAllLines(caminhoArquivo);
            return conteudo;
        }

        public static int[,] MatrixFromFile(string nomeArquivo)
        {
            var conteudo = ConfigFile(nomeArquivo);

            int[,] matrizDistancias = new int[conteudo.Length, conteudo.Length];

            for (int i = 0; i < conteudo.Length; i++)
            {
                string[] distancias = conteudo[i].Split(',');
                for (int j = 0; j < conteudo.Length; j++)
                {
                    matrizDistancias[i,j] = int.Parse(distancias[j]);
                }
            }

            return matrizDistancias;
        }

        public static int[] VectorFromFile(string nomeArquivo)
        {
            string[] conteudo = ConfigFile(nomeArquivo);
            var cidades = conteudo[0].Split(','); 
            int[] vetorCidades = new int[cidades.Length];

            for (int i = 0; i < vetorCidades.Length; i++)
            {
                vetorCidades[i] = int.Parse(cidades[i]);
                vetorCidades[i]--;
            }

            return vetorCidades;
        }
    }
}

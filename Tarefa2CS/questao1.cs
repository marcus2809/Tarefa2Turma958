using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var itensMatriz = LeitorCsv("matriz.txt");
            int tamMatriz = (int) Math.Sqrt(itensMatriz.Count());
            
            int[,] matrizDistancias = new int[tamMatriz,tamMatriz];

            for (int i = 0; i < tamMatriz; i++)
            {
                for (int j = 0; j < tamMatriz; j++)
                {
                    matrizDistancias[i, j] = itensMatriz[tamMatriz * i + j];
                }
            }

            var percurso = LeitorCsv("caminho.txt");
            
            int distanciaPercorrida = 0;

            for (int i = 1; i < percurso.Count(); i++)
            {
                distanciaPercorrida += matrizDistancias[percurso[i-1]-1, percurso[i]-1];
            }

            Console.WriteLine($"A distância percorrida foi {distanciaPercorrida}");
        }
        
        public static string ConfigFile(string nomeArquivo)
        {
            var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoArquivo = Path.Combine(caminhoDesktop, nomeArquivo);
            return caminhoArquivo;
        }

        public static List<int> LeitorCsv(string nomeArquivo)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var caminhoMatriz = ConfigFile(nomeArquivo);
            using var reader = new StreamReader(caminhoMatriz);
            using var csv = new CsvParser(reader, config);

            var items = new List<int>();

            while (csv.Read())
            {
                foreach (var item in csv.Record)
                {
                    items.Add(int.Parse(item));
                }
            }

            return items;
        }
    }
}

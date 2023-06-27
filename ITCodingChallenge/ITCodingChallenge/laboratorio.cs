using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCodingChallenge
{
    public class laboratorio
    {

        #region Base
        [Benchmark(Description = "ContaParede")]
        public int ContaParede(int[][] wall)
        {
            int soma = 0;
            int alvo = 0;
            int totalBlocks;
            int result;
            Dictionary<int, int> total = new Dictionary<int, int>();

            for (int coluna = 0; coluna < wall[1].Length; coluna++) // O(N)
            {
                alvo += wall[1][coluna];
            }

            #region O(N^3)
            for (int posicao = 1; posicao < alvo; posicao++) // O(N)
            {
                totalBlocks = 0;
                for (int linha = 0; linha < wall.Length; linha++) // O(N)
                {
                    for (int coluna = 0; coluna < wall[linha].Length; coluna++) // O(N)
                    {
                        int valor = wall[linha][coluna];
                        soma += valor;
                        if (posicao == soma)
                        {
                            break;
                        }
                        else if (posicao < soma)
                        {
                            totalBlocks++;
                            break;
                        }
                    }
                    soma = 0;
                }
                total.Add(posicao, totalBlocks);

            }
            #endregion O(N^3)

            result = total.Values.Min();

            return result;
        }

        #endregion Base


        public int[][] GerarParedeExemplo()
        {
            int[][] parede = new int[6][];
            parede[0] = new int[] { 1, 2, 2, 1 };
            parede[1] = new int[] { 3, 1, 2 };
            parede[2] = new int[] { 1, 3, 2 };
            parede[3] = new int[] { 2, 4 };
            parede[4] = new int[] { 3, 1, 2 };
            parede[5] = new int[] { 1, 3, 1, 1 };

            return parede;
        }

        #region Calculando
        //[Benchmark(Description = "QtdLargura")]
        public int QtdLargura(int[] wall)
        {
            int qtd = 0;

            #region O(N)
            for (int coluna = 0; coluna < wall.Length; coluna++)
            {
                qtd += wall[coluna];
            }
            #endregion O(N)

            return qtd;
        }

        //[Benchmark(Description = "ContaNumeroTijoloPorPosicao")]
        public Dictionary<int, int> ContaNumeroTijoloPorPosicao()
        {
            int soma = 0;
            int[][] parede = GerarParedeExemplo();
            int alvo = QtdLargura(parede[0]);  //O(N)
            int totalBlocks = 0;
            Dictionary<int, int> total = new Dictionary<int, int>();

            #region O(N^3)
            for (int posicao = 1; posicao < alvo; posicao++) //O(N)
            {
                totalBlocks = 0;
                for (int linha = 0; linha < parede.Length; linha++) //O(N)
                {
                    for (int coluna = 0; coluna < parede[linha].Length; coluna++) //O(N)
                    {
                        int valor = parede[linha][coluna];
                        soma += valor;
                        if (posicao == soma)
                        {
                            break;
                        }
                        else if (posicao < soma)
                        {
                            totalBlocks++;
                            break;
                        }
                    }
                    soma = 0;
                }
                total.Add(posicao, totalBlocks);

            }
            #endregion O(N^3)

            return total;
        }

        //[Benchmark(Description = "MenorQtdTijoloCortado")]
        public int MenorQtdTijoloCortado()
        {

            Dictionary<int, int> cortes = ContaNumeroTijoloPorPosicao();

            return cortes.Values.Min(); //O(N)

        }

        #endregion Calculando
    }
}

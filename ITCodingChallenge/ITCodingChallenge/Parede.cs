using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Mathematics;

namespace ITCodingChallenge
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Arabic)]
    public class Parede
    {

        #region contrutor

        public Parede()
        {
        }

        #endregion contrutor

        [Benchmark(Description = "MenorNumTijolosCortados")]
        public int MenorNumTijolosCortados() // O(n*m) + O(n) = O(2n*m) = O(n*m)
        {
            int[][] parede = GerarParedeExemplo2();
            Dictionary<int, int> contaTamnhoArestaTijolos = new Dictionary<int, int>();

            // O(n) * (O(m) + O(1)) = O(n*m)
            for (int linha = 0; linha < parede.Length; linha++) // O(n)
            {
                int posicao = 0;
                for (int tijolo = 0; tijolo < parede[linha].Length - 1; tijolo++)  // O(m)
                {
                    posicao += parede[linha][tijolo];

                    if (contaTamnhoArestaTijolos.ContainsKey(posicao)) // O(1)
                    {
                        contaTamnhoArestaTijolos[posicao]++;  //adiciona qual posição passou novamente
                    }
                    else
                    {
                        /*cria o tamanho do tijolo, 
                         * exemplo: passando 1x no tijolo, cria o tamanho de tijolo 1, 
                         * passando no tamanho 1+2=3 do tijolo, cria o tamanho 3 tijolo, 
                         * que é a posição. 
                         */
                        contaTamnhoArestaTijolos[posicao] = 1;
                    }
                }
            }
            int maxTijolosCortados = 0;
            int menor = 0;
            if (contaTamnhoArestaTijolos.Values.Count() > 0)
                maxTijolosCortados = contaTamnhoArestaTijolos.Values.Max(); // O(n)

            int altura = parede.GetLength(0);
            if (maxTijolosCortados < altura)
                menor = altura - maxTijolosCortados;

            return menor;
        }

        [Benchmark(Description = "ContaParede")]
        public int ContaParede()
        {
            int[][] parede = GerarParedeExemplo2();
            int soma = 0;
            int alvo = 0;
            int totalBlocks;
            int result;
            Dictionary<int, int> total = new Dictionary<int, int>();

            alvo = parede[0].Sum(); // O(n)

            #region O(N^3)
            for (int posicao = 1; posicao < alvo; posicao++) // O(n)
            {
                totalBlocks = 0;
                for (int linha = 0; linha < parede.Length; linha++) // O(n)
                {
                    for (int coluna = 0; coluna < parede[linha].Length; coluna++) // O(n)
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

            result = total.Values.Min();

            return result;
        }

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

        public int[][] GerarParedeExemplo2()
        {
            int[][] parede = new int[14][];
            parede[0] = new int[] { 1, 2, 2, 1, 1, 3, 1, 1, 3, 1, 2, 3, 1, 2, 1 };
            parede[1] = new int[] { 3, 1, 2, 3, 1, 2, 1, 1, 2, 2, 1, 1, 3, 1, 1 };
            parede[2] = new int[] { 1, 3, 2, 2, 4, 1, 2, 4, 1, 3, 2, 1 };
            parede[3] = new int[] { 2, 4, 1, 3, 2, 1, 1, 3, 2, 2, 4, 1 };
            parede[4] = new int[] { 3, 1, 2, 3, 1, 3, 1, 3, 1, 1, 1, 2, 2, 2 };
            parede[5] = new int[] { 1, 3, 1, 1, 1, 2, 2, 2, 3, 1, 2, 3, 1, 3 };
            parede[6] = new int[] { 13, 13 };
            parede[7] = new int[] { 1, 2, 2, 1, 1, 3, 1, 1, 3, 1, 2, 3, 1, 2, 1 };
            parede[8] = new int[] { 3, 1, 2, 3, 1, 2, 1, 1, 2, 2, 1, 1, 3, 1, 1 };
            parede[9] = new int[] { 1, 3, 2, 2, 4, 1, 2, 4, 1, 3, 2, 1 };
            parede[10] = new int[] { 2, 4, 1, 3, 2, 1, 1, 3, 2, 2, 4, 1 };
            parede[11] = new int[] { 3, 1, 2, 3, 1, 3, 1, 3, 1, 1, 1, 2, 2, 2 };
            parede[12] = new int[] { 1, 3, 1, 1, 1, 2, 2, 2, 3, 1, 2, 3, 1, 3 };
            parede[13] = new int[] { 26 };

            return parede;
        }

    }
}

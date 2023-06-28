﻿using ParedeAPI.Contrato.Servico;

namespace ParedeAPI.Servico
{
    public class ParedeService : IParedeService
    {

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

        public int[][] GerarParedeMassaGrande()
        {
            Dictionary<int, int[]> randomarray = new Dictionary<int, int[]>();
            randomarray.Add(1, new int[] { 1, 2, 2, 1 });
            randomarray.Add(2, new int[] { 3, 1, 2 });
            randomarray.Add(3, new int[] { 1, 3, 2 });
            randomarray.Add(4, new int[] { 2, 4 });
            randomarray.Add(5, new int[] { 3, 1, 2 });
            randomarray.Add(6, new int[] { 1, 3, 1, 1 });
            randomarray.Add(7, new int[] { 1, 1, 3, 1 });
            randomarray.Add(8, new int[] { 2, 2, 2 });
            randomarray.Add(9, new int[] { 1, 2, 3 });
            randomarray.Add(10, new int[] { 3, 3 });

            int[][] parede = new int[6200][];

            for (int i = 0; i < 6200; i++)
            {
                if (i >= 0 && i <= 999)
                    parede[i] = randomarray.Single(x => x.Key == 1).Value;
                else if (i >= 1000 && i <= 1999)
                    parede[i] = randomarray.Single(x => x.Key == 2).Value;
                else if (i >= 2000 && i <= 2999)
                    parede[i] = randomarray.Single(x => x.Key == 3).Value;
                else if (i >= 3000 && i <= 3999)
                    parede[i] = randomarray.Single(x => x.Key == 4).Value;
                else if (i >= 4000 && i <= 4999)
                    parede[i] = randomarray.Single(x => x.Key == 5).Value;
                else if (i >= 5000 && i <= 5999)
                    parede[i] = randomarray.Single(x => x.Key == 6).Value;
                else
                    parede[i] = randomarray.Single(x => x.Key == 7).Value;
            }

            return parede;
        }

        public bool IsParede(int[][]? parede) // O(n+m) + O(n) = O(2n+m) = O(n+m) 
        {
            //valida se a parede existe
            if (parede == null)
                return false;

            //soma quantidade de elemento/tijolos da parede
            int totalTijolos = parede.Sum(p => p.Length); // O(n+m)

            //compara se a parede temo minimo ou tem o maximo de tijolos
            if (totalTijolos < 1 || totalTijolos > 20000)
                return false;

            //verificar se a altura tem o maximo permitido
            if (parede.Length > 10000)
                return false;

            int linhaSoma = 0;
            int soma = 0;
            //verifica se a largura tem o maximo permitido
            // O(n) * O(m) = O(n*m)
            for (int linha = 0; linha < parede.Length; linha++) // O(n)
            {
                if (linhaSoma == 0)
                    linhaSoma = parede[linha].Sum(); // O(m)

                if (parede[linha].Length > 10000)
                    return false;

                soma = parede[linha].Sum(); // O(m)
                if (linhaSoma != soma)
                    return false;

            }

            return true;
        }

        public int ContaParede(int[][] parede)
        {
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
    }
}

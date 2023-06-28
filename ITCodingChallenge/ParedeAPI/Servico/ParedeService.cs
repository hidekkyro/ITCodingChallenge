using ParedeAPI.Contrato.Servico;

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

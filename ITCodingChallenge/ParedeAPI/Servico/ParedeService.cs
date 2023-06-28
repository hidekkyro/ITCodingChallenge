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

        public int[][] GerarParedeMassaGrande()
        {
            Dictionary<int, int[]> randomarray = new Dictionary<int, int[]>();
            randomarray.Add(1, new int[] { 10000, 20000, 20000, 10000 });
            randomarray.Add(2, new int[] { 30000, 10000, 20000 });
            randomarray.Add(3, new int[] { 10000, 30000, 20000 });
            randomarray.Add(4, new int[] { 20000, 40000 });
            randomarray.Add(5, new int[] { 30000, 10000, 20000 });
            randomarray.Add(6, new int[] { 10000, 30000, 10000, 10000 });
            randomarray.Add(7, new int[] { 10000, 10000, 30000, 10000 });
            randomarray.Add(8, new int[] { 20000, 20000, 20000 });
            randomarray.Add(9, new int[] { 10000, 20000, 30000 });
            randomarray.Add(10, new int[] { 30000, 30000 });

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

        /*
         * contar quantas vezes eu fui até certo ponto e quantificar, 
         * no exemplo do enunciado, contando os tijolos, quantidas vezes eu cheguei até a certa posição
         * 1-1+1+1
         * 3-1+1+1
         * 5-1+1
         * 4-1+1+1+1
         * 2-1
         */
        public int MenorNumTijolosCortados(int[][] parede) // O(n*m) + O(n) = O(2n*m) = O(n*m)
        {
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
    }
}

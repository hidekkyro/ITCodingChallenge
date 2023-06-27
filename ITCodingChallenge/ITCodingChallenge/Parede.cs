using BenchmarkDotNet.Attributes;

namespace ITCodingChallenge
{

    public class Parede
    {

        #region contrutor

        public Parede()
        {
        }

        #endregion contrutor


        #region Metodos

        public string Status(int[][] parede)
        {
            string printParede = "[";
            for (int i = 0; i < parede.Length; i++)
            {
                printParede += "[";
                for (int j = 0; j < parede[i].Length; j++)
                {
                    printParede += parede[i][j] + ", ";
                }
                printParede = printParede.Substring(0, printParede.Length - 2);
                printParede += "], \n";
            }
            printParede = printParede.Substring(0, printParede.Length - 3);
            printParede += "]";

            return printParede;
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

        #region 
        /*
         * Altura da parede tem até 10.000 (linhas)
         */
        public int[][] GerarParedeAltura(int maxLinhas = 10000)
        {
            Random random = new Random();
            return new int[random.Next(1, maxLinhas)][];
        }

        /*
         * o tamanho dos blocos podem ser de até max_int = 2.147.483.647
         * pode contem 20.000 tijolos
         * o tamanho total dos tijolos, são sempre os mesmos
         * exemplo, parede tem uma largura de 2 e uma altura de 2, podedo gerar um tijolo de 2.147.483.646 e o outro de 1
         * [ [2.147.483.646, 1],
         *   [1, 2.147.483.646] ]
        */
        public void CriarTijolo(int[][] parede, int tamanhoMin = 1, int tamanhoMax = int.MaxValue)
        {
            Random random = new Random();
            int qtdTijoloPorLinha = random.Next(1, 20000) / parede.Length;
            int totalComprimentoTj = random.Next(tamanhoMin, tamanhoMax);

            //for(int linha = 0; linha < parede.Length; linha++)
            //{

            //}

        }

        public bool ValidaParede(int[][] parede)
        {

            if (parede.Length > 10000)
                return false;

            for (int linha = 0; linha < parede.Length; linha++)
            {
                if (parede[linha].Length > 10000)
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
        public int MenorNumTijolosCortados(int[][] parede)
        {
            Dictionary<int, int> contaTamnhoArestaTijolos = new Dictionary<int, int>();

            // O(n^2)
            for (int linha = 0; linha < parede.Length; linha++) // O(n)
            {
                int posicao = 0;
                for (int tijolo = 0; tijolo < parede[linha].Length - 1; tijolo++)  // O(n)
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

            int menor = parede.GetLength(0) - contaTamnhoArestaTijolos.Values.Max(); // O(n)

            return menor;
        }


        #endregion

        #endregion Metodos
    }
}

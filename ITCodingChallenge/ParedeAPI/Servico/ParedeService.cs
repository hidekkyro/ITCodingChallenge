﻿namespace ParedeAPI.Servico
{
    public class ParedeService
    {
        public ParedeService()
        {
            
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

            int menor = parede.GetLength(0) - contaTamnhoArestaTijolos.Values.Max(); // O(n)

            return menor;
        }
    }
}
# ITCodingChallenge
Teste de proficiência em raciocínio lógico e conhecimentos de programação

- Existe uma parede de tijolos em frente de você. Esta parede é retangular e possui várias linhas compostas de tijolos de 
mesma altura, mas de comprimentos diferentes. Você precisa desenhar uma linha vertical do topo à base que corta o 
mínimo número de tijolos.

- A parede de tijolos é representada como um array de arrays de inteiros. Cada inteiro representa o comprimento de cada 
tijolo.

- Se a linha que você precisa traçar passa pela aresta de um tijolo, então este tijolo não é considerado como um tijolo 
cortado. Você precisa encontrar como traçar essa linha cortando o menor número de tijolos possível e retornar o número 
de tijolos cortados.

Não é permitido traçar uma linha através de uma das extremidades da parede, o que contaria como nenhum tijolo 
cortado.
#### o Exemplo:
```C#
Input: [[1,2,2,1],
       [3,1,2],
       [1,3,2],
       [2,4],
       [3,1,2],
       [1,3,1,1]]
Output: 2
```
- Explicação:
  
![](https://github.com/hidekkyro/ITCodingChallenge/blob/main/parede.jpg?raw=true)
- Notas:
  - A soma dos comprimentos dos tijolos em cada array interno é sempre a mesma e não excederá MAX_INT.
  - O número de tijolos em cada linha está em um range de [1,10.000]. A altura da parede está em um range de [1, 10.000]. O número total de tijolos não excederá 20.000.

- Os entregáveis consistem no código fonte em uma linguagem de programação a seu critério e uma análise da complexidade assintótica (big-O notation) do tempo de execução da sua solução



# Resolução

Verifica a quantidade de tamanho dos blocos de uma amostra, no caso a primeira linha, desta forma, começo a verificar cada possível corte, linha e coluna, um a um.

Percorre a linha até a posição do possível corte. 
    
- Caso a somatório dos tijolos resulte na posição do possível corte, então o corte será na emenda, não cortando o tijolo; 

- Caso a somatório dos tijolos resulte maior do que a posição do possível corte, então há corte no tijolo, desta maneira é adicionado em um dicionario a posição e a quantidade de blocos cortado para aquela posição.

Após o termino de categorizar os cortes de tijolos por posição, é recuperado o menor valor do dicionário, com o objetivo de retornar o menor números de cortes.


```C#
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
```



# Complexidade

Conforme mostra o código acima, temos uma complexidade O(n^3) em big-O notation.



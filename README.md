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

O método consiste em passar linha a linha somando cada aresta dos tijolos, somando a quantidade de tijolos não cortados.

Para cada última aresta de cada tijolo, é computado em um dicionário, armazenado-o a quantidade de vezes que passou por este tamanho de tijolo, seja ela um tijolo ou um conjunto de tijolos, desta forma, conseguimos computar a quantidade de tijolos não cortados e independente do tamanho dos tijolos.

For fim, comparamos a altura da parede com o maior número de cortes "perfeitos" (não cortados), o resultado é a quantidade de tijolos cortados.


```C#
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
```



# Complexidade

Conforme mostra o código acima, temos uma complexidade O(n*m) em big-O notation.

Foram executados dois cenários, um com o modelo exemplo do enunciado, e o outro com uma quantidade maior de linhas e tijolos.

### Parede Exemplo
```
Altura de 6 (linhas)
Total de 19 tijolos
Total de cortes: 2
Tempo total de execução: 00:00:00.0000924 
```

### Parede Maior
```
Altura de 6.200 (linhas)
Total de 19.800 tijolos
Total de cortes: 2200
Tempo total de execução: 00:00:00.0052446
```

Veja abaixo uma tabela que compara o tempo de execução para cada cenário

| Cenário      | Tempo |
| --------- | -----:|
| Parede Exemplo  | 00:00:00.0000924 |
| Parede Maior     | 00:00:00.0052446 |

Concluímos que por se tratar de uma complexidade quadrática O(n*m), a tendência é que aumente forma quadrática de acordo com o tamanho do dado processado.

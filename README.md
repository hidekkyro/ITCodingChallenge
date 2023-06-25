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

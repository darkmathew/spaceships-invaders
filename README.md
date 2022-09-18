# Download do jogo

[Baixar jogo no Gamejolt](https://gamejolt.com/games/spaceshipsinvaders/751062)

[Baixar jogo via Github](https://github.com/darkmathew/spaceships-invaders/tree/main/Windows%20Executable/spaceships-invaders-windows.rar)

# Qual o objetivo do jogo?

Spaceships Invaders é inspirado no clássico jogo [Space Invaders](https://pt.wikipedia.org/wiki/Space_Invaders), porém com notáveis modificações. Para esta adaptação foi solicitado que o conceito de Pilha e Fila fosse aplicado, durante o curso de Jogos Digitais (IFBA - Lauro de Freitas), para avaliação na matéria de Oficina de Desenvolvimento de Jogos II (Semestre 2022.2).

## Em que lugar Pilha entra nessa história?

Durante as 3 fases presentes no jogo, é observável que algumas missões para destruir uma quantia aleatória X de naves irão aparecer. Para isso acontecer fez-se a atribuição de missões numa pilha, cada missão é obtida via `stack_name.Peek()` e após concluir a missão é feito um `stack_name.Pop()` e prossegue para a posterior, até que não haja mais missões disponíveis para serem realizadas.


## E a fila, o que tem a ver?

Para a aplicação de fila, fez-se o instanciamento dos [**GameObjects**](https://docs.unity3d.com/ScriptReference/GameObject.html) e adicionou-se a fila. A regra da fila é: "O primeiro entrar é o primeiro a sair.", logo para que uma nave de uma fila específica seja destruída, ela necessita estar no topo da fila, para assim abrir espaço para a posterior ser destruída também.

## Game Engine 

O jogo foi desenvolvido na [Unity](https://unity.com/), utilizando a linguagem de programação C#.

# Créditos

### Desenvolvedores: 

Matheus Augusto & Bruna Santos.

### Docentes orientadores:

Bárbara Janaína & Luiz Alcántara.

### Instituição

Instituto Federal de Educação, Ciência e Tecnologia da Bahia - Campus Lauro de Freitas. [Conheça o portal da Instituição](https://portal.ifba.edu.br/lauro-de-freitas/menu-cursos/superior/tec-jogos-digitais).
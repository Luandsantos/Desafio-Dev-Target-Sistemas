Programas desenvolvidos em C# como parte do processo seletivo da Target Sistemas para a vaga de Desenvolvedor/a de Sistemas Jr.

# Como executar
É necessário ter o **.NET 9 SDK** instalado.

No diretório do projeto, na pasta dos desafios (/Desafio1, /Desafio2 e /Desafio3), execute:

```bash
dotnet run
```

# Desafio 1 

Programa recebe uma lista de vendas em formato JSON e calcula a comissão correspondente a cada venda, agrupando posteriormente o valor total da comissão por vendedor.

## Funcionamento

O programa:

1. Lê os dados de vendas armazenados em uma string JSON.
2. Desserializa o JSON para objetos Venda.
3. Percorre cada venda e determina a porcentagem de comissão de acordo com seu valor.
4. Localiza o vendedor na lista de comissões.
5. Cria um novo registro caso seja a primeira venda do vendedor ou adiciona a comissão ao seu total.
6. Exibe a comissão total de cada vendedor com duas casas decimais.

## Resultado

Com os dados fornecidos no desafio, o programa produz:

```
---
Vendedor: João Silva
Comissão total: R$ 495,68
---
Vendedor: Maria Souza
Comissão total: R$ 465,95
---
Vendedor: Carlos Oliveira
Comissão total: R$ 379,37
---
Vendedor: Ana Lima
Comissão total: R$ 404,98
---
```

# Desafio 2

Programa gerencia movimentações de estoque, permitindo registrar entradas e saídas de produtos e consultar a quantidade atual após cada movimentação.

## Funcionamento

O programa:

1. Lê os dados dos produtos armazenados em uma string JSON.
2. Desserializa o JSON para objetos Estoque.
3. Exibe a lista inicial de produtos e suas respectivas quantidades em estoque.
4. Solicita o código do produto que será movimentado e verifica se ele existe.
5. Solicita o tipo de movimentação, permitindo entrada ou saída.
6. Solicita a quantidade a ser movimentada e valida se a operação pode ser realizada.
7. Atualiza a quantidade do estoque de acordo com o tipo de movimentação.
8. Solicita uma descrição para a movimentação e gera um identificador único para ela.
9. Exibe a quantidade atualizada do produto.
10. Permite realizar novas movimentações até que o usuário encerre as operações.
11. Ao final, exibe a lista de movimentações realizadas.

## Resultado

Com os dados fornecidos no desafio, após uma entrada de 500 unidades para o produto Borracha Branca e a confirmação de encerramento de operações, o programa produz:

```
---
Produto movimentado: Borracha Branca
Estoque atual: 700
---

LISTA DE MOVIMENTAÇÕES
---
Código da Movimentação: 1
Descrição da movimentação: Adição de 500 borrachas ao estoque.
---
```

# Desafio 3

Programa recebe um valor em reais e uma data de vencimento e calcula o valor dos juros com base na quantidade de dias de atraso, considerando uma multa de 2,5% ao dia.

## Funcionamento

O programa:

1. Obtém a data atual do computador.
2. Solicita um valor em reais até que seja informado um valor válido.
3. Solicita a data de vencimento até que seja informada uma data válida.
4. Calcula a quantidade de dias entre a data de vencimento e a data atual.
5. Verifica a situação da dívida:
- Se houver atraso, calcula e exibe o valor dos juros.
- Se o vencimento for hoje, informa que não há juros por atraso.
- Se o vencimento for futuro, informa que a dívida ainda não está vencida.

## Resultado

Usando a data atual 08/10/2026, após uma entrada de R$500,50 e data 01/10/2026, o programa produz:

```
Digite um valor em reais:
500,50
Digite a data de vencimento:
01/10/2026
Devido ao atraso de 7 dia(s), o valor dos juros será de R$87,59.
```

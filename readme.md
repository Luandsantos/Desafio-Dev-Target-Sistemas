Programas desenvolvidos em C# como parte do processo seletivo da Target Sistemas para a vaga de Desenvolvedor/a de Sistemas Jr.

## Desafio 1 

O programa recebe uma lista de vendas em formato JSON e calcula a comissão correspondente a cada venda, agrupando posteriormente o valor total da comissão por vendedor.

### Regras de comissão

| Valor da venda                       | Comissão |
| ------------------------------------ | -------: |
| Abaixo de R$ 100,00                  |       0% |
| De R$ 100,00 até abaixo de R$ 500,00 |       1% |
| A partir de R$ 500,00                |       5% |

## Funcionamento

O programa:

1. Lê os dados de vendas armazenados em uma string JSON.
2. Desserializa o JSON para objetos `Venda`.
3. Percorre cada venda e determina a porcentagem de comissão de acordo com seu valor.
4. Localiza o vendedor na lista de comissões.
5. Cria um novo registro caso seja a primeira venda do vendedor ou adiciona a comissão ao seu total.
6. Exibe a comissão total de cada vendedor com duas casas decimais.

## Como executar

É necessário ter o **.NET 9 SDK** instalado.

No diretório do projeto, execute:

```bash
dotnet run
```

Também é possível compilar o projeto com:

```bash
dotnet build
```

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

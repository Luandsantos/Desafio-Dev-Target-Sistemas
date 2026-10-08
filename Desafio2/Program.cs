using System.Text.Json;

namespace Desafio2
{

    public class Estoques
    {
        public required Estoque[] estoque { get; set; }
    }

    public class Estoque
    {
        public required int codigoProduto { get; set; }
        public required string descricaoProduto { get; set; }
        public int estoque { get; set; }
    }

    public class Movimentacao
    {
        public int codigoMovimentacao { get; set; }
        public required string descricaoMovimentacao { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            string jsonString =
                """
                                {
                 	"estoque":
                	[
                	  {
                		"codigoProduto": 101,
                		"descricaoProduto": "Caneta Azul",
                		"estoque": 150
                	  },
                	  {
                		"codigoProduto": 102,
                		"descricaoProduto": "Caderno Universitário",
                		"estoque": 75
                	  },
                	  {
                		"codigoProduto": 103,
                		"descricaoProduto": "Borracha Branca",
                		"estoque": 200
                	  },
                	  {
                		"codigoProduto": 104,
                		"descricaoProduto": "Lápis Preto HB",
                		"estoque": 320
                	  },
                	  {
                		"codigoProduto": 105,
                		"descricaoProduto": "Marcador de Texto Amarelo",
                		"estoque": 90
                	  }
                	]
                }
                
                """;

            Estoques? estoques = JsonSerializer.Deserialize<Estoques>(jsonString);

            if (estoques?.estoque != null)
            {
                Console.WriteLine("LISTA DE ESTOQUES");
                foreach (Estoque e in estoques.estoque)
                {
                    Console.WriteLine("---");
                    Console.WriteLine($"Código do Produto: {e.codigoProduto}");
                    Console.WriteLine($"Descrição do Produto: {e.descricaoProduto}");
                    Console.WriteLine($"Qtde em Estoque: {e.estoque}");
                }
                Console.WriteLine("---");
            }

            var movimentacoes = new List<Movimentacao>();
            int codigoMovimentacaoGerada = 0;
            int count = 0;

            // COMEÇO DAS OPERAÇÕES
            string continuarOperacoes = "sim";

            while(continuarOperacoes.ToLower() == "sim" || continuarOperacoes.ToLower() == "s")
            {
                // ATRIBUTOS PARA OPERAÇÕES
                int lerCodigoProduto = 0;
                string operacaoMovimentacao = "";
                int qtdeMovimentada = 0;
                string descricaoMovimento = "";

                // Procura o produto
                bool produtoEncontrado;

                do
                {
                    produtoEncontrado = false;
                    count = 0;

                    Console.WriteLine("\nDigite o código do produto que deseja movimentar: ");
                    lerCodigoProduto = Convert.ToInt32(Console.ReadLine());

                    foreach (Estoque e in estoques!.estoque)
                    {
                        if (e.codigoProduto == lerCodigoProduto)
                        {
                            produtoEncontrado = true;
                            break;
                        }
                        count++;
                    }

                } while (!produtoEncontrado);

                Console.WriteLine($"Produto: {estoques.estoque[count].descricaoProduto}");

                // Define se é entrada ou saída
                do
                {
                    Console.WriteLine("Entrada ou Saída?");
                    operacaoMovimentacao = (Console.ReadLine() ?? "").ToLower(); ;
                } while (operacaoMovimentacao != "entrada" && operacaoMovimentacao != "saída" && operacaoMovimentacao != "saida");

                // Define e valida valor do movimento
                bool valorValido = false;

                do
                {
                    Console.WriteLine("Digite o valor do movimento:");
                    qtdeMovimentada = Convert.ToInt32(Console.ReadLine());

                    if (qtdeMovimentada > 0)
                    {
                        if (operacaoMovimentacao == "entrada")
                        {
                            estoques.estoque[count].estoque += qtdeMovimentada;
                            valorValido = true;
                        }
                        else if (estoques.estoque[count].estoque >= qtdeMovimentada)
                        {
                            estoques.estoque[count].estoque -= qtdeMovimentada;
                            valorValido = true;
                        }
                        else
                        {
                            Console.WriteLine("Essa quantidade não é válida para essa operação.");
                        }
                    } else
                    {
                        Console.WriteLine("Digite um valor maior que zero.");
                    }
                } while (!valorValido);

                // Define a descrição da movimentação
                Console.WriteLine("Digite a descrição desse movimento.");
                descricaoMovimento = Console.ReadLine() ?? "";

                // Adicionar movimentacao na classe
                codigoMovimentacaoGerada++;
                movimentacoes.Add(new Movimentacao
                {
                    codigoMovimentacao = codigoMovimentacaoGerada,
                    descricaoMovimentacao = descricaoMovimento
                });

                Console.WriteLine("\n---");
                Console.WriteLine($"Produto movimentado: {estoques.estoque[count].descricaoProduto}");
                Console.WriteLine($"Estoque atual: {estoques.estoque[count].estoque}");
                Console.WriteLine("---");

                // Encerra operações
                Console.WriteLine("\nDeseja continuar as operações? [sim/s]");
                continuarOperacoes = Console.ReadLine() ?? "";
            }
            // FIM DAS OPERAÇÕES

            // Lista de movimentações
            Console.WriteLine("\nLISTA DE MOVIMENTAÇÕES");
            foreach (Movimentacao movimento in movimentacoes)
            {
                Console.WriteLine("---");
                Console.WriteLine($"Código da Movimentação: {movimento.codigoMovimentacao}");
                Console.WriteLine($"Descrição da movimentação: {movimento.descricaoMovimentacao}");
            }
            Console.WriteLine("---");
        }
    }
}
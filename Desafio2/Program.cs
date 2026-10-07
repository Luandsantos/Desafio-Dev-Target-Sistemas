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
        public string descricaoMovimentacao { get; set; }
        public int qtdeMovimentada { get; set; }
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

            int codProduto; // alterar nome para maior clareza
            int count = 0;
            string operacaoMovimentacao = "";
            int qtdeMovimentada = 0;
            string descricaoMovimento;

            // COMEÇO DAS OPERAÇÕES

            Console.WriteLine("Digite o código do produto que deseja movimentar: ");
            codProduto = Convert.ToInt32(Console.ReadLine());


            foreach (Estoque e in estoques.estoque)
            {
                if (e.codigoProduto == codProduto)
                {
                    Console.WriteLine("Código de produto encontrado.");
                    break;
                }
                count++;
            }

            Console.WriteLine($"Produto: {estoques.estoque[count].descricaoProduto}");
            Console.WriteLine($"Produto: {estoques.estoque[count].estoque}");

            Console.WriteLine("Deseja continuar? [S/N]");

            Console.WriteLine("Entrada ou Saída?");
            operacaoMovimentacao = Console.ReadLine();

            if (operacaoMovimentacao == "Entrada")
            {

            } else if (operacaoMovimentacao == "Saída")
            {

            } else
            {
                Console.WriteLine("Operação incorreta.");
            }




            switch (operacaoMovimentacao)
                {
                    case "Entrada":
                        Console.WriteLine("Digite o valor do movimento:");
                        qtdeMovimentada = Convert.ToInt32(Console.ReadLine());
                        estoques.estoque[count].estoque += qtdeMovimentada;

                        codigoMovimentacaoGerada++;
                        movimentacoes.Add(new Movimentacao
                        {
                            codigoMovimentacao = codigoMovimentacaoGerada,
                            descricaoMovimentacao = "Entrada",
                        });

                        break;
                    case "Saída":
                        Console.WriteLine("Digite o valor do movimento:");
                        qtdeMovimentada = Convert.ToInt32(Console.ReadLine());
                        if (estoques.estoque[count].estoque > qtdeMovimentada)
                        {
                            estoques.estoque[count].estoque -= qtdeMovimentada;

                            codigoMovimentacaoGerada++;
                            movimentacoes.Add(new Movimentacao
                            {
                                codigoMovimentacao = codigoMovimentacaoGerada,
                                descricaoMovimentacao = "Saída",
                            });
                        }
                        else
                        {
                            Console.WriteLine("Não é possível fazer essa saída.");
                        }
                        break;
                    default:
                        Console.WriteLine("Tipo de movimentação incorreta.");
                        break;
                }

            // FIM DAS OPERAÇÕES

            foreach(Movimentacao movimento in movimentacoes)
            {
                Console.WriteLine($"Código da Movimentação: {movimento.codigoMovimentacao}");
                Console.WriteLine($"Descrição da movimentação: {movimento.descricaoMovimentacao}:");
                Console.WriteLine($"Quantidade de produto movimentado: {movimento.qtdeMovimentada}");
            }
            Console.WriteLine("---");
        }
    }
}
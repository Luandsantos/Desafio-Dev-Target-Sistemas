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
            int codProduto;

            // Dentro do array de estoque em estoques, encontre o primeiro cujo codigoProduto = codProduto

            Console.WriteLine("Digite o código do produto que deseja movimentar: ");
            codProduto = Convert.ToInt32(Console.ReadLine());

            foreach (Estoque e in estoques.estoque)
            {
                if (e.codigoProduto == codProduto)
                {
                    Console.WriteLine("Código de produto encontrado.");
                    break;
                }
            }


            Console.WriteLine("Confirmação: O produto é {descricaoProduto}?");
            Console.WriteLine("Confirmado. Entrada ou Saída?");
            Console.WriteLine("Confirmado. Digite o valor do movimento:");
            Console.WriteLine("Ótimo.");

            foreach(Movimentacao movimento in movimentacoes)
            {
                Console.WriteLine($"Código da Movimentação: {movimento.codigoMovimentacao}");
                Console.WriteLine($"Descrição da movimentação {movimento.descricaoMovimentacao}:");
                Console.WriteLine($"Quantidade de produto movimentado: {movimento.qtdeMovimentada}");
            }
            Console.WriteLine("---");
        }
    }
}
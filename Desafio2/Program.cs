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
        }
    }
}
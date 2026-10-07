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

            int codProduto; // alterar nome para maior clareza
            int count = 0;
            string operacaoMovimentacao = "";
            int qtdeMovimentada = 0;
            string descricaoMovimento = "";

            // COMEÇO DAS OPERAÇÕES

            Console.WriteLine("\nDigite o código do produto que deseja movimentar: ");
            codProduto = Convert.ToInt32(Console.ReadLine());

            foreach (Estoque e in estoques.estoque)
            {
                if (e.codigoProduto == codProduto)
                {
                    break;
                }
                count++;
            }

            Console.WriteLine($"Produto: {estoques.estoque[count].descricaoProduto}");

            Console.WriteLine("Entrada ou Saída?");
            operacaoMovimentacao = Console.ReadLine();

            while (operacaoMovimentacao != "Entrada" && operacaoMovimentacao != "Saída")
            {
                Console.WriteLine("Operação incorreta");
                Console.WriteLine("Entrada ou Saída?");
                operacaoMovimentacao = Console.ReadLine();
            }

            Console.WriteLine("Digite o valor do movimento:");
            qtdeMovimentada = Convert.ToInt32(Console.ReadLine());

            if (operacaoMovimentacao == "Entrada")
            {
                estoques.estoque[count].estoque += qtdeMovimentada;
            } else if (estoques.estoque[count].estoque >= qtdeMovimentada)
            {
                estoques.estoque[count].estoque -= qtdeMovimentada;
            } else
            {
                Console.WriteLine("Essa quantidade não é válida.");
            }

            Console.WriteLine("Digite a descrição desse movimento.");
            descricaoMovimento = Console.ReadLine();

            // Adicionar movimentacao na classe
            codigoMovimentacaoGerada++;
            movimentacoes.Add(new Movimentacao
            {
                codigoMovimentacao = codigoMovimentacaoGerada,
                descricaoMovimentacao = descricaoMovimento
            });

            Console.WriteLine($"\nProduto movimentado: {estoques.estoque[count].descricaoProduto}");
            Console.WriteLine($"Estoque atual: {estoques.estoque[count].estoque}");

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
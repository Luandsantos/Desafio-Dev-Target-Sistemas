using System.Text.Json;

namespace Desafio1
{
    public class Vendas
    {
        public required Venda[] vendas { get; set; }
    }

    public class Venda
    {
        public required string vendedor { get; set; }
        public decimal valor { get; set; }
    }

    public class Comissao
    {
        public required string comissao_vendedor { get; set; }
        public decimal comissao_total { get; set; }
    }


    public class Program
    {
        public static void Main()
        {
            string jsonString =
                """
                {
                  "vendas": [
                    { "vendedor": "João Silva", "valor": 1200.50 },
                    { "vendedor": "João Silva", "valor": 950.75 },
                    { "vendedor": "João Silva", "valor": 1800.00 },
                    { "vendedor": "João Silva", "valor": 1400.30 },
                    { "vendedor": "João Silva", "valor": 1100.90 },
                    { "vendedor": "João Silva", "valor": 1550.00 },
                    { "vendedor": "João Silva", "valor": 1700.80 },
                    { "vendedor": "João Silva", "valor": 250.30 },
                    { "vendedor": "João Silva", "valor": 480.75 },
                    { "vendedor": "João Silva", "valor": 320.40 },

                    { "vendedor": "Maria Souza", "valor": 2100.40 },
                    { "vendedor": "Maria Souza", "valor": 1350.60 },
                    { "vendedor": "Maria Souza", "valor": 950.20 },
                    { "vendedor": "Maria Souza", "valor": 1600.75 },
                    { "vendedor": "Maria Souza", "valor": 1750.00 },
                    { "vendedor": "Maria Souza", "valor": 1450.90 },
                    { "vendedor": "Maria Souza", "valor": 400.50 },
                    { "vendedor": "Maria Souza", "valor": 180.20 },
                    { "vendedor": "Maria Souza", "valor": 90.75 },

                    { "vendedor": "Carlos Oliveira", "valor": 800.50 },
                    { "vendedor": "Carlos Oliveira", "valor": 1200.00 },
                    { "vendedor": "Carlos Oliveira", "valor": 1950.30 },
                    { "vendedor": "Carlos Oliveira", "valor": 1750.80 },
                    { "vendedor": "Carlos Oliveira", "valor": 1300.60 },
                    { "vendedor": "Carlos Oliveira", "valor": 300.40 },
                    { "vendedor": "Carlos Oliveira", "valor": 500.00 },
                    { "vendedor": "Carlos Oliveira", "valor": 125.75 },

                    { "vendedor": "Ana Lima", "valor": 1000.00 },
                    { "vendedor": "Ana Lima", "valor": 1100.50 },
                    { "vendedor": "Ana Lima", "valor": 1250.75 },
                    { "vendedor": "Ana Lima", "valor": 1400.20 },
                    { "vendedor": "Ana Lima", "valor": 1550.90 },
                    { "vendedor": "Ana Lima", "valor": 1650.00 },
                    { "vendedor": "Ana Lima", "valor": 75.30 },
                    { "vendedor": "Ana Lima", "valor": 420.90 },
                    { "vendedor": "Ana Lima", "valor": 315.40 }
                  ]
                }
                """;


            Vendas? vendas = JsonSerializer.Deserialize<Vendas>(jsonString);

            decimal comissao_venda = 0;
            var comissoes = new List<Comissao>();

            if (vendas?.vendas != null)
            {
                foreach(Venda venda in vendas.vendas)
                {

                    if (venda.valor >= 500m)
                    {
                        comissao_venda = venda.valor * (5m / 100m);
                    }
                    else if (venda.valor >= 100m)
                    {
                        comissao_venda = venda.valor * (1m / 100m);
                    }
                    else
                    {
                        comissao_venda = 0m;
                    }

                    Comissao? vendedor_buscado = comissoes.Find(e => e.comissao_vendedor == venda.vendedor);

                    if (vendedor_buscado == null)
                    {
                        comissoes.Add(new Comissao() { 
                            comissao_vendedor = venda.vendedor, 
                            comissao_total = comissao_venda 
                        });
                    } else
                    {
                        vendedor_buscado.comissao_total += comissao_venda;

                    }
                }
            }

            foreach(Comissao comissao in comissoes)
            {
                Console.WriteLine("---");
                Console.WriteLine($"Vendedor: {comissao.comissao_vendedor}");
                Console.WriteLine($"Comissão total: R${comissao.comissao_total:F2}"); // remover o :F2 mostra o valor total, sem arrendodamento.
            }
            Console.WriteLine("---");

        }
    }
}
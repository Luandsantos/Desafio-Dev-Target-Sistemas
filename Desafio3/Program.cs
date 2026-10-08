public class Desafio3
{
    public static void Main()
    {
        DateTime dataAtual = DateTime.Now.Date;
        DateTime dataVencimento;
        decimal valorInicial;
        decimal valorJuros;
        decimal multa = 0.025m; // 2,5%
        string? input;

        // Inserir valor inicial válido
        do
        {
            Console.WriteLine("Digite um valor em reais:");
            valorInicial = Convert.ToDecimal(Console.ReadLine());
        } while (valorInicial <= 0);


        // Inserir data válida
        do
        {
            Console.WriteLine("Digite a data de vencimento:");
            input = Console.ReadLine();
        } while (!DateTime.TryParse(input, out dataVencimento));

        // Calcular e mostrar juros
        TimeSpan diasVencimento = dataAtual - dataVencimento;
        if (diasVencimento.Days > 0)
        {
            valorJuros = valorInicial * multa * diasVencimento.Days;
            Console.WriteLine($"Devido ao atraso de {diasVencimento.Days} dia(s), o valor dos juros será de R${valorJuros:F2}.");
        }
        else if (diasVencimento.Days == 0)
        {
            Console.WriteLine("A data de vencimento é hoje. Não há juros por atraso.");
        }
        else
        {
            Console.WriteLine("Ainda não chegou a data de vencimento.");
        }
    }
}

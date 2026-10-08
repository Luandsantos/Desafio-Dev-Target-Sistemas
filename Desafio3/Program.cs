using System;

public class Desafio3
{
    public static void Main()
    {
        DateTime dataAtual = DateTime.Now.Date;
        DateTime dataVencimento;
        decimal valorInicial;
        decimal valorJuros;
        decimal multa = 0.025m; // 2,5%

        // Inserir valor inicial válido
        do
        {
            Console.WriteLine("Digite um valor em reais:");
            valorInicial = Convert.ToDecimal(Console.ReadLine());
        } while (valorInicial < 0);


        // Inserir data válida
        do
        {
            Console.WriteLine("Digite a data de vencimento (dd/mm/yyyy):");
            var input = Console.ReadLine();
            DateTime.TryParse(input, out dataVencimento);
        } while (dataVencimento.Equals(DateTime.MinValue));

        // Calcular e mostrar juros
        TimeSpan dataAtraso = dataAtual - dataVencimento;
        valorJuros = valorInicial * multa * dataAtraso.Days;
        Console.WriteLine($"Devido ao atraso de {dataAtraso.Days} dias(s), o valor dos juros será de R${valorJuros:F2}.");
    }
}

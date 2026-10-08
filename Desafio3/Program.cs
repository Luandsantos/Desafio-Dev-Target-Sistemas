using System;

public class Desafio3
{
    public static void Main()
    {
        DateTime dataAtual = DateTime.Now.Date;
        DateTime dataVencimento;
        decimal valor;
        decimal juros;

        Console.WriteLine("Digite a data de vencimento. Dia (1-31): ");
        int dia = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Mês (1-12):");
        int mes = Convert.ToInt32(Console.ReadLine());
        // erro: esse dia n existe nesse mes
        // erro geral: fora do range
        Console.WriteLine("Ano: (2020-2099)"); // intervalo "arbitrário" fácilmente alterável
        int ano = Convert.ToInt32(Console.ReadLine());

        dataVencimento = new DateTime(ano, mes, dia).Date;
        Console.WriteLine(dataAtual.ToString("d"));
        Console.WriteLine(dataVencimento.ToString("d"));
        DateTime dataAtraso = dataAtual - dataVencimento; 
        Console.WriteLine($"Diferença de dias: {dataAtual - dataVencimento} dia(s).");
    }
}

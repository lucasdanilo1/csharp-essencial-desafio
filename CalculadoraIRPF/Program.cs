namespace CalculadoraIRPF;

using System;

class Program {

    static void Main(string[] args) {
        int numContribuintes = LerNumeroContribuintes();

        for (int i = 0; i < numContribuintes; i++) {
            string nomeContribuinte = LerNomeContribuinte();
            double valorSalario = LerSalario(nomeContribuinte);

            Console.WriteLine("Nome do Contribuinte: " + nomeContribuinte);
            Console.WriteLine($"Salário Bruto: R$ {valorSalario:N2}");

            double desconto = CalculadoraDesconto.Calcular(valorSalario);
            Console.WriteLine($"Desconto: R$ {desconto:N2}");

            double salarioLiquido = valorSalario - desconto;
            Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:N2}");
        }

        Console.WriteLine("\nCálculo finalizado.");
    }

    public static int LerNumeroContribuintes() {
        Console.WriteLine("Informe o número de contribuintes: ");

        try {
            int numContribuintes = int.Parse(Console.ReadLine());
            ValidadorContribuinte.ValidarNumeroContribuintes(numContribuintes);
            return numContribuintes;
        } catch (FormatException) {
            Console.WriteLine("Entrada inválida. Digite um número.");
            return LerNumeroContribuintes();
        } catch (NumeroContribuintesInvalidoException ex) {
            Console.WriteLine(ex.Message);
            return LerNumeroContribuintes();
        }
    }

    public static string LerNomeContribuinte() {
        Console.WriteLine("Informe o nome do contribuinte");
        string nomeContribuinte = Console.ReadLine();

        try {
            ValidadorContribuinte.ValidarNome(nomeContribuinte);
            return nomeContribuinte;
        } catch (NomeContribuinteInvalidoException ex) {
            Console.WriteLine(ex.Message);
            return LerNomeContribuinte();
        }
    }

    public static double LerSalario(string nomeContribuinte) {
        Console.Write("Informe um valor para o salário. \n");

        try {
            string entrada = Console.ReadLine();

            ValidadorContribuinte.ValidarFormatoSalario(entrada);

            double valorSalario = double.Parse(entrada, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

            if (valorSalario <= 0) throw new SalarioInvalidoException();

            return valorSalario;
        } catch (FormatException) {
            Console.WriteLine("Entrada inválida. O salário deve ser maior que 0 e deve ter ',' como separador de centavos. Exemplo: 1520,50.");
            return LerSalario(nomeContribuinte);
        } catch (SalarioInvalidoException ex) {
            Console.WriteLine(ex.Message);
            return LerSalario(nomeContribuinte);
        }
    }
}

namespace CalculadoraIRPF;

class Program {
    static void Main(string[] args) {
        int numContribuintes = LeitorEntrada.LerNumeroContribuintes();

        for (int i = 0; i < numContribuintes; i++) {
            string nomeContribuinte = LeitorEntrada.LerNomeContribuinte();
            double valorSalario = LeitorEntrada.LerSalario(nomeContribuinte);

            Console.WriteLine("Nome do Contribuinte: " + nomeContribuinte);
            Console.WriteLine($"Salário Bruto: R$ {valorSalario:N2}");

            double desconto = CalculadoraDesconto.Calcular(valorSalario);
            Console.WriteLine($"Desconto: R$ {desconto:N2}");

            double salarioLiquido = valorSalario - desconto;
            Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:N2}");
        }

        Console.WriteLine("\nCálculo finalizado.");
    }
}

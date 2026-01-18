namespace CalculadoraIRPF;

class Program {
    static void Main(string[] args) {
        int numContribuintes = LeitorEntrada.LerNumeroContribuintes();

        for (int i = 0; i < numContribuintes; i++) {
            string nomeContribuinte = LeitorEntrada.LerNomeContribuinte();
            double valorSalario = LeitorEntrada.LerSalario(nomeContribuinte);

            Console.WriteLine("Nome do Contribuinte: " + nomeContribuinte);
            Console.WriteLine($"Salário Bruto: R$ {valorSalario:N2}");

            double descontoInss = CalculadoraInss.Calcular(valorSalario);
            Console.WriteLine($"Desconto INSS: R$ {descontoInss:N2}");

            double baseCalculoIrpf = valorSalario - descontoInss;
            double descontoIrpf = CalculadoraDesconto.Calcular(baseCalculoIrpf);
            Console.WriteLine($"Desconto IRPF: R$ {descontoIrpf:N2}");

            double salarioLiquido = valorSalario - descontoInss - descontoIrpf;
            Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:N2}");
        }

        Console.WriteLine("\nCálculo finalizado.");
    }
}

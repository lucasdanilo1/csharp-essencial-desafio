namespace EvolucaoTestes.IRPF;

using System;

class Program {
    
    static void Main(string[] args){
        int numContribuintes = lerNumeroContribuintes();

        for(int i = 0; i < numContribuintes; i++) {
            string nomeContribuinte = lerNomeContribuinte();
            double valorSalario = lerSalario(nomeContribuinte);
            
            Console.WriteLine("Nome do Contribuinte: " + nomeContribuinte);
            Console.WriteLine($"Salário Bruto: R$ {valorSalario:N2}");
            
            double desconto = calcularDesconto(valorSalario);
            Console.WriteLine($"Desconto: R$ {desconto:N2}");

            double salarioLiquido = valorSalario - desconto;
            Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:N2}");
        }

        Console.WriteLine("\nCálculo finalizado.");
    }

    public static int lerNumeroContribuintes() {
        Console.WriteLine("Informe o número de contribuintes: ");
        
        try {
            int numContribuintes = int.Parse(Console.ReadLine());
            validaNumContribuintes(numContribuintes);
            return numContribuintes;
        } catch (FormatException) {
            Console.WriteLine("Entrada inválida. Digite um número.");
            return lerNumeroContribuintes();
        } catch (NumeroContribuintesInvalidoException ex) {
            Console.WriteLine(ex.Message);
            return lerNumeroContribuintes();
        }
    }

    public static string lerNomeContribuinte() {
        Console.WriteLine("Informe o nome do contribuinte");
        string nomeContribuinte = Console.ReadLine();

        try {
            validaNomeContribuinte(nomeContribuinte);
            return nomeContribuinte;
        } catch (NomeContribuinteInvalidoException ex) {
            Console.WriteLine(ex.Message);
            return lerNomeContribuinte();
        }
    }

    public static double lerSalario(string nomeContribuinte) {
        Console.Write("Informe um valor para o salário. \n");
        
        try {
            string entrada = Console.ReadLine();
            
            validaFormatoSalario(entrada);
            
            double valorSalario = double.Parse(entrada, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

            if (valorSalario <= 0) throw new SalarioInvalidoException();

            return valorSalario;
        } catch (FormatException) {
            Console.WriteLine("Entrada inválida. O salário deve ser maior que 0 e deve ter ',' como separador de centavos. Exemplo: 1520,50.");
            return lerSalario(nomeContribuinte);
        } catch (SalarioInvalidoException ex) {
            Console.WriteLine(ex.Message);
            return lerSalario(nomeContribuinte);
        }
    }

   public static double calcularDesconto(double salarioBruto) {
        return salarioBruto switch {
            <= 2000 => 0,
            <= 3000 => salarioBruto * 0.08,
            <= 4500 => salarioBruto * 0.18,
            _ => salarioBruto * 0.28
        };
    }

    public static void validaNumContribuintes(int numContribuintes){
        if(numContribuintes <= 0 || numContribuintes > 99) {
            throw new NumeroContribuintesInvalidoException("O número de contribuintes deve ser entre 1 e 99.");
        } 
    }

    public static void validaNomeContribuinte(string nomeContribuinte){
        if (string.IsNullOrWhiteSpace(nomeContribuinte)) 
            throw new NomeContribuinteInvalidoException("O nome não pode estar vazio.");
        
        if (nomeContribuinte.Any(char.IsDigit)) 
            throw new NomeContribuinteInvalidoException("O nome não pode conter números.");
        
        if (nomeContribuinte.Any(char.IsSymbol) || nomeContribuinte.Any(char.IsPunctuation)) 
            throw new NomeContribuinteInvalidoException("O nome não pode conter caracteres especiais.");
    }

    public static void validaFormatoSalario(string entrada) {
        
        if (string.IsNullOrWhiteSpace(entrada)) throw new SalarioInvalidoException();

        if (entrada.Contains('.')) throw new SalarioInvalidoException();

        int contadorVirgulas = entrada.Count(c => c == ',');

        if (contadorVirgulas > 1)  throw new SalarioInvalidoException();

        if (contadorVirgulas == 1) {
            string[] partes = entrada.Split(',');
            if (partes[1].Length > 2) {
                throw new SalarioInvalidoException();
            }
        }

        if (!entrada.All(c => char.IsDigit(c) || c == ','))  throw new SalarioInvalidoException();
    }
}

public class NumeroContribuintesInvalidoException : Exception {
    public NumeroContribuintesInvalidoException(string msg) : base(msg) {} 
}

public class NomeContribuinteInvalidoException : Exception {
    public NomeContribuinteInvalidoException(string msg) : base(msg) { }
}

public class SalarioInvalidoException : Exception {
    public SalarioInvalidoException() : base("Salário inválido. Deve ser maior que 0 e deve ter ',' como separador de centavos. Exemplo: 1520,50.") { }
}
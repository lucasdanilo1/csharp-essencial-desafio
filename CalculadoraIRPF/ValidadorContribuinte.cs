namespace CalculadoraIRPF;

public class ValidadorContribuinte {
    public static void ValidarNumeroContribuintes(int numContribuintes) {
        if (numContribuintes <= 0 || numContribuintes > 99) {
            throw new NumeroContribuintesInvalidoException("O número de contribuintes deve ser entre 1 e 99.");
        }
    }

    public static void ValidarNome(string nomeContribuinte) {
        if (string.IsNullOrWhiteSpace(nomeContribuinte))
            throw new NomeContribuinteInvalidoException("O nome não pode estar vazio.");

        if (nomeContribuinte.Any(char.IsDigit))
            throw new NomeContribuinteInvalidoException("O nome não pode conter números.");

        if (nomeContribuinte.Any(char.IsSymbol) || nomeContribuinte.Any(char.IsPunctuation))
            throw new NomeContribuinteInvalidoException("O nome não pode conter caracteres especiais.");
    }

    public static void ValidarFormatoSalario(string entrada) {
        if (string.IsNullOrWhiteSpace(entrada)) throw new SalarioInvalidoException();

        if (entrada.Contains('.')) throw new SalarioInvalidoException();

        int contadorVirgulas = entrada.Count(c => c == ',');

        if (contadorVirgulas > 1) throw new SalarioInvalidoException();

        if (contadorVirgulas == 1) {
            string[] partes = entrada.Split(',');
            if (partes[1].Length > 2) {
                throw new SalarioInvalidoException();
            }
        }

        if (!entrada.All(c => char.IsDigit(c) || c == ',')) throw new SalarioInvalidoException();
    }
}

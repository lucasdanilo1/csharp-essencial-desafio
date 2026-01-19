namespace CalculadoraIRPF;

public class NumeroContribuintesInvalidoException : Exception {
    public NumeroContribuintesInvalidoException(string msg) : base(msg) {}
}

public class NomeContribuinteInvalidoException : Exception {
    public NomeContribuinteInvalidoException(string msg) : base(msg) { }
}

public class SalarioInvalidoException : Exception {
    public SalarioInvalidoException() : base("Salário inválido. Deve ser maior que 0 e deve ter ',' como separador de centavos. Exemplo: 1520,50.") { }
}

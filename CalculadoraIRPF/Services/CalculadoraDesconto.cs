namespace CalculadoraIRPF.Services;

public class CalculadoraDesconto {
    public static double Calcular(double salarioBruto) {
        return salarioBruto switch {
            <= 2000 => 0,
            <= 3000 => salarioBruto * 0.08,
            <= 4500 => salarioBruto * 0.18,
            _ => salarioBruto * 0.28
        };
    }
}

namespace CalculadoraIRPF.Services;

public class CalculadoraInss {
    public static double Calcular(double salarioBruto) {
        return salarioBruto switch {
            <= 1412.00 => salarioBruto * 0.075,
            <= 2666.68 => salarioBruto * 0.09,
            <= 4000.03 => salarioBruto * 0.12,
            <= 7786.02 => salarioBruto * 0.14,
            _ => 908.86
        };
    }
}

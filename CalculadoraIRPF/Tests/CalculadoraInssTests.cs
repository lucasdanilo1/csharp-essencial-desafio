namespace CalculadoraIRPF.Tests;

using CalculadoraIRPF.Services;
using Xunit;

public class CalculadoraInssTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1000, 75)]
    [InlineData(1412, 105.90)]
    public void Calcular_SalarioAte1412_DeveRetornar7_5Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraInss.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(1500, 135)]
    [InlineData(2000, 180)]
    [InlineData(2666.68, 240)]
    public void Calcular_SalarioEntre1412_01e2666_68_DeveRetornar9Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraInss.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(3000, 360)]
    [InlineData(3500, 420)]
    [InlineData(4000.03, 480)]
    public void Calcular_SalarioEntre2666_69e4000_03_DeveRetornar12Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraInss.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(5000, 700)]
    [InlineData(6000, 840)]
    [InlineData(7786.02, 1090.04)]
    public void Calcular_SalarioEntre4000_04e7786_02_DeveRetornar14Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraInss.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(8000, 908.86)]
    [InlineData(10000, 908.86)]
    [InlineData(15000, 908.86)]
    public void Calcular_SalarioAcima7786_02_DeveRetornarTetoInss(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraInss.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }
}

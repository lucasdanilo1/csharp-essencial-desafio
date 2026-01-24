namespace CalculadoraIRPF.Tests;

using CalculadoraIRPF.Services;
using Xunit;

public class CalculadoraDescontoTests
{
    [Theory]
    [InlineData(1000, 0)]
    [InlineData(2000, 0)]
    [InlineData(0, 0)]
    public void Calcular_SalarioAte2000_DeveRetornarZero(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraDesconto.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado);
    }

    [Theory]
    [InlineData(2001, 160.08)]
    [InlineData(2500, 200)]
    [InlineData(3000, 240)]
    public void Calcular_SalarioEntre2001e3000_DeveRetornar8Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraDesconto.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(3001, 540.18)]
    [InlineData(4000, 720)]
    [InlineData(4500, 810)]
    public void Calcular_SalarioEntre3001e4500_DeveRetornar18Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraDesconto.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(4501, 1260.28)]
    [InlineData(5000, 1400)]
    [InlineData(10000, 2800)]
    public void Calcular_SalarioAcima4500_DeveRetornar28Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = CalculadoraDesconto.Calcular(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }
}
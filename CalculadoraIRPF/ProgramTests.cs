namespace CalculadoraIRPF.Tests;

using System;
using CalculadoraIRPF;
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

public class ValidadorContribuinteTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(50)]
    [InlineData(99)]
    public void ValidarNumeroContribuintes_NumeroValido_NaoDeveLancarExcecao(int numero)
    {
        var exception = Record.Exception(() => ValidadorContribuinte.ValidarNumeroContribuintes(numero));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void ValidarNumeroContribuintes_NumeroMenorOuIgualZero_DeveLancarExcecao(int numero)
    {
        var exception = Assert.Throws<NumeroContribuintesInvalidoException>(() =>
            ValidadorContribuinte.ValidarNumeroContribuintes(numero)
        );

        Assert.Equal("O número de contribuintes deve ser entre 1 e 99.", exception.Message);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(150)]
    [InlineData(999)]
    public void ValidarNumeroContribuintes_NumeroMaiorQue99_DeveLancarExcecao(int numero)
    {
        var exception = Assert.Throws<NumeroContribuintesInvalidoException>(() =>
            ValidadorContribuinte.ValidarNumeroContribuintes(numero)
        );

        Assert.Equal("O número de contribuintes deve ser entre 1 e 99.", exception.Message);
    }

    [Theory]
    [InlineData("João Silva")]
    [InlineData("Maria")]
    [InlineData("José de Souza")]
    [InlineData("Ana")]
    public void ValidarNome_NomeValido_NaoDeveLancarExcecao(string nome)
    {
        var exception = Record.Exception(() => ValidadorContribuinte.ValidarNome(nome));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ValidarNome_NomeVazioOuNulo_DeveLancarExcecao(string nome)
    {
        var exception = Assert.Throws<NomeContribuinteInvalidoException>(() =>
            ValidadorContribuinte.ValidarNome(nome)
        );

        Assert.Equal("O nome não pode estar vazio.", exception.Message);
    }

    [Theory]
    [InlineData("João123")]
    [InlineData("Maria2")]
    [InlineData("123")]
    public void ValidarNome_NomeComNumeros_DeveLancarExcecao(string nome)
    {
        var exception = Assert.Throws<NomeContribuinteInvalidoException>(() =>
            ValidadorContribuinte.ValidarNome(nome)
        );

        Assert.Equal("O nome não pode conter números.", exception.Message);
    }

    [Theory]
    [InlineData("João@Silva")]
    [InlineData("Maria#")]
    [InlineData("José!")]
    [InlineData("Ana.Silva")]
    public void ValidarNome_NomeComCaracteresEspeciais_DeveLancarExcecao(string nome)
    {
        var exception = Assert.Throws<NomeContribuinteInvalidoException>(() =>
            ValidadorContribuinte.ValidarNome(nome)
        );

        Assert.Equal("O nome não pode conter caracteres especiais.", exception.Message);
    }

    [Theory]
    [InlineData("1000")]
    [InlineData("1520,50")]
    [InlineData("2500,5")]
    [InlineData("3000,00")]
    public void ValidarFormatoSalario_FormatoValido_NaoDeveLancarExcecao(string entrada)
    {
        var exception = Record.Exception(() => ValidadorContribuinte.ValidarFormatoSalario(entrada));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ValidarFormatoSalario_EntradaVazia_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => ValidadorContribuinte.ValidarFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("1000.50")]
    [InlineData("2500.00")]
    public void ValidarFormatoSalario_ComPonto_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => ValidadorContribuinte.ValidarFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("1000,50,25")]
    [InlineData("1,5,2")]
    public void ValidarFormatoSalario_MaisDeUmaVirgula_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => ValidadorContribuinte.ValidarFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("1000,500")]
    [InlineData("1500,1234")]
    public void ValidarFormatoSalario_MaisDeDuasCasasDecimais_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => ValidadorContribuinte.ValidarFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("12a34")]
    [InlineData("@#$")]
    public void ValidarFormatoSalario_CaracteresInvalidos_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => ValidadorContribuinte.ValidarFormatoSalario(entrada));
    }
}

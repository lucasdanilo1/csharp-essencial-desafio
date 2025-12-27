namespace EvolucaoTestes.IRPF.Tests;

using System;
using EvolucaoTestes.IRPF;
using Xunit;

public class ProgramTests
{
    [Theory]
    [InlineData(1000, 0)]
    [InlineData(2000, 0)]
    [InlineData(0, 0)]
    public void CalcularDesconto_SalarioAte2000_DeveRetornarZero(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = Program.calcularDesconto(salario);

        Assert.Equal(descontoEsperado, resultado);
    }

    [Theory]
    [InlineData(2001, 160.08)]
    [InlineData(2500, 200)]
    [InlineData(3000, 240)]
    public void CalcularDesconto_SalarioEntre2001e3000_DeveRetornar8Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = Program.calcularDesconto(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(3001, 540.18)]
    [InlineData(4000, 720)]
    [InlineData(4500, 810)]
    public void CalcularDesconto_SalarioEntre3001e4500_DeveRetornar18Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = Program.calcularDesconto(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(4501, 1260.28)]
    [InlineData(5000, 1400)]
    [InlineData(10000, 2800)]
    public void CalcularDesconto_SalarioAcima4500_DeveRetornar28Porcento(
        double salario,
        double descontoEsperado
    )
    {
        double resultado = Program.calcularDesconto(salario);

        Assert.Equal(descontoEsperado, resultado, 2);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(50)]
    [InlineData(99)]
    public void ValidaNumContribuintes_NumeroValido_NaoDeveLancarExcecao(int numero)
    {
        var exception = Record.Exception(() => Program.validaNumContribuintes(numero));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void ValidaNumContribuintes_NumeroMenorOuIgualZero_DeveLancarExcecao(int numero)
    {
        var exception = Assert.Throws<NumeroContribuintesInvalidoException>(() =>
            Program.validaNumContribuintes(numero)
        );

        Assert.Equal("O número de contribuintes deve ser entre 1 e 99.", exception.Message);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(150)]
    [InlineData(999)]
    public void ValidaNumContribuintes_NumeroMaiorQue99_DeveLancarExcecao(int numero)
    {
        var exception = Assert.Throws<NumeroContribuintesInvalidoException>(() =>
            Program.validaNumContribuintes(numero)
        );

        Assert.Equal("O número de contribuintes deve ser entre 1 e 99.", exception.Message);
    }

    [Theory]
    [InlineData("João Silva")]
    [InlineData("Maria")]
    [InlineData("José de Souza")]
    [InlineData("Ana")]
    public void ValidaNomeContribuinte_NomeValido_NaoDeveLancarExcecao(string nome)
    {
        var exception = Record.Exception(() => Program.validaNomeContribuinte(nome));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ValidaNomeContribuinte_NomeVazioOuNulo_DeveLancarExcecao(string nome)
    {
        var exception = Assert.Throws<NomeContribuinteInvalidoException>(() =>
            Program.validaNomeContribuinte(nome)
        );

        Assert.Equal("O nome não pode estar vazio.", exception.Message);
    }

    [Theory]
    [InlineData("João123")]
    [InlineData("Maria2")]
    [InlineData("123")]
    public void ValidaNomeContribuinte_NomeComNumeros_DeveLancarExcecao(string nome)
    {
        var exception = Assert.Throws<NomeContribuinteInvalidoException>(() =>
            Program.validaNomeContribuinte(nome)
        );

        Assert.Equal("O nome não pode conter números.", exception.Message);
    }

    [Theory]
    [InlineData("João@Silva")]
    [InlineData("Maria#")]
    [InlineData("José!")]
    [InlineData("Ana.Silva")]
    public void ValidaNomeContribuinte_NomeComCaracteresEspeciais_DeveLancarExcecao(string nome)
    {
        var exception = Assert.Throws<NomeContribuinteInvalidoException>(() =>
            Program.validaNomeContribuinte(nome)
        );

        Assert.Equal("O nome não pode conter caracteres especiais.", exception.Message);
    }

    [Theory]
    [InlineData("1000")]
    [InlineData("1520,50")]
    [InlineData("2500,5")]
    [InlineData("3000,00")]
    public void ValidaFormatoSalario_FormatoValido_NaoDeveLancarExcecao(string entrada)
    {
        var exception = Record.Exception(() => Program.validaFormatoSalario(entrada));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ValidaFormatoSalario_EntradaVazia_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => Program.validaFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("1000.50")]
    [InlineData("2500.00")]
    public void ValidaFormatoSalario_ComPonto_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => Program.validaFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("1000,50,25")]
    [InlineData("1,5,2")]
    public void ValidaFormatoSalario_MaisDeUmaVirgula_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => Program.validaFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("1000,500")]
    [InlineData("1500,1234")]
    public void ValidaFormatoSalario_MaisDeDuasCasasDecimais_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => Program.validaFormatoSalario(entrada));
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("12a34")]
    [InlineData("@#$")]
    public void ValidaFormatoSalario_CaracteresInvalidos_DeveLancarExcecao(string entrada)
    {
        Assert.Throws<SalarioInvalidoException>(() => Program.validaFormatoSalario(entrada));
    }
}

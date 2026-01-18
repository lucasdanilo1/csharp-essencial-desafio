# Calculadora de IRPF

Aplicacao console em C# para calculo de Imposto de Renda Pessoa Fisica (IRPF).

## Funcionalidades

- Calculo de INSS sobre o salario bruto
- Calculo de IRPF sobre a base de calculo (salario bruto - INSS)
- Suporte a multiplos contribuintes
- Validacao de dados de entrada
- Exibicao de salario bruto, descontos (INSS e IRPF) e salario liquido

## Tabela de Aliquotas do INSS

| Faixa Salarial | Aliquota |
|----------------|----------|
| Ate R$ 1.412,00 | 7,5% |
| R$ 1.412,01 a R$ 2.666,68 | 9% |
| R$ 2.666,69 a R$ 4.000,03 | 12% |
| R$ 4.000,04 a R$ 7.786,02 | 14% |
| Acima de R$ 7.786,02 | Teto R$ 908,86 |

## Tabela de Aliquotas do IRPF

| Faixa Salarial | Aliquota |
|----------------|----------|
| Ate R$ 2.000,00 | 0% |
| R$ 2.001,00 a R$ 3.000,00 | 8% |
| R$ 3.001,00 a R$ 4.500,00 | 18% |
| Acima de R$ 4.500,00 | 28% |

## Validacoes

- **Numero de contribuintes**: deve ser entre 1 e 99
- **Nome do contribuinte**: nao pode estar vazio, conter numeros ou caracteres especiais
- **Salario**: deve ser maior que 0, usar virgula como separador decimal (formato brasileiro)

## Como executar

```bash
dotnet run --project CalculadoraIRPF
```

## Testes

O projeto inclui testes unitarios com xUnit cobrindo:
- Calculo de INSS por faixa salarial
- Calculo de IRPF por faixa salarial
- Validacao de numero de contribuintes
- Validacao de nome do contribuinte
- Validacao de formato de salario

Para executar os testes:

```bash
dotnet test
```

## Tecnologias

- .NET 8.0
- xUnit (testes unitarios)

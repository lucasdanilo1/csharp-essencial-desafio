# Calculadora de IRPF

Aplicacao console em C# para calculo de Imposto de Renda Pessoa Fisica (IRPF).

## Funcionalidades

- Calculo de IRPF para multiplos contribuintes
- Validacao de dados de entrada
- Exibicao de salario bruto, desconto e salario liquido

## Tabela de Aliquotas

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
dotnet run --project EvolucaoTestes.IRPF
```

## Testes

O projeto inclui testes unitarios com xUnit cobrindo:
- Calculo de desconto por faixa salarial
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

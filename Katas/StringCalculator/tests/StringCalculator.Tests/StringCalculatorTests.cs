using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator = new();

    #region Étape 1 : Cas de base

    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        // Arrange & Act
        var result = _calculator.Add("");

        // Assert
        result.Should().Be(0);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("5", 5)]
    [InlineData("42", 42)]
    public void Add_SingleNumber_ReturnsNumber(string input, int expected)
    {
        _calculator.Add(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("10,20", 30)]
    public void Add_TwoNumbers_ReturnsSum(string input, int expected)
    {
        _calculator.Add(input).Should().Be(expected);
    }

    #endregion

    #region Étape 2 : Nombre illimité

    // TODO: Ajoutez vos tests pour l'étape 2
    // [Fact]
    // public void Add_MultipleNumbers_ReturnsSum()
    // {
    //     _calculator.Add("1,2,3,4,5").Should().Be(15);
    // }

    #endregion

    #region Étape 3 : Saut de ligne

    // TODO: Ajoutez vos tests pour l'étape 3
    // [Fact]
    // public void Add_WithNewLineDelimiter_ReturnsSum()
    // {
    //     _calculator.Add("1\n2,3").Should().Be(6);
    // }

    #endregion

    #region Étape 4 : Délimiteur personnalisé

    // TODO: Ajoutez vos tests pour l'étape 4
    // [Theory]
    // [InlineData("//;\n1;2", 3)]
    // [InlineData("//|\n1|2|3", 6)]
    // public void Add_WithCustomDelimiter_ReturnsSum(string input, int expected)
    // {
    //     _calculator.Add(input).Should().Be(expected);
    // }

    #endregion

    #region Étape 5 : Nombres négatifs

    // TODO: Ajoutez vos tests pour l'étape 5
    // [Fact]
    // public void Add_WithNegativeNumbers_ThrowsException()
    // {
    //     var act = () => _calculator.Add("1,-2,3,-4");
    //     act.Should().Throw<ArgumentException>()
    //        .WithMessage("*-2*-4*");
    // }

    #endregion

    #region Étape 6 : Ignorer les grands nombres

    // TODO: Ajoutez vos tests pour l'étape 6
    // [Fact]
    // public void Add_NumbersGreaterThan1000_AreIgnored()
    // {
    //     _calculator.Add("2,1001").Should().Be(2);
    // }

    #endregion

    #region Bonus : Délimiteurs avancés

    // TODO: Ajoutez vos tests bonus
    // [Fact]
    // public void Add_WithMultiCharDelimiter_ReturnsSum()
    // {
    //     _calculator.Add("//[***]\n1***2***3").Should().Be(6);
    // }

    // [Fact]
    // public void Add_WithMultipleDelimiters_ReturnsSum()
    // {
    //     _calculator.Add("//[*][%]\n1*2%3").Should().Be(6);
    // }

    #endregion
}

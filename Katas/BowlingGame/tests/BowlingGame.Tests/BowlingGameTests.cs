using FluentAssertions;
using Xunit;

namespace BowlingGame.Tests;

public class BowlingGameTests
{
    private readonly BowlingGame _game = new();

    #region Méthodes helper

    private void RollMany(int times, int pins)
    {
        for (int i = 0; i < times; i++)
            _game.Roll(pins);
    }

    private void RollSpare()
    {
        _game.Roll(5);
        _game.Roll(5);
    }

    private void RollStrike()
    {
        _game.Roll(10);
    }

    #endregion

    #region Étape 1 : Partie de zéros

    [Fact]
    public void GutterGame_ScoreIsZero()
    {
        // Arrange & Act
        RollMany(20, 0);

        // Assert
        _game.Score().Should().Be(0);
    }

    #endregion

    #region Étape 2 : Partie de uns

    [Fact]
    public void AllOnes_ScoreIsTwenty()
    {
        RollMany(20, 1);
        _game.Score().Should().Be(20);
    }

    #endregion

    #region Étape 3 : Un spare

    // TODO: Décommentez ce test quand vous êtes prêt
    // [Fact]
    // public void OneSpare_BonusIsNextRoll()
    // {
    //     RollSpare();
    //     _game.Roll(3);
    //     RollMany(17, 0);
    //     _game.Score().Should().Be(16); // 10 + 3 + 3
    // }

    #endregion

    #region Étape 4 : Un strike

    // TODO: Décommentez ce test quand vous êtes prêt
    // [Fact]
    // public void OneStrike_BonusIsNextTwoRolls()
    // {
    //     RollStrike();
    //     _game.Roll(3);
    //     _game.Roll(4);
    //     RollMany(16, 0);
    //     _game.Score().Should().Be(24); // 10 + 7 + 7
    // }

    #endregion

    #region Étape 5 : Partie parfaite

    // TODO: Décommentez ce test quand vous êtes prêt
    // [Fact]
    // public void PerfectGame_ScoreIs300()
    // {
    //     RollMany(12, 10);
    //     _game.Score().Should().Be(300);
    // }

    #endregion

    #region Tests supplémentaires

    // TODO: Ajoutez vos propres tests
    // - Partie avec tous des spares
    // - Plusieurs strikes consécutifs
    // - 10ème frame avec spare
    // - 10ème frame avec strike

    #endregion
}

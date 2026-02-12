# Kata : Bowling Game

Un kata classique créé par Uncle Bob (Robert C. Martin) pour apprendre le TDD.

## Règles du Bowling

Une partie de bowling se compose de **10 frames** (manches).

### Calcul du score

| Situation | Points |
|-----------|--------|
| **Normal** | Nombre de quilles renversées |
| **Spare** (/) | 10 + quilles du prochain lancer |
| **Strike** (X) | 10 + quilles des 2 prochains lancers |

### Règles spéciales

- Un **spare** : toutes les quilles tombent en 2 lancers dans une frame
- Un **strike** : toutes les quilles tombent au 1er lancer → pas de 2ème lancer
- **10ème frame** : si spare ou strike, lancers bonus accordés

---

## Exemples de scores

### Partie normale (pas de spare ni strike)

```
Frame:    1    2    3    4    5    6    7    8    9    10
Lancers: 3,4  2,5  1,1  0,0  5,4  3,2  4,4  2,1  3,3  4,2
Score:    7   14   16   16   25   30   38   41   47   53
```

### Partie avec un spare

```
Frame:    1    2    ...
Lancers: 5,5  3,2  ...
Score:   13   18   ...
         └─ 10 + 3 (bonus du prochain lancer)
```

### Partie avec un strike

```
Frame:    1    2    ...
Lancers:  X   3,4  ...
Score:   17   24   ...
         └─ 10 + 3 + 4 (bonus des 2 prochains lancers)
```

### Partie parfaite (12 strikes)

```
Lancers: X X X X X X X X X X X X
Score: 300
```

---

## Étapes du kata

### Étape 1 : Partie de zéros

Une partie où aucune quille n'est renversée → score = 0

```csharp
// 20 lancers de 0 quille
game.Roll(0); // × 20 fois
game.Score().Should().Be(0);
```

### Étape 2 : Partie de uns

Une partie où une seule quille est renversée à chaque lancer.

```csharp
// 20 lancers de 1 quille
game.Roll(1); // × 20 fois
game.Score().Should().Be(20);
```

### Étape 3 : Un spare

Une partie avec un spare suivi de 3 quilles, puis des zéros.

```csharp
game.Roll(5);
game.Roll(5); // Spare!
game.Roll(3);
// puis 17 lancers de 0
game.Score().Should().Be(16); // 10 + 3 + 3
```

### Étape 4 : Un strike

Une partie avec un strike suivi de 3 et 4, puis des zéros.

```csharp
game.Roll(10); // Strike!
game.Roll(3);
game.Roll(4);
// puis 16 lancers de 0
game.Score().Should().Be(24); // 10 + 3 + 4 + 3 + 4
```

### Étape 5 : Partie parfaite

12 strikes consécutifs = 300 points.

```csharp
for (int i = 0; i < 12; i++)
    game.Roll(10);
game.Score().Should().Be(300);
```

---

## API suggérée

```csharp
public class BowlingGame
{
    public void Roll(int pins) { }
    public int Score() { }
}
```

---

## Tests suggérés

```csharp
public class BowlingGameTests
{
    private readonly BowlingGame _game = new();

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

    [Fact]
    public void GutterGame_ScoreIsZero()
    {
        RollMany(20, 0);
        _game.Score().Should().Be(0);
    }

    [Fact]
    public void AllOnes_ScoreIsTwenty()
    {
        RollMany(20, 1);
        _game.Score().Should().Be(20);
    }

    [Fact]
    public void OneSpare_BonusIsNextRoll()
    {
        RollSpare();
        _game.Roll(3);
        RollMany(17, 0);
        _game.Score().Should().Be(16);
    }

    [Fact]
    public void OneStrike_BonusIsNextTwoRolls()
    {
        RollStrike();
        _game.Roll(3);
        _game.Roll(4);
        RollMany(16, 0);
        _game.Score().Should().Be(24);
    }

    [Fact]
    public void PerfectGame_ScoreIs300()
    {
        RollMany(12, 10);
        _game.Score().Should().Be(300);
    }
}
```

---

## Structure du projet

```
BowlingGame/
├── README.md
├── src/
│   └── BowlingGame/
│       ├── BowlingGame.csproj
│       └── BowlingGame.cs
└── tests/
    └── BowlingGame.Tests/
        ├── BowlingGame.Tests.csproj
        └── BowlingGameTests.cs
```

---

## Conseils

1. **Ne pensez pas à toute la complexité** - Concentrez-vous sur un test à la fois
2. **Refactorisez souvent** - Le code évoluera naturellement
3. **Utilisez des méthodes helper** - `RollMany`, `RollSpare`, `RollStrike`
4. **Attention à la 10ème frame** - C'est souvent là que ça se complique !

---

## Liens

- [Bowling Game Kata - Uncle Bob](http://butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata)
- [Retour aux Katas](../)

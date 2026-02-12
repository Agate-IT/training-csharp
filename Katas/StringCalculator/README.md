# Kata : StringCalculator

Un kata classique pour apprendre le TDD, créé par Roy Osherove.

## Règles du kata

Créez une classe `StringCalculator` avec une méthode `Add(string numbers)` qui retourne un entier.

---

## Étapes (suivez-les dans l'ordre !)

### Étape 1 : Cas de base

- Une chaîne **vide** retourne `0`
- Un **seul nombre** retourne ce nombre
- **Deux nombres** séparés par une virgule retournent leur somme

```csharp
Add("")      → 0
Add("1")     → 1
Add("1,2")   → 3
```

### Étape 2 : Nombre illimité

Gérer un **nombre illimité** de nombres.

```csharp
Add("1,2,3,4,5") → 15
```

### Étape 3 : Saut de ligne

Gérer le **saut de ligne** comme séparateur (en plus de la virgule).

```csharp
Add("1\n2,3") → 6
```

### Étape 4 : Délimiteur personnalisé

Supporter les **délimiteurs personnalisés**. Le format est : `//[délimiteur]\n[nombres]`

```csharp
Add("//;\n1;2")   → 3
Add("//|\n1|2|3") → 6
```

### Étape 5 : Nombres négatifs

Les **nombres négatifs** lèvent une exception avec le message :
`"Les nombres négatifs ne sont pas autorisés : -1, -2"`

```csharp
Add("1,-2,3,-4") → Exception: "Les nombres négatifs ne sont pas autorisés : -2, -4"
```

### Étape 6 : Ignorer les grands nombres

Les nombres **supérieurs à 1000** sont ignorés.

```csharp
Add("2,1001") → 2
Add("1000,1001,2") → 1002
```

### Étape 7 (Bonus) : Délimiteurs de longueur variable

Les délimiteurs peuvent avoir **plusieurs caractères** : `//[***]\n1***2***3`

```csharp
Add("//[***]\n1***2***3") → 6
```

### Étape 8 (Bonus) : Plusieurs délimiteurs

Supporter **plusieurs délimiteurs** : `//[*][%]\n1*2%3`

```csharp
Add("//[*][%]\n1*2%3") → 6
```

---

## Tests suggérés

```csharp
public class StringCalculatorTests
{
    private readonly StringCalculator _calculator = new();

    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        _calculator.Add("").Should().Be(0);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("5", 5)]
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

    // Continuez avec les autres étapes...
}
```

---

## Structure du projet

```
StringCalculator/
├── README.md
├── src/
│   └── StringCalculator/
│       ├── StringCalculator.csproj
│       └── StringCalculator.cs
└── tests/
    └── StringCalculator.Tests/
        ├── StringCalculator.Tests.csproj
        └── StringCalculatorTests.cs
```

---

## Démarrage rapide

```bash
# Créer la solution
cd Katas/StringCalculator
dotnet new sln -n StringCalculator

# Créer les projets
dotnet new classlib -o src/StringCalculator
dotnet new xunit -o tests/StringCalculator.Tests

# Ajouter à la solution
dotnet sln add src/StringCalculator tests/StringCalculator.Tests

# Ajouter les références
dotnet add tests/StringCalculator.Tests reference src/StringCalculator
dotnet add tests/StringCalculator.Tests package FluentAssertions

# Lancer les tests
dotnet test
```

---

## Conseils

1. **Un test à la fois** - N'écrivez qu'un seul test avant de coder
2. **Code minimal** - Écrivez le minimum pour faire passer le test
3. **Refactorisez** - Améliorez le code après chaque test vert
4. **Pas de triche** - Ne lisez pas les solutions à l'avance !

---

## Liens

- [Article original de Roy Osherove](https://osherove.com/tdd-kata-1/)
- [Retour aux Katas](../)

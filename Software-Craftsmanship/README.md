# Software Craftsmanship

L'art d'écrire du code propre, maintenable et testé.

## TDD - Test-Driven Development

### Le cycle TDD

```
    ┌──────────────┐
    │   1. RED     │  Écrire un test qui échoue
    └──────┬───────┘
           │
           ▼
    ┌──────────────┐
    │  2. GREEN    │  Écrire le code minimal pour passer
    └──────┬───────┘
           │
           ▼
    ┌──────────────┐
    │ 3. REFACTOR  │  Améliorer le code sans casser les tests
    └──────┬───────┘
           │
           └──────────► Répéter
```

### Les 3 règles du TDD

1. N'écrivez pas de code de production sans un test qui échoue
2. N'écrivez pas plus de test que nécessaire pour échouer
3. N'écrivez pas plus de code que nécessaire pour passer le test

---

## Kata : StringCalculator

### Étape 1
Créer une méthode `Add(string numbers)` qui retourne un entier.
- Chaîne vide → 0
- Un seul nombre → ce nombre
- Deux nombres séparés par virgule → leur somme

```csharp
[Fact]
public void Add_EmptyString_ReturnsZero()
{
    var calc = new StringCalculator();
    Assert.Equal(0, calc.Add(""));
}

[Fact]
public void Add_SingleNumber_ReturnsNumber()
{
    var calc = new StringCalculator();
    Assert.Equal(1, calc.Add("1"));
}

[Fact]
public void Add_TwoNumbers_ReturnsSum()
{
    var calc = new StringCalculator();
    Assert.Equal(3, calc.Add("1,2"));
}
```

### Étape 2
Gérer un nombre illimité de nombres.

### Étape 3
Gérer le saut de ligne comme séparateur : "1\n2,3" → 6

### Étape 4
Supporter les délimiteurs personnalisés : "//;\n1;2" → 3

### Étape 5
Les nombres négatifs lèvent une exception avec le message "negatives not allowed: -1"

---

## BDD - Behavior-Driven Development

### Syntaxe Gherkin

```gherkin
Feature: Calculatrice de chaînes

  Scenario: Additionner deux nombres
    Given une calculatrice
    When j'ajoute "1,2"
    Then le résultat est 3

  Scenario: Chaîne vide
    Given une calculatrice
    When j'ajoute ""
    Then le résultat est 0
```

### Outils recommandés
- **SpecFlow** - BDD pour .NET
- **xBehave** - BDD léger

---

## Clean Code

### Principes KISS, DRY, YAGNI

| Principe | Signification |
|----------|---------------|
| **KISS** | Keep It Simple, Stupid |
| **DRY** | Don't Repeat Yourself |
| **YAGNI** | You Ain't Gonna Need It |

### Règles de nommage

```csharp
// ❌ Mauvais
int d; // temps écoulé en jours
public void Process(List<int> l) { }

// ✅ Bon
int elapsedTimeInDays;
public void CalculerTotal(List<int> montants) { }
```

### Fonctions courtes et focalisées

```csharp
// ❌ Mauvais - fait trop de choses
public void TraiterCommande(Commande cmd)
{
    // Valider
    // Calculer
    // Sauvegarder
    // Envoyer email
    // Logger
}

// ✅ Bon - une responsabilité par fonction
public void TraiterCommande(Commande cmd)
{
    Valider(cmd);
    var total = Calculer(cmd);
    Sauvegarder(cmd);
    NotifierClient(cmd);
}
```

---

## Ressources

- [Clean Code - Robert C. Martin](https://www.oreilly.com/library/view/clean-code-a/9780136083238/)
- [The Pragmatic Programmer](https://pragprog.com/titles/tpp20/the-pragmatic-programmer-20th-anniversary-edition/)
- [TDD by Example - Kent Beck](https://www.oreilly.com/library/view/test-driven-development/0321146530/)

---

➡️ **Suivant** : [05 - Environnements .NET](../05-Environnements-DotNet/)

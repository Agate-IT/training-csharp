# Katas de Programmation

Les katas sont des exercices de programmation conçus pour être répétés régulièrement afin d'améliorer vos compétences.

## Principes du Kata

- **Répétition** : Refaire le même kata plusieurs fois pour maîtriser les concepts
- **TDD** : Toujours commencer par écrire un test qui échoue
- **Petits pas** : Avancer par petites étapes incrémentales
- **Refactoring** : Améliorer le code sans changer son comportement

---

## Katas disponibles

| Kata | Niveau | Concepts | Durée estimée |
|------|--------|----------|---------------|
| [StringCalculator](./StringCalculator/) | Débutant | TDD, Parsing, Exceptions | 30-60 min |
| [Bowling Game](./BowlingGame/) | Intermédiaire | TDD, Logique métier | 45-90 min |
| [Gilded Rose](./GildedRose/) | Avancé | Refactoring, Legacy code | 60-120 min |

---

## Comment pratiquer

### 1. Préparez votre environnement

```bash
cd Katas/StringCalculator
dotnet new sln -n StringCalculator
dotnet new classlib -o src/StringCalculator
dotnet new xunit -o tests/StringCalculator.Tests
dotnet sln add src/StringCalculator tests/StringCalculator.Tests
dotnet add tests/StringCalculator.Tests reference src/StringCalculator
dotnet add tests/StringCalculator.Tests package FluentAssertions
```

### 2. Suivez le cycle TDD

```
┌─────────────────────────────────────────────────────────┐
│  1. RED    │  Écrivez un test qui échoue                │
├─────────────────────────────────────────────────────────┤
│  2. GREEN  │  Écrivez le code minimal pour passer       │
├─────────────────────────────────────────────────────────┤
│  3. REFACTOR │  Améliorez le code sans casser les tests │
└─────────────────────────────────────────────────────────┘
```

### 3. Contraintes supplémentaires (pour progresser)

- **Time-boxing** : Limitez-vous à 30 minutes
- **Sans souris** : Utilisez uniquement le clavier
- **Pair programming** : Faites-le en binôme
- **Mob programming** : Faites-le en groupe

---

## Progression recommandée

```
StringCalculator (Débutant)
        │
        ▼
  Bowling Game (Intermédiaire)
        │
        ▼
   Gilded Rose (Avancé)
        │
        ▼
MiniBourse-Kata (Projet complet)
```

---

## Ressources

- [Kata-Log](https://kata-log.rocks/) - Catalogue de katas
- [Coding Dojo](https://codingdojo.org/) - Pratiques et katas
- [Emily Bache - GitHub](https://github.com/emilybache) - Katas de refactoring

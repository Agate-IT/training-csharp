# Formation C# / .NET - AGATE IT

Bienvenue dans le référentiel de formation C# d'AGATE IT !

Ce dépôt a pour objectif de vous accompagner dans l'apprentissage et le perfectionnement de vos compétences en C# et .NET. Vous y trouverez des ressources allant des concepts fondamentaux jusqu'aux sujets avancés.

## Table des matières

| Module | Description | Niveau |
|--------|-------------|--------|
| [00 - Programmation Orientée Objet](./00-OOP/) | Les 4 piliers de la POO | Débutant |
| [01 - C# Fondamental](./01-Basic-CSharp/) | Syntaxe, types, LINQ, delegates | Débutant |
| [02 - C# Avancé](./02-Advanced-CSharp/) | Multithreading, async/await, collections | Intermédiaire |
| [03 - SOLID](./03-SOLID/) | Les 5 principes de conception | Intermédiaire |
| [Design Patterns](./Design-Patterns/) | Patterns de création, structure, comportement | Intermédiaire |
| [04 - Algorithmes](./04-Algorithmes/) | Exercices algorithmiques | Tous niveaux |
| [Software Craftsmanship](./Software-Craftsmanship/) | TDD, BDD, Clean Code | Avancé |
| [05 - Environnements .NET](./05-Environnements-DotNet/) | .NET Framework, Core, 5/6/7/8 | Tous niveaux |
| **[Katas](./Katas/)** | **Exercices pratiques TDD** | **Tous niveaux** |

---

## Parcours recommandé

```
┌─────────────────────────────────────────────────────────────────┐
│                        DÉBUTANT                                 │
├─────────────────────────────────────────────────────────────────┤
│  00-OOP  →  01-Basic-CSharp  →  04-Algorithmes (FizzBuzz)      │
└─────────────────────────────────────────────────────────────────┘
                              ↓
┌─────────────────────────────────────────────────────────────────┐
│                      INTERMÉDIAIRE                              │
├─────────────────────────────────────────────────────────────────┤
│  02-Advanced-CSharp  →  03-SOLID  →  Design-Patterns           │
└─────────────────────────────────────────────────────────────────┘
                              ↓
┌─────────────────────────────────────────────────────────────────┐
│                         AVANCÉ                                  │
├─────────────────────────────────────────────────────────────────┤
│  Software-Craftsmanship (TDD/BDD)  →  MiniBourse-Kata          │
└─────────────────────────────────────────────────────────────────┘
```

---

## 00 - Programmation Orientée Objet (POO)

Les 4 piliers fondamentaux :

| Concept | Description |
|---------|-------------|
| **Encapsulation** | Regrouper données et méthodes, contrôler l'accès |
| **Héritage** | Réutiliser et étendre des classes existantes |
| **Polymorphisme** | Une interface, plusieurs implémentations |
| **Abstraction** | Masquer la complexité, exposer l'essentiel |

➡️ [Voir le module](./00-OOP/)

---

## 01 - C# Fondamental

Les bases essentielles du langage :

- **Types et variables** : value types vs reference types, nullables
- **Classes et interfaces** : abstract, virtual, override, new
- **Génériques** : contraintes, covariance, contravariance
- **LINQ** : syntaxe fluent et query, jointures, groupements
- **Delegates et events** : Func, Action, expressions lambda
- **Gestion mémoire** : IDisposable, using, garbage collector

➡️ [Voir le module](./01-Basic-CSharp/)

---

## 02 - C# Avancé

Programmation parallèle et concepts avancés :

- **Multithreading** : Thread, Task, ThreadPool
- **Synchronisation** : lock, Monitor, Mutex, Semaphore
- **Async/Await** : programmation asynchrone moderne
- **Collections concurrentes** : ConcurrentDictionary, ConcurrentQueue
- **Problèmes courants** : Race conditions, Deadlocks

➡️ [Voir le module](./02-Advanced-CSharp/)

---

## 03 - SOLID

Les 5 principes de conception orientée objet :

| Principe | Nom complet | Description |
|----------|-------------|-------------|
| **S** | Single Responsibility | Une classe = une responsabilité |
| **O** | Open/Closed | Ouvert à l'extension, fermé à la modification |
| **L** | Liskov Substitution | Les sous-types doivent être substituables |
| **I** | Interface Segregation | Interfaces spécifiques plutôt que générales |
| **D** | Dependency Inversion | Dépendre des abstractions, pas des implémentations |

➡️ [Voir le module](./03-SOLID/)

---

## Design Patterns

### Patterns de création
| Pattern | Utilisation |
|---------|-------------|
| **Singleton** | Instance unique globale |
| **Factory Method** | Déléguer la création à des sous-classes |
| **Abstract Factory** | Familles d'objets liés |
| **Builder** | Construction complexe étape par étape |
| **Prototype** | Clonage d'objets |

### Patterns de structure
| Pattern | Utilisation |
|---------|-------------|
| **Adapter** | Compatibilité entre interfaces |
| **Decorator** | Ajouter des comportements dynamiquement |
| **Facade** | Interface simplifiée pour un sous-système |
| **Proxy** | Contrôler l'accès à un objet |

### Patterns de comportement
| Pattern | Utilisation |
|---------|-------------|
| **Strategy** | Algorithmes interchangeables |
| **Observer** | Notifications de changement d'état |
| **Command** | Encapsuler des requêtes |
| **State** | Comportement selon l'état |

➡️ [Voir le module](./Design-Patterns/)

---

## 04 - Algorithmes

Exercices pratiques pour s'entraîner :

| Exercice | Concepts |
|----------|----------|
| **FizzBuzz** | Conditions, modulo, tests |
| **Fibonacci** | Récursivité vs itération, performance |

➡️ [Voir le module](./04-Algorithmes/)

---

## Software Craftsmanship

L'art du code propre et maintenable :

### TDD - Test-Driven Development
```
RED → GREEN → REFACTOR
```
1. Écrire un test qui échoue
2. Écrire le code minimal pour le faire passer
3. Refactoriser en gardant les tests verts

**Exercice** : [StringCalculator Kata](./Software-Craftsmanship/)

### BDD - Behavior-Driven Development
Spécifications par l'exemple avec Gherkin :
```gherkin
Given un utilisateur connecté
When il ajoute un produit au panier
Then le panier contient 1 produit
```

➡️ [Voir le module](./Software-Craftsmanship/)

---

## 05 - Environnements .NET

| Version | Type | Support |
|---------|------|---------|
| .NET Framework 4.8 | Windows only | LTS |
| .NET Core 3.1 | Cross-platform | Fin de support |
| .NET 6 | Cross-platform | LTS (fin 2024) |
| .NET 8 | Cross-platform | **LTS (recommandé)** |
| .NET 9 | Cross-platform | STS |

➡️ [Voir le module](./05-Environnements-DotNet/)

---

## Kata pratique : MiniBourse

Pour mettre en pratique tous ces concepts, nous avons créé un kata progressif en 3 niveaux :

| Niveau | Cible | Concepts |
|--------|-------|----------|
| Junior | Débutants | Classes, Interfaces, Tests xUnit |
| Intermédiaire | 1-2 ans | Strategy, Factory, DI, Mocking |
| Avancé | Confirmés | Clean Architecture, DDD, CQRS |

➡️ **[Accéder au MiniBourse-Kata](https://github.com/Agate-IT/MiniBourse-Kata)** (accès privé)

---

## Prérequis

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Un IDE : Visual Studio 2022, VS Code, ou JetBrains Rider
- Git

## Comment contribuer

Ce référentiel est collaboratif ! N'hésitez pas à :

1. **Forker** le dépôt
2. **Créer** une branche pour votre contribution
3. **Soumettre** une Pull Request

Ensemble, faisons de cette ressource quelque chose d'exceptionnel !

---

## Ressources complémentaires

- [Documentation officielle C#](https://learn.microsoft.com/fr-fr/dotnet/csharp/)
- [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns)
- [Clean Code - Robert C. Martin](https://www.oreilly.com/library/view/clean-code-a/9780136083238/)

---

*Créé et maintenu par [AGATE IT](https://github.com/Agate-IT)*

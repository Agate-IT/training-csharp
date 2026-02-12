# C# Fondamental

Les bases essentielles du langage C#.

## Types et variables

### Value Types vs Reference Types

| Value Types | Reference Types |
|-------------|-----------------|
| `int`, `double`, `bool`, `char` | `string`, `object`, classes |
| `struct`, `enum` | `interface`, tableaux |
| Stockés sur la **stack** | Stockés sur le **heap** |
| Copie par **valeur** | Copie par **référence** |

```csharp
// Value type - copie indépendante
int a = 5;
int b = a;
b = 10;
Console.WriteLine(a); // 5

// Reference type - même objet
var list1 = new List<int> { 1, 2, 3 };
var list2 = list1;
list2.Add(4);
Console.WriteLine(list1.Count); // 4
```

---

## Classes et modificateurs

### virtual, override, new

```csharp
public class Parent
{
    public virtual void Methode() => Console.WriteLine("Parent");
}

public class Enfant : Parent
{
    public override void Methode() => Console.WriteLine("Enfant"); // Redéfinition
}

public class AutreEnfant : Parent
{
    public new void Methode() => Console.WriteLine("Caché"); // Masquage
}
```

### abstract vs interface

| `abstract class` | `interface` |
|------------------|-------------|
| Peut contenir du code | Seulement des signatures (avant C# 8) |
| Héritage unique | Implémentation multiple |
| Peut avoir des champs | Pas de champs (seulement propriétés) |
| Peut avoir un constructeur | Pas de constructeur |

---

## Génériques

```csharp
// Classe générique
public class Repository<T> where T : class, new()
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public T Create() => new T();
}

// Contraintes possibles
// where T : struct        - T doit être un value type
// where T : class         - T doit être un reference type
// where T : new()         - T doit avoir un constructeur sans paramètre
// where T : BaseClass     - T doit hériter de BaseClass
// where T : IInterface    - T doit implémenter IInterface
```

---

## LINQ

### Syntaxe Query vs Fluent

```csharp
var personnes = new List<Personne>();

// Syntaxe Query
var adultes = from p in personnes
              where p.Age >= 18
              orderby p.Nom
              select p;

// Syntaxe Fluent (préférée)
var adultes = personnes
    .Where(p => p.Age >= 18)
    .OrderBy(p => p.Nom);
```

### Opérations courantes

```csharp
// Filtrage
.Where(x => x.Actif)
.First() / .FirstOrDefault()
.Single() / .SingleOrDefault()

// Projection
.Select(x => x.Nom)
.SelectMany(x => x.Commandes)

// Agrégation
.Count() / .Sum() / .Average()
.Min() / .Max()

// Groupement
.GroupBy(x => x.Categorie)

// Jointures
.Join(autres, x => x.Id, y => y.RefId, (x, y) => new { x, y })
```

---

## Delegates et Events

### Func, Action, Predicate

```csharp
// Action - pas de retour
Action<string> afficher = message => Console.WriteLine(message);

// Func - avec retour
Func<int, int, int> additionner = (a, b) => a + b;

// Predicate - retourne bool
Predicate<int> estPair = n => n % 2 == 0;
```

### Events

```csharp
public class Bouton
{
    public event EventHandler? Click;

    protected virtual void OnClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}

// Abonnement
bouton.Click += (sender, e) => Console.WriteLine("Cliqué!");
```

---

## Gestion mémoire

### IDisposable et using

```csharp
// Utilisation avec using
using (var ressource = new FileStream("fichier.txt", FileMode.Open))
{
    // Utilisation
} // Dispose() appelé automatiquement

// Syntaxe moderne (C# 8+)
using var ressource = new FileStream("fichier.txt", FileMode.Open);
// Dispose() appelé à la fin du scope
```

---

## Questions d'entretien

- [ ] Différence entre `new` et `override` ?
- [ ] Différence entre `virtual` et `abstract` ?
- [ ] Différence entre agrégation et composition ?
- [ ] Différence entre classe abstraite et interface ?
- [ ] Qu'est-ce qu'un type générique ? Quelles sont les contraintes ?
- [ ] Types immutables vs mutables ?
- [ ] Les 5 modificateurs de visibilité ?
- [ ] Qu'est-ce que la réflexion ?
- [ ] `dynamic` vs `var` ?
- [ ] Value type vs reference type ?
- [ ] Implémentation implicite vs explicite d'interface ?
- [ ] Comment déclarer une méthode anonyme ?
- [ ] Différence entre `Func` et `Action` ?
- [ ] Qu'est-ce que `IDisposable` ?
- [ ] Les deux utilisations du mot-clé `using` ?
- [ ] Qu'est-ce que `IEnumerable` / `IEnumerator` ?
- [ ] Le mot-clé `yield` ?
- [ ] Comment créer une méthode d'extension ?

---

## 🎯 Kata recommandé

**[MiniBourse-Kata Level 1 (Junior)](https://github.com/Agate-IT/MiniBourse-Kata/tree/main/Level1-Junior)**

Mettez en pratique les fondamentaux C# :
- Utilisation des collections et LINQ
- Implémentation d'interfaces
- Tests unitaires avec xUnit et FluentAssertions

---

➡️ **Suivant** : [02 - C# Avancé](../02-Advanced-CSharp/)

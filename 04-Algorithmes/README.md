# Algorithmes

Exercices pratiques pour s'entraîner à la logique et aux algorithmes.

## FizzBuzz

### Énoncé
Pour les nombres de 1 à 100 :
- Si le nombre est divisible par 3, afficher "Fizz"
- Si le nombre est divisible par 5, afficher "Buzz"
- Si le nombre est divisible par 3 ET 5, afficher "FizzBuzz"
- Sinon, afficher le nombre

### Solution

```csharp
for (int i = 1; i <= 100; i++)
{
    string resultat = (i % 3 == 0, i % 5 == 0) switch
    {
        (true, true) => "FizzBuzz",
        (true, false) => "Fizz",
        (false, true) => "Buzz",
        _ => i.ToString()
    };
    Console.WriteLine(resultat);
}
```

### Exercice
Implémentez FizzBuzz en TDD avec les tests suivants :
- [ ] Retourne "1" pour 1
- [ ] Retourne "Fizz" pour 3
- [ ] Retourne "Buzz" pour 5
- [ ] Retourne "FizzBuzz" pour 15

---

## Fibonacci

### Énoncé
La suite de Fibonacci : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...

Chaque nombre est la somme des deux précédents.

### Solution récursive (simple mais lente)

```csharp
public int FibonacciRecursif(int n)
{
    if (n <= 1) return n;
    return FibonacciRecursif(n - 1) + FibonacciRecursif(n - 2);
}
// Complexité : O(2^n) - Exponentielle !
```

### Solution itérative (optimisée)

```csharp
public int FibonacciIteratif(int n)
{
    if (n <= 1) return n;

    int prev = 0, curr = 1;
    for (int i = 2; i <= n; i++)
    {
        int next = prev + curr;
        prev = curr;
        curr = next;
    }
    return curr;
}
// Complexité : O(n) - Linéaire
```

### Solution avec mémorisation

```csharp
private readonly Dictionary<int, long> _cache = new();

public long FibonacciMemo(int n)
{
    if (n <= 1) return n;

    if (_cache.TryGetValue(n, out var cached))
        return cached;

    var result = FibonacciMemo(n - 1) + FibonacciMemo(n - 2);
    _cache[n] = result;
    return result;
}
// Complexité : O(n) avec cache
```

---

## Autres exercices recommandés

| Exercice | Niveau | Concepts |
|----------|--------|----------|
| Palindrome | Facile | Strings, comparaison |
| Anagramme | Facile | Strings, tri |
| Deux sommes | Moyen | Dictionary, recherche |
| Tri rapide | Moyen | Récursivité, divide & conquer |
| Recherche binaire | Moyen | Tableaux triés, O(log n) |

---

## Conseils pour les entretiens

1. **Clarifiez** le problème avant de coder
2. **Pensez** à voix haute
3. **Commencez** par une solution simple
4. **Optimisez** ensuite si demandé
5. **Testez** avec des cas limites

---

➡️ **Suivant** : [Software Craftsmanship](../Software-Craftsmanship/)

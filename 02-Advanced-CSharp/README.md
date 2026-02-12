# C# Avancé

Programmation parallèle, asynchrone et concepts avancés.

## Multithreading

### Thread vs Task

| Thread | Task |
|--------|------|
| Bas niveau | Haut niveau (TPL) |
| Gestion manuelle | Géré par le ThreadPool |
| Plus de contrôle | Plus simple à utiliser |

```csharp
// Thread (bas niveau)
var thread = new Thread(() => Console.WriteLine("Thread"));
thread.Start();
thread.Join(); // Attendre la fin

// Task (recommandé)
var task = Task.Run(() => Console.WriteLine("Task"));
await task;

// Task avec résultat
var taskAvecResultat = Task.Run(() => 42);
int resultat = await taskAvecResultat;
```

---

## Synchronisation

### Le mot-clé `lock`

```csharp
private readonly object _verrou = new();
private int _compteur = 0;

public void Incrementer()
{
    lock (_verrou)
    {
        _compteur++; // Section critique protégée
    }
}
```

### Primitives de synchronisation

| Primitive | Utilisation |
|-----------|-------------|
| `lock` / `Monitor` | Exclusion mutuelle simple |
| `Mutex` | Exclusion entre processus |
| `Semaphore` | Limiter le nombre d'accès concurrents |
| `SemaphoreSlim` | Version légère du Semaphore |
| `ReaderWriterLockSlim` | Plusieurs lecteurs OU un écrivain |

```csharp
// Semaphore - max 3 accès simultanés
private readonly SemaphoreSlim _semaphore = new(3);

public async Task AccederRessource()
{
    await _semaphore.WaitAsync();
    try
    {
        // Accès à la ressource
    }
    finally
    {
        _semaphore.Release();
    }
}
```

---

## Async / Await

### Principes de base

```csharp
// Méthode asynchrone
public async Task<string> TelechargerAsync(string url)
{
    using var client = new HttpClient();
    return await client.GetStringAsync(url);
}

// Appel
var contenu = await TelechargerAsync("https://example.com");
```

### Bonnes pratiques

```csharp
// ✅ Bon - ConfigureAwait(false) dans les librairies
await task.ConfigureAwait(false);

// ✅ Bon - Éviter async void (sauf event handlers)
public async Task FaireQuelqueChoseAsync() { }

// ❌ Mauvais - Bloquer sur du code async
var result = task.Result; // Deadlock possible!
task.Wait();              // Deadlock possible!

// ✅ Bon - Utiliser await
var result = await task;
```

---

## Problèmes courants

### Race Condition

```csharp
// ❌ Race condition
private int _compteur = 0;

public void Incrementer()
{
    _compteur++; // Non thread-safe!
}

// ✅ Solution avec Interlocked
public void IncrementerSafe()
{
    Interlocked.Increment(ref _compteur);
}
```

### Deadlock

```csharp
// ❌ Deadlock potentiel
lock (A) { lock (B) { } } // Thread 1
lock (B) { lock (A) { } } // Thread 2 - DEADLOCK!

// ✅ Solution : toujours verrouiller dans le même ordre
```

---

## Collections concurrentes

```csharp
// Thread-safe collections
ConcurrentDictionary<string, int> dict = new();
ConcurrentQueue<string> queue = new();
ConcurrentBag<int> bag = new();

// Opérations atomiques
dict.TryAdd("clé", 1);
dict.AddOrUpdate("clé", 1, (k, v) => v + 1);
dict.GetOrAdd("clé", k => CalculerValeur(k));
```

---

## Questions d'entretien

- [ ] Qu'est-ce que le mot-clé `lock` ?
- [ ] Différence entre Thread et Task ?
- [ ] Qu'est-ce qu'un ThreadPool ?
- [ ] Différence entre Thread et Process ?
- [ ] Qu'est-ce qu'une Race Condition ?
- [ ] Qu'est-ce qu'un Deadlock ?
- [ ] Qu'est-ce que le mot-clé `volatile` ?
- [ ] La classe `Interlocked` ?
- [ ] Monitor, Mutex, Semaphore ?
- [ ] `async` et `await` ?
- [ ] `ConcurrentDictionary` vs `Dictionary` ?

---

➡️ **Suivant** : [03 - SOLID](../03-SOLID/)

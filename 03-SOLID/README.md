# Principes SOLID

Les 5 principes fondamentaux de la conception orientée objet.

## S - Single Responsibility Principle (SRP)

> Une classe ne doit avoir qu'une seule raison de changer.

### Exemple

```csharp
// ❌ Mauvais - plusieurs responsabilités
public class Employee
{
    public void CalculatePay() { }
    public void Save() { }
    public void GenerateReport() { }
}

// ✅ Bon - une responsabilité par classe
public class Employee { /* données */ }
public class PayCalculator { public decimal Calculate(Employee e) { } }
public class EmployeeRepository { public void Save(Employee e) { } }
public class EmployeeReporter { public string GenerateReport(Employee e) { } }
```

➡️ [Voir l'exercice SRP](./Single%20Responsibility%20Principle/)

---

## O - Open/Closed Principle (OCP)

> Ouvert à l'extension, fermé à la modification.

### Exemple

```csharp
// ❌ Mauvais - modification nécessaire pour chaque nouveau type
public decimal CalculerAire(object forme)
{
    if (forme is Rectangle r) return r.Largeur * r.Hauteur;
    if (forme is Cercle c) return Math.PI * c.Rayon * c.Rayon;
    // Ajouter Triangle = modifier cette méthode
}

// ✅ Bon - extension sans modification
public interface IForme
{
    decimal CalculerAire();
}

public class Rectangle : IForme
{
    public decimal CalculerAire() => Largeur * Hauteur;
}

public class Triangle : IForme // Nouvelle forme = nouvelle classe
{
    public decimal CalculerAire() => Base * Hauteur / 2;
}
```

➡️ [Voir l'exercice OCP](./Open%20Close%20Principle/)

---

## L - Liskov Substitution Principle (LSP)

> Les objets d'une classe dérivée doivent pouvoir remplacer les objets de la classe de base sans altérer le comportement.

### Exemple

```csharp
// ❌ Mauvais - viole LSP
public class Rectangle
{
    public virtual int Largeur { get; set; }
    public virtual int Hauteur { get; set; }
}

public class Carre : Rectangle
{
    public override int Largeur
    {
        set { base.Largeur = base.Hauteur = value; }
    }
    // Comportement inattendu quand utilisé comme Rectangle
}

// ✅ Bon - hiérarchie correcte
public interface IForme
{
    decimal CalculerAire();
}

public class Rectangle : IForme { /* ... */ }
public class Carre : IForme { /* ... */ } // Pas d'héritage problématique
```

---

## I - Interface Segregation Principle (ISP)

> Les clients ne doivent pas être forcés de dépendre d'interfaces qu'ils n'utilisent pas.

### Exemple

```csharp
// ❌ Mauvais - interface trop large
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class Robot : IWorker
{
    public void Work() { /* OK */ }
    public void Eat() { throw new NotImplementedException(); } // Problème!
    public void Sleep() { throw new NotImplementedException(); } // Problème!
}

// ✅ Bon - interfaces séparées
public interface IWorkable { void Work(); }
public interface IFeedable { void Eat(); }
public interface ISleepable { void Sleep(); }

public class Robot : IWorkable { public void Work() { } }
public class Human : IWorkable, IFeedable, ISleepable { /* ... */ }
```

---

## D - Dependency Inversion Principle (DIP)

> Dépendre des abstractions, pas des implémentations.

### Exemple

```csharp
// ❌ Mauvais - dépendance sur l'implémentation
public class OrderService
{
    private readonly SqlDatabase _database = new SqlDatabase();

    public void SaveOrder(Order order)
    {
        _database.Save(order);
    }
}

// ✅ Bon - dépendance sur l'abstraction
public class OrderService
{
    private readonly IDatabase _database;

    public OrderService(IDatabase database) // Injection
    {
        _database = database;
    }

    public void SaveOrder(Order order)
    {
        _database.Save(order);
    }
}

// Peut utiliser SqlDatabase, MongoDatabase, InMemoryDatabase...
```

---

## Résumé

| Principe | En une phrase |
|----------|---------------|
| **S**RP | Une classe = une responsabilité |
| **O**CP | Étendre sans modifier |
| **L**SP | Sous-types substituables |
| **I**SP | Interfaces petites et spécifiques |
| **D**IP | Dépendre des abstractions |

---

## Questions d'entretien

- [ ] Expliquez le principe SRP avec un exemple.
- [ ] Comment OCP aide-t-il à éviter les bugs de régression ?
- [ ] Donnez un exemple de violation de LSP.
- [ ] Pourquoi ISP est-il important pour les tests ?
- [ ] Comment DIP facilite-t-il les tests unitaires ?

---

➡️ **Suivant** : [Design Patterns](../Design-Patterns/)

# Design Patterns

Les patterns de conception sont des solutions éprouvées à des problèmes récurrents.

## Patterns de création

### Singleton
> Une seule instance dans toute l'application.

```csharp
public sealed class Singleton
{
    private static readonly Lazy<Singleton> _instance =
        new(() => new Singleton());

    public static Singleton Instance => _instance.Value;

    private Singleton() { }
}
```

### Factory Method
> Déléguer la création d'objets aux sous-classes.

```csharp
public abstract class Creator
{
    public abstract IProduct CreateProduct();
}

public class ConcreteCreator : Creator
{
    public override IProduct CreateProduct() => new ConcreteProduct();
}
```

### Builder
> Construire des objets complexes étape par étape.

```csharp
var pizza = new PizzaBuilder()
    .AvecPate("fine")
    .AvecSauce("tomate")
    .AvecFromage("mozzarella")
    .AvecGarniture("champignons")
    .Build();
```

---

## Patterns de structure

### Adapter
> Convertir l'interface d'une classe en une autre.

```csharp
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee) => _adaptee = adaptee;

    public void Request() => _adaptee.SpecificRequest();
}
```

### Decorator
> Ajouter des comportements dynamiquement.

```csharp
IBoisson cafe = new Cafe();
cafe = new AvecLait(cafe);
cafe = new AvecSucre(cafe);
Console.WriteLine(cafe.Prix); // Prix cumulé
```

### Facade
> Interface simplifiée pour un sous-système complexe.

```csharp
public class CommandeFacade
{
    public void PasserCommande(Panier panier)
    {
        _inventaire.Verifier(panier);
        _paiement.Traiter(panier.Total);
        _expedition.Preparer(panier);
        _notification.Envoyer("Commande confirmée");
    }
}
```

---

## Patterns de comportement

### Strategy
> Algorithmes interchangeables.

```csharp
public interface IStrategyPaiement
{
    void Payer(decimal montant);
}

public class PaiementCB : IStrategyPaiement { /* ... */ }
public class PaiementPayPal : IStrategyPaiement { /* ... */ }

// Utilisation
_strategie.Payer(100m);
```

### Observer
> Notification automatique des changements.

```csharp
public class Sujet
{
    public event EventHandler<string>? Changement;

    protected void NotifierChangement(string message)
    {
        Changement?.Invoke(this, message);
    }
}
```

### Command
> Encapsuler une requête comme un objet.

```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}

public class AjouterTexteCommand : ICommand
{
    public void Execute() => _document.Ajouter(_texte);
    public void Undo() => _document.Supprimer(_texte);
}
```

---

## Questions d'entretien

### Patterns de création
- [ ] Singleton : avantages et inconvénients ?
- [ ] Factory Method vs Abstract Factory ?
- [ ] Quand utiliser le Builder ?
- [ ] Prototype : cas d'utilisation ?

### Patterns de structure
- [ ] Adapter vs Facade ?
- [ ] Decorator vs héritage ?
- [ ] Quand utiliser Proxy ?

### Patterns de comportement
- [ ] Strategy vs State ?
- [ ] Observer vs événements C# ?
- [ ] Command : undo/redo ?

---

## Ressources

- [Refactoring Guru](https://refactoring.guru/design-patterns)
- [Head First Design Patterns](https://www.oreilly.com/library/view/head-first-design/0596007124/)

---

➡️ **Suivant** : [04 - Algorithmes](../04-Algorithmes/)

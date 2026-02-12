# Programmation Orientée Objet (POO)

La POO est un paradigme de programmation basé sur le concept d'objets qui contiennent des données et du code.

## Les 4 piliers de la POO

### 1. Encapsulation

> Regrouper les données et les méthodes qui les manipulent, tout en contrôlant l'accès.

```csharp
public class CompteBancaire
{
    private decimal _solde; // Donnée privée

    public decimal Solde => _solde; // Accès en lecture seule

    public void Deposer(decimal montant)
    {
        if (montant > 0)
            _solde += montant;
    }

    public bool Retirer(decimal montant)
    {
        if (montant > 0 && montant <= _solde)
        {
            _solde -= montant;
            return true;
        }
        return false;
    }
}
```

**Avantages** :
- Protection des données internes
- Contrôle de la modification de l'état
- Réduction du couplage

---

### 2. Héritage

> Créer de nouvelles classes basées sur des classes existantes.

```csharp
public class Animal
{
    public string Nom { get; set; }
    public virtual void Parler() => Console.WriteLine("...");
}

public class Chien : Animal
{
    public override void Parler() => Console.WriteLine("Wouf!");
}

public class Chat : Animal
{
    public override void Parler() => Console.WriteLine("Miaou!");
}
```

**Types d'héritage** :
- `class Enfant : Parent` - Héritage de classe
- `class Implementation : IInterface` - Implémentation d'interface
- `abstract class` - Classe abstraite (ne peut pas être instanciée)
- `sealed class` - Classe scellée (ne peut pas être héritée)

---

### 3. Polymorphisme

> Une même interface, plusieurs implémentations.

```csharp
// Polymorphisme par héritage
Animal animal = new Chien();
animal.Parler(); // "Wouf!"

animal = new Chat();
animal.Parler(); // "Miaou!"

// Polymorphisme par interface
IEnumerable<int> nombres = new List<int>();
nombres = new int[] { 1, 2, 3 };
nombres = new HashSet<int>();
```

**Formes de polymorphisme** :
- **Surcharge (overloading)** : Même nom, signatures différentes
- **Redéfinition (overriding)** : Même signature, comportement différent
- **Interfaces** : Contrat commun, implémentations variées

---

### 4. Abstraction

> Masquer la complexité et exposer uniquement l'essentiel.

```csharp
// Interface = abstraction pure
public interface IEmailService
{
    void Envoyer(string destinataire, string sujet, string corps);
}

// L'utilisateur ne connaît pas les détails d'implémentation
public class SmtpEmailService : IEmailService
{
    public void Envoyer(string destinataire, string sujet, string corps)
    {
        // Complexité cachée : connexion SMTP, authentification, etc.
    }
}
```

---

## Questions d'entretien

- [ ] Qu'est-ce que la programmation orientée objet ?
- [ ] Expliquez l'encapsulation avec un exemple.
- [ ] Quelle est la différence entre héritage et composition ?
- [ ] Qu'est-ce que le polymorphisme ? Donnez un exemple.
- [ ] Pourquoi utiliser l'abstraction ?
- [ ] Différence entre `abstract class` et `interface` ?

---

## Exercice pratique

Créez une hiérarchie de classes pour un système de formes géométriques :

1. Une classe abstraite `Forme` avec une méthode `CalculerAire()`
2. Des classes `Rectangle`, `Cercle`, `Triangle` qui héritent de `Forme`
3. Une interface `IDessinable` avec une méthode `Dessiner()`
4. Faites en sorte que les formes implémentent `IDessinable`

---

➡️ **Suivant** : [01 - C# Fondamental](../01-Basic-CSharp/)

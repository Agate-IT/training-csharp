# Kata : Gilded Rose

Un kata de **refactoring** créé par Terry Hughes et popularisé par Emily Bache.

## Contexte

Bienvenue à la **Gilded Rose**, une petite auberge située dans un coin stratégique d'une ville importante. L'auberge achète et vend uniquement les meilleurs produits.

Malheureusement, la qualité de nos produits se dégrade à mesure qu'ils approchent de leur date de péremption.

Nous avons un système en place qui met à jour notre inventaire. Il a été développé par Leeroy, un développeur qui est parti pour de nouvelles aventures. Votre tâche est d'ajouter une nouvelle fonctionnalité à ce système pour pouvoir vendre un nouveau type de produit.

---

## Règles métier actuelles

Tous les articles ont :
- `SellIn` : nombre de jours pour vendre l'article
- `Quality` : valeur de l'article (0-50)

À la fin de chaque journée, les valeurs sont mises à jour :

| Article | Règle |
|---------|-------|
| **Normal** | Quality -1 par jour, -2 après SellIn |
| **Aged Brie** | Quality +1 par jour (s'améliore avec l'âge) |
| **Backstage passes** | Quality +1 (>10j), +2 (≤10j), +3 (≤5j), 0 après concert |
| **Sulfuras** | Ne se vend jamais, Quality ne change pas (toujours 80) |

### Contraintes

- La Quality ne peut jamais être **négative**
- La Quality ne peut jamais dépasser **50** (sauf Sulfuras = 80)
- Sulfuras n'a jamais à être vendu (SellIn ne change pas)

---

## Nouvelle fonctionnalité à ajouter

Nous avons signé un accord avec un fournisseur de **"Conjured"** (articles magiques).

Les articles **"Conjured"** se dégradent **2 fois plus vite** que les articles normaux.

```
Conjured Mana Cake : Quality -2 par jour, -4 après SellIn
```

---

## Le code legacy

Voici le code que vous devez refactorer. **Ne modifiez pas la classe Item !**

```csharp
public void UpdateQuality()
{
    for (var i = 0; i < Items.Count; i++)
    {
        if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (Items[i].Quality > 0)
            {
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].Quality = Items[i].Quality - 1;
                }
            }
        }
        else
        {
            if (Items[i].Quality < 50)
            {
                Items[i].Quality = Items[i].Quality + 1;

                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].SellIn < 11)
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }

                    if (Items[i].SellIn < 6)
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }

        if (Items[i].SellIn < 0)
        {
            // ... encore plus de conditions imbriquées
        }
    }
}
```

---

## Approche recommandée

### 1. Écrire des tests de caractérisation

Avant de toucher au code, écrivez des tests qui capturent le comportement actuel :

```csharp
[Fact]
public void NormalItem_QualityDecreases()
{
    var items = new List<Item> { new Item { Name = "Normal", SellIn = 10, Quality = 20 } };
    var app = new GildedRose(items);

    app.UpdateQuality();

    items[0].Quality.Should().Be(19);
    items[0].SellIn.Should().Be(9);
}
```

### 2. Couvrir tous les cas

- [ ] Article normal avant SellIn
- [ ] Article normal après SellIn
- [ ] Aged Brie avant SellIn
- [ ] Aged Brie après SellIn
- [ ] Backstage passes > 10 jours
- [ ] Backstage passes ≤ 10 jours
- [ ] Backstage passes ≤ 5 jours
- [ ] Backstage passes après concert
- [ ] Sulfuras
- [ ] Quality ne descend pas sous 0
- [ ] Quality ne dépasse pas 50

### 3. Refactorer

Une fois les tests en place, refactorez le code :

- Extraire des méthodes
- Utiliser le polymorphisme (Strategy pattern)
- Simplifier les conditions

### 4. Ajouter la nouvelle fonctionnalité

Ajoutez le support des articles "Conjured" **en TDD**.

---

## Structure du projet

```
GildedRose/
├── README.md
├── src/
│   └── GildedRose/
│       ├── GildedRose.csproj
│       ├── GildedRose.cs      # Code legacy à refactorer
│       └── Item.cs            # NE PAS MODIFIER
└── tests/
    └── GildedRose.Tests/
        ├── GildedRose.Tests.csproj
        └── GildedRoseTests.cs
```

---

## Conseils

1. **Ne touchez à rien avant d'avoir des tests** - Le code legacy est fragile
2. **Petits pas** - Refactorez une chose à la fois
3. **Gardez les tests verts** - Exécutez les tests après chaque modification
4. **Utilisez le refactoring automatique** - Renommer, extraire méthode, etc.

---

## Variantes du kata

### Niveau 1 : Refactoring simple
Refactorez le code en gardant la même structure procédurale.

### Niveau 2 : Avec polymorphisme
Utilisez le Strategy pattern pour gérer les différents types d'articles.

### Niveau 3 : Avec contraintes
- Pas de `if/else` (utilisez le polymorphisme)
- Pas de mutation (style fonctionnel)

---

## Liens

- [Gilded Rose - Emily Bache GitHub](https://github.com/emilybache/GildedRose-Refactoring-Kata)
- [Retour aux Katas](../)

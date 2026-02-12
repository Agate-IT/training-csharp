# Environnements .NET

Comprendre l'écosystème .NET et ses différentes versions.

## Historique

```
2002  .NET Framework 1.0    Windows only
  │
2016  .NET Core 1.0         Cross-platform
  │
2019  .NET Core 3.1         LTS
  │
2020  .NET 5                Unification (pas de "Core")
  │
2021  .NET 6                LTS
  │
2022  .NET 7                STS
  │
2023  .NET 8                LTS (recommandé)
  │
2024  .NET 9                STS
```

## Comparaison

| Aspect | .NET Framework | .NET (Core/5+) |
|--------|----------------|----------------|
| **Plateforme** | Windows uniquement | Cross-platform |
| **Performance** | Bonne | Excellente |
| **Déploiement** | GAC, IIS | Self-contained, Docker |
| **Open Source** | Partiel | Complet |
| **Avenir** | Maintenance | Développement actif |

---

## Architecture .NET

```
┌─────────────────────────────────────────────────┐
│                 Application                      │
├─────────────────────────────────────────────────┤
│            Bibliothèques .NET                    │
│     (BCL - Base Class Library)                   │
├─────────────────────────────────────────────────┤
│                   CLR                            │
│        (Common Language Runtime)                 │
│  ┌─────────┐  ┌─────────┐  ┌─────────┐         │
│  │   JIT   │  │   GC    │  │  Type   │         │
│  │Compiler │  │         │  │ System  │         │
│  └─────────┘  └─────────┘  └─────────┘         │
├─────────────────────────────────────────────────┤
│              Système d'exploitation              │
└─────────────────────────────────────────────────┘
```

### CLR - Common Language Runtime

Le moteur d'exécution .NET :
- **JIT Compiler** : Compile l'IL en code natif
- **Garbage Collector** : Gère la mémoire automatiquement
- **Type System** : Vérifie les types à l'exécution
- **Exception Handling** : Gère les exceptions

### CTS - Common Type System

Système de types partagé entre tous les langages .NET :
- `System.Int32` → `int` (C#) → `Integer` (VB.NET)
- Permet l'interopérabilité entre langages

### MSIL / IL

Code intermédiaire généré par le compilateur :
```
C# → Compilateur → IL → JIT → Code natif
```

---

## Types de projets

### Console
```bash
dotnet new console -n MonApp
```

### Web API
```bash
dotnet new webapi -n MonApi
```

### Blazor (WebAssembly)
```bash
dotnet new blazorwasm -n MonBlazor
```

### Class Library
```bash
dotnet new classlib -n MaLib
```

---

## Commandes utiles

```bash
# Créer un projet
dotnet new console -n MonProjet

# Restaurer les packages
dotnet restore

# Compiler
dotnet build

# Exécuter
dotnet run

# Tester
dotnet test

# Publier
dotnet publish -c Release

# Ajouter un package
dotnet add package Newtonsoft.Json
```

---

## Questions d'entretien

- [ ] Différence entre .NET Framework et .NET Core ?
- [ ] Qu'est-ce que le CLR ?
- [ ] Comment fonctionne le JIT ?
- [ ] Qu'est-ce que le Garbage Collector ?
- [ ] Qu'est-ce que le CTS ?
- [ ] Qu'est-ce que l'IL/MSIL ?
- [ ] Différence entre LTS et STS ?
- [ ] Avantages de .NET 8 ?

---

## Ressources

- [Documentation .NET](https://learn.microsoft.com/fr-fr/dotnet/)
- [.NET Release Schedule](https://dotnet.microsoft.com/platform/support/policy)

---

➡️ **Kata pratique** : [MiniBourse-Kata](https://github.com/Agate-IT/MiniBourse-Kata)

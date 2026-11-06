# RogueLike

A turn-based roguelike combat system written in C# (.NET 10).

> **Status: work in progress.** The project is at the architecture stage: the core domain model is being designed and the code does not build yet.

## Concept

- **Duos**: each combat unit is a pair of a *main* character and a *support* character, with shared HP and combined speed.
- **Team formation**: up to three duos placed in *front*, *mid* and *back* positions, which skills can target (front enemies, back enemies, all allies, ...).
- **Resources**: skills cost SP; spending SP charges the team's ultimate gauge.
- **Combos**: a main and a support character with matching combo IDs unlock a combo skill.
- **Effects**: buffs and debuffs (ATK/DEF) with a duration, ticked every turn.
- **Progression**: characters gain experience and level up, increasing their stats.

## Project structure

```
Roguelike/
├── Core/         # Enums (stats, targets, actions, effects) and core interfaces
├── Characters/   # Main/support characters, duos, team
├── Skills/       # Skills and combo skills
└── Effects/      # Status effects (e.g. ATK buff)
diagrams/         # UML class diagrams (Mermaid source + exports)
cs_cheatsheet/    # C# cheat sheet
```

The full class diagram is in [`diagrams/combat_uml_packages.mermaid`](diagrams/combat_uml_packages.mermaid).

## Getting started

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
cd Roguelike
dotnet build
dotnet run
```

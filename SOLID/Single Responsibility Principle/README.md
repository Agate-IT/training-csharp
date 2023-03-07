# Single Responsibility Principle

- [Single Responsibility Principle](#single-responsibility-principle)
  - [What is SRP?](#what-is-srp)
  - [Demo](#demo)
    - [Case description](#case-description)
    - [Tips for implementation](#tips-for-implementation)
  - [More?](#more)
    - [Why many classes is not a problem for your application?](#why-many-classes-is-not-a-problem-for-your-application)
    - [How to keep a balance: when to split up a class](#how-to-keep-a-balance-when-to-split-up-a-class)

## What is SRP?
A class should have only one responsibility.

## Demo
### Case description
In the SRPDemo, we have a simple ConsoleUI that generate username for the person.
Do you think it is good enough? 

### Tips for implementation
- If we want to change the way that we want to talk to user, we need to change the Program.cs file.
- If we want to inform user that we've finished creating the username, we also need to change the Program.cs file.
- If we change the way to capture the user's first or last name?
- Morever, if we change the way to validate the input from user?

## More?
### Why many classes is not a problem for your application?
### How to keep a balance: when to split up a class
# Open Close Principle

- [Open Close Principle](#open-close-principle)
  - [What is OCP?](#what-is-ocp)
  - [Demo](#demo)
    - [Case description](#case-description)
    - [Senario](#senario)
  - [Tips](#tips)

## What is OCP?
The Open Closed Principle (OCP) states that objects should be open to extension but closed for modification.

## Demo
### Case description
In the OCPDemo, we have a simple ConsoleUI that generate employee information from person information.
Do you think it is good enough? 

### Senario
- We need to have a way to identify if the employee is a manager so we created a new Enum : EmployeeType with Staff, Manager.
- But if we need a new more role like executive? And the fourth, fifth new role?

## Tips
- Modifying existing code to add new features can introduce bugs and violate the Open Closed Principle.
- Separating responsibilities into separate classes to avoid modification.
- Using interfaces to allow for extension without changing working code
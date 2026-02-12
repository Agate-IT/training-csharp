using OCPLibrary;

List<PersonModel> applicants = new List<PersonModel>()
{
    new PersonModel { FirstName = "Tim", LastName = "Corey" },
    new PersonModel { FirstName = "Sue", LastName = "Storm", TypeOfEmployee = EmployeeType.Manager },
    new PersonModel { FirstName = "Nancy", LastName = "Roman" },
    new PersonModel { FirstName = "Tom", LastName = "Riddle"}
};

List<EmployeeModel> employees = new List<EmployeeModel>();
Accounts accountProcessor = new Accounts();

foreach (var person in applicants)
{
    employees.Add(accountProcessor.Create(person));
}   

foreach(var emp in employees)
{
    Console.WriteLine($"{emp.FirstName} {emp.LastName}: {emp.EmailAddress} IsManager :{emp.IsManager}");
}

Console.ReadLine();
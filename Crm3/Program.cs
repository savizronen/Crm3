
using Crm3;
int idCount=1;
Console.WriteLine("Task-1");
Console.WriteLine("-------------------------------------------------");
// Create a list to hold different types of employees
List<Employee> employees = new List<Employee>();
for (int i = 1; i <= 3; i++)
{
    var hourEmployee = new HourEmployee
    {
        fname = $"HourEmployee{i}",
        Lname = "LastName",
        Id = idCount++,
        JobTitle = "Hourly Worker",
        AccumulatedHours = i * 10,
        PaymentPerHour = i * 5
    };
    employees.Add(hourEmployee);
}

// Create 5 SalaryEmployees with different base salary and extra payments
for (int i = 1; i <= 3; i++)
{
    var salaryEmployee = new SalaryEmployee
    {
        fname = $"SalaryEmployee{i}",
        Lname = "LastName",
        Id = idCount++,
        JobTitle = "Salaried Worker",
        BaseSalary = i * 1000,
        ExtraPayments = new List<ExtraPay> {
                new ExtraPay { Amount = i * 50, Description = "Bonus1", Paid = false },
                new ExtraPay { Amount = i * 100, Description = "Bonus2", Paid = false },
                new ExtraPay { Amount = i * 200, Description = "Bonus3", Paid = false }
            }
    };
    employees.Add(salaryEmployee);
}

// Create 3 SalaryEmployeesWithCommissions with different base salary and commission bonuses
for (int i = 1; i <= 3; i++)
{
    var salaryEmployeeWithCommission = new SalaryEmployeeWithCommissions
    {
        fname = $"SalaryEmployeeWithCommission{i}",
        Lname = "LastName",
        Id = idCount++,
        JobTitle = "Salaried Worker with Commissions",
        BaseSalary = i * 2000,
        CommissionBonuses = new List<CommissionBonus> {
                new CommissionBonus { Amount = i * 50, Description = "Commission1", Paid = false, CommissionPercent = 0.01m },
                new CommissionBonus { Amount = i * 100, Description = "Commission2", Paid = false, CommissionPercent = 0.02m },
                new CommissionBonus { Amount = i * 200, Description = "Commission3", Paid = false, CommissionPercent = 0.03m }
            },
        ExtraPayments = new List<ExtraPay> {
                new ExtraPay { Amount = i * 50, Description = "Bonus1", Paid = false },
                new ExtraPay { Amount = i * 100, Description = "Bonus2", Paid = false }
            }
    };
    employees.Add(salaryEmployeeWithCommission);


}
// Create 3 salaryEmployeeWithPerformanceBonus with different base salary and formance bonuses
for (int i = 1; i <= 3; i++)
{
    var salaryEmployeeWithPerformanceBonus = new SalaryEmployeeWithPerformanceBonus
    {
        fname = $"SalaryEmployeeWithPerformanceBonus{i}",
        Lname = "LastName",
        Id = idCount++,
        JobTitle = "Salaried Worker with Performance Bonuses",
        BaseSalary = i * 10000,
        PerformanceBonuses = new List<PerformanceBonus> {
                    new PerformanceBonus { Amount = i * 500, Description = "Performance1", Paid = false },
                    new PerformanceBonus { Amount = i * 750, Description = "Performance2", Paid = false },
                    new PerformanceBonus { Amount = i * 1000, Description = "Performance3", Paid = false }
                }
    };
    employees.Add(salaryEmployeeWithPerformanceBonus);
}
// Print out the information of the created employees
foreach (var employee in employees)
{
    Console.WriteLine($"Name: {employee.fname} {employee.Lname}");
    Console.WriteLine($"ID: {employee.Id}");
    Console.WriteLine($"Job Title: {employee.JobTitle}");
    Console.WriteLine($"Payment: {employee.CalculatePayment()}");
    Console.WriteLine();
}

var products = new[]
{
    new Product { Name = "Product A", Price = 10.0m },
    new Product { Name = "Product B", Price = 5.0m },
    new Product { Name = "Product C", Price = 15.0m },
    new Product { Name = "Product D", Price = 2.0m },
    new Product { Name = "Product E", Price = 8.0m },
};
Console.WriteLine("Task-2 : 2 and 3 ");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Products array:");
Array.Sort(products, (x, y) => x.Price.CompareTo(y.Price));
foreach (var product in products)
{
    Console.WriteLine($"{product.Name}: {product.Price:C}");
}

Console.WriteLine("Task-2 : 4"); 
Console.WriteLine("-------------------------------------------------");
Console.WriteLine();
Console.WriteLine("DataStore test:");
Console.WriteLine("=== Before ===");

var dataStore = new DataStore(0);

var observer1 = new Observer();
var observer2 = new Observer();
var observer3 = new Observer();

var subscription1 = dataStore.Subscribe(observer1);
var subscription2 = dataStore.Subscribe(observer2);
var subscription3 = dataStore.Subscribe(observer3);

Console.WriteLine($"Initial value of X: {dataStore.X}");

Console.WriteLine();
Console.WriteLine("=== After 1st update ===");

dataStore.X = 10;

Console.WriteLine($"New value of X: {dataStore.X}");
Console.WriteLine($"Observer 1 received value: {observer1.Value}");
Console.WriteLine($"Observer 2 received value: {observer2.Value}");
Console.WriteLine($"Observer 3 received value: {observer3.Value}");

Console.WriteLine();
Console.WriteLine("=== After 2nd update ===");

dataStore.X = 20;

Console.WriteLine($"New value of X: {dataStore.X}");
Console.WriteLine($"Observer 1 received value: {observer1.Value}");
Console.WriteLine($"Observer 2 received value: {observer2.Value}");
Console.WriteLine($"Observer 3 received value: {observer3.Value}");

Console.WriteLine();
Console.WriteLine("=== After 3rd update ===");

subscription2.Dispose();

dataStore.X = 30;

Console.WriteLine($"New value of X: {dataStore.X}");
Console.WriteLine($"Observer 1 received value: {observer1.Value}");
Console.WriteLine($"Observer 2 received value: {observer2.Value} (should not receive anything)");
Console.WriteLine($"Observer 3 received value: {observer3.Value}");

subscription1.Dispose();
subscription3.Dispose();
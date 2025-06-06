using System;

class Program
{
    static void Main()
    {
        EmployeeService service = new EmployeeService();

        while (true)
        {
            Console.WriteLine("\n--- Employee Management System ---");
            Console.WriteLine("1. Add Full-Time Employee");
            Console.WriteLine("2. Add Part-Time Employee");
            Console.WriteLine("3. Display All Employees");
            Console.WriteLine("4. Search Employee by ID");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    FullTimeEmployee ftEmp = new FullTimeEmployee();

                    Console.Write("Enter ID: ");
                    ftEmp.Id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    ftEmp.Name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    ftEmp.Department = Console.ReadLine();

                    Console.Write("Enter Monthly Salary: ");
                    ftEmp.MonthlySalary = double.Parse(Console.ReadLine());

                    service.AddEmployee(ftEmp);
                    Console.WriteLine("Full-Time Employee added.");
                    break;

                case "2":
                    PartTimeEmployee ptEmp = new PartTimeEmployee();

                    Console.Write("Enter ID: ");
                    ptEmp.Id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    ptEmp.Name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    ptEmp.Department = Console.ReadLine();

                    Console.Write("Enter Hourly Rate: ");
                    ptEmp.HourlyRate = double.Parse(Console.ReadLine());

                    Console.Write("Enter Hours Worked: ");
                    ptEmp.HoursWorked = int.Parse(Console.ReadLine());

                    service.AddEmployee(ptEmp);
                    Console.WriteLine("Part-Time Employee added.");
                    break;

                case "3":
                    Console.WriteLine("\n--- Employee List ---");
                    foreach (var emp in service.GetAllEmployees())
                    {
                        Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.CalculateSalary()}");
                    }
                    break;

                case "4":
                    Console.Write("Enter ID to search: ");
                    int id = int.Parse(Console.ReadLine());
                    var empFound = service.GetEmployeeById(id);
                    if (empFound != null)
                    {
                        Console.WriteLine($"ID: {empFound.Id}, Name: {empFound.Name}, Dept: {empFound.Department}, Salary: {empFound.CalculateSalary()}");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;

class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        int nextId = 1;
        string input;

        while (true)
        {
            Console.WriteLine("\n===== Student Management Menu =====");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Display all students");
            Console.WriteLine("3. Search a student by name");
            Console.WriteLine("4. Remove a student by name");
            Console.WriteLine("5. Count total students");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();
                    students.Add(new Student { ID = nextId++, Name = name });
                    Console.WriteLine("Student added.");
                    break;

                case "2":
                    Console.WriteLine("\nAll Students:");
                    if (students.Count == 0)
                        Console.WriteLine("No students available.");
                    else
                        DisplayStudents(students);
                    break;

                case "3":
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();
                    Student found = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
                    if (found != null)
                        Console.WriteLine($"Found: ID={found.ID}, Name={found.Name}");
                    else
                        Console.WriteLine("Student not found.");
                    break;

                case "4":
                    Console.Write("Enter name to remove: ");
                    string removeName = Console.ReadLine();
                    Student toRemove = students.Find(s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));
                    if (toRemove != null)
                    {
                        students.Remove(toRemove);
                        Console.WriteLine("Student removed.");
                    }
                    else
                        Console.WriteLine("Student not found.");
                    break;

                case "5":
                    Console.WriteLine($"Total number of students: {students.Count}");
                    break;

                case "6":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void DisplayStudents(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
        }
    }
}

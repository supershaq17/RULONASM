
using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> students = new Dictionary<string, Student>();

        while (true)
        {
            Console.WriteLine("\n===== STUDENT LOOKUP SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Student s = new Student();

                    Console.Write("Student Number: ");
                    s.StudentNumber = Console.ReadLine();

                    if (students.ContainsKey(s.StudentNumber))
                    {
                        Console.WriteLine("Student Number already exists.");
                        break;
                    }

                    Console.Write("Name: ");
                    s.Name = Console.ReadLine();

                    Console.Write("Program: ");
                    s.Program = Console.ReadLine();

                    Console.Write("Year Level: ");
                    s.YearLevel = int.Parse(Console.ReadLine());

                    students.Add(s.StudentNumber, s);

                    Console.WriteLine("Student added successfully.");
                    break;

                case 2:
                    Console.Write("Enter Student Number: ");
                    string id = Console.ReadLine();

                    if (students.ContainsKey(id))
                    {
                        Student found = students[id];

                        Console.WriteLine("\nStudent Found");
                        Console.WriteLine($"Student Number: {found.StudentNumber}");
                        Console.WriteLine($"Name: {found.Name}");
                        Console.WriteLine($"Program: {found.Program}");
                        Console.WriteLine($"Year Level: {found.YearLevel}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 3:
                    Console.WriteLine("\n--- Student List ---");

                    if (students.Count == 0)
                    {
                        Console.WriteLine("No students found.");
                    }
                    else
                    {
                        foreach (var item in students)
                        {
                            Student st = item.Value;

                            Console.WriteLine($"{st.StudentNumber} | {st.Name} | {st.Program} | Year {st.YearLevel}");
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
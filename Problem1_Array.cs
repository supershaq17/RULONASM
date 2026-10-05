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
        Student[] students = new Student[10];
        int studentCount = 0;

        Dictionary<string, int> studentIndex = new Dictionary<string, int>();

        while (true)
        {
            Console.WriteLine("\n===== STUDENT RECORD MANAGEMENT =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (studentCount == 10)
                    {
                        Console.WriteLine("Student list is full.");
                        break;
                    }

                    Console.Write("Student Number: ");
                    string number = Console.ReadLine();

                    if (studentIndex.ContainsKey(number))
                    {
                        Console.WriteLine("Student Number already exists.");
                        break;
                    }

                    students[studentCount].StudentNumber = number;

                    Console.Write("Name: ");
                    students[studentCount].Name = Console.ReadLine();

                    Console.Write("Program: ");
                    students[studentCount].Program = Console.ReadLine();

                    Console.Write("Year Level: ");
                    students[studentCount].YearLevel = int.Parse(Console.ReadLine());

                    studentIndex.Add(number, studentCount);

                    studentCount++;

                    Console.WriteLine("Student added successfully.");
                    break;

                case 2:
                    Console.WriteLine("\n--- Student List ---");

                    if (studentCount == 0)
                    {
                        Console.WriteLine("No students found.");
                    }
                    else
                    {
                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.WriteLine($"{students[i].StudentNumber} | {students[i].Name} | {students[i].Program} | Year {students[i].YearLevel}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Student Number: ");
                    string search = Console.ReadLine();

                    if (studentIndex.ContainsKey(search))
                    {
                        int index = studentIndex[search];

                        Console.WriteLine("\nStudent Found");
                        Console.WriteLine($"Student Number: {students[index].StudentNumber}");
                        Console.WriteLine($"Name: {students[index].Name}");
                        Console.WriteLine($"Program: {students[index].Program}");
                        Console.WriteLine($"Year Level: {students[index].YearLevel}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Student Number to update: ");
                    string update = Console.ReadLine();

                    if (studentIndex.ContainsKey(update))
                    {
                        int index = studentIndex[update];

                        Console.Write("New Name: ");
                        students[index].Name = Console.ReadLine();

                        Console.Write("New Program: ");
                        students[index].Program = Console.ReadLine();

                        Console.Write("New Year Level: ");
                        students[index].YearLevel = int.Parse(Console.ReadLine());

                        Console.WriteLine("Student updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 5:
                    Console.Write("Enter Student Number to delete: ");
                    string delete = Console.ReadLine();

                    if (studentIndex.ContainsKey(delete))
                    {
                        int index = studentIndex[delete];

                        for (int i = index; i < studentCount - 1; i++)
                        {
                            students[i] = students[i + 1];
                        }

                        studentCount--;

                        studentIndex.Clear();

                        for (int i = 0; i < studentCount; i++)
                        {
                            studentIndex.Add(students[i].StudentNumber, i);
                        }

                        Console.WriteLine("Student deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
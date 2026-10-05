using System;
using System.Collections.Generic;

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
    static void Main()
    {
        Stack<Operation> operationHistory = new Stack<Operation>();

        while (true)
        {
            Console.WriteLine("\n===== OPERATION HISTORY =====");
            Console.WriteLine("1. Add Operation");
            Console.WriteLine("2. View All History");
            Console.WriteLine("3. View Last Operation");
            Console.WriteLine("4. Remove Last Operation");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Operation op = new Operation();

                    Console.Write("Action (Added/Updated/Deleted): ");
                    op.Action = Console.ReadLine();

                    Console.Write("Student Number: ");
                    op.StudentNumber = Console.ReadLine();

                    Console.Write("Student Name: ");
                    op.StudentName = Console.ReadLine();

                    operationHistory.Push(op);

                    Console.WriteLine("Operation saved successfully.");
                    break;

                case 2:
                    Console.WriteLine("\n--- Operation History ---");

                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No history available.");
                    }
                    else
                    {
                        foreach (Operation item in operationHistory)
                        {
                            Console.WriteLine($"{item.Action} | {item.StudentNumber} | {item.StudentName}");
                        }
                    }
                    break;

                case 3:
                    if (operationHistory.Count > 0)
                    {
                        Operation last = operationHistory.Peek();

                        Console.WriteLine("\nLast Operation");
                        Console.WriteLine($"Action: {last.Action}");
                        Console.WriteLine($"Student Number: {last.StudentNumber}");
                        Console.WriteLine($"Student Name: {last.StudentName}");
                    }
                    else
                    {
                        Console.WriteLine("No history available.");
                    }
                    break;

                case 4:
                    if (operationHistory.Count > 0)
                    {
                        Operation removed = operationHistory.Pop();

                        Console.WriteLine($"\nRemoved: {removed.Action} | {removed.StudentName}");
                    }
                    else
                    {
                        Console.WriteLine("No history available.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
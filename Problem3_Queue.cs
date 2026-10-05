using System;
using System.Collections.Generic;

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

class Program
{
    static void Main()
    {
        Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

        while (true)
        {
            Console.WriteLine("\n===== STUDENT REQUEST QUEUE =====");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Next Request");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    StudentRequest request = new StudentRequest();

                    Console.Write("Student Number: ");
                    request.StudentNumber = Console.ReadLine();

                    Console.Write("Student Name: ");
                    request.StudentName = Console.ReadLine();

                    Console.Write("Request Type: ");
                    request.RequestType = Console.ReadLine();

                    requestQueue.Enqueue(request);

                    Console.WriteLine("Request added successfully.");
                    break;

                case 2:
                    Console.WriteLine("\n--- Pending Requests ---");

                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("No pending requests.");
                    }
                    else
                    {
                        foreach (StudentRequest req in requestQueue)
                        {
                            Console.WriteLine($"{req.StudentNumber} | {req.StudentName} | {req.RequestType}");
                        }
                    }
                    break;

                case 3:
                    if (requestQueue.Count > 0)
                    {
                        StudentRequest processed = requestQueue.Dequeue();

                        Console.WriteLine("\nProcessing Request");
                        Console.WriteLine($"Student Number: {processed.StudentNumber}");
                        Console.WriteLine($"Student Name: {processed.StudentName}");
                        Console.WriteLine($"Request Type: {processed.RequestType}");
                    }
                    else
                    {
                        Console.WriteLine("No pending requests.");
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
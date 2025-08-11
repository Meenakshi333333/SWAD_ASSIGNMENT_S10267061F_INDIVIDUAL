// See https://aka.ms/new-console-template for more information
// Student Name: Senthilnathan Meenakshi
// Student ID: S10267061F
// Use Case ID: UC05 - Indicate Operational Issues

using System;
using System.Collections.Generic;

class Program
{
    // Simulated database
    static List<FoodStallStaff> Staffs = new List<FoodStallStaff>();
    static List<PlatformOperator> Operators = new List<PlatformOperator>();
    static List<ReportedIssue> Issues = new List<ReportedIssue>();
    static Dictionary<int, List<string>> AffectedStudentsByItem = new Dictionary<int, List<string>>();

    static void Main()
    {
        SeedData();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=== Food Stall Operational Issue Reporting ===");
            Console.WriteLine("1. Report Operational Issue");
            Console.WriteLine("2. Exit");
            Console.Write("Select option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReportOperationalIssue();
                    break;
                case "2":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void SeedData()
    {
        // Staffs
        Staffs.Add(new FoodStallStaff(101, "Cashier", 5));
        Staffs.Add(new FoodStallStaff(102, "Chef", 5));

        // Operators
        Operators.Add(new PlatformOperator(201));
        Operators.Add(new PlatformOperator(202));

        // Affected students who bookmarked itemID 10 (e.g. Chicken rice)
        AffectedStudentsByItem[10] = new List<string> { "student001", "student002" };
    }

    static void ReportOperationalIssue()
    {
        Console.WriteLine("\n-- Staff Login --");
        Console.Write("Enter Staff ID: ");
        if (!int.TryParse(Console.ReadLine(), out int staffId))
        {
            Console.WriteLine("Invalid Staff ID.");
            return;
        }

        FoodStallStaff staff = Staffs.Find(s => s.StaffID == staffId);
        if (staff == null)
        {
            Console.WriteLine("Staff not found.");
            return;
        }
        Console.WriteLine($"Welcome, Staff {staff.StaffID}, Role: {staff.Role}");

        Console.WriteLine("\n-- Report Issue --");
        Console.WriteLine("Select Issue Type:");
        Console.WriteLine("1. Item Unavailable");
        Console.WriteLine("2. Equipment Fault");
        Console.WriteLine("3. Other");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine();

        string issueType = typeChoice switch
        {
            "1" => "Item Unavailable",
            "2" => "Equipment Fault",
            "3" => "Other",
            _ => null
        };

        if (issueType == null)
        {
            Console.WriteLine("Invalid issue type selected.");
            return;
        }

        Console.Write("Enter Issue Details: ");
        string issueDetails = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(issueDetails))
        {
            Console.WriteLine("Issue details cannot be empty.");
            return;
        }

        // Simulate logging the issue
        int newIssueId = Issues.Count + 1;
        Issues.Add(new ReportedIssue
        {
            IssueID = newIssueId,
            StaffID = staff.StaffID,
            StallID = staff.StallID,
            IssueType = issueType,
            Details = issueDetails,
            Timestamp = DateTime.Now
        });

        Console.WriteLine($"Issue logged successfully with ID: {newIssueId}");

        // Notify Platform Operators
        foreach (var op in Operators)
        {
            Console.WriteLine($"Notification sent to Platform Operator #{op.OperatorID}");
        }

        // Notify affected students if issue type is Item Unavailable and matches itemID 10 for demo
        if (issueType == "Item Unavailable")
        {
            if (AffectedStudentsByItem.TryGetValue(10, out List<string> students) && students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"Notification sent to student {student}");
                }
            }
            else
            {
                Console.WriteLine("No affected students found. Only notifying platform operators.");
            }
        }

        // Confirmation message to staff
        Console.WriteLine("Confirmation: Issue report submitted and notifications sent.\n");
    }
}

// Supporting classes
public class FoodStallStaff
{
    public int StaffID { get; set; }
    public string Role { get; set; }
    public int StallID { get; set; }

    public FoodStallStaff(int staffID, string role, int stallID)
    {
        StaffID = staffID;
        Role = role;
        StallID = stallID;
    }
}

public class PlatformOperator
{
    public int OperatorID { get; set; }
    public PlatformOperator(int operatorID)
    {
        OperatorID = operatorID;
    }
}

public class ReportedIssue
{
    public int IssueID { get; set; }
    public int StaffID { get; set; }
    public int StallID { get; set; }
    public string IssueType { get; set; }
    public string Details { get; set; }
    public DateTime Timestamp { get; set; }
}


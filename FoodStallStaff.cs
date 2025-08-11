using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSIGNMENT
{
    class FoodStallStaff
    {
        // Attributes
        public int StaffID { get; set; }
        public string Role { get; set; }
        public int StallID { get; set; }

        // Constructor
        public FoodStallStaff(int staffID, string role, int stallID)
        {
            StaffID = staffID;
            Role = role;
            StallID = stallID;
        }

        // Method to display staff info
        public void DisplayStaffInfo()
        {
            Console.WriteLine($"Staff ID: {StaffID}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Stall ID: {StallID}");
        }
    }
}

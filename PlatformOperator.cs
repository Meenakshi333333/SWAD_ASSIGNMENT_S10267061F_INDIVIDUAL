using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_ASSIGNMENT
{
    public class PlatformOperator
    {
        // Attributes
        public int OperatorID { get; set; }

        // Constructor
        public PlatformOperator(int operatorID)
        {
            OperatorID = operatorID;
        }

        // Method to display operator info
        public void DisplayOperatorInfo()
        {
            Console.WriteLine($"Operator ID: {OperatorID}");
        }
    }
}

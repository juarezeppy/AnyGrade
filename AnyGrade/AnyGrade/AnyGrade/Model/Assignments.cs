using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyGrade.Model
{
    public class Assignments
    {
        public string AssignmentName { get; set; }
        public string AssignmentGrade { get; set; }

        public Assignments()
        {
            AssignmentName = "New Assignment Added";
            AssignmentGrade = "0.00";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyGrade
{
    public class Course
    {
        public string Name { get; set; }

        public List<double> Assignments;

        public Course()
        {
            Name = "New Course";

            //add a test assignment grade
            Assignments = new List<double>
            {
                5.0
            };
        }

    }
}

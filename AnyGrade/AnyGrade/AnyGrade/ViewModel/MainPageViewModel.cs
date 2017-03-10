using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyGrade.ViewModel
{
    public class MainPageViewModel
    {
        //this constructor takes a class object 
        //and then initializes its own member variable with it

        //public MainPageViewModel(Course course)
        //{
        //    courseName = course.name;
        //}
//        public string courseName { get; set; }

        public List<Course> Courses {
            get {
                return new List<Course>() {
                    new Course() {name = "ICS 6D" },
                    new Course() {name = "CS 122A"},
                    new Course() {name = "ICS 139W"}
                };
            }
        }


        /*
         * This method creates and returns a course object
         * 
         * var course allocates memory for the object then initializes
         * member variable
         */
        public static Course GetCourse()
        {
            var course = new Course()
            {
                name = "COMP SCI"
            };

            return course;                  
        }

    }
}

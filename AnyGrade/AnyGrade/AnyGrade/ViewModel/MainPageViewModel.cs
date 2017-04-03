using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using AnyGrade.Model;

namespace AnyGrade.ViewModel
{
    class MainPageViewModel
    {
        //A list of course objects which holds course data, etc.
        public ObservableCollection<Course> Courses;

        //This is now bound to the view's listview
        public ObservableCollection<Course> GetCourseList
        {
            get
            {
                return Courses;
            }
        }

        //no arg constructor
        public MainPageViewModel()
        {
            Courses = new ObservableCollection<Course>();
        }

        public void AddCourse()
        {
            Course NewCourse = new Course();
            Courses.Add(NewCourse);
        }

        internal void RemoveCourse(Course SelectedCourse)
        {

            Courses.Remove(SelectedCourse);
        }

        public void CalculateTotalTopicWeights()
        {
            
        }
    }
}

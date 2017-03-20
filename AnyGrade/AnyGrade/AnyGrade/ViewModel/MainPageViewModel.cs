using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace AnyGrade.ViewModel
{
    class MainPageViewModel
    {
        public string Name { get; set; }

        public ObservableCollection<Course> Courses;

        //add observablecollection of assignments

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
    }
}

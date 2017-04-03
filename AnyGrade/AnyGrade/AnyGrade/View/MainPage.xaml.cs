using AnyGrade.View;
using AnyGrade.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnyGrade
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm;                //create a vm object so the view can grab its data
        private int index;

        public MainPage()
        {
            vm = new MainPageViewModel();            //initialize the vm object by using its constructor to get course object info
            BindingContext = vm;
            index = 0;

            InitializeComponent();
        }


        private async void CourseList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            //sets and creates a coursedetail page to naviagate to while passing the object
            var selectedCourse = e.SelectedItem as Course;
            
            //this line deselects the course from the chosen list
            CourseList.SelectedItem = null;

            await Navigation.PushAsync(new CourseDetail(selectedCourse));
        }

        private void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }

        private async void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            //var response = await DisplayAlert("Warning", "Are you sure you want to remove this course?", "Yes", "No");
            var response = await DisplayActionSheet("Course ToolBar", "Cancel", "Delete", "Rename");
            
            if (response == "Delete")
            {
                var course = (sender as Button).CommandParameter as Course;
                vm.RemoveCourse(course);
            }
            else if (response == "Rename")
            {
                var course = (sender as Button).CommandParameter as Course;


                GridLayout.IsVisible = false;
                renameCourse.IsVisible = true;

                index = vm.Courses.IndexOf(course);
            }
        }

        private void Add_Course(object sender, EventArgs e)
        {
            vm.AddCourse();
            Debug.WriteLine(vm.Courses[0].CourseName);
        }

        private void RenameCourse_OnCompleted(object sender, EventArgs e)
        {
            vm.Courses[index].CourseName = renameCourse.Text;
            renameCourse.Text = "";

            GridLayout.IsVisible = true;
            renameCourse.IsVisible = false;

            CourseList.ItemsSource = null;
            CourseList.ItemsSource = vm.GetCourseList;
        }
    }



}

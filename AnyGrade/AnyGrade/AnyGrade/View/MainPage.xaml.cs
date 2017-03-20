using AnyGrade.View;
using AnyGrade.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnyGrade
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;                               //create a vm object so the view can grab its data

        public MainPage()
        {
            vm = new MainPageViewModel();                  //initialize the vm object by using its constructor to get course object info

            BindingContext = vm;

            InitializeComponent();
        }


        async private void CourseList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedCourse = e.SelectedItem as Course;
            await Navigation.PushAsync(new CourseDetail(selectedCourse));

            //this line deselects the course from the chosen list
            CourseList.SelectedItem = null;
        }

        private void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        async private void DeleteCourse_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure you want to remove this course?", "Yes", "No");

            if (response)
            {
                var course = (sender as Button).CommandParameter as Course;

                vm.RemoveCourse(course);
            }
        }

        private void Add_Course(object sender, EventArgs e)
        {
            vm.AddCourse();
        }
    }



}

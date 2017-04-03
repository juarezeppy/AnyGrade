using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyGrade.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TextChangedEventArgs = Android.Text.TextChangedEventArgs;

namespace AnyGrade.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetail : ContentPage
    {
        public Course course;
        private int index;

        //This constructor now accepts a course
        public CourseDetail(Course courseSelected)
        {
            if (courseSelected == null)
                throw new ArgumentException();

            index = 0;
            course = courseSelected;

            //bind the page to the dictionary
            BindingContext = courseSelected;
            InitializeComponent();

            CourseList.ItemsSource = null;
            CourseList.ItemsSource = course.GetTopicList;
        }

        private void CourseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }

        //this needs to navigate to a assignment list page
        async public void CourseList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var topic = e.SelectedItem as Topics;
            await Navigation.PushAsync(new AssignmentDetail(ref topic));

            CourseList.SelectedItem = null;
        }

        private void Add_Topic(object sender, EventArgs e)
        {
            course.TopicList.Add(new Topics());
        }

        private async Task DeleteTopic_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Topic ToolBar", "Cancel", "Delete", "Rename");

            if (response == "Delete")
            {
                var selectedTopic = (sender as Button).CommandParameter as Topics;
                course.RemoveTopic(selectedTopic);
            }
            else if (response == "Rename")
            {
                var selectedTopic = (sender as Button).CommandParameter as Topics;


                GridLayout.IsVisible = false;
                renameTopic.IsVisible = true;

                index = course.TopicList.IndexOf(selectedTopic);
            }
        }


        private async void Calculate_Grade_Clicked(object sender, EventArgs e)
        {
            double total = course.CalculateTopicTotals();

            if (total != 100)
            {
                var response = await DisplayAlert("Error", "Total % Must Be Equal to 100 To Calculate Grade! ", "Ok", " ");
                return;
            }

            course.CourseGrade = course.CalculateGrade();

            CourseList.ItemsSource = null;
            CourseList.ItemsSource = course.GetTopicList;

            //need a way to refresh this 
            CourseGrade_Label.BindingContext = null;
            CourseGrade_Label.BindingContext = course.CourseGrade;
        }

        
        //this function may not be needed because of xaml binding to object member
        private void AssignmentWeight_OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string test = e.NewTextValue;
            Debug.WriteLine(test);
        }

        private void RenameCourse_OnCompleted(object sender, EventArgs e)
        {
            course.TopicList[index].topicName = renameTopic.Text;
            renameTopic.Text = "";

            GridLayout.IsVisible = true;
            renameTopic.IsVisible = false;

            CourseList.ItemsSource = null;
            CourseList.ItemsSource = course.GetTopicList;
        }
    }
}

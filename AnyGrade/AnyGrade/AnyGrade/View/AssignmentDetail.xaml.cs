using AnyGrade.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnyGrade.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignmentDetail : ContentPage
    {
        private Topics pageTopic;
        private int index;
        public AssignmentDetail(ref Topics Assignments)
        {
            if (Assignments == null)
                throw new ArgumentException();

            index = 0;
            pageTopic = Assignments;

            //bind the page to the dictionary
            BindingContext = Assignments;

            InitializeComponent();
            AssignmentsPageHeader.Text = Assignments.topicName + " Assignment List";

            //this binds the list view to the dictionary
            AssignmentList.ItemsSource = Assignments.AssignmentlisList;
        }

        private void Button_AddAssignment(object sender, EventArgs e)
        {
            pageTopic.AssignmentlisList.Add(new Assignments());
        }

        private async void Button_AssignmentOptions(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Assignment ToolBar", "Cancel", "Delete", "Rename");

            if (response == "Delete")
            {
                var selectedAssignment = (sender as Button).CommandParameter as Assignments;
                pageTopic.RemoveAssignment(selectedAssignment);
            }
            else if (response == "Rename")
            {
                var selectedAssignment = (sender as Button).CommandParameter as Assignments;


                GridLayout.IsVisible = false;
                RenameAssignment.IsVisible = true;

                index = pageTopic.AssignmentlisList.IndexOf(selectedAssignment);
            }
        }

        private void RenameAssignment_OnCompleted(object sender, EventArgs e)
        {
            pageTopic.AssignmentlisList[index].AssignmentName = RenameAssignment.Text;
            RenameAssignment.Text = "";

            GridLayout.IsVisible = true;
            RenameAssignment.IsVisible = false;

            AssignmentList.ItemsSource = null;
            AssignmentList.ItemsSource = pageTopic.GetAssignmentList;

        }

        private void AssignmentGradeEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string test = e.NewTextValue;
            //Debug.WriteLine(test);
            
            Debug.WriteLine(pageTopic.average);
            if (e.NewTextValue.Length > 0)
            {
                pageTopic.average = pageTopic.CalculateAverage();
            }
            Debug.WriteLine("pageTopic average is now: " + pageTopic.average);
        }

        private void AssignmentList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            AssignmentList.SelectedItem = null;
        }

        private void AssignmentList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }
}

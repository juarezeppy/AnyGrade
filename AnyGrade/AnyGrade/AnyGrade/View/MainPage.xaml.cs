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

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var crse = e.Item as Course;
            DisplayAlert("Selection made", "You tapped on " + crse.name, "OK");
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnyGrade.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetail : ContentPage
    {
        //This constructor now accepts a course
        public CourseDetail(Course course)
        {
            if (course == null)
                throw new ArgumentException();

            BindingContext = course;

            InitializeComponent();
        }
    }
}

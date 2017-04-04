using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyGrade.Model
{
    public class Topics
    {
        public string topicName { get; set; }
        public string topicWeight { get;set;}
        public string average { get; set;}

        public ObservableCollection<Assignments> AssignmentlisList;

        public Topics()
        {
            topicName = "New Topic Added";
            topicWeight = "0.00";
            average = "0.00";

            AssignmentlisList = new ObservableCollection<Assignments>()
            {
            };
        }

        //returns a list of topics for the course object
        public ObservableCollection<Assignments> GetAssignmentList
        {
            get
            {
                return AssignmentlisList;
            }
        }

        public void RemoveAssignment(Assignments SelectedAssignment)
        {

            AssignmentlisList.Remove(SelectedAssignment);
        }

        public string CalculateAverage()
        {
            if (AssignmentlisList.Count == 0)
            {
                return "empty list";
            }

            //get total possible points
            double totalPossiblePoints = AssignmentlisList.Count * 100;
            Debug.WriteLine(totalPossiblePoints);
            double earnedPoints = 0;

            foreach (var VARIABLE in AssignmentlisList)
            {
                earnedPoints += Convert.ToDouble(VARIABLE.AssignmentGrade);
            }

            average = (earnedPoints / totalPossiblePoints).ToString("F");

            Debug.WriteLine("Average is now: " + average);

            return average;
        }
    }
}

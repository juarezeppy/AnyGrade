using AnyGrade.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyGrade
{
    public class Course
    {
        //course name holds and displays the name of the course
        public string CourseName { get; set; }

        public string CourseGrade { get; set; }

        public string GradePercentage { get; set; }

        //topic list holds a nested list that has the topic names, and assignment grades for each topic
        public ObservableCollection<Topics> TopicList;

        public Course()
        {
            CourseName = "New Course";
            TopicList = new ObservableCollection<Topics>();
        }

        //returns a list of topics for the course object
        public ObservableCollection<Topics> GetTopicList
        {
            get
            {
                return TopicList;
            }
        }
        public void RemoveTopic(Topics SelectedTopic)
        {

            TopicList.Remove(SelectedTopic);
        }

        public double CalculateTopicTotals()
        {
            double total = 0.00;
            int numTopics = TopicList.Count();

            foreach (var VARIABLE in TopicList)
            {
                Debug.WriteLine(VARIABLE.topicWeight);
                Debug.WriteLine(total);

                total += Convert.ToDouble(VARIABLE.topicWeight);
            }
            return total;
        }

        public string CalculateGrade()
        {
            double totalPoints = 0;
            double sums = 0;

            if (TopicList.Count == 0)
            {
                return "empty list";
            }

            //calculate sums of all percentages earned in every topic

            foreach (var VARIABLE in TopicList)
            {
                totalPoints = Convert.ToDouble(VARIABLE.average) * Convert.ToDouble(VARIABLE.topicWeight);
                sums += totalPoints;
                totalPoints = 0;
            }

            Debug.WriteLine("Sum of Points IS: " + sums);

            GradePercentage = sums.ToString();

            if (sums >= 90)
            {
                return "A";
            }
            else if (sums >= 80 && sums < 90)
            {
                return "B";
            }
            else if (sums >= 70 && sums < 80)
            {
                return "C";
            }
            else
            {
                return "Fail";
            }
        }

    }
}

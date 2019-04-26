using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestWPF
{
    class Course
    {
        private string courseName;
        private int courseNumber;
        private int creditHours;
        private double gpa;
        private string student;
        private int studentID;
        private static int high = 4;
        private static int low = 0;
        private static string levelCheck = "Undergraduate";//Testing variable used to check the input from the ComboBox


        public Course()
        {
        }
        public Course(string student, int id)
        {
            StudentID = id;
            Student = student;
        }
        public Course(string CourseName, int CourseNumber, int CreditHours, double Gpa, string student, int id)
        {
            courseName = CourseName;
            courseNumber = CourseNumber;
            creditHours = CreditHours;
            gpa = Gpa;
            Student = student;
            StudentID = id;

        }
        public string LevelCheck
        {
            get
            {
                return levelCheck;
            }
            
        }
        public int High
        {
            get
            {
                return high;
            }
        }
        public int Low
        {
            get
            {
                return low;
            }
        }
        public string Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
            }
        }

        public string CourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }
        public int CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                courseNumber = value;
            }
        }
        public int StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }
        public int CreditHours
        {
            get
            {
                return creditHours;
            }
            set
            {
                creditHours = value;
            }
        }
        public double GPA
        {
            get
            {
                return gpa;
            }
            set
            {
                gpa = value;
            }
        }

        
        public bool Check(string courseName, int courseNumber, int credHours, double gpa, string level)
        {
                string CName = courseName;
                int CNumber = courseNumber;
                int CredHours = credHours;
                double Gpa = gpa;
            
           
            if (gpa < Low || gpa > High)
            {
                MessageBox.Show("Gpa out of range, 0.0-4.0 scale");
                return false;
            }
            if(CNumber <= 4999 && CNumber >= 1000 && level == LevelCheck)
            {
                return true;
            }
            else if(CNumber <= 9999 && CNumber >= 5000 && level != LevelCheck)
            {
                return true;
            }
            else if (CNumber <= 9999 && CNumber >= 5000 && level == LevelCheck)
            {
                MessageBox.Show("Graduate Student courses cannot be taken by undergraduates");
                return false;
            }//if course number is in grad range but level is undergraduate
            else if (CNumber <= 4999 && CNumber >= 1000 && level != LevelCheck)
            {
                MessageBox.Show("Undergraduate courses cannot be taken by undergraduates");
                return false;
            }//if course number is in undergrad range but level is grad
            else
            {
                MessageBox.Show("Please verify your school status and course level\n" + "    -Undegraduate courses are 1000-4999 and may only be taken by Undergraduates\n" + "    -Graduate courses are 5000-9999 and may only be taken by graduate students\n" + "    -Courses must be 4 digit whole numbers");
                return false;
            }//any input errors, out of range and such
            
        }
    }
}


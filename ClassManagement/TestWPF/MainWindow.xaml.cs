using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;//counter for Addstudent
        UndergraduateStudent[] storage = new UndergraduateStudent[1000];//lots of room for lots of students

        int j = 0;//counter for addCourse
        Course[] courseStorage = new Course[5000];//assume each student has 5 classes

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            UndergraduateStudent test = new UndergraduateStudent();
         
            try //test if in correct format if not cancel action by return
            {
                test.Confirm(FirstNameTextBox.Text, LastNameTextBox.Text, Convert.ToInt32(StudentIDTextBox.Text), comboBox.Text, levelBox.Text, Convert.ToInt32(AgeTextBox.Text));
                
            }
            catch (OverflowException)
            {
                MessageBox.Show("ID or age to large please try again");
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("   Input was not in proper format\n" + "\t- All fields are required");
                return;
            }
            //if no exception fill usuable variables
                string fName = FirstNameTextBox.Text;
                string lName = LastNameTextBox.Text;
                int id = Convert.ToInt32(StudentIDTextBox.Text);
                string gender = comboBox.Text;
                string level = levelBox.Text;
                int age = Convert.ToInt32(AgeTextBox.Text);
                string nameTest = lName + fName ;
                string name = fName + " " + lName;
            try
            {
                while (storage != null)
                {
                    for (int counter = 0; counter < storage.Length; counter++)
                    {
                        string checkName = storage[counter].LastName + storage[counter].FirstName;
                        int checkID = storage[counter].ID;
                        if (!test.StudentCheck(nameTest, checkName, id, checkID))
                        {
                            MessageBox.Show(nameTest + "\n" + checkName + "\n" + Convert.ToString(id) + "\n" + Convert.ToString(checkID));
                            return;
                        }
                    }
                    continue;
                }
            }
            catch (NullReferenceException)
            {
               //do nothing, storage array is empty and nothing to compare it to 
            }
                if (levelBox.Text == test.Check)//if student will be undergraduate then make one and put into array for later use
                {
                    UndergraduateStudent student = new UndergraduateStudent(fName, lName, gender, age, id, level);
                    storage[i] = student;
                    MessageBox.Show(name + " Added to storage " + "\n");
                    
                }
                else//else must be grad student, create one, put into storage
                {
                    GraduateStudent gStudent = new GraduateStudent(fName, lName, gender, age, id, level);
                    storage[i] = gStudent;
                    MessageBox.Show(name + " Added to storage " + "\n" );
                }
                
                //populate list box with relevant info
                ListBoxItem studentListBoxItem = new ListBoxItem();
                studentListBoxItem.Content = storage[i].LastName + " " + storage[i].FirstName + "\n" + storage[i].ID + "\n" + storage[i].Gender + " " + storage[i].Age + "\n" + storage[i].lvl;
                StudentsListBox.Items.Add(studentListBoxItem);
                
                //clear text boxes for ease of use and bump i for next use
                FirstNameTextBox.Text = null;
                LastNameTextBox.Text = null;
                StudentIDTextBox.Text = null;
                AgeTextBox.Text = null;
                comboBox.SelectedIndex = 0;
                levelBox.SelectedIndex = 0;

                i++;
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            UndergraduateStudent test = new UndergraduateStudent();
            Course courseTest = new Course();
            ListBoxItem selected = new ListBoxItem();
            string[] content = null;
            string stuff = null;
            selected.Content = StudentsListBox.SelectedItem;
            stuff = Convert.ToString(selected.Content);
            content = stuff.Split();
            string level;
            try
            {
                int idTest = Convert.ToInt32(content[3]);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Please Select a Student");
                return;
            }
            int id = Convert.ToInt32(content[3]);
            if (selected.Content != null)
            {

                try
                {
                    if (!courseTest.Check(CourseNameTextBox.Text, Convert.ToInt32(CourseNumberTextBox.Text), Convert.ToInt32(CreditHoursTextBox.Text), Convert.ToDouble(GPATextBox.Text), level = content[6]))
                    {
                        return;
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Input in improper format");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a student");
                return;
            }
          
            string name = content[2] + " " + content[1]; 
            string cName = CourseNameTextBox.Text;
            int cNumber = Convert.ToInt32(CourseNumberTextBox.Text);
            int credHours = Convert.ToInt32(CreditHoursTextBox.Text);
            double gpa = Convert.ToDouble(GPATextBox.Text);

            Course course = new Course(cName, cNumber, credHours, gpa, name, id);
            courseStorage[j] = course;
            MessageBox.Show("Course Added to " + name + "'s Courses" + "\n");

            if (true)
            {
                j++;
                CourseNumberTextBox.Text = null;//clear text boxes for next entry
                CourseNameTextBox.Text = null;
                GPATextBox.Text = null;
                CreditHoursTextBox.Text = null;
                return;
            }//always true will trigger if reach this point, cleanup method while debugging code
        }

             

        private void StudentsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CoursessListBox.Items.Clear();
            string[] content = null;
            string stuff = null;

            ListBoxItem selected = new ListBoxItem();
            selected.Content = StudentsListBox.SelectedItem;
            stuff = Convert.ToString(selected.Content);
            content = stuff.Split();
            double fGpa = 0.0, gpa = 0.0;
            int tHours = 0;



            if (selected.Content == null) //if nothing is selected, Load nothing
            {
                MessageBox.Show("Please select a student to use the load feature");
                return;
            }
            else
            {
                for (int counter = 0; counter < storage.Length; counter++)
                {

                    string checkName = content[1] + content[2];
                    int id = Convert.ToInt32(content[3]);

                    while (storage[counter].LastName + storage[counter].FirstName == checkName)
                    {
                        LastNameTextBox.Text = storage[counter].LastName;
                        FirstNameTextBox.Text = storage[counter].FirstName;
                        StudentIDTextBox.Text = Convert.ToString(storage[counter].ID);
                        AgeTextBox.Text = Convert.ToString(storage[counter].Age);
                        if (storage[counter].Gender == "Male")
                        {
                            comboBox.SelectedIndex = 0;
                        }
                        else if (storage[counter].Gender == "Female")
                        {
                            comboBox.SelectedIndex = 1;
                        }
                        else
                        {
                            comboBox.SelectedIndex = 2;
                        }
                        if (storage[counter].lvl == "Undergraduate")
                        {
                            levelBox.SelectedIndex = 0;
                        }
                        else
                        {
                            levelBox.SelectedIndex = 1;
                        }
                        //comboBox.Text = content[5]; /*Find way to load in strings to fill comboBoxes*/
                        //levelBox.Text = content[];
                        Course tester = new Course(storage[counter].FirstName + " " + storage[counter].LastName, id);
                        for (int k = 0; k < j; k++)
                        {
                            if (courseStorage[k] == null)
                            {
                                MessageBox.Show("lets gtfo of here");
                                return;
                            }
                            else if (courseStorage[k].Student == tester.Student && courseStorage[k].StudentID == tester.StudentID)//now can hav multiple students with same name yet all ID #s are unique
                            {
                                tHours += courseStorage[k].CreditHours;
                                gpa += (courseStorage[k].GPA * courseStorage[k].CreditHours);
                                ListBoxItem courseListBoxItem = new ListBoxItem();
                                courseListBoxItem.Content = courseStorage[k].CourseName + " - " + courseStorage[k].CourseNumber + "\n" + courseStorage[k].CreditHours + " hrs- " + courseStorage[k].GPA + "\n";
                                CoursessListBox.Items.Add(courseListBoxItem);

                            }
                        }

                        TotalGPATextBox.Text = Convert.ToString(Math.Round(fGpa = gpa / tHours, 2));
                        return;//in the while but outside the for should take me back to a usuable state

                    }
                }
            }
        }

        private void CoursessListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string[] content = null;
            string stuff = null;
            ListBoxItem selected = new ListBoxItem();
            selected.Content = CoursessListBox.SelectedItem;
            stuff = Convert.ToString(selected.Content);
            content = stuff.Split();

            for (int i = 0; i < content.Length; i++)
            {
                CourseNameTextBox.Text = content[1];
                CourseNumberTextBox.Text = content[3];
                CreditHoursTextBox.Text = content[4];
                GPATextBox.Text = content[6];
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

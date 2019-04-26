using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF
{
    class UndergraduateStudent : Person
    {
        private int iD;
        private string Level;
        private static string check = "Undergraduate";//Testing variable used to check the input from the ComboBox

        public UndergraduateStudent() : base()//empty constructor to use for calling test methods and to not send information when its not needing to be sent
        {
        }
         
        public UndergraduateStudent(string fName, string lName, string gen, int Age, int Id, string level) : base(fName, lName, gen, Age)
        {
            iD = Id;
            lvl = level;
        }
        
        public string lvl
        {
            get
            {
                return Level;
            }
            set
            {
                Level = value;
            }
        }
        public int ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
            }
        }
        public string Check
        {
            get
            {
                return check;
            }
        }
        public bool Confirm(string firstName, string lastName, int id, string gender, string level, int age)
        {
            
                string fName = firstName;
                string lName = lastName;
                string gen = gender;
                string lvl = level;
                int ID = id;
                int AGE = age;
            
            return true;
        }
        public bool StudentCheck(string name, string checkName, int id, int checkID)
        {
            if(name == checkName && id == checkID)
            {
                MessageBox.Show("Student already exists");
                return false;
            }
            if (id == checkID)
            {
                MessageBox.Show("That Id number is already in use");
                return false;
            }
            return true;
        }
    }
}

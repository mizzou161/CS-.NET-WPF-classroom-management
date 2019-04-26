using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    abstract class Person
    {
        /// <summary>
        /// 0 for male
        /// 1 for female
        /// 2 for other
        /// </summary>
        private string firstName;
        private string lastName;
        private string gender;
        private int age;
        public Person()
        {
        }
       
        public Person(string fName, string lName, string gen, int age)
        {
            FirstName = fName;
            LastName = lName;
            Gender = gen;
            Age = age;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class GraduateStudent : UndergraduateStudent
    {
        
        public GraduateStudent():base()
        {
        }
        public GraduateStudent(string fName, string lName, string gen, int Age, int Id, string level) : base(fName, lName, gen, Age, Id, level)
        {
            return;
        }
    }
}

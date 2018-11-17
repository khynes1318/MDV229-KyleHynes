using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Classes
    {
        private string _className;
        private double _grade;
        private List<Classes> _classes = new List<Classes>();

        public List<Classes> GetClass
        {
            get { return _classes; }
        }

        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        public double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public Classes (string classname, double grades)
        {
            _className = classname;
            _grade = grades;
        }
    }
}

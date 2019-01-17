using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public class ExtramuralStudent : Student
    {
        public ExtramuralStudent()
        {
        }

        public ExtramuralStudent(string name, string faculty, int course) : base(name, faculty, course, Student.Department.Extramural)
        {
        }

        public override bool Equals(object obj)
        {
            var extramuralStudent = obj as ExtramuralStudent;
            return extramuralStudent != null && base.Equals(obj);
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => base.ToString();

        public override String GetInformation() => "Extramural Student: { " + "Name = " + Name
            + ", Faculty = " + Faculty + ", Course = " + Course + " }";
    }
}

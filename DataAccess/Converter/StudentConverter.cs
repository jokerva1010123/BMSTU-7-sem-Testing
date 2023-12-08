using Models;
using DBModels;

namespace Converter
{
    public class StudentConverter
    {
        public static Student? DBtoBL(StudentModel? student)
        {
            if (student == null) return null;
            return new Student(student.Id_student, student.Name, student.GroupStudent, student.StudentCode, student.Id_room, DateTime.Parse(student.Date), student.Id_user);
        }
        public static StudentModel? BLtoDB(Student? student)
        {
            if (student == null) return null;
            return new StudentModel
            {
                Id_student = student.Id_student,
                Name = student.Name,
                GroupStudent = student.Group,
                StudentCode = student.StudentCode,
                Id_room = student.Id_room,
                Date = student.DataIn.ToString(),
                Id_user = student.Id_user
            };
        }
    }
}

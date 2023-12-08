using InterfaceDB;
using Microsoft.EntityFrameworkCore;
using Models;
using DBModels;
using Converter;

namespace DataAccess
{
    public class StudentDA : IStudentDB
    {
        private readonly AppDbContext db;
        public StudentDA(AppDbContext curDb)
        {
            db = curDb;
        }
        public List<Student>? getAllStudent()
        {
            List<StudentModel> students =  db.Students.OrderBy(s => s.Id_student).ToList();
            List<Student> result = new List<Student>();
            foreach(StudentModel student in students) 
                result.Add(StudentConverter.DBtoBL(student));
            return result;
        }
        public Student? getStudentByCode(string codeStudent)
        {
            StudentModel? student = db.Students.AsNoTracking().FirstOrDefault(u => u.StudentCode == codeStudent);
            return StudentConverter.DBtoBL(student);
        }
        public Student? getStudentById(int id_student)
        {
            StudentModel? student = db.Students.AsNoTracking().FirstOrDefault(u => u.Id_student == id_student);
            return StudentConverter.DBtoBL(student);
        }
        public int addStudent(Student student)
        {
            List<StudentModel>? lst = db.Students.Count() > 0 ? db.Students.ToList() : null;
            int maxid = 0;
            foreach (StudentModel temp in lst)
                if (temp.Id_student > maxid)
                    maxid = temp.Id_student;
            student.Id_student = maxid + 1;
            student.DataIn = DateTime.Now;
            db.Students.Add(StudentConverter.BLtoDB(student));
            db.SaveChanges();
            return student.Id_student;
        }
        public int updateStudent(Student newStudent)
        {
            string codeStudent = newStudent.StudentCode;
            StudentModel? student = db.Students.Where(s => s.StudentCode == codeStudent).FirstOrDefault();
            if (student == null)
                return -1;
            student.Name = newStudent.Name;
            student.GroupStudent = newStudent.Group;
            db.SaveChanges();
            return 1;
        }
        public int changeRoom(string code, int id_room)
        {
            StudentModel? student = db.Students.Where(s => s.StudentCode == code).FirstOrDefault();
            if (student == null)
                return -1;
            student.Id_room = id_room;
            db.SaveChanges();
            return 1;
        }
    }
}

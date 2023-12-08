using Models;

namespace InterfaceDB
{
    public interface IStudentDB
    {
        public List<Student>? getAllStudent();
        public Student? getStudentByCode(string codeStudent);
        public Student? getStudentById(int id_student);
        public int addStudent(Student student);
        public int updateStudent(Student newStudent);
        public int changeRoom(string code, int id_room);
    }
}

using Models;
using DBModels;

namespace Builders
{
    public class StudentBuilder
    {
        private int id_student;
        private string name;
        private string group;
        private string code;
        private int id_room;
        private int id_user;
        private DateTime datein;
        public StudentBuilder buildId(int id)
        {
            this.id_student = id;
            return this;
        }
        public StudentBuilder buildName(string name)
        {
            this.name = name;
            return this;
        }
        public StudentBuilder buildGroup(string group)
        {
            this.group = group;
            return this;
        }
        public StudentBuilder buildCode(string code)
        {
            this.code = code;
            return this;
        }
        public StudentBuilder buildDate(DateTime datein)
        {
            this.datein = datein;
            return this;
        }
        public StudentBuilder buildIdRoom(int id_room)
        {
            this.id_room = id_room;
            return this;
        }
        public StudentBuilder buildIdUser(int id_user)
        {
            this.id_user = id_user;
            return this;
        }
        public Student buildBL()
        {
            Student student = new Student(id_student, name, group, code, id_room, datein, id_user);
            return student;
        }
        public StudentModel buildDA()
        {
            return new StudentModel
            {
                Id_room = id_room,
                Id_student = id_student,
                Id_user = id_user,
                Name = name,
                GroupStudent = group,
                StudentCode = code,
                Date = datein.ToString()
            };
        }
    }
}

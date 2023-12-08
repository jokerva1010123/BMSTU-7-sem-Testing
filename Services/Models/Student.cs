namespace Models
{
    public class Student
    {
        private int id_student;
        private string name;
        private string group;
        private string studentCode;
        private int id_room;
        private DateTime dataIn;
        private int id_user;
        public int Id_student { get => id_student; set => id_student = value; }
        public string Name { get => name; set => name = value; }
        public string Group { get => group; set => group = value; }
        public int Id_room { get => id_room; set => id_room = value; }
        public DateTime DataIn { get => dataIn; set => dataIn = value; }
        public string StudentCode { get => studentCode; set => studentCode = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public Student(string name, string group, string studentCode, int id_room, DateTime dataIn, int id_user)
        {
            this.id_student = -1;
            this.name = name;
            this.group = group;
            this.studentCode = studentCode;
            this.id_room = id_room;
            this.dataIn = dataIn;
            this.id_user = id_user;
        }
        public Student(int id_student, string name, string group, string studentCode, int id_room, DateTime dataIn, int id_user)
        {
            this.id_student = id_student;
            this.name = name;
            this.group = group;
            this.studentCode = studentCode;
            this.id_room = id_room;
            this.dataIn = dataIn;
            this.id_user = id_user;
        }
    }
}

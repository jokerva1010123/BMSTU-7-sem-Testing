using InterfaceDB;
using Models;
using Error;
using NLog;

namespace Services
{
    public class StudentServices
    {
        private readonly IRoomDB iroomDB;
        private IStudentDB istudentDB;
        public IStudentDB IstudentDB { get => istudentDB; set => istudentDB = value; }
        public StudentServices(IStudentDB istudentDB, IRoomDB roomDB)
        {
            this.IstudentDB = istudentDB;
            this.iroomDB = roomDB;
        }
        public int addStudent(Student newStudent)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (newStudent.Id_user < 1)
                throw new UserNotFoundException();
            if (newStudent.Name.Length < 1 || newStudent.Group.Length < 1 || newStudent.StudentCode.Length < 1)
            {
                log.Info("User adds new student unsuccessfully.");
                throw new AddStudentErrorException();                
            }
            if (this.istudentDB.getStudentByCode(newStudent.StudentCode) != null)
                throw new AddStudentErrorException();
            log.Info("User adds new student successfully.");
            return this.istudentDB.addStudent(newStudent); 
        }
        public int getIdStudentFromCode(string studentCode)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentByCode(studentCode);
            if (student == null)
            {
                log.Info("User views student's information unsuccessfully.");
                throw new StudentNotFoundException();
            }
            else
                return student.Id_student;
        }
        public int getRoomStudent(int id_student)
        {
            if (id_student < 0)
                throw new StudentNotFoundException();
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
                throw new StudentNotFoundException();
            return student.Id_room;
        }
        public void changeStudentGroup(int id_student, string newGroup)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User changes student's group unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Student? newStudent = new Student(id_student, student.Name, newGroup, student.StudentCode, student.Id_room, student.DataIn, student.Id_user);
            this.istudentDB.updateStudent(newStudent);
            log.Info("User changes student's group successfully.");
        }
        public void changeStudentName(int id_student, string newName)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User changes student's name successfully.");
                throw new StudentNotFoundException();
            }
            Student? newStudent = new Student(id_student, newName, student.Group, student.StudentCode, student.Id_room, student.DataIn, student.Id_user);
            this.istudentDB.updateStudent(newStudent);
            log.Info("User changes student's name successfully.");
        }
        public void setRoomStudent(int id_student, int id_room)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User sets student's room unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Room? room = this.iroomDB.getRoom(id_room);
            if (room == null)
            {
                log.Info("User sets student's room unsuccessfully.");
                throw new RoomNotFoundException();
            }
            this.istudentDB.changeRoom(student.StudentCode, id_room);
            log.Info("User sets student's room successfully.");
        }
        public Student getStudent(int id_student)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (id_student < 1)
            {
                log.Info("User views student's information unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student != null)
            {
                log.Info("User views student's information successfully.");
                return student;
            }
            else
            {
                log.Info("User views student's information unsuccessfully.");
                throw new StudentNotFoundException();
            }
        }
        public List<Student>? getAllStudent()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all students successfully.");
            return this.IstudentDB.getAllStudent();
        }
        public void returnRoomStudent(int id_student)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User gets student's room unsuccessfully.");
                throw new StudentNotFoundException();
            }
            if (student.Id_room <= 0)
            {
                log.Info("User gets student's room unsuccessfully.");
                throw new StudentNotInRoomException();
            }
            this.istudentDB.changeRoom(student.StudentCode, 0);
            log.Info("User gets student's room successfully.");
        }
    }
}

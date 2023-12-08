using Services;
using Models;
using NLog;

namespace Main
{
    internal class StudentManager
    {
        private StudentServices studentServices;
        private UserServices userServices;
        public StudentManager(UserServices userServices, StudentServices studentServices)
        {
            this.studentServices = studentServices;
            this.userServices = userServices;
        }
        public void addStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();

            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();

            Console.Write("Введите логни студента: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль студента: ");
            string password = Console.ReadLine();
            DateTime now = DateTime.Now;
            try
            {
                this.userServices.addUser(new User(login, password, Levels.STUDENT));
                int id = this.userServices.getIdUser(login);
                this.studentServices.addStudent(new Student(name, group, code, -1, now, id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void viewStudent()
        {
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();
            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                if (id_student > 0)
                {
                    Student student = this.studentServices.getStudent(id_student);
                    Console.Write("Студент: " + student.Name + ", группа - " + student.Group + ", код: " + student.StudentCode);
                    if (student.Id_room > 0)
                        Console.WriteLine(", живет в общежитии.");
                    else
                        Console.WriteLine(", не живет в общежитии.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void viewAllStudent()
        {
            List<Student> allStudent = this.studentServices.getAllStudent();
            foreach (Student student in allStudent)
            {
                Console.Write("Студент: " + student.Name + ", группа - " + student.Group + ", код: " + student.StudentCode);
                if (student.Id_room > 0)
                    Console.WriteLine(", живет в общежитии.");
                else
                    Console.WriteLine(", не живет в общежитии.");
            }
        }

        public void changeStudentGroup()
        {
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();

            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                this.studentServices.changeStudentGroup(id_student, group);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void changeStudentName()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();

            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                this.studentServices.changeStudentName(id_student, name);
                log.Info("User changes student's name successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                log.Info("User changes student's name unsuccessfully.");
            }
        }

        public void setRoom()
        {
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();

            Console.Write("Введите id комнаты: ");
            int id_room = Convert.ToInt32(Console.ReadLine());

            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                this.studentServices.setRoomStudent(id_student, id_room);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void returnRoom()
        {
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();
            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                this.studentServices.returnRoomStudent(id_student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string getStudentByIdUser(int id)
        {
            string result = "";
            List<Student>? allStudent = this.studentServices.getAllStudent();
            foreach (Student student in allStudent)
                if (student.Id_user == id)
                {
                    result = student.StudentCode;
                    break;
                }
            return result;
        }
    }
}

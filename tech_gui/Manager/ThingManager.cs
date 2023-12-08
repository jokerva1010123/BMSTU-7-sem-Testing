using Models;
using Error;
using NLog;
using Services;

namespace Main
{
    internal class ThingManager
    {
        private ThingServices thingServices;
        private StudentServices studentServices;
        private RoomServices roomServices;
        public ThingManager(ThingServices thingServices, StudentServices studentServices, RoomServices roomServices)
        {
            this.thingServices = thingServices;
            this.studentServices = studentServices;
            this.roomServices = roomServices;
        }
        public void viewAllThing()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            List<Thing>? allThing = this.thingServices.getAllThing();
            foreach (Thing thing in allThing)
                Console.WriteLine("ID: " + thing.Id_thing.ToString() + ", " + thing.Type + ", код: " + thing.Code);
            log.Info("User views all things.");
        }
        public void viewFreeThing()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            List<Thing>? allThing = this.thingServices.getFreeThing();
            foreach (Thing thing in allThing)
                Console.WriteLine("ID: " + thing.Id_thing.ToString() + ", " + thing.Type + ", код: " + thing.Code);
            log.Info("User views all free things.");
        }
        public void viewStudentThing()
        {
            Console.Write("Введите код студента: ");
            string studentCode = Console.ReadLine();
            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(studentCode);
                if (id_student > 0)
                {
                    List<Thing> things = this.thingServices.getStudentThing(id_student);
                    foreach (Thing thing in things)
                        Console.WriteLine("ID: " + thing.Id_thing.ToString() + ", " + thing.Type + ", код: " + thing.Code);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void viewStudentThingForStudent(string studentCode)
        {
            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(studentCode);
                if (id_student > 0)
                {
                    List<Thing> things = this.thingServices.getStudentThing(id_student);
                    foreach (Thing thing in things)
                        Console.WriteLine("ID: " + thing.Id_thing.ToString() + ", " + thing.Type + ", код: " + thing.Code);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void addNewThing()
        {
            Console.Write("Введите тип вещи: ");
            string type = Console.ReadLine();

            Console.Write("Введите код вещи: ");
            string code = Console.ReadLine();

            try
            {
                this.thingServices.addThing(new Thing(code, type));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void giveStudentThing()
        {
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();
            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                if (id_student > 0)
                {
                    Console.Write("Введите код вещи: ");
                    string codething = Console.ReadLine();
                    Thing thing = thingServices.getThing(codething);
                    if (thing != null)
                    {
                        if (thing.Id_student < 1)
                            this.thingServices.transferStudentThing(id_student, codething);
                        else
                            throw new ThingNotFreeException();
                    }
                    else
                        throw new ThingNotFoundException();
                }
                else
                    throw new StudentNotFoundException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void returnStudentThing()
        {
            Console.Write("Введите код студента: ");
            string code = Console.ReadLine();
            try
            {
                int id_student = this.studentServices.getIdStudentFromCode(code);
                if (id_student > 0)
                {
                    Console.Write("Введите код вещи: ");
                    string codething = Console.ReadLine();
                    Thing thing = thingServices.getThing(codething);
                    if (thing != null)
                    {
                        int? owner = thing.Id_student;
                        if (owner == id_student)
                            this.thingServices.returnThing(id_student, codething);
                        else
                            throw new ThingNotFoundException();
                    }
                    else throw new ThingNotFoundException();
                }
                else throw new StudentNotFoundException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

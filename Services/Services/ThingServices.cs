using InterfaceDB;
using Models;
using Error;
using NLog;

namespace Services
{
    public class ThingServices
    {
        private IThingDB ithingDB;
        private readonly IRoomDB iroomDB;
        private readonly IStudentDB istudentDB;
        public IThingDB IthingDB { get => ithingDB; set => ithingDB = value; }
        public ThingServices(IThingDB thingDB, IRoomDB iroomDB, IStudentDB istudentDB)
        {
            this.ithingDB = thingDB;
            this.istudentDB = istudentDB;
            this.iroomDB = iroomDB;
        }
        public int addThing(Thing newThing)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            List<Thing> allThing = this.ithingDB.getAllThing();
            foreach (Thing thing in allThing)
                if (thing.Code == newThing.Code)
                {
                    log.Info("User adds new thing unsuccessfully.");
                    throw new CodeThingExistsException();
                }
            log.Info("User adds new thing successfully.");
            return this.ithingDB.addThing(newThing);
        }
        public Thing getThing(string codeThing)
        {
            Thing? thing = this.ithingDB.getThing(codeThing);
            if (thing != null)
                return thing;
            else
                throw new ThingNotFoundException();
        }
        public List<Thing>? getAllThing()
        {
            return this.ithingDB.getAllThing();
        }
        public void changeRoomThing(string codeThing, int id_to)
        {
            Thing? thing = this.ithingDB.getThing(codeThing);
            if (thing == null)
                throw new ThingNotFoundException();
            else
            {
                Room? room = this.iroomDB.getRoom(id_to);
                if (room == null)
                    throw new RoomNotFoundException();
                else
                    this.IthingDB.changeRoomThing(codeThing, id_to);
            }
        }
        public List<Thing> getFreeThing()
        {
            List<Thing> things = this.ithingDB.getAllThing();
            List<Thing> result = new List<Thing>();
            foreach(Thing thing in things)
                if(thing.Id_room == 1 && thing.Id_student < 1)
                    result.Add(thing);
            return result;
        }
        public void transferStudentThing(int id_student, string codeThing)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User gives thing to student unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Thing? thing = this.ithingDB.getThing(codeThing);
            if (thing == null)
            {
                log.Info("User gives thing to student unsuccessfully.");
                throw new ThingNotFoundException();
            }
            if (thing.Id_student < 1 && thing.Id_room == 1)
            {
                log.Info("User gives thing to student successfully.");
                this.ithingDB.changeStudentThing(codeThing, id_student);
            }
            else
            {
                log.Info("User gives thing to student unsuccessfully.");
                throw new ThingNotFreeException();
            }
        }
        public void returnThing(int id_student, string codeThing)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User returns thing from student unsuccessfully.");
                throw new StudentNotFoundException();
            }
            Thing? thing = this.ithingDB.getThing(codeThing);
            if (thing == null)
            {
                log.Info("User returns thing from student unsuccessfully."); 
                throw new ThingNotFoundException();
            }
            if (thing.Id_student == id_student)
            {
                this.ithingDB.changeStudentThing(codeThing, 0);
                log.Info("User returns thing from student successfully.");
            }
            else
            {
                log.Info("User returns thing from student unsuccessfully.");
                throw new WrongOwnerThingException();
            }
        }
        public List<Thing> getStudentThing(int id_student)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Student? student = this.istudentDB.getStudentById(id_student);
            if (student == null)
            {
                log.Info("User views student's things succesfully.");
                throw new StudentNotFoundException();
            }
            List<Thing> allThing = this.ithingDB.getAllThing();
            List<Thing> result = new List<Thing>();
            foreach (Thing thing in allThing)
                if (thing.Id_student == id_student)
                    result.Add(thing);
            log.Info("User views student's things succesfully.");
            return result;
        }
    }
}

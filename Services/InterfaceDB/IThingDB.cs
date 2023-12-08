using Models;

namespace InterfaceDB
{
    public interface IThingDB
    {
        public List<Thing> getAllThing();
        public Thing? getThing(string codeThing);
        public int addThing(Thing thing);
        public int changeRoomThing(string codeThing, int id_room);
        public int changeStudentThing(string codeThing, int id_student);
    }
}


using Models;
using DBModels;
using DataAccess;

namespace Converter
{
    public class ThingConverter
    {
        public static Thing? DBtoBL(ThingModel? thing)
        {
            if (thing == null) return null;
            return new Thing(thing.Id_thing, thing.Code, thing.Type, thing.Id_room, thing.Id_student);
        }
        public static ThingModel? BLtoDB(Thing? thing)
        {
            if (thing == null) return null;
            return new ThingModel
            {
                Id_thing = thing.Id_thing,
                Code = thing.Code,
                Type = thing.Type,
                Id_room = thing.Id_room,
                Id_student = thing.Id_student.Value
            };
        }
    }
}

using InterfaceDB;
using Models;
using DBModels;
using Converter;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ThingDA : IThingDB
    {
        private readonly AppDbContext db;
        public ThingDA(AppDbContext curDb)
        {
            db = curDb;
        }
        public List<Thing> getAllThing()
        {
            List<ThingModel> things =  db.Things.OrderBy(t => t.Id_thing).ToList();
            List<Thing> result = new List<Thing>();
            foreach (ThingModel thing in things) 
                result.Add(ThingConverter.DBtoBL(thing));
            return result;
        }
        public Thing? getThing(string codeThing)
        {
            ThingModel? thing =  db.Things.AsNoTracking().FirstOrDefault(u => u.Code == codeThing);
            return ThingConverter.DBtoBL(thing);
        }
        public int addThing(Thing thing)
        {
            List<ThingModel>? lst = db.Things.Count() > 0 ? db.Things.ToList() : null;
            int maxid = 0;
            foreach (ThingModel temp in lst)
                if (temp.Id_thing > maxid)
                    maxid = temp.Id_thing;
            thing.Id_thing = maxid + 1;
            thing.Id_room = 1;
            db.Things.Add(ThingConverter.BLtoDB(thing));
            db.SaveChanges();
            return thing.Id_thing;
        }
        public int changeRoomThing(string codeThing, int id_room)
        {
            ThingModel thing = db.Things.Where(t => t.Code == codeThing).FirstOrDefault();
            thing.Id_room = id_room;
            db.SaveChanges();
            return 1;
        }
        public int changeStudentThing(string codeThing, int id_student)
        {
            ThingModel thing = db.Things.Where(t => t.Code == codeThing).FirstOrDefault();
            thing.Id_student = id_student;
            db.SaveChanges();
            return 1;
        }
    }
}

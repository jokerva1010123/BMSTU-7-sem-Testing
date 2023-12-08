using InterfaceDB;
using Microsoft.EntityFrameworkCore;
using Converter;
using Models;
using DBModels;

namespace DataAccess
{
    public class RoomDA : IRoomDB
    {
        private readonly AppDbContext db;
        public RoomDA(AppDbContext curDb)
        {
            db = curDb;
        }
        public List<Room> getAllRoom()
        {
            List<RoomModel> obj = db.Rooms.AsNoTracking().OrderBy(r => r.Id_room).ToList();
            List<Room> result = new List<Room>();
            foreach(RoomModel room in obj) 
                result.Add(RoomConverter.DBtoBL(room));
            return result;
        }
        public Room? getRoom(int id_room)
        {
            RoomModel? room = db.Rooms.AsNoTracking().FirstOrDefault(r => r.Id_room == id_room);
            return RoomConverter.DBtoBL(room);
        }
    }
}

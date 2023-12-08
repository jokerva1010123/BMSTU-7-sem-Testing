using Models;
using DBModels;

namespace Converter
{
    public class RoomConverter
    {
        public static Room? DBtoBL(RoomModel? room)
        {
            if (room == null) return null;
            return new Room(room.Id_room, room.Number, room.Roomtype);
        }
        public static RoomModel? BLtoDB(Room? room)
        {
            if (room == null) return null;
            return new RoomModel { Id_room = room.Id_room, Number = room.Number, Roomtype = room.RoomTypes };
        }
    }
}

using Models;
using DBModels;

namespace Builders
{
    public class RoomBuilder
    {
        private int id_room;
        private int number;
        private RoomType roomType;
        public RoomBuilder buildId(int id_room)
        {
            this.id_room = id_room;
            return this;
        }
        public RoomBuilder buildNumber(int number) 
        {
            this.number = number;
            return this;
        }
        public RoomBuilder buildRoomType(RoomType roomType)
        {
            this.roomType = roomType;
            return this;
        }
        public Room buildBL()
        {
            Room room = new Room(id_room, number, roomType);
            return room;
        }
        public RoomModel buildDA()
        {
            RoomModel room = new RoomModel
            {
                Id_room = id_room,
                Number = number,
                Roomtype = roomType
            };
            return room;
        }
    }
}

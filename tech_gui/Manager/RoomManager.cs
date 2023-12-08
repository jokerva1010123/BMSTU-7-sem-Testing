using Services;
using Models;

namespace Main
{
    internal class RoomManager
    {
        private RoomServices roomServices;
        public RoomManager(RoomServices roomServices)
        {
            this.roomServices = roomServices;
        }
        public void printAllRoom()
        {
            List<Room> allRoom = this.roomServices.getAllRoom();
            foreach (Room room in allRoom)
            {
                Console.WriteLine("ID = " + room.Id_room.ToString() + " тип комнаты: " + room.RoomTypes.ToString() + ", номер комната: " + room.Number.ToString());
            }
        }
    }
}

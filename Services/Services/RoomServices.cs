using InterfaceDB;
using Models;
using Error;
using NLog;

namespace Services
{
    public class RoomServices
    {
        private IRoomDB iroomDB;
        public IRoomDB IroomDB { get => iroomDB; set => iroomDB = value; }
        public RoomServices(IRoomDB iroomDB)
        {
            this.IroomDB = iroomDB;
        }
        public Room getRoom(int id_room)
        {
            Room? room = this.IroomDB.getRoom(id_room);
            if (room == null)
                throw new RoomNotFoundException();
            else
                return room;
        }
        public List<Room> getAllRoom()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all rooms.");
            return this.IroomDB.getAllRoom();
        }
    }
}

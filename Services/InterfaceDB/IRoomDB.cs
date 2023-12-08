using Models;

namespace InterfaceDB
{
    public interface IRoomDB
    {
        Room? getRoom(int id_room);
        List<Room> getAllRoom();
    }
}

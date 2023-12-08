using Builders;
using Models;

namespace ObjectMothers
{
    public class RoomOM
    {
        public static RoomBuilder createStorage(int id)
        {
            return new RoomBuilder().buildId(id)
                .buildNumber(100 + id)
                .buildRoomType(RoomType.Storage);
        }
        public static RoomBuilder createStudentRoom(int id)
        {
            return new RoomBuilder().buildId(id)
                .buildNumber(300 + id)
                .buildRoomType(RoomType.StudentRoom);
        }
    }
}

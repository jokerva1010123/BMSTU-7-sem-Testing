namespace Models;

public enum RoomType
{
    None,
    StudentRoom,
    Storage
};
public class Room
{
    private int id_room;
    private int number;
    private RoomType roomType;
    public int Id_room { get => id_room; set => id_room = value; }
    public int Number { get => number; set => number = value; }
    public RoomType RoomTypes { get => roomType; set => roomType = value; }
    public Room(int id_room, int number, RoomType roomType)
    {
        this.id_room = id_room;
        this.number = number;
        this.roomType = roomType;
    }
    public Room(int number, RoomType roomType)
    {
        this.id_room = -1;
        this.number = number;
        this.roomType = roomType;
    }
}

namespace Models
{
    public class Thing
    {
        private int id_thing;
        private string code;
        private string type;
        private int id_room;
        private int? id_student;
        public int Id_thing { get => id_thing; set => id_thing = value; }
        public string Code { get => code; set => code = value; }
        public string Type { get => type; set => type = value; }
        public int Id_room { get => id_room; set => id_room = value; }
        public int? Id_student { get => id_student; set => id_student = value; }
        public Thing(string code, string type)
        {
            this.id_thing = -1;
            this.code = code;
            this.type = type;
            this.id_student = -1;
            this.id_room = 1;
        }
        public Thing(int id_thing, string code, string type, int id_room, int? id_student)
        {
            this.id_thing = id_thing;
            this.code = code;
            this.type = type;
            this.id_room = id_room;
            this.id_student = id_student;
        }
    }
}

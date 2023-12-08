using Models;
using DBModels;

namespace Builders
{
    public class ThingBuilder
    {
        private int id_thing;
        private string type;
        private string code;
        private int id_room;
        private int id_student;
        public ThingBuilder buildId(int id_thing)
        {
            this.id_thing = id_thing;
            return this;
        }
        public ThingBuilder buildType(string type)
        {
            this.type = type;
            return this;
        }
        public ThingBuilder buildCode(string code)
        {
            this.code = code;
            return this;
        }
        public ThingBuilder buildIdStudent(int id_student)
        {
            this.id_student = id_student;
            return this;
        }
        public ThingBuilder buildIdRoom(int id_room)
        {
            this.id_room = id_room;
            return this;
        }
        public Thing buildBL()
        {
            Thing thing = new Thing(id_thing, code, type, id_room, id_student);
            return thing;
        }
        public ThingModel buildDA()
        {
            return new ThingModel()
            {
                Code = code,
                Id_room = id_room,
                Id_student  = id_student,
                Id_thing = id_thing,
                Type = type
            };
        }
    }
}

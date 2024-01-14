using Builders;

namespace ObjectMothers
{
    public class ThingOM
    {
        public static ThingBuilder createTable(int id)
        {
            return new ThingBuilder().buildId(id)
                .buildType("Table")
                .buildCode("Table" + id)
                .buildIdRoom(id).buildIdStudent(id);
        }
        public static ThingBuilder createChair(int id)
        {
            return new ThingBuilder().buildId(id)
                .buildType("Chair")
                .buildCode("Chair" + id)
                .buildIdRoom(id).buildIdStudent(id);
        }
        public static ThingBuilder createFree(int id)
        {
            return new ThingBuilder().buildId(id)
                .buildType("Chair")
                .buildCode("Chair" + id)
                .buildIdRoom(1).buildIdStudent(0);
        }
    }
}

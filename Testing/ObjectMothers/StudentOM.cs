using Builders;

namespace ObjectMothers
{
    public class StudentOM
    {
        public static StudentBuilder createNewStudent(int id)
        {
            return new StudentBuilder().buildId(id)
                .buildName("alex" + id)
                .buildGroup("IU7-" + id)
                .buildCode("alex" + id + "IU7")
                .buildDate(DateTime.Parse("Jan 01 2023"))
                .buildIdRoom(id)
                .buildIdUser(id);
        }
    }
}

using Builders;

namespace ObjectMothers
{
    public class UserOM
    {
        public static UserBuilder CreateStudent(int id)
        {
            return new UserBuilder()
                .buildId(id)
                .buildLogin("student" + id)
                .buildPassword("student" + id)
                .buildLevel(Models.Levels.STUDENT);
        }
        public static UserBuilder CreateKamedan(int id)
        {
            return new UserBuilder()
                .buildId(id)
                .buildLogin("kamedan" + id)
                .buildPassword("kamedan" + id)
                .buildLevel(Models.Levels.KAMEDAN);
        }
        public static UserBuilder CreateManager(int id)
        {
            return new UserBuilder()
                .buildId(id)
                .buildLogin("manager" + id)
                .buildPassword("manager" + id)
                .buildLevel(Models.Levels.MANAGER);
        }
    }
}

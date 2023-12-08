namespace Models
{
    public enum Levels
    {
        NONE,
        STUDENT,
        KAMEDAN,
        MANAGER
    }
    public class User
    {
        private int id;
        private string login;
        private string password;
        private Levels userLevel;
        public int Id { get { return id; } set { id = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public Levels UserLevel { get => userLevel; set => userLevel = value; }
        public User(string login, string password, Levels userLevel)
        {
            this.id = -1;
            this.login = login;
            this.password = password;
            this.userLevel = userLevel;
        }
        public User(int id, string login, string password, Levels userLevel)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.userLevel = userLevel;
        }
    }
}

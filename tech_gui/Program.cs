using Services;
using DataAccess;
using System.Text;
using Microsoft.Extensions.Configuration;
using InterfaceDB;

namespace Main
{
    internal static class Program
    {
        [STAThread]
        [Obsolete]
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var configuration = new ConfigurationBuilder().AddJsonFile("dbsettings.json");
            var config = configuration.Build();
            var useDB = config.GetSection("App").GetSection("UseDB").Value;
            var connectionString = config.GetSection("PostgreSql").GetSection("ConnectionString").Value;

            try
            {
                Repositories repositories = new Repositories(connectionString);

                IUserDB userDA = repositories.CreateUserDB();
                IStudentDB studentDA = repositories.CreateStudentDB();
                IThingDB thingDA = repositories.CreateThingDB();
                IRoomDB roomDA = repositories.CreateRoomDB();

                UserServices userServices = new UserServices(userDA);
                RoomServices roomServices = new RoomServices(roomDA);
                StudentServices studentServices = new StudentServices(studentDA, roomDA);
                ThingServices thingServices = new ThingServices(thingDA, roomDA, studentDA);

                UserManager userManager = new UserManager(userServices);
                StudentManager studentManager = new StudentManager(userServices, studentServices);
                RoomManager roomManager = new RoomManager(roomServices);
                ThingManager thingManager = new ThingManager(thingServices, studentServices, roomServices);

                App app = new App(userManager, studentManager, roomManager, thingManager);
                while (true)
                {
                    app.menu();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
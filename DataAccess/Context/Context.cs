using Microsoft.EntityFrameworkCore;
using DBModels;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        private string ConnectionString { get; set; }
        public AppDbContext(string conn)
        {
            ConnectionString = conn;
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<ThingModel> Things { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }
    }
}

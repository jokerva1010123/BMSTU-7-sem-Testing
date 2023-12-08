using System.ComponentModel.DataAnnotations;
using Models;

namespace DBModels
{    
    public class UserModel
    {
        [Key]
        public int ID { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public Levels Level { get; set; }
    }
}

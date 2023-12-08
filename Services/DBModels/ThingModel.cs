using System.ComponentModel.DataAnnotations;

namespace DBModels
{
    public class ThingModel
    {
        [Key]
        public int Id_thing { get; set; }
        public string Code { get; set; }
        public string? Type { get; set; }
        public int Id_room { get; set; }
        public int Id_student { get; set; }
    }
}

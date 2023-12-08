using System.ComponentModel.DataAnnotations;
using Models;

namespace DBModels
{
    public class RoomModel
    {
        [Key]
        public int Id_room { get; set; }
        public int Number { get; set; }
        public RoomType Roomtype { get; set; }  
    }
}

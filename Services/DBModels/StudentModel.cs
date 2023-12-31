﻿using System.ComponentModel.DataAnnotations;

namespace DBModels
{
    public class StudentModel
    {
        [Key]
        public int Id_student { get; set; }
        public string Name { get; set; }
        public string StudentCode { get; set;}
        public string GroupStudent { get; set;}
        public int Id_room { get; set;}
        public int Id_user { get; set;}
        public string Date { get; set;}
    }
}

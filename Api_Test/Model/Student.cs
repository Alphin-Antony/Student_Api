﻿using System.ComponentModel.DataAnnotations;

namespace Api_Test.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


    }
}

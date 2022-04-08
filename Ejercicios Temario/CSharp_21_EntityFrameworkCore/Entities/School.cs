using System;
using System.Collections.Generic;

namespace CSharp_21_EntityFrameworkCore.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public List<Student> Students { get; set; }
    }
}

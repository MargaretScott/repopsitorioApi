using System;

namespace CSharp_21_EntityFrameworkCore.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public int? ClassId { get; set; }
        public Class Class { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}

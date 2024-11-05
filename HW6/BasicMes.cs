using System;
namespace StudentManagementSystem.Models
{
    public class School
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassCount { get; set; }
        public int StudentCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Class
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public int StudentCount { get; set; }
        public int SchoolID { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string Hometown { get; set; }
        public string Address { get; set; }
        public int ClassID { get; set; }
    }
}

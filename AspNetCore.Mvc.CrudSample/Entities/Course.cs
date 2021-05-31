using System;
namespace AspNetCore.Mvc.CrudSample.Entities
{
    public class Course
    {
        public Course()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}

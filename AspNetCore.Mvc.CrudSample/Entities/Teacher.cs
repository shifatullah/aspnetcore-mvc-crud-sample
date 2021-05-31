using System;
namespace AspNetCore.Mvc.CrudSample.Entities
{
    public class Teacher
    {
        public Teacher()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Course Course { get; set; }
    }
}

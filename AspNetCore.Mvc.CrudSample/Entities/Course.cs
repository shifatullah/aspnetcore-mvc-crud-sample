using System;
using System.Collections.Generic;

namespace AspNetCore.Mvc.CrudSample.Entities
{
    public class Course
    {
        public Course()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}

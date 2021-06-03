using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Mvc.CrudSample.Entities
{
    public class Course
    {
        public Course()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}

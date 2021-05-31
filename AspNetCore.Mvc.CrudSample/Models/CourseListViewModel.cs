using System;
using System.Collections.Generic;
using AspNetCore.Mvc.CrudSample.Entities;

namespace AspNetCore.Mvc.CrudSample.Models
{
    public class CourseListViewModel
    {
        public CourseListViewModel()
        {
        }

        public List<Course> Courses { get; set; }
    }
}

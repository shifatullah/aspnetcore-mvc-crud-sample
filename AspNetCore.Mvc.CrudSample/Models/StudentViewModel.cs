using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Mvc.CrudSample.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCore.Mvc.CrudSample.Models
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> CourseIds { get; set; }

        public List<Course> Courses { get; set; }

        public List<SelectListItem> CoursesListItem
        {
            get
            {
                return Courses == null ? null : Courses.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            }
        }
    }
}

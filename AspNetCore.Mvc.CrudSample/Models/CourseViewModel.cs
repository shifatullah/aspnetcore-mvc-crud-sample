using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Mvc.CrudSample.Models
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

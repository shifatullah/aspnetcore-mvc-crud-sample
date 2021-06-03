using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Mvc.CrudSample.Entities
{
    public class Teacher
    {
        public Teacher()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}

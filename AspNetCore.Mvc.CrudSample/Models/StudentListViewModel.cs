using System;
using System.Collections.Generic;
using AspNetCore.Mvc.CrudSample.Entities;

namespace AspNetCore.Mvc.CrudSample.Models
{
    public class StudentListViewModel
    {
        public StudentListViewModel()
        {
        }

        public List<Student> Students { get; set; }
    }
}

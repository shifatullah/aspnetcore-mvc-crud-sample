using System;
using System.Collections.Generic;
using AspNetCore.Mvc.CrudSample.Entities;

namespace AspNetCore.Mvc.CrudSample.Models
{
    public class TeacherListViewModel
    {
        public TeacherListViewModel()
        {
        }

        public List<Teacher> Teachers { get; set; }
    }
}

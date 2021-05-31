using System;
namespace AspNetCore.Mvc.CrudSample.Models
{
    public class NewCourseViewModel
    {
        public NewCourseViewModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}

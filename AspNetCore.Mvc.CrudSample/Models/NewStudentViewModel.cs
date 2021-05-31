using System;
namespace AspNetCore.Mvc.CrudSample.Models
{
    public class NewStudentViewModel
    {
        public NewStudentViewModel()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}

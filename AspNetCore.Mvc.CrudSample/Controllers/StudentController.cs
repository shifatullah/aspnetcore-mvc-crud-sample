using System;
using System.Linq;
using AspNetCore.Mvc.CrudSample.Entities;
using AspNetCore.Mvc.CrudSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.CrudSample.Controllers
{
    public class StudentController : Controller
    {
        CrudContext _context;

        public StudentController(CrudContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            StudentListViewModel model = new StudentListViewModel();
            model.Students = _context.Students.ToList();
            return View(model);
        }

        public ViewResult New()
        {
            return View();
        }

        public IActionResult Save(NewStudentViewModel model)
        {
            Student student = null;
            if (model.Id != 0)
                student = _context.Students.Where(x => x.Id == model.Id).FirstOrDefault();

            if (student == null)
            {
                student = new Student();
                student.Name = model.Name;

                _context.Students.Add(student);
            }
            else
            {
                student.Name = model.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            Student student =
                _context.Students.Where(x => x.Id == id).FirstOrDefault();

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Id = student.Id;
            studentViewModel.Name = student.Name;

            return View(studentViewModel);
        }

        public ViewResult Details(int id)
        {
            Student student =
                _context.Students.Where(x => x.Id == id).FirstOrDefault();

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Id = student.Id;
            studentViewModel.Name = student.Name;

            return View(studentViewModel);
        }

        public IActionResult Delete(int id)
        {
            Student student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

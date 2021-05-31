using System;
using System.Linq;
using AspNetCore.Mvc.CrudSample.Entities;
using AspNetCore.Mvc.CrudSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.CrudSample.Controllers
{
    public class TeacherController : Controller
    {
        CrudContext _context;

        public TeacherController(CrudContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            TeacherListViewModel model = new TeacherListViewModel();
            model.Teachers = _context.Teachers.ToList();
            return View(model);
        }

        public ViewResult New()
        {
            return View();
        }

        public IActionResult Save(NewTeacherViewModel model)
        {
            Teacher teacher =
                _context.Teachers.Where(x => x.Id == model.Id).FirstOrDefault();

            if (teacher == null)
            {
                teacher = new Teacher();
                teacher.Id = model.Id;
                teacher.Name = model.Name;

                _context.Teachers.Add(teacher);
            }
            else
            {
                teacher.Name = model.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            Teacher teacher =
                _context.Teachers.Where(x => x.Id == id).FirstOrDefault();

            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Id = teacher.Id;
            teacherViewModel.Name = teacher.Name;

            return View(teacherViewModel);
        }

        public ViewResult Details(int id)
        {
            Teacher teacher =
                _context.Teachers.Where(x => x.Id == id).FirstOrDefault();

            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Id = teacher.Id;
            teacherViewModel.Name = teacher.Name;

            return View(teacherViewModel);
        }

        public IActionResult Delete(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
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
            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Courses = _context.Courses.ToList();
            return View(teacherViewModel);
        }

        public IActionResult Save(TeacherViewModel model)
        {
            Teacher teacher = null;
            if (model.Id != 0)
                teacher = _context.Teachers.Find(model.Id);

            if (teacher == null)
            {
                teacher = new Teacher();
                teacher.Name = model.Name;
                teacher.Course = _context.Courses.Find(Convert.ToInt32(model.CourseId));
                _context.Teachers.Add(teacher);
            }
            else
            {
                teacher.Name = model.Name;
                teacher.Course = _context.Courses.Find(Convert.ToInt32(model.CourseId));
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            Teacher teacher =
                _context.Teachers.Where(x => x.Id == id).FirstOrDefault();

            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Courses = _context.Courses.ToList();
            teacherViewModel.Id = teacher.Id;
            teacherViewModel.Name = teacher.Name;
            if (teacher.Course != null)
                teacherViewModel.CourseId = teacher.Course.Id.ToString();

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
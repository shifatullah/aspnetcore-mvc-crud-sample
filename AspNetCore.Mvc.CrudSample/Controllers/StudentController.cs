using System;
using System.Linq;
using AspNetCore.Mvc.CrudSample.Entities;
using AspNetCore.Mvc.CrudSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Courses = _context.Courses.ToList();
            return View(studentViewModel);
        }

        public IActionResult Save(StudentViewModel model)
        {
            Student student = null;
            if (model.Id != 0)
                student = _context.Students.Include(s => s.StudentCourses).Where(x => x.Id == model.Id).FirstOrDefault();

            if (student == null)
            {
                student = new Student();
                student.Name = model.Name;

                if (model.CourseIds.Count > 0)
                {
                    student.StudentCourses = model.CourseIds.Select(c =>
                            new StudentCourse
                            {
                                Student = student,
                                Course = _context.Courses.Find(c)
                            }
                        ).ToList();
                }

                _context.Students.Add(student);
            }
            else
            {
                student.Name = model.Name;

                if (model.CourseIds.Count > 0)
                {
                    student.StudentCourses = model.CourseIds.Select(c =>
                            new StudentCourse
                            {
                                Student = student,
                                Course = _context.Courses.Find(c)
                            }
                        ).ToList();
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ViewResult Edit(int id)
        {
            Student student =
                _context.Students.Include(s => s.StudentCourses).Where(s => s.Id == id).FirstOrDefault();

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Id = student.Id;
            studentViewModel.Name = student.Name;
            if (student.StudentCourses != null)
                studentViewModel.CourseIds = student.StudentCourses.Select(sc => sc.CourseId).ToList();
            studentViewModel.Courses = _context.Courses.ToList();

            return View(studentViewModel);
        }

        public ViewResult Details(int id)
        {
            Student student =
                _context.Students.Include(s => s.StudentCourses).Where(x => x.Id == id).FirstOrDefault();

            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Id = student.Id;
            studentViewModel.Name = student.Name;
            if (student.StudentCourses != null)
                studentViewModel.CourseIds = student.StudentCourses.Select(sc => sc.CourseId).ToList();
            studentViewModel.Courses = _context.Courses.ToList();

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

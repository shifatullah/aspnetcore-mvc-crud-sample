using System;
using System.Linq;
using AspNetCore.Mvc.CrudSample.Entities;
using AspNetCore.Mvc.CrudSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.CrudSample.Controllers
{
    public class CourseController : Controller
    {
        CrudContext _context;

        public CourseController(CrudContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            CourseListViewModel courseViewModel = new CourseListViewModel();
            courseViewModel.Courses = _context.Courses.ToList();
            return View(courseViewModel);
        }

        public ViewResult New()
        {
            CourseViewModel courseViewModel = new CourseViewModel();
            return View("Edit", courseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = null;
                if (model.Id != 0)
                    course = _context.Courses.Where(x => x.Id == model.Id).FirstOrDefault();

                if (course == null)
                {
                    course = new Course();
                    course.Name = model.Name;

                    _context.Courses.Add(course);
                }
                else
                {
                    course.Name = model.Name;
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                    return BadRequest();
            }
        }

        public ViewResult Edit(int id)
        {
            Course course =
                _context.Courses.Where(x => x.Id == id).FirstOrDefault();

            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.Id = course.Id;
            courseViewModel.Name = course.Name;

            return View(courseViewModel);
        }

        public ViewResult Details(int id)
        {
            Course course =
                _context.Courses.Where(x => x.Id == id).FirstOrDefault();

            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.Id = course.Id;
            courseViewModel.Name = course.Name;

            return View(courseViewModel);
        }

        public IActionResult Delete(int id)
        {
            Course course = _context.Courses.Find(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

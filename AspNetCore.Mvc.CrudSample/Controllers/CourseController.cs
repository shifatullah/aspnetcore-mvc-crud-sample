﻿using System;
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
            CourseListViewModel model = new CourseListViewModel();
            model.Courses = _context.Courses.ToList();
            return View(model);
        }

        public ViewResult New()
        {
            return View();
        }

        public IActionResult Save(NewCourseViewModel model)
        {
            Course course =
                _context.Courses.Where(x => x.Id == model.Id).FirstOrDefault();

            if (course == null)
            {
                course = new Course();
                course.Id = model.Id;
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
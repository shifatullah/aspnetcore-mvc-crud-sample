﻿using System;
using System.Collections.Generic;

namespace AspNetCore.Mvc.CrudSample.Entities
{
    public class StudentCourse
    {
        public StudentCourse()
        {
        }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}

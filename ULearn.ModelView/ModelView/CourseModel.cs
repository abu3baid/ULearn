﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULearn.ModelView.ModelView
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Rate { get; set; }
        public int TeacherId { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace ULearn.DbModel.Models.DB
{
    public partial class Course
    {
        public Course()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Rate { get; set; }
        public int TeacherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte IsArchived { get; set; }

        public virtual User Teacher { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

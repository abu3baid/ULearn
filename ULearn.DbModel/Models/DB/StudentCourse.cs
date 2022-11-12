using System;
using System.Collections.Generic;

#nullable disable

namespace ULearn.DbModel.Models.DB
{
    public partial class StudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte IsArchived { get; set; }

        public virtual Course Course { get; set; }
        public virtual User Student { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ULearn.DbModel.Models.DB
{
    public partial class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LessonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte IsArchived { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}

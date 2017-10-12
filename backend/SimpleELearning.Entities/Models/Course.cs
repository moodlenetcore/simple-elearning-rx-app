using System;

namespace SimpleELearning.Entities.Models
{
    public class Course : BaseEntity
    {
        public int CourseCategoryId { get; set;}

        public CourseCategory CourseCategory { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string Summary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

namespace SimpleELearning.Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public Guid? CourseCategoryId { get; set; }

        public CourseCategory CourseCategory { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string Summary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

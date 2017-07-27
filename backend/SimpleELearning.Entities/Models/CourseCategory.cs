namespace SimpleELearning.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CourseCategory : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public CourseCategory ParentCategory { get; set; }

        public virtual ICollection<Course> Courses { get; set;}
    }
}

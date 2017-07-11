namespace SimpleELearning.Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CourseCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public CourseCategory ParentCategory { get; set; }
    }
}

namespace SimpleELearning.Entities.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SimpleELearning.Entities.Models;

    public class SimpleELearningContext : DbContext
    {
        public SimpleELearningContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

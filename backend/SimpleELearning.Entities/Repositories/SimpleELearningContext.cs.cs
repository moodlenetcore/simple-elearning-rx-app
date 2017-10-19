using Microsoft.EntityFrameworkCore;
using SimpleELearning.Entities.Models;

namespace SimpleELearning.Entities.Repositories
{
    public class SimpleELearningContext : DbContext
    {
        public SimpleELearningContext() : base()
        {
        }

        #region DbSet
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SimpleELearning;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}

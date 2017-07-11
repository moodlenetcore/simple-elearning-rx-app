namespace SimpleELearning.Entities.Repositories
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public class DbContextFactory : IDbContextFactory<SimpleELearningContext>
    {
        public SimpleELearningContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimpleELearningContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-RJ20MT0;Database=SimpleELearning;User Id=sa;Password=123456789;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SimpleELearningContext(optionsBuilder.Options);
        }
    }
}

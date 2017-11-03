using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleELearning.Entities.Repositories;
using SimpleELearning.Entities.Interface;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using SimpleElearning.Services.Interfaces;
using SimpleElearning.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace SimpleELearning.Api
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public Startup(IConfigurationRoot configuration)
    {
      this.Configuration = configuration;
    }
    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("AllowSpecificOrigin",
                  builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
      });
      // Add framework services.
      services.AddMvc();
      services.Configure<MvcOptions>(options =>
      {
        options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
      });

      //services.AddDbContext<SimpleELearningContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddDbContext<SimpleELearningContext>(options => options.UseInMemoryDatabase());
      services.AddScoped<DbContext, SimpleELearningContext>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
      services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
      services.AddScoped(typeof(ICourseCategoryRepository), typeof(CourseCategoryRepository));
      services.AddTransient<ICourseService, CourseService>();
      services.AddTransient<IUserService, UserService>();
      services.AddTransient<ICourseCategoriesService, CourseCategoriesService>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "Course API", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseCors("AllowSpecificOrigin");
      app.UseMvcWithDefaultRoute();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Course API V1");
      });
    }
  }
}

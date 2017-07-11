using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SimpleELearning.Entities.Repositories;

namespace SimpleELearning.Entities.Migrations
{
    [DbContext(typeof(SimpleELearningContext))]
    partial class SimpleELearningContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleELearning.Entities.Models.Course", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid?>("CourseCategoryId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("FullName");

                    b.Property<string>("ShortName");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.HasIndex("CourseCategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SimpleELearning.Entities.Models.CourseCategory", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CourseCategories");
                });

            modelBuilder.Entity("SimpleELearning.Entities.Models.Course", b =>
                {
                    b.HasOne("SimpleELearning.Entities.Models.CourseCategory", "CourseCategory")
                        .WithMany()
                        .HasForeignKey("CourseCategoryId");
                });

            modelBuilder.Entity("SimpleELearning.Entities.Models.CourseCategory", b =>
                {
                    b.HasOne("SimpleELearning.Entities.Models.CourseCategory", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
        }
    }
}

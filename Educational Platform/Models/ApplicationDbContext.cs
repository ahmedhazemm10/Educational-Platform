using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Educational_Platform.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(ci => new { ci.StudentId, ci.CourseId })
                .IsUnique();
        }
        public DbSet<Student> Students {  get; set; }
        public DbSet<Course> Courses {  get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Exam> Exams {  get; set; }
        public DbSet<Question> Questions {  get; set; }
        public DbSet<Enrollment> Enrollments {  get; set; }
        public DbSet<Grade> Grades {  get; set; }
        public DbSet<Options> Options { get; set; }
    }
}

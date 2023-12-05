using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniversityManagementSystem.Data
{
    public class UniversityMSDbContext : DbContext
    {
        public UniversityMSDbContext(DbContextOptions<UniversityMSDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Code)
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Course>()
               .HasIndex(c => c.Code)
               .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<Teacher>()
              .HasIndex(t => t.Email)
              .IsUnique();
            modelBuilder.Entity<Student>()
              .HasIndex(s => s.Email)
              .IsUnique();

            modelBuilder.Entity<Room>()
             .HasIndex(r => r.RoomNo)
             .IsUnique();
            modelBuilder.Entity<Day>()
             .HasIndex(d => d.DayName)
             .IsUnique();
            //modelBuilder.Entity<Course>()
            //    .HasOne(c => c.Teacher)
            //    .WithMany(t => t.Courses)
            //    .HasForeignKey(c => c.TeacherId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<Day> Days { get; set; }
        public DbSet<Allocate> Allocates { get; set; }
        public DbSet<Enroll> Enrolls { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}

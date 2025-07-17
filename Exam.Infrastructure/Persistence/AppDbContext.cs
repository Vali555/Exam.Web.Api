using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ExamProcess> ExamProcesses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamProcess>()
     .HasOne(e => e.Lesson)
     .WithMany(l => l.ExamProcesses)
     .HasForeignKey(e => e.LessonId)
     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamProcess>()
                .HasOne(e => e.Student)
                .WithMany(s => s.ExamProcesses)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}

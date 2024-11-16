using Exam.Model;
using Microsoft.EntityFrameworkCore;
using PreExam.Model;

namespace PreExam.Data
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
        public DbSet<Student>students { get; set; }
        public DbSet<Enrollment>enrollments { get; set; }
        public DbSet<Course>courses { get; set; }
    }
}

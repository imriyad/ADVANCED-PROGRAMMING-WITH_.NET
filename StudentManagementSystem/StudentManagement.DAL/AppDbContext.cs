using System.Data.Entity;
using StudentManagement.DAL.Models;

namespace StudentManagement.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=StudentDBConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}

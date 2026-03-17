using CrudProject.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
        public DbSet<Student> students { get; set; }
    }
}

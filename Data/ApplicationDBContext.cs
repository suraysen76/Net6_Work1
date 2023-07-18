using Microsoft.EntityFrameworkCore;
using Net6_Work1.Models;
using System.Data;

namespace Net6_Work1.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base (options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}

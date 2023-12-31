
using Kitaplik.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitaplik.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}

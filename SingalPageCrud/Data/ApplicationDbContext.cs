using Microsoft.EntityFrameworkCore;
using SingalPageCrud.Models;

namespace SingalPageCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }     

    }
}

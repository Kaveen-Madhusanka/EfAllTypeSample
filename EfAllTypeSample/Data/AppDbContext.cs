using EfAllTypeSample.Models;
using Microsoft.EntityFrameworkCore;

namespace EfAllTypeSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public  DbSet<Productstbl> Productstbl { get; set; }
    }
}

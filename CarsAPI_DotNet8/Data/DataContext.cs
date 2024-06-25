using CarsAPI_DotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
    }
}

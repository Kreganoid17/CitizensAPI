using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        
        
        }

        public DbSet<Citizen> citizens { get; set; }

    }
}

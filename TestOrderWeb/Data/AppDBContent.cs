using Microsoft.EntityFrameworkCore;
using TestOrderWebApplication.Data.Models;

namespace TestOrderWebApplication.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent>  opt): base(opt)
        {
            
        }

        public DbSet<Order> AllOrders { get; set; } = null!;

    }
}

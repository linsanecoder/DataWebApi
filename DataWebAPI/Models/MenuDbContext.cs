using Microsoft.EntityFrameworkCore;

namespace DataWebAPI.Models
{
   public class MenuDbContext : DbContext
   {
      public MenuDbContext(DbContextOptions options) : base(options)
      {
      }

      public MenuDbContext() : base()
      {
      }

      public DbSet<FoodItem> FoodItems { get; set; }
   }
}

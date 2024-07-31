using Microsoft.EntityFrameworkCore;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Contexts
{
  public class NorthwndContext:DbContext
  {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\MGSERVER;database=NORTHWND;trusted_connection=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<AdminPanelUser> AdminPanelUsers{ get; set; }

    }
}

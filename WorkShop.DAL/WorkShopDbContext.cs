
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WorkShop.DAL.Models;

namespace WorkShop.DAL
{
    public class WorkShopDbContext : IdentityDbContext<IdentityUser> //DbContext //IdentityDbContext
    {
        //public WorkShopDbContext()
        //{
        //}
        public WorkShopDbContext(DbContextOptions<WorkShopDbContext> options)
            :base(options) { }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    //Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = "1",
                },
                new IdentityRole()
                {
                    //Id = Guid.NewGuid().ToString(),
                    Name = "Employee",
                    NormalizedName = "employee",
                    ConcurrencyStamp = "2",
                });
            //base.OnModelCreating(modelBuilder);
        }

    }
}

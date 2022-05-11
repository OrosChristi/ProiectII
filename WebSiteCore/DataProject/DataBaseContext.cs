using DataProject.Models;
using Microsoft.EntityFrameworkCore;


namespace DataProject
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //public DbSet<User> Users { get; set; }
        public DbSet<Auto> Auto { get; set; }
        public DbSet<Order> Order { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "" });
            //modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "" });
            //modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "" });
        }

    }
}

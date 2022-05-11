using DataProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace DataProject
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name = testconn") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Auto> Auto { get; set; }
        public DbSet<Order> Order { get; set; }        
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersRole> UserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//opesere sa imi puna "s" la finalul tabelelor
            //modelBuilder.Entity<Persoane>().ToTable("Persoane");
            //modelBuilder.Entity<Persoane(aici vine numele tabelului din clasa)>().ToTable("Persoane"(sub ce denumire sa apara tabelul));
        }

    }
}

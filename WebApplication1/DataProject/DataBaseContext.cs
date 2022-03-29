using DataProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace DataProject
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name = testconn") { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//opesere sa imi puna "s" la finalul tabelelor
            //modelBuilder.Entity<Persoane>().ToTable("Persoane");
            //modelBuilder.Entity<Persoane(aici vine numele tabelului din clasa)>().ToTable("Persoane"(sub ce denumire sa apara tabelul));
        }

    }
}

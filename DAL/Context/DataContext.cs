using System.Data.Entity;
using DAL.Models;

namespace DAL.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("TemplateDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public DbSet<TemplateEntity> TemplateEntities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
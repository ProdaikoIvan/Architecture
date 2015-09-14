using System;
using System.Data.Entity.Migrations;
using DAL.Context;
using DAL.Models;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  Enable-Migrations
            //  Add-Migration {Name} (if entities exists)
            //  Update-Database

            context.Countries.AddOrUpdate(x => x.Id, new Country
            {
                Id = 1,
                Name = "Ukraine"
            }, new Country
            {
                Id = 2,
                Name = "USA"
            }, new Country
            {
                Id = 3,
                Name = "France"
            }, new Country
            {
                Id = 4,
                Name = "Germany"
            });

            context.TemplateEntities.AddOrUpdate(x => x.Id,
                new TemplateEntity
                {
                    Id = 1,
                    Name = "John",
                    DateTime = DateTime.Now,
                    IsActive = true,
                    CountryId = 1
                },
                new TemplateEntity
                {
                    Id = 2,
                    Name = "Eugene",
                    DateTime = DateTime.Now.AddHours(1),
                    IsActive = false,
                    CountryId = 4
                });
        }
    }
}
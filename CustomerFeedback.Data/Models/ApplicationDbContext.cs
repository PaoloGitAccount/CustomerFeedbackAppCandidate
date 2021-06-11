using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
//using MyCookingMaster.BL.Models;
using System.IO;

namespace CustomerFeedback.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feedback> Feedback { get; set; }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../CustomerFeedback.App/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                //var connectionString = configuration.GetConnectionString("DatabaseConnection");
                var connectionString = configuration.GetConnectionString("AzureDbConnection");
                builder.UseSqlServer(connectionString);
                return new ApplicationDbContext(builder.Options);
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Feedback>(entity =>
        //    {
        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Lastname)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Comment)
        //            .IsRequired()
        //            .HasMaxLength(5000);
        //    });

        //    //modelBuilder.Entity<Product>(entity =>
        //    //{
        //    //    entity.Property(e => e.Description)
        //    //        .IsRequired()
        //    //        .HasMaxLength(50);

        //    //    entity.Property(e => e.Name)
        //    //        .IsRequired()
        //    //        .HasMaxLength(50);

        //    //    entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        //    //});

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        //{
        //    //throw new NotImplementedException();
        //}

        ////partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

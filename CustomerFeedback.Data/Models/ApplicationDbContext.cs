using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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

        public const string appJsonSettings = "/../CustomerFeedback.App/appsettings.json";

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + appJsonSettings)
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

        //        entity.HasKey(e => e.Id)
        //            .HasName("PK__Feedback__970EC36669B0E780");

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

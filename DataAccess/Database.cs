using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Database : DbContext
    {
        public DbSet<Common.Page> Pages { get; set; }

        public DbSet<Common.HTMLObjects> Objects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Common.Page>()
                .HasKey(c => c.Id);
            builder.Entity<Common.HTMLObjects>()
                .HasOne(a => a.page)
                .WithMany(b => b.Objects).HasForeignKey(a => a.PageId);
            // Define composite key.
            builder.Entity<Common.HTMLObjects>()
                .HasKey(c => c.key);

            builder.Entity<Common.HTMLObjects>()
                .HasOne(a => a.options)
                .WithOne(b => b.HTMLObjects).HasForeignKey<Common.Options>(a=> a.ObjectId);
            //    builder.Entity<Common.HTMLObjects>()
            //       .HasOne<Common.Options>(s => s.options).WithOne(ad => ad.HTMLObjects);\
            base.OnModelCreating(builder);
        }
    }
}

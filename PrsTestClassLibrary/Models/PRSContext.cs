using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Models
{
    public class PRSContext : DbContext
    {  
        public virtual DbSet <User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestLine> RequestLines { get; set; }

        public PRSContext() { }

        public PRSContext(DbContextOptions<PRSContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=PRSDB;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(e => e.Username).IsUnique();
            builder.Entity<Vendor>().HasIndex(e => e.Code).IsUnique();
            builder.Entity<Product>().HasIndex(e => e.PartNbr).IsUnique();

        }
    }
}

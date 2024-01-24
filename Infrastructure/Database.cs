using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
            Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.ID);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}

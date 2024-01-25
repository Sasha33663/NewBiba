using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Domain;

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
            modelBuilder.Entity<User>().HasKey(a => a.ID);
            modelBuilder.Entity<Note>().HasKey(x => x.ID);
            modelBuilder.Entity<Note>().HasOne(x => x.User)
                                       .WithMany(x=>x.Notes)
                                       .HasForeignKey(x=>x.UserID);

            modelBuilder.Entity<Note>() .Property(n => n.Date).HasColumnType("timestamp without time zone");

            base.OnModelCreating(modelBuilder);
        }
       public DbSet<Note> Notes { get; set; }
       public DbSet<User> Users { get; set; }
    }
}

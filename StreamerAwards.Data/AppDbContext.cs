using Microsoft.EntityFrameworkCore;
using StreamerAwards.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace StreamerAwards.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> ctx)
            : base(ctx)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Streamers)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Streamer)
                .WithMany()
                .HasForeignKey(v => v.StreamerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Category)
                .WithMany()
                .HasForeignKey(v => v.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Streamer>()
                .Property(s => s.VotesCount)
                .HasDefaultValue(0);

            base.OnModelCreating(modelBuilder);
        }
    }
}

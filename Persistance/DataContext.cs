using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Persistance
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Caste> Castes { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Rashi> Rashis { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            //builder.Entity<State>()
            //    .HasOne<Country>(p => p.Country)
            //    .WithMany(q => q.States)
            //    .HasForeignKey(ur => ur.country_id);
            //builder.Entity<City>()
            //    .HasOne<State>(p => p.State)
            //    .WithMany(q => q.Cities)
            //    .HasForeignKey(ur => ur.state_id);
            //builder.Entity<City>()
            //    .HasOne<Country>(p => p.Country)
            //    .WithMany(q => q.Cities)
            //    .HasForeignKey(ctctry => ctctry.country_id);
        }
    }
}
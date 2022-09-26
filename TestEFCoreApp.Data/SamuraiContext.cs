using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCoreApp.Domain;

namespace TestEFCoreApp.Data
{
    public class SamuraiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = 127.0.0.1, 1433; Database = SamuraiApp; Integrated Security = False; User Id = SA; Password = Admin1234!; MultipleActiveResultSets = True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattleSamurai> BattleSamurai { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>().
                HasMany(bs => bs.Battles).
                WithMany(bs => bs.Samurais).
                UsingEntity<BattleSamurai>(bs => bs.HasOne<Battle>().WithMany(),
                                           bs => bs.HasOne<Samurai>().WithMany()).
                Property(bs => bs.BattleDate).
                HasDefaultValueSql("getdate()");



        }
    }
}

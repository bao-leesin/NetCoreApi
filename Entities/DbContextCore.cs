using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using NetCoreApi.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace NetCoreApi.Entities
{
    public class DbContextCore : DbContext
    {
        public DbContextCore(DbContextOptions<DbContextCore> options) : base(options) { }
        public DbSet<ACCOUNT> ACCOUNTs  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>().HasData(
                new ACCOUNT() { ID = 1, USERNAME = "Tester1", PASSWORD = "TestPwd1" });
        }

    }
}

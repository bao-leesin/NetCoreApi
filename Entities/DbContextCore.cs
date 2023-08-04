using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using NetCoreApi.Models;


namespace NetCoreApi.Entities
{
    public class DbContextCore : DbContext
    {
        public DbContextCore(DbContextOptions<DbContextCore> options) : base(options) { }
        public DbSet<ACCOUNT> ACCOUNTs  { get; set; }
    }
}

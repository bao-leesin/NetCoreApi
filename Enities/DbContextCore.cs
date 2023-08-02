using Microsoft.EntityFrameworkCore;
using NetCoreApi.Models;
using System.ComponentModel.DataAnnotations;


namespace NetCoreApi.Enities
{
    public class DbContextCore : DbContext
    {
        public DbSet<Tester> Testers { get; set; }
    }
}

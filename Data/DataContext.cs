using DatingApp.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace DatingApp.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) {}

        public DbSet<Value> Values { get; set; }
    }
}

// https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
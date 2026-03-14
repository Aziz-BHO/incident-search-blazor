using BackendIncidents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendIncidents.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}

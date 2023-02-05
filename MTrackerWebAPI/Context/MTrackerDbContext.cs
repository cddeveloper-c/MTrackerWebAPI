using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

public class MTrackerDbContext : DbContext
{
    public MTrackerDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Customer> Customer { get; set; }
}

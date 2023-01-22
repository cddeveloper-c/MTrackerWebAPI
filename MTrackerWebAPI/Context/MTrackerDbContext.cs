using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Context;

public class MTrackerDbContext : DbContext
{
    public MTrackerDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employee { get; set; }
}

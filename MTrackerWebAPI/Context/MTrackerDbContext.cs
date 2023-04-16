using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

public class MTrackerDbContext : DbContext
{
    public MTrackerDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Resource> Resource { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<ProjectTasks> ProjectTasks { get; set; }   
    public DbSet<UserStories> UserStories { get; set; }
    public DbSet<ManagerComments> ManagerComments { get; set; }

}

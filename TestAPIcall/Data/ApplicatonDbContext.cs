using Microsoft.EntityFrameworkCore;
using TestAPIcall.Models;
namespace TestAPIcall.Data

{
    public class ApplicatonDbContext : DbContext
    {
        public ApplicatonDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ImageModel> ImageModels { get; set; }
    }
}

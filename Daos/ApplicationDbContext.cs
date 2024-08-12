using DotNetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Daos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FileStatus> FileStatuses { get; set; }
    }
}

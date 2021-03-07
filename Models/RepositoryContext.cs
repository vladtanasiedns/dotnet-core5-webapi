using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
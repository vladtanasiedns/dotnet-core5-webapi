using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<TodoItem>()
        //         .HasOne(p => p.Project)
        //         .WithMany(b => b.TodoItems)
        //         .HasForeignKey(t => t.Id)
        //         .HasConstraintName("ProjectId");
        // }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
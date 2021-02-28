using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    // Dependent entity class
    public class TodoItem
    {
        // [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        // Foreign key pointing to the project this TodoItem belongs to
        public int ProjectId { get; set; }
        // Navigation propery referencing the project model
        [ForeignKey("Id")]
        public Project Project { get; set; }
    }
}
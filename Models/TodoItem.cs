using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    // Dependent entity class
    [Table("todos")]
    public class TodoItem
    {
        // [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("iscomplete")]
        public bool IsComplete { get; set; }
        // Foreign key pointing to the project this TodoItem belongs to
        [Column("projectid")]
        [ForeignKey("projectid")]
        public int ProjectId { get; set; }
        // Navigation propery referencing the project model
        // [Column("projectid")]
        // [ForeignKey("projectid")]
        public virtual Project Project { get; set; }
    }
}
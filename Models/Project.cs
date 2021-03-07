using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    [Table("projects")]
    public class Project
    {
        // [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        // Navigation propery
        // [InverseProperty("Project")]
        public List<TodoItem> TodoItems { get; set; }
    }
}
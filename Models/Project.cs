using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        // Navigation propery
        [InverseProperty("Project")]
        public List<TodoItem> TodoItems { get; set; }
    }
}
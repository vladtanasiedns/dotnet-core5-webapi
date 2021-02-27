using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        // Navigation propery
        [InverseProperty("project")]
        public List<TodoItem> TodoItems { get; set; }
    }
}
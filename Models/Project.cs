using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        // Navigation propery
        public List<TodoItem> TodoItems { get; set; }
    }
}
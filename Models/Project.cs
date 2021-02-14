using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Project
    {
        public long Id;
        public string Name;
        // Navigation propery
        public List<TodoItem> TodoItems;
    }
}
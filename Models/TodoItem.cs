namespace TodoApi.Models
{
    // Dependent entity class
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        // Foreign key pointing to the project this TodoItem belongs to
        public int ProjectId { get; set; }
        // Inverse navigation property
        public Project Project { get; set; }
    }
}
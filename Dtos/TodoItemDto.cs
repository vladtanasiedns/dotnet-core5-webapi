namespace TodoApi.Dtos
{
    // Dependent entity class
    public class TodoItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        // Foreign key pointing to the project this TodoItem belongs to
        public int ProjectId { get; set; }

        public TodoItemDto(long Id ,string Name, int ProjectId, bool IsComplete)
        {
            this.Id = Id;
            this.Name = Name;
            this.ProjectId = ProjectId;
            this.IsComplete = IsComplete;
        }
    }
}
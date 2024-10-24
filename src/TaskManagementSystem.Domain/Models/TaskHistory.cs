namespace TaskManagementSystem.Domain.Models
{
    public class TaskHistory : BaseEntity
    {
        public string Description { get; private set; }
        public DateTime Timestamp { get; private set; }

        public TaskHistory(string description, DateTime timestamp)
        {
            Id = Guid.NewGuid();
            Description = description;
            Timestamp = timestamp;
            CreatedAt = timestamp;
        }
    }
}

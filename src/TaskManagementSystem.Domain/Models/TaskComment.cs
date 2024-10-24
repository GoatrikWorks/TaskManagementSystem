namespace TaskManagementSystem.Domain.Models
{
    public class TaskComment : BaseEntity
    {
        public string Text { get; private set; }
        public Guid CreatedById { get; private set; }

        public TaskComment(string text, Guid createdById)
        {
            Id = Guid.NewGuid();
            Text = text;
            CreatedById = createdById;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

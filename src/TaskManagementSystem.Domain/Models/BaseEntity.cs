namespace TaskManagementSystem.Domain.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? LastModifiedAt { get; protected set; }
        public Guid? LastModifiedById { get; protected set; }
    }
}

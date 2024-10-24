// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using TaskManagementSystem.Domain.Enums;
using Ardalis.GuardClauses;
using TaskState = TaskManagementSystem.Domain.Enums.TaskStatus;

namespace TaskManagementSystem.Domain.Models
{
    public class Task : BaseEntity
    {
        private Task()
        {
            _comments = new List<TaskComment>();
            _history = new List<TaskHistory>();
            Title = string.Empty;
            Description = string.Empty;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskState Status { get; private set; }
        public Guid CreatedById { get; private set; }
        public Guid? AssignedToId { get; private set; }

        public IReadOnlyCollection<TaskComment> Comments => _comments.AsReadOnly();
        private readonly List<TaskComment> _comments;

        public IReadOnlyCollection<TaskHistory> History => _history.AsReadOnly();
        private readonly List<TaskHistory> _history;

        public static Task Create(string title, string description, Guid createdById, TaskPriority priority)
        {
            Guard.Against.NullOrWhiteSpace(title, nameof(title));
            Guard.Against.NullOrWhiteSpace(description, nameof(description));
            Guard.Against.Default(createdById, nameof(createdById));

            var task = new Task
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                CreatedById = createdById,
                Priority = priority,
                Status = TaskState.New,
                CreatedAt = DateTime.UtcNow
            };

            task.AddHistoryEntry($"Task created with priority {priority}");
            return task;
        }

        public void UpdateStatus(TaskState newStatus, Guid updatedById)
        {
            Guard.Against.Default(updatedById, nameof(updatedById));

            var oldStatus = Status;
            Status = newStatus;
            LastModifiedAt = DateTime.UtcNow;
            LastModifiedById = updatedById;

            AddHistoryEntry($"Status changed from {oldStatus} to {newStatus}");
        }

        public void AssignTo(Guid assignedToId, Guid updatedById)
        {
            Guard.Against.Default(assignedToId, nameof(assignedToId));
            Guard.Against.Default(updatedById, nameof(updatedById));

            AssignedToId = assignedToId;
            LastModifiedAt = DateTime.UtcNow;
            LastModifiedById = updatedById;

            AddHistoryEntry($"Task assigned to user {assignedToId}");
        }

        public void AddComment(string comment, Guid userId)
        {
            Guard.Against.NullOrWhiteSpace(comment, nameof(comment));
            Guard.Against.Default(userId, nameof(userId));

            var taskComment = new TaskComment(comment, userId);
            _comments.Add(taskComment);

            AddHistoryEntry($"Comment added by user {userId}");
        }

        public void SetDueDate(DateTime dueDate)
        {
            if (dueDate <= DateTime.UtcNow)
                throw new ArgumentException("Due date must be in the future", nameof(dueDate));

            DueDate = dueDate;
            AddHistoryEntry($"Due date set to {dueDate:g}");
        }

        private void AddHistoryEntry(string description)
        {
            _history.Add(new TaskHistory(description, DateTime.UtcNow));
        }
    }
}

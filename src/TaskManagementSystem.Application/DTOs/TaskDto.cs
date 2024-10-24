// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

namespace TaskManagementSystem.Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public DateTime? DueDate { get; init; }
        public required string Priority { get; init; }
        public required string Status { get; init; }
        public Guid CreatedById { get; init; }
        public Guid? AssignedToId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? LastModifiedAt { get; init; }
        public List<TaskCommentDto> Comments { get; init; } = new();
    }
}

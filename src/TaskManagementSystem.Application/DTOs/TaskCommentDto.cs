// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

namespace TaskManagementSystem.Application.DTOs
{
    public class TaskCommentDto
    {
        public Guid Id { get; init; }
        public required string Text { get; init; }
        public Guid CreatedById { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}

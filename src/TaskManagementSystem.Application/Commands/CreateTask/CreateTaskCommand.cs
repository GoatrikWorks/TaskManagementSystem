// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using MediatR;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<TaskDto>
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public DateTime? DueDate { get; init; }
        public TaskPriority Priority { get; init; }
        public Guid CreatedById { get; init; }
    }
}

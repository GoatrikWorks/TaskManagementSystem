// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using MediatR;
using TaskManagementSystem.Application.DTOs;
using TaskState = TaskManagementSystem.Domain.Enums.TaskStatus;

namespace TaskManagementSystem.Application.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommand : IRequest<TaskDto>
    {
        public Guid TaskId { get; set; }
        public TaskState NewStatus { get; set; }
        public Guid UpdatedById { get; set; }
    }
}

// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using TaskState = TaskManagementSystem.Domain.Enums.TaskStatus;

namespace TaskManagementSystem.API.Models.Requests
{
    public class UpdateTaskStatusRequest
    {
        public TaskState NewStatus { get; set; }
        public Guid UpdatedById { get; set; }
    }
}

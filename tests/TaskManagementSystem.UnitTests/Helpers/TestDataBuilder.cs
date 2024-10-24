// Copyright (c) 2022 GoatrikWorks - Erik Elb
// Licensed under MIT License

using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Domain.Models;
using Task = TaskManagementSystem.Domain.Models.Task;

namespace TaskManagementSystem.UnitTests.Helpers
{
    public static class TestDataBuilder
    {
        public static Task CreateTestTask(
            string title = "Test Task",
            string description = "Test Description",
            TaskPriority priority = TaskPriority.Medium)
        {
            return Task.Create(
                title,
                description,
                Guid.NewGuid(),
                priority
            );
        }
    }
}

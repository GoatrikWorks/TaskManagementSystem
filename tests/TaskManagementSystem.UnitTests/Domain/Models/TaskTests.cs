// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using FluentAssertions;
using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Domain.Models;
using TaskManagementSystem.UnitTests.Helpers;
using DomainTask = TaskManagementSystem.Domain.Models.Task;
using TaskState = TaskManagementSystem.Domain.Enums.TaskStatus;

namespace TaskManagementSystem.UnitTests.Domain.Models
{
    public class TaskTests
    {
        [Fact]
        public void Create_Should_CreateNewTask_WithCorrectProperties()
        {
            // Arrange
            var title = "Test Task";
            var description = "Test Description";
            var createdById = Guid.NewGuid();
            var priority = TaskPriority.High;

            // Act
            var task = DomainTask.Create(title, description, createdById, priority);

            // Assert
            task.Should().NotBeNull();
            task.Title.Should().Be(title);
            task.Description.Should().Be(description);
            task.CreatedById.Should().Be(createdById);
            task.Priority.Should().Be(priority);
            task.Status.Should().Be(TaskState.New);
            task.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void UpdateStatus_Should_UpdateStatusAndCreateHistoryEntry()
        {
            // Arrange
            var task = TestDataBuilder.CreateTestTask();
            var newStatus = TaskState.InProgress;
            var updatedById = Guid.NewGuid();

            // Act
            task.UpdateStatus(newStatus, updatedById);

            // Assert
            task.Status.Should().Be(newStatus);
            task.LastModifiedById.Should().Be(updatedById);
            task.History.Should().ContainSingle(h => 
                h.Description.Contains(newStatus.ToString()) && 
                h.Description.Contains(TaskState.New.ToString()));
        }

        [Fact]
        public void AddComment_Should_AddCommentAndCreateHistoryEntry()
        {
            // Arrange
            var task = TestDataBuilder.CreateTestTask();
            var commentText = "Test Comment";
            var userId = Guid.NewGuid();

            // Act
            task.AddComment(commentText, userId);

            // Assert
            task.Comments.Should().ContainSingle();
            task.Comments.First().Text.Should().Be(commentText);
            task.Comments.First().CreatedById.Should().Be(userId);
            task.History.Should().ContainSingle(h => h.Description.Contains("Comment added"));
        }
    }
}

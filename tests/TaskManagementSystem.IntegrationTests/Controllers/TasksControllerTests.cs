// Copyright (c) 2022 GoatrikWorks - Erik Elb
// Licensed under MIT License

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using TaskManagementSystem.API.Models.Requests;
using TaskManagementSystem.Application.Commands.CreateTask;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.IntegrationTests.Helpers;

namespace TaskManagementSystem.IntegrationTests.Controllers
{
    public class TasksControllerTests : IClassFixture<IntegrationTestWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public TasksControllerTests(IntegrationTestWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateTask_ShouldCreateNewTask_AndReturnCreatedResponse()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Title = "Integration Test Task",
                Description = "Test Description",
                CreatedById = Guid.NewGuid(),
                Priority = TaskPriority.High
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/tasks", command);
            var taskDto = await response.Content.ReadFromJsonAsync<TaskDto>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            taskDto.Should().NotBeNull();
            taskDto!.Title.Should().Be(command.Title);
            taskDto.Description.Should().Be(command.Description);
            taskDto.Priority.Should().Be(command.Priority.ToString());
        }

        [Fact]
        public async Task GetTask_ShouldReturnTask_WhenTaskExists()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Title = "Task to Retrieve",
                Description = "Test Description",
                CreatedById = Guid.NewGuid(),
                Priority = TaskPriority.Medium
            };

            var createResponse = await _client.PostAsJsonAsync("/api/tasks", command);
            var createdTask = await createResponse.Content.ReadFromJsonAsync<TaskDto>();

            // Act
            var response = await _client.GetAsync($"/api/tasks/{createdTask!.Id}");
            var taskDto = await response.Content.ReadFromJsonAsync<TaskDto>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            taskDto.Should().NotBeNull();
            taskDto!.Id.Should().Be(createdTask.Id);
            taskDto.Title.Should().Be(command.Title);
        }
    }
}

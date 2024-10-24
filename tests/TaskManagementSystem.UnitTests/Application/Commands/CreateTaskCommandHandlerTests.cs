// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using AutoMapper;
using FluentAssertions;
using Moq;
using TaskManagementSystem.Application.Commands.CreateTask;
using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Application.Mappings;
using DomainTask = TaskManagementSystem.Domain.Models.Task;

namespace TaskManagementSystem.UnitTests.Application.Commands
{
    public class CreateTaskCommandHandlerTests
    {
        private readonly Mock<ITaskRepository> _mockTaskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandlerTests()
        {
            _mockTaskRepository = new Mock<ITaskRepository>();
            
            var config = new MapperConfiguration(cfg => 
                cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_Should_CreateTask_AndReturnTaskDto()
        {
            // Arrange
            var command = new CreateTaskCommand
            {
                Title = "Test Task",
                Description = "Test Description",
                CreatedById = Guid.NewGuid(),
                Priority = TaskPriority.High
            };

            DomainTask? createdTask = null;
            _mockTaskRepository
                .Setup(r => r.AddAsync(It.IsAny<DomainTask>()))
                .Callback<DomainTask>(task => createdTask = task)
                .ReturnsAsync((DomainTask task) => task);

            var handler = new CreateTaskCommandHandler(_mockTaskRepository.Object, _mapper);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(command.Title);
            result.Description.Should().Be(command.Description);
            result.Priority.Should().Be(command.Priority.ToString());
            
            createdTask.Should().NotBeNull();
            _mockTaskRepository.Verify(r => r.AddAsync(It.IsAny<DomainTask>()), Times.Once);
        }
    }
}

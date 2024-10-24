using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Interfaces;

namespace TaskManagementSystem.Application.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = Domain.Models.Task.Create(
                request.Title,
                request.Description,
                request.CreatedById,
                request.Priority);

            await _taskRepository.AddAsync(task);
            return _mapper.Map<TaskDto>(task);
        }
    }
}

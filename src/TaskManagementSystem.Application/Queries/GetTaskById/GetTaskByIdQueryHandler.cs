using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Common.Exceptions;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Interfaces;

namespace TaskManagementSystem.Application.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            
            if (task == null)
                throw new NotFoundException(nameof(Task), request.Id);

            return _mapper.Map<TaskDto>(task);
        }
    }
}
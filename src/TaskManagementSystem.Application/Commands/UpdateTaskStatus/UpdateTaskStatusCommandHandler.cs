// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Common.Exceptions;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Interfaces;
using DomainTask = TaskManagementSystem.Domain.Models.Task;

namespace TaskManagementSystem.Application.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskStatusCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task<TaskDto> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.TaskId);
            
            if (task == null)
                throw new NotFoundException(nameof(DomainTask), request.TaskId);

            task.UpdateStatus(request.NewStatus, request.UpdatedById);
            await _taskRepository.UpdateAsync(task);
            
            return _mapper.Map<TaskDto>(task);
        }
    }
}

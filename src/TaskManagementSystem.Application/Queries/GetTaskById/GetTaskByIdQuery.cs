using MediatR;
using TaskManagementSystem.Application.DTOs;

namespace TaskManagementSystem.Application.Queries.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<TaskDto>
    {
        public Guid Id { get; set; }
    }
}

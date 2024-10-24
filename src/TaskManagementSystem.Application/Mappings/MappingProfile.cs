using AutoMapper;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Models.Task, TaskDto>()
                .ForMember(d => d.Priority, opt => opt.MapFrom(s => s.Priority.ToString()))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

            CreateMap<TaskComment, TaskCommentDto>();
        }
    }
}

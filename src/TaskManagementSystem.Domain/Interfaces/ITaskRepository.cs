// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Domain.Models;
using DomainTask = TaskManagementSystem.Domain.Models.Task;
using TaskState = TaskManagementSystem.Domain.Enums.TaskStatus;

namespace TaskManagementSystem.Domain.Interfaces
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task<DomainTask> GetByIdAsync(Guid id);
        
        System.Threading.Tasks.Task<IEnumerable<DomainTask>> GetAllAsync(
            TaskState? status = null,
            TaskPriority? priority = null,
            Guid? assignedToId = null,
            int page = 1,
            int pageSize = 10);

        System.Threading.Tasks.Task<DomainTask> AddAsync(DomainTask task);
        
        System.Threading.Tasks.Task UpdateAsync(DomainTask task);
        
        System.Threading.Tasks.Task DeleteAsync(Guid id);
    }
}

// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Infrastructure.Persistence;
using TaskManagementSystem.Application.Common.Exceptions;
using DomainTask = TaskManagementSystem.Domain.Models.Task;
using TaskState = TaskManagementSystem.Domain.Enums.TaskStatus;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<DomainTask> GetByIdAsync(Guid id)
        {
            var task = await _context.Tasks
                .Include(t => t.Comments)
                .Include(t => t.History)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                throw new NotFoundException(nameof(DomainTask), id);

            return task;
        }

        public async System.Threading.Tasks.Task<IEnumerable<DomainTask>> GetAllAsync(
            TaskState? status = null,
            Domain.Enums.TaskPriority? priority = null,
            Guid? assignedToId = null,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.Tasks
                .Include(t => t.Comments)
                .Include(t => t.History)
                .AsQueryable();

            if (status.HasValue)
                query = query.Where(t => t.Status == status.Value);

            if (priority.HasValue)
                query = query.Where(t => t.Priority == priority.Value);

            if (assignedToId.HasValue)
                query = query.Where(t => t.AssignedToId == assignedToId.Value);

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task<DomainTask> AddAsync(DomainTask task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task UpdateAsync(DomainTask task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}

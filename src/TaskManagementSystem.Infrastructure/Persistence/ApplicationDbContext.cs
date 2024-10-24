// Copyright (c) 2022 GoatrikWorks - Erik Elb
// Licensed under MIT License

using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Models;
using Task = TaskManagementSystem.Domain.Models.Task;

namespace TaskManagementSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks => Set<Task>();
        public DbSet<TaskComment> TaskComments => Set<TaskComment>();
        public DbSet<TaskHistory> TaskHistory => Set<TaskHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Models;
using Task = TaskManagementSystem.Domain.Models.Task;

namespace TaskManagementSystem.Infrastructure.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.HasMany(t => t.Comments)
                .WithOne()
                .HasForeignKey("TaskId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.History)
                .WithOne()
                .HasForeignKey("TaskId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.Infrastructure.Persistence.Configurations
{
    public class TaskCommentConfiguration : IEntityTypeConfiguration<TaskComment>
    {
        public void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(t => t.CreatedAt)
                .IsRequired();
        }
    }
}

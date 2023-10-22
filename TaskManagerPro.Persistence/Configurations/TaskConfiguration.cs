using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Common.Enums;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasData(
                new ProjectTask()
                {
                    Id = 1,
                    Description = "Task",
                    Status = StatusOfTask.NotStarted,
                    ProjectId = 1,
                    Project = new Project() 
                    {
                        Id = 1,
                        Name = "Project",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        IsClosed = false,
                        ManagerId = 1,
                        Manager = new User() 
                        {
                            UserName = "UserName",
                            Email = "user1@gmail.com",
                            Phone = "094386742",
                        },
                        Tasks = null

                    },
                    AssigneeId = 1,
                    Assignee = new User(),
                    Comments = null
                }
                );

            builder.Property(q => q.Description)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}

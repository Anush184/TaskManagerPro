using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Task> builder)
        {
            builder.HasData(
                new Domain.Task()
                {
                    Id = 1,
                    Description = "Task1",
                    Status = Domain.Common.Enums.TaskStatus.NotStarted,
                    ResolvedAt = null,
                    ProjectId = 1,
                    Project = new Domain.Project() 
                    {
                        Id = 1,
                        Name = "Project1",
                        Description = string.Empty,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        EndDate = null,
                        ManagerId = "1",
                        Manager = new Domain.User() 
                        {
                            FirstName = "User1",
                            LastName = "User1yan",
                            Email = "user1@gmail.com",
                            PasswordHash = "user1!",
                            DateOfBirth = DateTime.Now,
                            IsLocked = false,
                            IsDeleted = false,
                        },
                        Tasks = null

                    },
                    AssignedToUserId = string.Empty,
                    AssignedToUser = null,
                    Comments = null
                }
                );

            builder.Property(q => q.Description)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}

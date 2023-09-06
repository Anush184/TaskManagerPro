using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Persistence.DatabaseContext
{
    public class TMPDatabaseContext: DbContext
    {
        public TMPDatabaseContext(DbContextOptions<TMPDatabaseContext> options): base(options)
        {
                
        }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TMPDatabaseContext).Assembly);

            
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified ))
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;  
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

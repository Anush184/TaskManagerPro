using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain;
using TaskManagerPro.Domain.Common;

namespace TaskManagerPro.Persistence.DatabaseContext
{
    public class TMPDatabaseContext: DbContext
    {
        public TMPDatabaseContext(DbContextOptions<TMPDatabaseContext> options): base(options)
        {
                
        }
        public DbSet<Domain.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

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

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyApplication.Authorization.Roles;
using MyApplication.Authorization.Users;
using MyApplication.MultiTenancy;
using MyApplication.ToDo;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Abp.Events.Bus.Entities;
using System;
using Abp.Extensions;

namespace MyApplication.EntityFrameworkCore
{
    public class MyApplicationDbContext : AbpZeroDbContext<Tenant, Role, User, MyApplicationDbContext>
    {
        /* Define a DbSet for each entity of the application */
            public virtual DbSet<ToDoList> ToDoLists { get; set; }
        
        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoList>().ToTable("tbltodolists");
            modelBuilder.Entity<Role>().ToTable("tsyroles");
            modelBuilder.Entity<User>().ToTable("tsyusers");
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(default(CancellationToken)).ConfigureAwait(false);
        }

        protected void ConfigureAdditionalFilters<TEntity>(ModelBuilder modelBuilder, Expression<Func<TEntity, bool>> additionalQueryFilter) where TEntity : class
        {
            var entityType = modelBuilder.Model.GetEntityTypes().FirstOrDefault(entity => entity.ClrType == typeof(TEntity));
            if (ShouldFilterEntity<TEntity>(entityType))
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                filterExpression = filterExpression == null ? additionalQueryFilter : CombineExpressions(filterExpression, additionalQueryFilter);

                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        protected override EntityChangeReport ApplyAbpConcepts()
        {
            var entries = this.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Added:
                        if (entry.Entity is IConcurrencyStamp)
                        {
                            entry.Entity.As<IConcurrencyStamp>().ConcurrencyStamp = Guid.NewGuid().ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
            return base.ApplyAbpConcepts();
        }

    }
}

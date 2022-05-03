namespace Deloitte.Task.DataAccessLayer.Context
{
    using Deloitte.Task.DomainModel;
    using Deloitte.Task.DataAccessLayer.Abstractions.Context;
    using Deloitte.Task.DataAccessLayer.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

    public class MasterContext : DbContext, IMasterContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterContext"/> class.
        /// </summary>
        public MasterContext()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterContext"/> class.
        /// </summary>
        /// <param name="options">Base option parameter.</param>
        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        public DbSet<TaskDto> TaskDetails { get ; set ; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ToDoListWebApp");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDetailsDomain>().HasIndex(u => u.Id).IsUnique();

            modelBuilder.Entity<TaskDetailsDomain>(taskDetailsDomain =>
            {
                var taskId = taskDetailsDomain.Property(p => p.Id);
                taskId.ValueGeneratedOnAdd();
                if (this.Database.IsInMemory())
                {
                    taskId.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
                }
            });
        }
    }
}

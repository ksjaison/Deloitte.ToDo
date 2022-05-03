namespace Deloitte.Task.DataAccessLayer.Abstractions.Context
{
    using Deloitte.Task.DataAccessLayer.Model;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DB Context class interface.
    /// </summary>
    public interface IMasterContext
    {
        /// <summary>
        /// Gets or sets Task Details.
        /// </summary>
        DbSet<TaskDto> TaskDetails { get; set; }
    }
}

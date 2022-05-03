namespace Deloitte.Task.DataAccessLayer.Abstractions.Context
{
    using Deloitte.Task.DataAccessLayer.Model;
    using Microsoft.EntityFrameworkCore;

    public interface IMasterContext
    {
        DbSet<TaskDto> TaskDetails { get; set; }
    }
}

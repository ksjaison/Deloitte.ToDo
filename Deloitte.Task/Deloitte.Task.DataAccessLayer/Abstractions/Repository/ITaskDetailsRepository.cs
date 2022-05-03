namespace Deloitte.Task.DataAccessLayer.Abstractions.Repository
{
    using System.Collections.Generic;
    using Deloitte.Task.DomainModel;
    
    public interface ITaskDetailsRepository
    {
        public IEnumerable<TaskDetailsDomain> GetTaskDetails();

        TaskDetailsDomain GetTaskDetailsById(int taskId);

        TaskDetailsDomain CreateTask(TaskDetailsDomain taskDetailsDomain);

        bool DeleteTaskDetails(int taskId);

        TaskDetailsDomain UpdateTaskDetails(TaskDetailsDomain taskDetailsDomain);
    }
}

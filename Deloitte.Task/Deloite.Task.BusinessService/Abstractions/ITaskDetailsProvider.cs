using Deloitte.Task.DomainModel;
using System.Collections.Generic;

namespace Deloitte.Task.BusinessService.Abstractions
{
    public interface ITaskDetailsProvider
    {
        public IEnumerable<TaskDetailsDomain> GetTaskDetails();

        TaskDetailsDomain GetTaskDetailsById(int taskId);

        TaskDetailsDomain CreateTask(TaskDetailsDomain taskDetailsDomain);

        bool DeleteTaskdetails(int taskId);

        TaskDetailsDomain UpdateTaskDetails(TaskDetailsDomain taskDetailsDomain);
    }
}

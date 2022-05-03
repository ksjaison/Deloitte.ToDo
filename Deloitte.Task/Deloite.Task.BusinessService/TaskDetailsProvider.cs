namespace Deloitte.Task.BusinessService
{
    using System.Collections.Generic;
    using Deloitte.Task.DataAccessLayer.Abstractions.Repository;
    using Deloitte.Task.DomainModel;
    using Deloitte.Task.BusinessService.Abstractions;

    public class TaskDetailsProvider : ITaskDetailsProvider
    {
        private readonly ITaskDetailsRepository _taskDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDetailsProvider"/> class.
        /// </summary>
        /// <param name="taskDetailsRepository">dddd.</param>
        public TaskDetailsProvider(ITaskDetailsRepository taskDetailsRepository)
        {
            this._taskDetailsRepository = taskDetailsRepository;
        }

        /// <inheritdoc/>
        public TaskDetailsDomain CreateTask(TaskDetailsDomain taskDetailsDomain)
        {
            return this._taskDetailsRepository.CreateTask(taskDetailsDomain);
        }

        public bool DeleteTaskdetails(int taskId)
        {
            return this._taskDetailsRepository.DeleteTaskDetails(taskId);
        }

        /// <inheritdoc/>
        public IEnumerable<TaskDetailsDomain> GetTaskDetails()
        {
            return this._taskDetailsRepository.GetTaskDetails();
        }

        public TaskDetailsDomain GetTaskDetailsById(int taskId)
        {
            return this._taskDetailsRepository.GetTaskDetailsById(taskId);
        }

        public TaskDetailsDomain UpdateTaskDetails(TaskDetailsDomain taskDetailsDomain)
        {
            return this._taskDetailsRepository.UpdateTaskDetails(taskDetailsDomain);
        }
    }
}

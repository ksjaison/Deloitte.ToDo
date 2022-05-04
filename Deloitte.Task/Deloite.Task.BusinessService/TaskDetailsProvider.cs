namespace Deloitte.Task.BusinessService
{
    using System.Collections.Generic;
    using Deloitte.Task.DataAccessLayer.Abstractions.Repository;
    using Deloitte.Task.DomainModel;
    using Deloitte.Task.DomainModel.Abstractions;

    /// <summary>
    /// This Business service or provider class which pass value to Repository.
    /// </summary>
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

        /// <summary>
        /// This method is for creating the task.
        /// </summary>
        /// <param name="taskDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public TaskDetailsDomain CreateTask(TaskDetailsDomain taskDetailsDomain)
        {
            return this._taskDetailsRepository.CreateTask(taskDetailsDomain);
        }

        /// <summary>
        /// This method is for deleting a selected task.
        /// </summary>
        /// <param name="taskId">Task Id parameter for deletion.</param>
        /// <returns>It returs domain model values.</returns>
        public bool DeleteTaskdetails(int taskId)
        {
            return this._taskDetailsRepository.DeleteTaskDetails(taskId);
        }

        /// <summary>
        /// This method is for fetching all task details.
        /// </summary>
        /// <returns>Returns the Task details.</returns>
        public IEnumerable<TaskDetailsDomain> GetTaskDetails()
        {
            return this._taskDetailsRepository.GetTaskDetails();
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="taskId">Task Id parameter for deletion.</param>
        /// <returns>Returns single Task details based on task id.</returns>
        public TaskDetailsDomain GetTaskDetailsById(int taskId)
        {
            return this._taskDetailsRepository.GetTaskDetailsById(taskId);
        }

        /// <summary>
        /// This method is for updating the task.
        /// </summary>
        /// <param name="taskDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public TaskDetailsDomain UpdateTaskDetails(TaskDetailsDomain taskDetailsDomain)
        {
            return this._taskDetailsRepository.UpdateTaskDetails(taskDetailsDomain);
        }
    }
}

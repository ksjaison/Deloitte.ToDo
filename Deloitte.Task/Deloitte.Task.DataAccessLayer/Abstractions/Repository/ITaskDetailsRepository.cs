namespace Deloitte.Task.DataAccessLayer.Abstractions.Repository
{
    using System.Collections.Generic;
    using Deloitte.Task.DomainModel;

    /// <summary>
    /// Repository class interface.
    /// </summary>
    public interface ITaskDetailsRepository
    {
        /// /// <summary>
        /// Fetch all Task details.
        /// </summary>
        /// <returns>Returns the Domain model class object.</returns>
        public IEnumerable<TaskDetailsDomain> GetTaskDetails();

        /// <summary>
        /// Fetch task details using Task Id.
        /// </summary>
        /// <param name="taskId">Task Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        TaskDetailsDomain GetTaskDetailsById(int taskId);

        /// <summary>
        /// Add new task.
        /// </summary>
        /// <param name="taskDetailsDomain">Domain class object.</param>
        /// <returns>Domain class object return after insert value to database.</returns>
        TaskDetailsDomain CreateTask(TaskDetailsDomain taskDetailsDomain);

        /// <summary>
        /// Modify Task.
        /// </summary>
        /// <param name="taskId">Task Id parameter.</param>
        /// <returns>Return true or false status after insert value to database.</returns>
        bool DeleteTaskDetails(int taskId);

        /// <summary>
        /// Modify Task.
        /// </summary>
        /// <param name="taskId">Task Id parameter.</param>
        /// <returns>Domain class object return after modifying the value to database.</returns>
        TaskDetailsDomain UpdateTaskDetails(TaskDetailsDomain taskDetailsDomain);
    }
}

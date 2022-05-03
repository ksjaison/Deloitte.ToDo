namespace Deloite.Task.DataAccessLayer.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Deloitte.Task.DataAccessLayer.Abstractions.Repository;
    using Deloitte.Task.DataAccessLayer.Context;
    using Deloitte.Task.DataAccessLayer.Model;
    using Deloitte.Task.DomainModel;

    /// <summary>
    /// This is Repository class.
    /// </summary>
    public class TaskDetailsRepository : ITaskDetailsRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDetailsRepository"/> class.
        /// </summary>
        /// <param name="mapper">IMapee object.</param>
        public TaskDetailsRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }

        /// <summary>
        /// This method is for fetching all task details.
        /// </summary>
        /// <returns>Returns the Task details.</returns>
        public IEnumerable<TaskDetailsDomain> GetTaskDetails()
        {
            using (var masterContext = new MasterContext())
            {
                var taskdetails = masterContext
                    .TaskDetails
                    .ToList();
                return this._mapper.Map<List<TaskDto>, List<TaskDetailsDomain>>(taskdetails);
            }
        }

        /// <summary>
        /// This method is for creating the task.
        /// </summary>
        /// <param name="taskDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public TaskDetailsDomain CreateTask(TaskDetailsDomain taskDetailsDomain)
        {
            var taskDetails = this._mapper.Map<TaskDetailsDomain, TaskDto>(taskDetailsDomain);

            using (var masterContext = new MasterContext())
            {
                masterContext.TaskDetails.Add(taskDetails);
                masterContext.SaveChanges();
                return this._mapper.Map<TaskDto, TaskDetailsDomain>(taskDetails);
            }
        }

        /// /// <summary>
        /// This method is for updating the task.
        /// </summary>
        /// <param name="taskDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public TaskDetailsDomain UpdateTaskDetails(TaskDetailsDomain taskDetailsDomain)
        {
            using (var masterContext = new MasterContext())
            {

                var taskDetails = masterContext.TaskDetails.FirstOrDefault(a => a.Id == taskDetailsDomain.Id);
                var taskDto = this._mapper.Map<TaskDetailsDomain, TaskDto>(taskDetailsDomain);
                masterContext.Entry(taskDetails).CurrentValues.SetValues(taskDto);
                masterContext.SaveChanges();
                return this._mapper.Map<TaskDto, TaskDetailsDomain>(taskDetails);
            }
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="taskId">Task Id parameter for deletion.</param>
        /// <returns>Returns single Task details based on task id.</returns>
        public TaskDetailsDomain GetTaskDetailsById(int taskId)
        {
            using (var masterContext = new MasterContext())
            {
                var taskDetails = masterContext.TaskDetails.FirstOrDefault(a => a.Id == taskId);
                return this._mapper.Map<TaskDto, TaskDetailsDomain>(taskDetails);
            }
        }

        /// <summary>
        /// This method is for deleting a selected task.
        /// </summary>
        /// <param name="taskId">Task Id parameter for deletion.</param>
        /// <returns>Return bool value after delete.</returns>
        public bool DeleteTaskDetails(int taskId)
        {
            using (var masterContext = new MasterContext())
            {
                var taskDetails = masterContext.TaskDetails.FirstOrDefault(a => a.Id == taskId);
                masterContext.TaskDetails.Remove(taskDetails);
                masterContext.SaveChanges();
                return true;
            }
        }
    }
}

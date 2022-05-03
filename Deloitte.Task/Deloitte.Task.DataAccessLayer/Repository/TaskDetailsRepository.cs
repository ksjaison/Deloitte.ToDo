namespace Deloite.Task.DataAccessLayer.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Deloitte.Task.DataAccessLayer.Abstractions.Repository;
    using Deloitte.Task.DomainModel;
    using Deloitte.Task.DataAccessLayer.Context;
    using Deloitte.Task.DataAccessLayer.Model;

    public class TaskDetailsRepository : ITaskDetailsRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDetailsRepository"/> class.
        /// </summary>
        /// <param name="mapper">sss.</param>
        public TaskDetailsRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }

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

        public TaskDetailsDomain GetTaskDetailsById(int taskId)
        {
            using (var masterContext = new MasterContext())
            {
                var taskDetails = masterContext.TaskDetails.FirstOrDefault(a => a.Id == taskId);
                return this._mapper.Map<TaskDto, TaskDetailsDomain>(taskDetails);
            }
        }

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

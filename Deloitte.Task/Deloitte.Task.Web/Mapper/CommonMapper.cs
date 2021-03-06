namespace Deloitte.Task.Web.Mapper
{
    using AutoMapper;
    using Deloitte.Task.DataAccessLayer.Model;
    using Deloitte.Task.DomainModel;
    using Deloitte.Task.Web.Models;

    /// <summary>
    /// This class helps auto mapping.
    /// </summary>
    public class CommonMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonMapper"/> class.
        /// </summary>
        public CommonMapper()
        {
            this.CreateMap<TaskDto, ToDoItemViewModel>().ReverseMap();
            this.CreateMap<TaskDetailsDomain, TaskDto>().ReverseMap();
            this.CreateMap<TaskDto, TaskDetailsDomain>().ReverseMap();
            this.CreateMap<TaskDetailsDomain, ToDoItemViewModel>().ReverseMap();
        }
    }
}

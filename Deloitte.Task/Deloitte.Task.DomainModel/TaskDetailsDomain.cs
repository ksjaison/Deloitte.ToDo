namespace Deloitte.Task.DomainModel
{
    using System;

    public class TaskDetailsDomain : Base
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public bool IsTaskChecked { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}

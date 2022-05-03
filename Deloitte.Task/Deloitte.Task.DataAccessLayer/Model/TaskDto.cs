namespace Deloitte.Task.DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TaskDto : Base
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public bool IsTaskChecked { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}

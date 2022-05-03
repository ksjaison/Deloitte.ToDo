namespace Deloitte.Task.DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class of data model class for setting and getting Task related values.
    /// </summary>
    public class TaskDto : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether task is checked.
        /// </summary>
        public bool IsTaskChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Last Updated Date.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}

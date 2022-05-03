namespace Deloitte.Task.DomainModel
{
    using System;

    /// <summary>
    /// Domain class for setting and getting Task items.
    /// </summary>
    public class TaskDetailsDomain : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets TaskName.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets TaskDescription.
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

namespace Deloitte.Task.DomainModel
{
    using System;

    /// <summary>
    /// Base class of domain class for setting and getting Task related values.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Gets or Sets Created By user.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets Updated By.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Updated Date.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
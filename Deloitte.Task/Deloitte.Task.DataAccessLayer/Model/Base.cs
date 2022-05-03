namespace Deloitte.Task.DataAccessLayer.Model
{
    using System;

    /// <summary>
    /// Base class of data model class for setting and getting Task related values.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Gets or Sets Created By.
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
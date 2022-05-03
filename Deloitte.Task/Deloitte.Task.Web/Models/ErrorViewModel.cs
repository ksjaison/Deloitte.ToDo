using System;

namespace TodoListWebApp.Models
{
    /// <summary>
    /// Error view model class.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or Sets Request Id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether Request is checked.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}

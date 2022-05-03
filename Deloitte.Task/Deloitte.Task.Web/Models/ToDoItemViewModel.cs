namespace Deloitte.Task.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This is class for item view model and setting and getting task related values.
    /// </summary>
    public class ToDoItemViewModel
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets TaskName.
        /// </summary>
        [Required(ErrorMessage = "Task Name is required")]
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets TaskDescription.
        /// </summary>
        [Required(ErrorMessage = "Item Description is required")]
        public string TaskDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether task is checked or not.
        /// </summary>
        public bool IsTaskChecked { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdatedDate.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}

namespace Deloitte.Task.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ToDoItemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task Name is required")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Item Description is required")]
        public string TaskDescription { get; set; }

        public bool IsTaskChecked { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}

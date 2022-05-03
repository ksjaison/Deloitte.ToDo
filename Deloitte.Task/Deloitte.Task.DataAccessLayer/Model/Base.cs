namespace Deloitte.Task.DataAccessLayer.Model
{
    using System;

    public class Base
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
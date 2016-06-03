
using System;

namespace WhenToDig90.Data.Entities
{
    public class Job : BaseEntity
    {
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string Plant { get; set; }

        public Job() { }
    }
}

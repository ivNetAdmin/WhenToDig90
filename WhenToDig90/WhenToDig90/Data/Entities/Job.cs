
using SQLite.Net.Attributes;
using System;

namespace WhenToDig90.Data.Entities
{
    public class Job : BaseEntity
    {
        public string Description { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Plant { get; set; }

        [Ignore]
        public string ShortDate {
            get {
                return Date.ToString("dd/MM");
            }            
        }

        [Ignore]
        public string TypeImage
        {
            get
            {
                return string.Format("{0}.png", this.Type.ToLowerInvariant());
            }
        }

        public Job() { }
    }
}

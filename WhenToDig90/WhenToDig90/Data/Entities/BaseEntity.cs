
using SQLite.Net.Attributes;

namespace WhenToDig90.Data.Entities
{
    public class BaseEntity 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}

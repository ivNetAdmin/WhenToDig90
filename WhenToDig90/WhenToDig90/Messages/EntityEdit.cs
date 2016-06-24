
namespace WhenToDig90.Messages
{
    public interface IEntityEdit<T> where T : class
    {
        int Value { get; set; }
    }

    public class EntityEdit<T> : IEntityEdit<T> where T : class
    {
        public int Value { get; set; }
        public string ValueList { get; set; }
    }
}


using System;

namespace WhenToDig90.Messages
{
    public interface IEntityAdded<T> where T : class
    {
        string Message();
        void UpdateMessage(string message);
    }

    public class EntityAdded<T> : IEntityAdded<T> where T : class
    {
        private string _message = "Entity Added";
        public string Message()
        {
            return _message;
        }

        public void UpdateMessage(string message)
        {
            _message = message;
        }
    }
}

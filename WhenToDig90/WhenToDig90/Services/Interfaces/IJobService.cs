
namespace WhenToDig90.Services.Interfaces
{
    public interface IJobService
    {
        Task Add(string name);

        Task<IList<Job>> GetAll();
    }
}

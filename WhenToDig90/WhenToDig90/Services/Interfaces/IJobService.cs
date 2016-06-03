
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data.Entities;

namespace WhenToDig90.Services.Interfaces
{
    public interface IJobService
    {
        Task Add(string name);

        Task<IList<Job>> GetAll();
    }
}

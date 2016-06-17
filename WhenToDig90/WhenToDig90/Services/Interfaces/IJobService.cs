
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data.Entities;

namespace WhenToDig90.Services.Interfaces
{
    public interface IJobService
    {
        Task Add(string name);

        Task Delete(int id);

        void GetAll(Action<Task<List<Job>>, Exception> callback);
        void GetJobsByMonth(Action<Task<List<Job>>, Exception> callback, DateTime date);
        void Get(Action<Task<Job>, Exception> callback, int id);

        //  Task<IList<Job>> GetJobsByMonth(DateTime date);
        Task<int> Save(int jobId, DateTime jobDate, string jobType, string description, string plantName, string notes);
        
    }
}

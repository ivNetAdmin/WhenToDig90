
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data.Entities;

namespace WhenToDig90.Services.Interfaces
{
    public interface IJobService
    {
        Task Add(string name);

        void GetAll(Action<Task<List<Job>>, Exception> callback);

        void GetJobsByMonth(Action<Task<List<Job>>, Exception> callback, DateTime date);

        Task<IList<Job>> GetJobsByMonth(DateTime date);
        Task<int> Save(DateTime jobDate, string jobType, string description, string plantName, string notes);
    }
}

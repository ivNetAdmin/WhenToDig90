
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data.Entities;

namespace WhenToDig90.Services.Interfaces
{
    public interface IJobService
    {
        Task Add(string name);

        Task<IList<Job>> GetAll();
        Task<IList<Job>> GetJobsByMonth(DateTime date);
        Task<Job> Save(DateTime jobDate, string jobType, string description, string plantName, string notes);
    }
}

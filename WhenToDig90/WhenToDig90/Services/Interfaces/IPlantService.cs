using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data.Entities;

namespace WhenToDig90.Services.Interfaces
{
    public interface IPlantService
    {
       // Task Add(string name);

       // Task Delete(int id);

       // void GetAll(Action<Task<List<Job>>, Exception> callback);
       // void GetJobsByMonth(Action<Task<List<Job>>, Exception> callback, DateTime date);
       // void Get(Action<Task<Job>, Exception> callback, int id);

        Task<int> Save(int plantId, string name, string type, string sow, string harvest, string notes);
        Task<int> SaveVariety(string plant, int _varietyId, string name, string plantingNotes, string harvestingNotes);
    }
}

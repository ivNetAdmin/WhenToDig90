using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data;
using WhenToDig90.Data.Entities;
using WhenToDig90.Helpers;
using WhenToDig90.Messages;
using WhenToDig90.Services;
using WhenToDig90.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlantService))]
namespace WhenToDig90.Services
{
 public class PlantService : IPlantService
    {
        private IRepository<Plant> _repository;

        private static readonly AsyncLock Locker = new AsyncLock();

        public JobService()
        {
            _repository = new Repository<Plant>();
        }

        public async Task<int> Save(int plantId, string name, string plantType, string sow, string harvest, string notes)
        {
            if (plantId > 0)
            {
                var plant = await _repository.Get(plantId);
                plant.Name = name;
                plant.Type = plantType;
                plant.Sow = sow;
                plant.Harvest = harvest;
                plant.Notes = notes;

                return await _repository.Update(plant);
            }
            else
            {
                var job = new Job
                {
                    Name = name,
                    Type = plantType,
                    Sow = sow,
                    Harvest = harvest,
                    Notes = notes
                };

                return await _repository.Insert(plant);
            }
        }
    }
}

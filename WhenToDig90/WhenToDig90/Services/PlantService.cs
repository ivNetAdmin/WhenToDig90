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
        private IRepository<Plant> _plantRepository;
        private IRepository<Variety> _varietyRepository;

        private static readonly AsyncLock Locker = new AsyncLock();

        public PlantService()
        {
            _plantRepository = new Repository<Plant>();
            _varietyRepository = new Repository<Variety>();
        }

        public async Task<int> Save(int plantId, string name, string plantType, string sow, string harvest, string notes)
        {
            if (plantId > 0)
            {
                var plant = await _plantRepository.Get(plantId);
                plant.Name = name;
                plant.Type = plantType;
                plant.PlantingTime = sow;
                plant.HarvestingTime = harvest;
                plant.Notes = notes;

                return await _plantRepository.Update(plant);
            }
            else
            {
                var plant = new Plant
                {
                    Name = name,
                    Type = plantType,
                    PlantingTime = sow,
                    HarvestingTime = harvest,
                    Notes = notes
                };

                return await _plantRepository.Insert(plant);
            }
        }

        public async Task<int> SaveVariety(string plant, int varietyId, string name, string plantingNotes, string harvestingNotes)
        {
            if (varietyId > 0)
            {
                var variety = await _varietyRepository.Get(varietyId);
                variety.Name = name;
                variety.PlantName = plant;
                variety.PlantingNotes = plantingNotes;
                variety.HarvestingNotes = harvestingNotes;
                 
                return await _varietyRepository.Update(variety);
            }
            else
            {
                var variety = new Variety
                {
                    Name = name,
                    PlantName = plant,
                    PlantingNotes = plantingNotes,
                    HarvestingNotes = harvestingNotes
                };

                return await _varietyRepository.Insert(variety);
            }
        }
    }
}

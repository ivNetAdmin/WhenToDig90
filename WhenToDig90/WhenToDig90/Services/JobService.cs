
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig90.Data;
using WhenToDig90.Data.Entities;
using WhenToDig90.Helpers;
using WhenToDig90.Services;
using WhenToDig90.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(JobService))]
namespace WhenToDig90.Services
{
 public class JobService : IJobService
    {
        private IRepository<Job> _repository;
       // private IMapper _mapper;

        private static readonly AsyncLock Locker = new AsyncLock();

        public JobService()
        {
            //var mapperConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Job, JobViewModel>();
            //});

            //_mapper = mapperConfig.CreateMapper();

            _repository = new Repository<Job>();
        }

        public async Task Add(string description)
        {
            var entity = new Job
            {
                Description = description
            };

            using (await Locker.LockAsync())
            {
                await _repository.Insert(entity);
            }
        }

        public async Task<IList<Job>> GetAll()
        {
            using (await Locker.LockAsync())
            {
                return await _repository.Get();
            }
        }

        public async Task<IList<Job>> GetJobsByMonth(DateTime date)
        {
            using (await Locker.LockAsync())
            {
                var startDate = new DateTime(date.Year, date.Month, 1);
                var endDate = startDate.AddMonths(1);
                return await _repository.Get(predicate: x => x.Date >= startDate && x.Date < endDate, orderBy: x => x.Date);
            }
        }

        public async Task<Job> Save(DateTime jobDate, string jobType, string description, string plantName, string notes)
        {
            var job = new Job
            {
                Date = jobDate,
                Type = 1,
                Description = description,
                Plant = plantName,
                Notes = notes
            };

            return await _repository.Insert(job);
        }
    }
}


[assembly: Dependency(typeof(JobService))]
namespace WhenToDig90.Services
{
 public class JobService : IJobService
    {
        private IRepository<Job> _repository;
        private IMapper _mapper;

        private static readonly AsyncLock Locker = new AsyncLock();

        public JobService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Job, JobViewModel>();
            });

            _mapper = mapperConfig.CreateMapper();

            _repository = new Repository<Job>();
        }

        public async Task Add(string name)
        {
            var entity = new Job
            {
                Name = name
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
    }
}

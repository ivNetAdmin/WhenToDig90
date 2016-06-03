
namespace WhenToDig90.Data.Entities
{
    public class Plant : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string PlantingTime { get; set; }
        public string HarvestingTime { get; set; }

        public Plant() { }
    }
}


namespace WhenToDig90.Data.Entities
{
    public class Variety : BaseEntity
    {
        public string PlantName { get; set; }
        public string Name { get; set; }
        public string PlantingNotes { get; set; }
        public string HarvestingNotes { get; set; }

        public Variety() { }
    }
}

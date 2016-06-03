
namespace WhenToDig90.Data.Entities
{
    public class Variety : BaseEntity
    {
        public int PlantID { get; set; }
        public string Name { get; set; }
        public string PlantingNotes { get; set; }
        public string HarvestingNotes { get; set; }

        public Variety() { }
    }
}

namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class BuildingType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BuildingCostId { get; set; }
        public BuildingCost BuildingCost { get; set; }

        public List<Building> Buildings { get; set; }
        public List<ProductionOption> ProductionOptions { get; set; }

        public int ResourceTypeId { get; set; }
        ResourceType? ResourceType {get;set;}
    }
}

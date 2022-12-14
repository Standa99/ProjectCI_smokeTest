using dusicyon_midnight_tribes_backend.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class BuildingCost
    {
        public int Id {get;set;}
        public int Amount { get; set; }
        public int Level { get; set; }

        [ForeignKey("BuildingType")]
        public int BuildingTypeId { get; set; }
        BuildingType BuildingType { get; set; }

        [ForeignKey("ResourceType")]
        public int ResourceTypeId { get; set; }
        ResourceType ResourceType {get;set;}
    }
}

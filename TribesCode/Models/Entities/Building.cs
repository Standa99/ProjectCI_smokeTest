using System.ComponentModel.DataAnnotations.Schema;

namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public int BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }

        public int KingdoomId { get; set; }
        public Kingdom Kingdom { get; set; }

        [ForeignKey("Production")]
        public int ProductionId { get; set; }
        public Production Production { get; set; }

    }
}

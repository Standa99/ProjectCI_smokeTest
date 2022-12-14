namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        
        public int UnitTypeId { get; set; }
        
        public int KingdomId { get; set; }
        
        public int ArmyId { get; set; }
        
        public int Attack { get; set; }
        
        public int Defense { get; set; }
        
        public int HPTotal { get; set; }
        
        private int hpCurrent;
        public int HPCurrent
        {
            get
            {
                if(this.hpCurrent>HPTotal)return HPTotal;
                else if (this.hpCurrent < 0) return 0;
                else
                {
                    return this.hpCurrent;
                }
            }
            set
            {
                if (value > HPTotal)
                {
                    this.hpCurrent = HPTotal;
                }
                else if (value < 0)
                {
                    this.hpCurrent = 0;
                }
                else
                {
                    this.hpCurrent = value;
                }                   
            }
            //prevents HPCurrent going below 0 or above HPTotal
        }

        public Unit(int unitTypeId, int kingdomId, int armyId, int attack, int defense, int hpTotal)
        {
            this.UnitTypeId = unitTypeId;
            this.KingdomId = kingdomId;
            this.ArmyId = armyId;
            this.Attack = attack;
            this.Defense = defense;
            this.HPTotal = hpTotal;
            this.HPCurrent = hpTotal; // its setup this way so that the unit start with full hp.
        }
    }
}

namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class UnitType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Attack { get; set; }
        
        public int Defense { get; set; }
        
        public int HPTotal { get; set; }

        public UnitType(string name, int attack, int defense, int hpTotal)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
            this.HPTotal = hpTotal;
        }
    }
}

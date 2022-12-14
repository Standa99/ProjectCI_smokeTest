namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class Army
    {
        public int Id { get; set; }
        
        public int KingdomID { get; set; }
        
        public List<Unit> Units { get; set; }
        
        public Type Type { get; set; }
        
        public Army(int kingdomId, string type)
        {
            this.KingdomID = kingdomId;
            this.Type = (Type)Enum.Parse(typeof(Type),type,true); // has to be parsed from string to enum (boolean value true makes it ignore case)
            this.Units = new List<Unit>();
        }

    }
    public enum Type
    {
        attack,
        defense
    }
    
}


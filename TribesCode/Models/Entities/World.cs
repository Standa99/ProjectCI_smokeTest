namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class World
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Kingdom> Kingdoms { get; set; }

        public World(string name)
        {
            this.Name = name;
            this.Kingdoms = new List<Kingdom>();
        }
    }
}

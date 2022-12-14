namespace dusicyon_midnight_tribes_backend.Models.Entities
{
    public class Kingdom
    {

        public int Id { get; set; }
        public int WorldId { get; set; }
        public World World { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public string Name { get; set; }        
        public int Coordinate_X { get; set; }        
        public int Coordinate_Y { get; set; }
        
        public Kingdom(int world_Id, string name, int coordinate_x, int coordinate_y)
        {
            this.WorldId = world_Id;
            this.Name = name;
            this.Coordinate_X = coordinate_x;
            this.Coordinate_Y = coordinate_y;
        }
    }
}

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Captured { get; set; }
        public bool Evolved { get; set; }
        public int Level { get; set; }
        public Pokemon(string name, int id, string type, bool captured, bool evolved, int level)
        {
            Name = name;
            Id = id;
            Type = type;
            Captured = captured;
            Evolved = evolved;
            Level = level;
        }
    }
}
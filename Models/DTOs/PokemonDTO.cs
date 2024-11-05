namespace PokemonAPI.Models.DTOs
{
    public class PokemonDTO

    {
        public required string Name { get; set; }
        public int Id { get; set; }
        public required string Type { get; set; }
        public bool Captured { get; set; }
        public bool Evolved { get; set; }
    }
}


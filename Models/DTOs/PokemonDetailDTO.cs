namespace PokemonAPI.Models.DTOs
{
    public class PokemonDetailDTO
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Captured { get; set; }
        public bool Evolved { get; set; }
        public int Level { get; set; }
    }
}
namespace CamerounWonders.API.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? PhotoUrl { get; set; }
    }
}

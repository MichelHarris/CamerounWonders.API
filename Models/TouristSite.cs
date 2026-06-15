namespace CamerounWonders.API.Models
{
    public class TouristSite
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int RegionId { get; set; }

        public Region? Region { get; set; }
    }
}

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
        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();
        public ICollection<Favorite> Favorites
        {
            get;
            set;
        }
= new List<Favorite>();
    }
}

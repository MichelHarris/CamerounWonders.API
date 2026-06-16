namespace CamerounWonders.API.Models;

public class Favorite
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User? User { get; set; }

    public int TouristSiteId { get; set; }

    public TouristSite? TouristSite { get; set; }

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
}
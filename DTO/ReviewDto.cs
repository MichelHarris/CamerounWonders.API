namespace CamerounWonders.API.DTOs;

public class ReviewDto
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public int TouristSiteId { get; set; }

    public DateTime CreatedAt { get; set; }
}
namespace CamerounWonders.API.DTOs;

public class CreateReviewDto
{
    public int TouristSiteId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;
}
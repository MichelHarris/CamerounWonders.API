using CamerounWonders.API.DTOs;
using CamerounWonders.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewsController(
        IReviewService service)
    {
        _service = service;
    }

[Authorize]
    [HttpPost]
    public async Task<ActionResult<ReviewDto>>
    Create(CreateReviewDto dto)
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId =
            int.Parse(userIdClaim.Value);

        var review =
            await _service.CreateAsync(
                dto,
                userId);

        return Ok(review);
    }

    [AllowAnonymous]
    [HttpGet("touristsite/{touristSiteId}")]
    public async Task<ActionResult<List<ReviewDto>>>
    GetByTouristSite(
        int touristSiteId)
    {
        var reviews =
            await _service
                .GetByTouristSiteAsync(
                    touristSiteId);

        return Ok(reviews);
    }

    [AllowAnonymous]
    [HttpGet("touristsite/{touristSiteId}/average")]
    public async Task<ActionResult<double>>
    GetAverageRating(
        int touristSiteId)
    {
        var average =
            await _service
                .GetAverageRatingAsync(
                    touristSiteId);

        return Ok(average);
    }
}
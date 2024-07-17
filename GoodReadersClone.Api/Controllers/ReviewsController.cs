using GoodReadersClone.Application.Features.Reviews.Queries;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class ReviewsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("getBookReviews/{bookId}")]
    public async Task<IActionResult> GetBookReviews(int bookId)
    {
        var result = await _sender.Send(new GetBookReviewsQuery(bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("getReaderReviews/{readerId}")]
    public async Task<IActionResult> GetReaderReviews(string readerId)
    {
        var result = await _sender.Send(new GetReaderReviewsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("getReaderBookReview")]
    public async Task<IActionResult> GetReaderReviews(string readerId, int bookId)
    {
        return Forbid();
    }

    [HttpGet]
    [Route("getBookOverallRating")]
    public async Task<IActionResult> GetBookOverallRating(int bookId, int NoOfStars = 0)
    {
        return Forbid();
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create()
    {
        return Forbid();
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> Edit()
    {
        return Forbid();
    }

    [HttpDelete]
    [Route("")]
    public async Task<IActionResult> Delete()
    {
        return Forbid();
    }
}

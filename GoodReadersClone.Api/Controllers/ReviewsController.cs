using GoodReadersClone.Application.DTOs.Review;
using GoodReadersClone.Application.Features.Reviews.Commands;
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
    public async Task<IActionResult> GetReaderBookReview(string readerId, int bookId)
    {
        var result = await _sender.Send(new GetReaderBookReviewQuery(readerId, bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("getBookRatingSummary")]
    public async Task<IActionResult> GetBookRatingSummary(int bookId)
    {
        var result = await _sender.Send(new GetBookRatingSummaryQuery(bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create(ReviewRequest request)
    {
        var result = await _sender.Send(new CreateReviewCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> Edit(string readerId, int bookId, EditReviewRequest request)
    {
        var result = await _sender.Send(new EditReviewCommand(readerId, bookId, request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("")]
    public async Task<IActionResult> Delete()
    {
        return Forbid();
    }
}

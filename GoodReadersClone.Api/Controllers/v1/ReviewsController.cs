using GoodReadersClone.Application.Features.Reviews.Commands;
using GoodReadersClone.Application.Features.Reviews.Queries;
using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Api.Controllers.v1;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
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
    [Authorize]
    public async Task<IActionResult> GetReaderReviews(string readerId)
    {
        var result = await _sender.Send(new GetReaderReviewsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("getReaderBookReview")]
    [Authorize]
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
    [Authorize(Roles = Roles.READER)]
    public async Task<IActionResult> Create(ReviewRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateReviewCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("")]
    [Authorize(Roles = Roles.READER)]
    public async Task<IActionResult> Edit(int bookId, EditReviewRequest request)
    {
        var readerId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new EditReviewCommand(readerId, bookId, request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("")]
    [Authorize(Roles = Roles.READER)]
    public async Task<IActionResult> Delete(int bookId)
    {
        var readerId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new DeleteReviewCommand(readerId, bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }
}

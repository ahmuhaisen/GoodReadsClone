using GoodReadsClone.Application.Features.Reviews.Commands;
using GoodReadsClone.Application.Features.Reviews.Queries;

namespace GoodReadsClone.Api.Controllers.v1;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ReviewsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    [Route("reader/{readerId}")]
    [Authorize]
    public async Task<IActionResult> GetReaderReviews(string readerId)
    {
        var result = await _sender.Send(new GetReaderReviewsQuery(readerId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }


    [HttpGet]
    [Route("book/{bookId}")]
    public async Task<IActionResult> GetBookReviews(int bookId)
    {
        var result = await _sender.Send(new GetBookReviewsQuery(bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetValue([FromQuery] string readerId, [FromQuery] int bookId)
    {
        var result = await _sender.Send(new GetReaderBookReviewQuery(readerId, bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("book/{bookId}/summary")]
    public async Task<IActionResult> GetBookRatingSummary(int bookId)
    {
        var result = await _sender.Send(new GetBookRatingSummaryQuery(bookId));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = Roles.READER)]
    public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
    {
        request.ReaderId = User.FindFirst("uid")!.Value;

        var result = await _sender.Send(new CreateReviewCommand(request));

        if (!result.Success)
            return NotFound(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("{bookId}")]
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
    [Route("{bookId}")]
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

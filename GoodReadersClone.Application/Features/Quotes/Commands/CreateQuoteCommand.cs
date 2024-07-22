using GoodReadsClone.Application.DTOs.Quote;

namespace GoodReadsClone.Application.Features.Quotes.Commands;
public record CreateQuoteCommand(QuoteDto Model) : IRequest<ApiResponse>;
public record DeleteQuoteCommand(int Id) : IRequest<ApiResponse>;


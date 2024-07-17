﻿using GoodReadersClone.Application.DTOs.Quote;

namespace GoodReadersClone.Application.Features.Quotes.Commands;
public record CreateQuoteCommand(QuoteModel Model) : IRequest<ApiResponse>;
public record DeleteQuoteCommand(int Id) : IRequest<ApiResponse>;

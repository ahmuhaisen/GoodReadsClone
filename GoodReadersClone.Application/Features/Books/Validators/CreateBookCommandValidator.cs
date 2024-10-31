// Ignore Spelling: Validator
using FluentValidation;
using GoodReadsClone.Application.Features.Books.Commands;

namespace GoodReadsClone.Application.Features.Books.Validators;

public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(c => c.Request.Title)
            .MinimumLength(10);

        RuleFor(c => c.Request.Description)
            .MinimumLength(10);

        RuleFor(c => c.Request.ISBN)
            .MinimumLength(10)
            .MustAsync(beAUniqueISBN)
            .WithMessage("ISBN already exist");

       // RuleFor(c => c.Request.FirstPublished).Must(beAValidDate);

        _unitOfWork = unitOfWork;
    }

    private bool beAValidDate(DateTime date) => date.Equals(default);
    private async Task<bool> beAUniqueISBN(string isbn, CancellationToken cancellationToken) => await _unitOfWork.BookRepository.IsISBNUniqueAsync(isbn);
}
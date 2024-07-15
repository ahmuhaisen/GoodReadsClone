using Bogus;
using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Infrastructure.Helpers;
public class DatabaseSeeder
{

    public IReadOnlyCollection<Book> Books { get; } = new List<Book>();
    public IReadOnlyCollection<Genre> Genres { get; } = new List<Genre>();
  

    public DatabaseSeeder()
    {
        Books = GenerateBooks(amount: 1000);
        Genres = GenerateGenres();
    }


    public IReadOnlyCollection<Genre> GenerateGenres()
    {
        return new List<Genre>()
        {
             new Genre()  {Id = 1, Name = "Fiction"},
             new Genre() {Id = 2, Name = "Non-Fiction"},
             new Genre() {Id = 3, Name = "Science Fiction"},
             new Genre() {Id = 4, Name = "Fantasy"},
             new Genre() {Id = 5, Name = "Biography"},
             new Genre() {Id = 6, Name = "History"},
             new Genre() {Id = 7, Name = "Mystery"},
             new Genre() {Id = 8, Name = "Romance"},
             new Genre() {Id = 9, Name = "Horror"},
             new Genre() {Id = 10, Name = "Self-Help"}
        };
    }

    public IReadOnlyCollection<Book> GenerateBooks(int amount)
    {
        var authors = new List<string>()
        {
            "6d144b3a-5122-4434-a603-8c8454cfda66",
            "5d97e774-2e5f-4083-a973-912858ca754e",
            "46cbaa02-042b-4449-9d2a-cad688f98630",
            "b827bcc0-e58e-4855-910c-68d38259e3ad"
        };

        var bookId = 1;
        var bookFacker = new Faker<Book>()
            .RuleFor(b => b.Id, f => bookId++)
            .RuleFor(b => b.AuthorId, f => authors[Random.Shared.Next(0, authors.Count() - 1)])
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
            .RuleFor(b => b.Description, f => f.Lorem.Sentence(25))
            .RuleFor(b => b.CoverURL, f => $"\\images\\books-covers\\{f.Random.Guid()}.jpg")
            .RuleFor(b => b.ISBN, f => f.Commerce.Ean13())
            .RuleFor(b => b.FirstPublished, f => f.Date.Past(50));


        var books = Enumerable.Range(1, amount)
            .Select(i => SeedRow(bookFacker, i))
            .ToList();


        return books;
    }


    private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        var recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}





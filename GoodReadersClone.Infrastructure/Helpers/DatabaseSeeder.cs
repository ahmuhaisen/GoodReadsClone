using Bogus;
using GoodReadersClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GoodReadersClone.Infrastructure.Helpers;
public class DatabaseSeeder
{

    public IReadOnlyCollection<Author> Authors { get; } = new List<Author>();
    public IReadOnlyCollection<Book> Books { get; } = new List<Book>();
    public IReadOnlyCollection<Genre> Genres { get; } = new List<Genre>();
  

    public DatabaseSeeder()
    {
        Books = GenerateBooks(amount: 100);
        Authors = GenerateAuthors(amount: 5);
        Genres = GenerateGenres();
    }


    public IReadOnlyCollection<Genre> GenerateGenres()
    {
        return new List<Genre>()
        {
             new Genre() { Name = "Fiction"},
             new Genre() { Name = "Non-Fiction"},
             new Genre() { Name = "Science Fiction"},
             new Genre() { Name = "Fantasy"},
             new Genre() { Name = "Biography"},
             new Genre() { Name = "History"},
             new Genre() { Name = "Mystery"},
             new Genre() { Name = "Romance"},
             new Genre() { Name = "Horror"},
             new Genre() { Name = "Self-Help"}
        };
    }

    public IReadOnlyCollection<Book> GenerateBooks(int amount)
    {
        var authors = new List<string>()
        {
            "0e67f4f5-e108-cd67-516d-e5a99e89e2eb",
            "1a273f2d-012a-ff97-9a81-02a524ad2f5e",
            "206d876b-3c61-40a1-9ddf-a24c6c73bd89",
            "467cf5f3-2cdf-062f-d926-edf7c086c59d",
            "5535fcef-40d5-200b-cc0a-21f2ad3a5df7",
            "6c6f0740-a9ec-0133-d897-0620a5f82b0a",
            "93f8c166-948a-a823-81bd-a1586288057f",
            "9a893d7e-4473-ac4f-9624-b34d74bd7f9f",
            "9cc6fee1-529b-135f-273b-10b9dde6c048",
            "a1cdafab-03b8-1943-7657-b2c15e9e7f9f",
            "abae4676-08c3-c72c-7f33-2971abf504b4",
            "b5656302-940a-be51-2e0f-8620e9df6b9b",
            "b7825fda-8ad6-34e3-9fcc-73eab34e88c6",
            "c343a760-bd64-b02e-7ffd-bf22c54a54f9",
            "eb07c8de-4431-b0cd-9072-9a4236eeaba3"
        };

        var bookId = 1111;
        var bookFacker = new Faker<Book>()
            .RuleFor(b => b.AuthorId, f => authors[Random.Shared.Next(0, authors.Count() - 1)])
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
            .RuleFor(b => b.Description, f => f.Lorem.Sentence(25))
            .RuleFor(b => b.CoverURL, f => $"\\images\\books-covers\\{f.Random.Guid()}.jpg")
            .RuleFor(b => b.ISBN, f => f.Commerce.Ean13())
            .RuleFor(b => b.FirstPublished, f => f.Date.PastOffset(
                refDate: new DateTimeOffset(2024, 1, 16, 15, 15, 0, TimeSpan.FromHours(1))).DateTime);


        var books = Enumerable.Range(1, amount)
            .Select(i => SeedRow(bookFacker, i))
            .ToList();


        return books;
    }

    public static IReadOnlyCollection<Author> GenerateAuthors(int amount)
    {
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        var consistentPassword = "Aa123*";
        var hashedPassword = passwordHasher.HashPassword(new ApplicationUser(), consistentPassword);

        var authorFaker = new Faker<Author>()
            .RuleFor(b => b.Id, f => f.Random.Guid().ToString())
            .RuleFor(b => b.FirstName, f => f.Name.FirstName())
            .RuleFor(b => b.LastName, f => f.Name.LastName())
            .RuleFor(b => b.UserName, f => f.Internet.UserName())
            .RuleFor(b => b.Email, f => f.Internet.Email())
            .RuleFor(b => b.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(b => b.DateOfBirth, f => f.Date.PastOffset(
                refDate: new DateTimeOffset(2024, 1, 16, 15, 15, 0, TimeSpan.FromHours(1))).DateTime)
            .RuleFor(b => b.JoindAt, f => f.Date.PastOffset(
                refDate: new DateTimeOffset(2024, 1, 16, 15, 15, 0, TimeSpan.FromHours(1))).DateTime)
            .RuleFor(b => b.Discrimintator, f => "Author")
            .RuleFor(b => b.PasswordHash, _ => hashedPassword);

        var authors = Enumerable.Range(1, amount)
            .Select(i => authorFaker.Generate())
            .ToList();

        return authors;
    }


    private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        var recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}
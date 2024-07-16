using Bogus;
using GoodReadersClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GoodReadersClone.Infrastructure.Helpers;
public class DatabaseSeeder
{

    public IReadOnlyCollection<Author> Authors { get; } = new List<Author>();
    public IReadOnlyCollection<ApplicationUser> Users { get; } = new List<ApplicationUser>();
    public IReadOnlyCollection<Book> Books { get; } = new List<Book>();
    public IReadOnlyCollection<Genre> Genres { get; } = new List<Genre>();
    public IReadOnlyCollection<Quote> Quotes { get; } = new List<Quote>();


    public DatabaseSeeder()
    {
        Books = GenerateBooks(amount: 100);
        Authors = GenerateAuthors(amount: 150);
        Genres = GenerateGenres();
        Users = GenerateUsers(amount: 500);
        Quotes = GenerateQuotes(amount:500);
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

    public static IReadOnlyCollection<ApplicationUser> GenerateUsers(int amount)
    {
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        var consistentPassword = "Aa123*";
        var hashedPassword = passwordHasher.HashPassword(new ApplicationUser(), consistentPassword);

        var usersFaker = new Faker<ApplicationUser>()
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
            .RuleFor(b => b.ProfilePectureURL, f => $"\\images\\profile-pictures\\{f.Random.Guid()}.jpg")
            .RuleFor(b => b.Discrimintator, f => "ApplicationUser")
            .RuleFor(b => b.PasswordHash, _ => hashedPassword);

        var users = Enumerable.Range(1, amount)
            .Select(i => usersFaker.Generate())
            .ToList();

        return users;
    }


    public static IReadOnlyCollection<Quote> GenerateQuotes(int amount)
    {
        var UsersList = new List<string>()
        {
            "033e42f3-5267-7aa4-607c-9492775b81c4",
            "03661a93-c6f0-7d22-a9a7-8b8077577848",
            "037a1034-db31-05cc-4ead-64d8927ed1a5",
            "03f5e466-5465-92c0-584c-430705d462fe",
            "05d76301-c110-3360-f04d-9a94c95dbc21",
            "05facba4-d0ec-3357-e42b-81726f29c621",
            "061110fe-a5e9-ac0c-8c3d-55533074ab5d",
            "062a467b-f8fb-f338-3181-d459417247d3",
            "06916266-321b-a51e-ca81-27d68960b571",
            "08ffebb7-3382-b998-ead1-7b92040d59ff",
            "09092821-8d83-688f-127f-c8b14e3e4357",
            "09147d33-f8c8-b477-2dc0-63186bb35665",
            "097fa9fc-1f56-26a3-6461-7d8696d3d5f5",
            "0a20cf0c-f53f-7257-436c-8551ab148fd9",
            "0e912922-2a9d-6755-8678-39d48b53f827",
            "0ed01751-5cc9-0954-3c5e-aee6c8515096",
            "0f3681dd-aebf-ae29-0990-1d86f4bbacd2",
            "0f821dc1-9e18-7504-f795-46c1fc55b196",
            "0feca10d-807b-d24f-d5e0-c2115424d8db",
            "0ff65af8-fe1b-b019-0524-525d9008ce47",
            "105f0763-8753-2e01-a0a6-1778db96386d",
            "1b6bfd60-b72f-47c1-0731-9c5d1398ba10",
            "1b72e56d-e6f5-36e5-25ba-e1de0f97e933",
            "1b9ddd98-68a7-f4ba-eee1-30fb536c5ad2",
            "1cdb7065-e3ab-767b-d3bf-2141c3d34ae1",
            "1d428cbe-077c-e9e9-ad62-5fc43c72bfb3",
            "1d6f5aaa-1a54-7631-b712-b53c3c12f3e2",
            "1db1977e-458c-8684-8916-838248243647",
            "1fbc90a5-12a6-5142-5d0a-b36f49b7a43f",
            "20551761-8d21-2f46-92a1-eb2cd751d472",
        };   


        var QuoteFaker = new Faker<Quote>()
            .RuleFor(b => b.Body, f => f.Lorem.Paragraph())
            .RuleFor(b => b.UserId, _ => UsersList[Random.Shared.Next(0, UsersList.Count() - 1)])
            .RuleFor(b => b.BookId, _ => Random.Shared.Next(1, 5000));

        var quotes = Enumerable.Range(1, amount)
            .Select(i => QuoteFaker.Generate())
            .ToList();

        return quotes;
    }


    private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        var recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}
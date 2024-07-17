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
    public IReadOnlyCollection<AuthorFollowing> AuthorFollowings { get; } = new List<AuthorFollowing>();
    public IReadOnlyCollection<Review> Reviews { get; } = new List<Review>();


    public DatabaseSeeder()
    {
        Books = GenerateBooks(amount: 100);
        Authors = GenerateAuthors(amount: 150);
        Genres = GenerateGenres();
        Users = GenerateUsers(amount: 500);
        Quotes = GenerateQuotes(amount: 500);
        AuthorFollowings = GenerateAuthorFollowings();
        Reviews = GenerateReviews(amount: 5);
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

    public static IReadOnlyCollection<AuthorFollowing> GenerateAuthorFollowings()
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
        var users = new List<string>()
        {
            "b6b0221c-7880-9334-80c5-fac5c2ce4c9a",
            "b6d5b752-7130-e38b-b06e-ac64b5cfac0e",
            "b707d28d-be32-48d0-c744-95bae8e9bdc8",
            "b773cfc3-8323-5b1a-a6cd-92f47fc43b36",
            "bbab1923-5464-5138-ea29-a22082eb78d0",
            "bbcf3153-f602-e81c-2d4e-0780be26f484",
            "bcfff5c4-bd8e-4b41-4ac7-8c6e7afe4af1",
            "bd392ea9-e34e-d83e-40a8-2bb7e1833fb8",
            "bdf53b6b-6dbf-e62f-bfd8-2e27b5100806",
            "be11ff51-9a20-b469-5c32-535d17ac72ff",
            "be1bd1ed-bc2b-980f-98d2-7b55ccef023e",
            "befa7b91-0c03-85dc-3d49-d9813f400dc8",
            "bf1d649b-acd7-32cb-9c4f-5876709899b7",
            "bf332c9c-d21a-02e0-4812-e8a3645fce9b",
            "bf3d445e-f849-4efa-c155-a3ef3e7addd6",
            "c0ae716c-1c92-2e05-7f68-f50287523972",
            "c0caccfc-ab08-1adf-ff5d-821ea0d1552c",
            "c0d9b880-ef34-8b09-1809-74af14661cbd",
            "c543d2b4-e4e5-1e00-6eb5-5e74c844290a",
            "c5cd1af9-8e81-bef1-db04-bc0c76a0eb02",
            "c63b542d-8c95-b82a-f875-96f4fc04d377",
            "c6900607-1a26-399f-8097-633dc863d7fa",
            "c7403b8c-1818-7a21-477c-c2aea7756fc2",
            "c7a40e32-821f-be1c-d7c9-948080a19a18",
            "c7ded5be-0e43-a455-7ea4-d1d5bef66cfd",
            "c839c1f9-fba7-097d-2550-72ef63b9faef",
            "c8732a20-da58-f261-ca79-09c5d20ecac8",
            "c8767f7e-e392-c78f-6066-969ff97442e9",
            "c8fd3e81-a253-1c12-e4d9-4bbbc4a47a7f",
            "c91ffa8d-eeda-b900-7bb7-b9c448095521",
            "c9b8564f-7911-a03a-dbbc-ee1301cfb81e",
            "ca51a09c-d44a-5021-6c39-f6280ef0344b",
            "cacaf64f-429d-d9a3-61d1-edaf60f05979",
            "caf15277-3471-c4be-f88e-38ad618c39ff",
            "cb2ab34a-22be-bb2d-de87-87bcbfaaa3ce",
            "cb9924a6-a101-aa64-6c1d-e59d2777b2cd",
            "ccd52449-3533-5e87-9499-4621241db852",
            "cd08aace-c226-754b-4ef4-46bc5f6172aa",
            "cd481f98-24e1-408a-aee9-a8b8afe34e64",
            "cd621766-02f0-3bcd-ab1b-c08a3de6085f",
            "ce142bb1-5bb2-9097-6472-634b0bd01f9b",
            "ce1a098d-0926-5c26-fa64-06403c4e2e4e"
        };

        var authorFollowings = (from authorId in authors
                                from userId in users
                                select new AuthorFollowing
                                {
                                    AuthorId = authorId,
                                    ApplicationUserId = userId
                                }).ToList();

        return authorFollowings;
    }

    public static IReadOnlyCollection<Review> GenerateReviews(int amount)
    {
        int counter = 1;
        var reviewFaker = new Faker<Review>()
            .RuleFor(r => r.ReaderId, _ => "b6b0221c-7880-9334-80c5-fac5c2ce4c9a")
            .RuleFor(r => r.BookId, _ => counter++)
            .RuleFor(r => r.Rating, f => f.Random.Number(0, 5))
            .RuleFor(r => r.Text, f => f.Lorem.Text())
            .RuleFor(r => r.CreatedAt, f => f.Date.Past());

        var reviews = Enumerable.Range(1, amount)
        .Select(i => reviewFaker.Generate())
        .ToList();

        return reviews;
    }


    private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
    {
        var recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}
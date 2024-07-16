using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using GoodReadersClone.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("tests")]
public class TestsController(ApplicationDbContext db, UserManager<ApplicationUser> manager) : ControllerBase
{
    [HttpPost]
    [Route("seed")]
    public async Task<IActionResult> seed()
    {
        var seeder = new DatabaseSeeder();
        //List<Author> data = seeder.Authors.ToList();
        //List<Book> data = seeder.Books.ToList();
        //List<Genre> data = seeder.Genres.ToList();
        //List<ApplicationUser> data = seeder.Users.ToList();
        //List<Quote> data = seeder.Quotes.ToList();



        //db.AddRange(data);
        //var r = db.SaveChanges();

        //foreach (var user in data)
        //    await manager.AddToRoleAsync(user, Roles.AUTHOR);


        return Ok();
    }
}

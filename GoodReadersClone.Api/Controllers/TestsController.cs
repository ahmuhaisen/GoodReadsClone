using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using GoodReadersClone.Infrastructure.Helpers;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("tests")]
public class TestsController(ApplicationDbContext db) : ControllerBase
{
    [HttpPost]
    [Route("seed")]
    public IActionResult seed()
    {
        var seeder = new DatabaseSeeder();
        //List<Author> data = seeder.Authors.ToList();
        //List<Book> data = seeder.Books.ToList();
        //List<Genre> data = seeder.Genres.ToList();


        //db.AddRange(data);


        return Ok(db.SaveChanges());
    }
}

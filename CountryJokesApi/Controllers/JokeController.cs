using CountryJokesApi.Database;
using CountryJokesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryJokesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly JokesDbContext _context;

        public JokeController(JokesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Joke>> GetRandomJoke([FromQuery] string country)
        {
            var jokes = await _context.Jokes.Where(j => j.Country.ToLower() == country.ToLower()).ToListAsync();


            if (jokes == null || jokes.Count == 0)
            {
                return NotFound();
            }

            var random = new Random();
            var joke = jokes[random.Next(jokes.Count)];

            return Ok(joke);
        }
    }
}

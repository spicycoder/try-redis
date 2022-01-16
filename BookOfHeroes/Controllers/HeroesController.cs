using BookOfHeroes.Models;
using Microsoft.AspNetCore.Mvc;
using Redis.OM;

namespace BookOfHeroes.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly RedisConnectionProvider _redisConnectionProvider;

        public HeroesController(RedisConnectionProvider redisConnectionProvider)
        {
            _redisConnectionProvider = redisConnectionProvider;
        }

        [HttpPost, ActionName("")]
        public async Task<IActionResult> AddHero([FromBody] Hero[] heroes)
        {
            var heroesCollection = _redisConnectionProvider.RedisCollection<Hero>();

            foreach (var hero in heroes)
            {
                var id = await heroesCollection.InsertAsync(hero);
            }

            return Ok();
        }

        [HttpGet, ActionName("")]
        public async Task<ActionResult<Hero>> GetHero([FromQuery] string id)
        {
            var heroes = _redisConnectionProvider.RedisCollection<Hero>();
            var hero = await heroes.FindByIdAsync(id);
            return hero != null ? hero : NotFound();
        }

        [HttpGet, ActionName("search")]
        public ActionResult<IEnumerable<Hero>> SearchHeroes([FromQuery] string universe)
        {
            var heroes = _redisConnectionProvider.RedisCollection<Hero>();
            var result = heroes
                .Where(x => x.Universe == universe)
                .ToList();

            return Ok(result);
        }
    }
}

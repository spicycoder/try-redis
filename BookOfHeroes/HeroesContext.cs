using BookOfHeroes.Models;
using Redis.OM;
using Redis.OM.Searching;

namespace BookOfHeroes;

public class HeroesContext
{
    public IRedisCollection<Hero> Heroes { get; init; }

    public HeroesContext(string connectionString)
    {
        var provider = new RedisConnectionProvider(connectionString);

        Heroes = provider.RedisCollection<Hero>();
    }
}
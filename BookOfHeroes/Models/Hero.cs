using Redis.OM.Modeling;

namespace BookOfHeroes.Models;

[Document(StorageType = StorageType.Json)]
public class Hero
{
    [Indexed]
    public string Name { get; set; }

    [Indexed]
    public string Identity { get; set; }

    [Searchable]
    public string Universe { get; set; }
}
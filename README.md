# Redis .NET

Try Redis in ASP.NET application

- [ ] Caching
- [x] Persistance Database

---

## Getting Started

Run an instance of RedisJson

```ps1
docker run --rm -d --name myredis -p 6379:6379 redislabs/rejson
```

And launch the application

Once done, run

```ps1
docker stop myredis
```

---

## Data Setup

Insert bulk data, through the `POST` end point

```json
[
    {
      "name": "Spiderman",
      "identity": "Peter Parker",
      "universe": "Marvel"
    },
    {
      "name": "Ironman",
      "identity": "Tony Stark",
      "universe": "Marvel"
    },
    {
      "name": "Hulk",
      "identity": "Bruce Banner",
      "universe": "Marvel"
    },
    {
      "name": "Superman",
      "identity": "Clark Kent",
      "universe": "DC"
    },
    {
      "name": "Batman",
      "identity": "Bruce Wayne",
      "universe": "DC"
    }
  ]
```

---

## Concerns

### How to identify, if index already exist?

When running the application for 2nd time (keeping redis continue running), the index already exist.

```cs
redisConnectionProvider?.Connection.CreateIndex(typeof(Hero));
```

Is there a way to contitionally create index?

### Not all properties can be searchable

If all properties are attributes with `Searchable`, it complains about `IndexAttribute` not found.

---

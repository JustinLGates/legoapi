using System;
using System.Collections.Generic;
using legomylego.Models;
using legomylego.Reopsitories;

namespace legomylego.Services
{
  public class KitsService
  {
    private readonly KitRepository _repo;
    public KitsService(KitRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Kit> Get()
    {
      return _repo.Get();

    }

    internal Kit Get(int id)
    {
      Kit found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("invalid id mi amigo");
      }
      return found;
    }

    internal Kit Create(Kit newKit)
    {
      int id = _repo.Create(newKit);
      newKit.Id = id;
      return newKit;
    }

    internal Kit Delete(int id)
    {
      Kit found = Get(id);
      _repo.Delete(id);
      return found;
    }
  }
}
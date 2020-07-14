using System;
using legomylego.Models;
using legomylego.Reopsitories;
using System.Collections.Generic;

namespace legomylego.Services
{
  public class LegoService
  {
    private readonly LegoRepository _repo;
    public LegoService(LegoRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Lego> Get()
    {
      return _repo.Get();

    }

    internal Lego Get(int id)
    {
      Lego found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("invalid id mi amigo");
      }
      return found;
    }

    internal Lego Create(Lego newLego)
    {
      int id = _repo.Create(newLego);
      newLego.Id = id;
      return newLego;
    }

    internal Lego Delete(int id)
    {
      Lego found = Get(id);
      _repo.Delete(id);
      return found;
    }
  }
}
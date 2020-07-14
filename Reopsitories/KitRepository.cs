using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legomylego.Models;

namespace legomylego.Reopsitories
{
  public class KitRepository
  {
    private readonly IDbConnection _db;
    public KitRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Kit> Get()
    {
      throw new NotImplementedException();
    }

    internal Kit Get(int id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal int Create(Kit newKit)
    {
      throw new NotImplementedException();
    }
  }
}
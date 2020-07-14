using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legomylego.Models;

namespace legomylego.Reopsitories
{
  public class LegoKitRepository
  {
    private readonly IDbConnection _db;
    public LegoKitRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(DTOLegoKit newDTOLegoKit)
    {
      throw new NotImplementedException();
    }

    internal DTOLegoKit Get(int id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
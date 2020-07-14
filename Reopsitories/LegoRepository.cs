using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legomylego.Models;

namespace legomylego.Reopsitories
{
  public class LegoRepository
  {
    private readonly IDbConnection _db;
    public LegoRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}
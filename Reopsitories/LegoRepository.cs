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

    internal int Create(Lego newLego)
    {
      string sql = @"
      INSERT INTO legos(x,y)
      VALUES(@X,@Y);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newLego);
    }

    internal IEnumerable<Lego> Get()
    {
      string sql = "SELECT * FROM legos";
      return _db.Query<Lego>(sql);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM legos WHERE id = @id;";
      _db.ExecuteScalar(sql, new { id });

    }

    internal Lego Get(int id)
    {
      string sql = "SELECT * FROM legos WHERE id = @id;";
      return _db.QueryFirstOrDefault<Lego>(sql, new { id });
    }
  }
}
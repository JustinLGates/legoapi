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

    internal int Create(Kit newKit)
    {
      string sql = @"
      INSERT INTO kits(price,description,name)
      VALUES(@Price,@Description,@Name);
      SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, newKit);
    }

    internal IEnumerable<Kit> Get()
    {
      string sql = "SELECT * FROM kits";
      return _db.Query<Kit>(sql);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM kits WHERE id = @id;";
      _db.ExecuteScalar(sql, new { id });

    }

    internal Kit Get(int id)
    {
      string sql = "SELECT * FROM kits WHERE id = @id;";
      return _db.QueryFirstOrDefault<Kit>(sql, new { id });
    }
  }
}
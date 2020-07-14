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
      string sql = @"
      INSERT INTO legokits(x,y);
      VALUES(@X,@Y);
      SELECT LAST_INSERT_ID";
      return _db.ExecuteScalar<int>(sql, newDTOLegoKit);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM legokits WHERE id = @id;";
      _db.ExecuteScalar(sql, new { id });

    }

    internal DTOLegoKit Get(int id)
    {
      string sql = "SELECT FROM legokits WHERE id = @id;";
      return _db.QueryFirstOrDefault<DTOLegoKit>(sql, new { id });
    }
  }
}
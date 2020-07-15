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
      INSERT INTO legokits(kitId,legoId)
      VALUES(@KitId,@LegoId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newDTOLegoKit);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM legokits WHERE id = @id;";
      _db.ExecuteScalar(sql, new { id });

    }

    internal LegoKitHelper Get(int id)
    {

      string sql = @"
      SELECT *,
      l.x as X,
      k.price as Price, 
      lk.id as legokitId FROM legoKits lk
      INNER JOIN legos l ON l.id = lk.legoId
      INNER JOIN kits k ON k.id = lk.kitId
      WHERE lk.legoId = @id;";
      return _db.QueryFirstOrDefault<LegoKitHelper>(sql, new { id });
    }
  }
}
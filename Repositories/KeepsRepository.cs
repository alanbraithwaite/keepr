using System;
using System.Data;
using Keepr.Models;
using Dapper;
namespace keepr.Repositories
{
  public class KeepsRepository
  {

    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // GetAll
    public object GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keep");
    }

    // GetById
    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keep WHERE id=@id", new { id });
    }

    // AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      ISERT INTO Keep(name, description, userId, img, isPrivate, views, shares, keeps)
      Values(@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();",
       newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep UpdateKeep(Keep value)
    {


      throw new NotImplementedException();
    }

    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"DELETE FROM Keep WHERE id = @id", new { id });
      return success != 0;
    }

  }
}
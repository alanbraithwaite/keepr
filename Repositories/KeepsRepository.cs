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

    // GetAllPublicKeeps
    public object GetAllPublicKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM Keeps WHERE isPrivate = 0");
    }


    // GetAllCurrentUserKeeps
    public object GetAllCurrentUserKeeps(string id)
    {
      return _db.Query<Keep>(@"SELECT * FROM Keeps WHERE userId=@id", new { id });
    }


    // GetById
    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id=@id", new { id });
    }

    // AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, userId, img, isPrivate, views, shares, keeps)
      Values(@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();",
       newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    // UpdateKeep 
    public Keep UpdateKeep(Keep value)
    {
      int success = _db.Execute(@"UPDATE keeps SET 
      name = @Name, description=@Description, img=@Img, isPrivate=@IsPrivate, 
      views=@Views, shares=@Shares, keeps=@Keeps
      WHERE id =@id 
      ", value);

      if (success != 1) return null;
      return value;
    }

    // DeleteKeep 
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"DELETE FROM Keeps WHERE id = @id", new { id });
      return success != 0;
    }

  }
}
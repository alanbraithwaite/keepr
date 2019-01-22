using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {


    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    // GetAll
    public object GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM Vaults");
    }

    public object GetByUserId(string userId)
    {
      return _db.Query<Vault>(@"SELECT * FROM Vaults WHERE userId = @userId", new { userId });
    }


    // GetById
    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id=@id", new { id });
    }

    // AddVault
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Vaults(name, description, userId)
      Values(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();",
       newVault);
      newVault.Id = id;
      return newVault;
    }

    public Vault UpdateVault(Vault value)
    {
      throw new NotImplementedException();
    }

    // DeleteVault
    public bool DeleteVault(int id, string userId)
    {
      int success = _db.Execute(@"DELETE FROM vaults WHERE id = @id AND userId=@userId", new { id, userId });
      return success != 0;
    }



  }
}
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
      return _db.Query<Vault>("SELECT * FROM Vault");
    }

    // GetById
    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vault WHERE id=@id", new { id });
    }

    // AddVault
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      ISERT INTO Vault(name, description, userId)
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
    public bool DeleteVault(int id)
    {
      int success = _db.Execute(@"DELETE FROM Vault WHERE id = @id", new { id });
      return success != 0;
    }



  }
}
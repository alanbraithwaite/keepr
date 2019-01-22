using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;

    }


    //GetKeepsByVaultId
    public IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      return _db.Query<Keep>($@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE (vaultId = @id);
      ", new { id });
    }

    //GetVaultsByKeepId
    // public IEnumerable<Vault> GetVaultsByKeepId(int id)
    // {
    //   return _db.Query<Vault>($@"
    //     SELECT * FROM vaultkeeps vk
    //     INNER JOIN vault v ON v.id = vk.vaultId
    //     WHERE (keepId = @id);
    //   ", new { id });
    // }


    //AddVaultKeep
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO VaultKeeps(keepId, vaultId, userId)
      VALUES(@KeepId, @VaultId, @UserId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }

    //DeleteVaultKeep

    public bool DeleteVaultKeep(VaultKeep vk)
    {
      int success = _db.Execute(@"DELETE FROM VaultKeeps WHERE keepId = @KeepId AND vaultId = @VaultId AND userId = @UserId", vk);
      return success != 0;

    }


  }
}
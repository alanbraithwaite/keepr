using System.Collections.Generic;
using keepr.Repositories;
using Keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class VaultKeepsController : ControllerBase
  {

    private readonly VaultKeepsRepository _repo;

    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    // GET api/vaultkeeps by vault id
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<VaultKeep>> Get(int id)
    {
      return Ok(_repo.GetKeepsByVaultId(id));
    }

    // POST api/vaultkeeps
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody]VaultKeep value)
    {
      // VaultKeep invalue = new VaultKeep();
      // invalue = (VaultKeep)value;
      // invalue.UserId = HttpContext.User.Identity.Name;
      // VaultKeep result = _repo.AddVaultKeep(invalue);
      value.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(value);
      return Created("/api/VaultKeeps/" + result.UserId, result); ;
    }

    // DELETE api/values/5
    [HttpPut]
    public ActionResult<string> Put([FromBody]VaultKeep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      if (_repo.DeleteVaultKeep(value))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }



  }

}
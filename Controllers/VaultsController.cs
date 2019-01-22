using System.Collections.Generic;
using keepr.Repositories;
using Keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase

  {

    private readonly VaultsRepository _repo;

    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }

    // GET api/vaults
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      return Ok(_repo.GetAll());
    }

    // GET api/vaults by user
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Vault>> GetAction()
    {
      return Ok(_repo.GetByUserId(HttpContext.User.Identity.Name));
    }

    // GET api/vaults vaults by id
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Vault>> Get(int id)
    {
      Vault result = _repo.GetByVaultId(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/vaults 
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody]Vault value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      Vault result = _repo.AddVault(value);
      return Created("/api/vaults/" + result.UserId, result); ;
    }


    // DELETE api/vaults
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteVault(id, HttpContext.User.Identity.Name))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }


  }

}
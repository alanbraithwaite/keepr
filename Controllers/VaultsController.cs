using System.Collections.Generic;
using keepr.Repositories;
using Keepr.Models;
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

    // GET api/values
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Vault>> Get(int id)
    {
      Vault result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Vault> Post([FromBody]Vault value)
    {
      Vault result = _repo.AddVault(value);
      return Created("/api/vault/" + result.UserId, result); ;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
    {
      Vault result = _repo.UpdateVault(value);
      return Created("/api/vault/" + result.Id, "success");
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteVault(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }


  }

}
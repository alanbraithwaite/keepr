using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class KeepsController : ControllerBase

  {

    private readonly KeepsRepository _repo;

    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }

    // GET api/keeps all public keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_repo.GetAllPublicKeeps());
    }

    // GET api/keeps/user all keeps by user
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetAction()
    {
      var id = HttpContext.User.Identity.Name;
      return Ok(_repo.GetAllCurrentUserKeeps(id));
    }

    // GET api/keeps/id 
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      Keep result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/keeps
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody]Keep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      Keep result = _repo.AddKeep(value);
      return Created("/api/keeps/" + result.UserId, result); ;
    }

    // PUT api/keeps/id
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      Keep result = _repo.UpdateKeep(value);
      return Created("/api/keeps/" + result.Id, "success");
    }

    // DELETE api/keeps/id
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteKeep(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }


  }

}
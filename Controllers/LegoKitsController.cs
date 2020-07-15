using System;
using Microsoft.AspNetCore.Mvc;
using legomylego.Models;
using legomylego.Services;
using Microsoft.AspNetCore.Authorization;

namespace legomylego.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LegoKitsController : ControllerBase
  {
    private readonly LegoKitsService _service;
    public LegoKitsController(LegoKitsService service)
    {
      _service = service;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<DTOLegoKit> Post([FromBody] DTOLegoKit newDTOLegoKits)
    {
      try
      {
        return Ok(_service.Create(newDTOLegoKits));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}
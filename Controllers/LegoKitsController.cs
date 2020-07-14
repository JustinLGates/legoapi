using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using legomylego.Models;
using legomylego.Services;
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
using System;
using System.Collections.Generic;
using legomylego.Services;
using Microsoft.AspNetCore.Mvc;
using legomylego.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace legomylego.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitsController : ControllerBase
  {
    private readonly KitsService _service;
    private readonly LegoKitsService _lkService;
    public KitsController(KitsService service, LegoKitsService lkService)
    {
      _service = service;
      _lkService = lkService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Kit>> getAll()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Kit> GetById(int id)
    {
      try
      {
        return Ok(_service.Get(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/details")]
    public ActionResult<LegoKitHelper> getByKiIid(int id)
    {
      try
      {
        return Ok(_lkService.Get(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public ActionResult<Kit> Post([FromBody] Kit newKit)
    {
      try
      {
        // string email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        // use the line above to get email info from auth
        return Ok(_service.Create(newKit));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}
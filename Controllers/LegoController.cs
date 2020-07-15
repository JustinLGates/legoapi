using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using legomylego.Services;
using legomylego.Models;
using Microsoft.AspNetCore.Authorization;

namespace legomylego.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LegoController : ControllerBase
  {
    private readonly LegoService _service;
    public LegoController(LegoService service)
    {
      _service = service;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Lego>> getAll()
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
    public ActionResult<Lego> GetById(int id)
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
    [HttpPost]
    [Authorize]
    public ActionResult<Lego> Post([FromBody] Lego newLego)
    {
      try
      {
        return Ok(_service.Create(newLego));
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
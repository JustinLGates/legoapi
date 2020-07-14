using System;
using System.Collections.Generic;
using legomylego.Services;
using Microsoft.AspNetCore.Mvc;

using legomylego.Models;

namespace legomylego.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitsController : ControllerBase
  {
    private readonly KitsService _service;
    public KitsController(KitsService service)
    {
      _service = service;
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
    [HttpPost]
    public ActionResult<Kit> Post([FromBody] Kit newKit)
    {
      try
      {
        return Ok(_service.Create(newKit));
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
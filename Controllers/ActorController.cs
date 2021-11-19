using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies.Mappers;
using movies.Models;
using movies.Services;

namespace movies.Controllers
{

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _as;

    public ActorController(IActorService actorService)
    {
        _as = actorService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(NewActor actor)
    {
        var result = await _as.CreateAsync(actor.ToEntity());

        if(result.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(result.Exception.Message);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        if(await _as.ExistsAsync(id))
        {
            return Ok(await _as.GetAsync(id));
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
        => Ok(await _as.GetAllAsync());

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid Id)
        => Ok(await _as.DeleteAsync(Id));

    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid Id, [FromBody]NewActor actor)
    {
        var result = await _as.UpdateAsync(actor.ToEntity());

        if(result.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(result.Exception.Message);
    }
      
}

}
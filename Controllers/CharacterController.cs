using MicroserviceExample.Models;
using MicroserviceExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceExample.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly CharacterService _characterService;

    public CharacterController(CharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        try
        {
            var characters = await _characterService.GetAll();
            serviceResponse.Data = characters;
        }
        catch (Exception exception)
        {
            serviceResponse.Success = false;
            serviceResponse.Data = null;
            serviceResponse.Message = exception.Message;
        }
        return Ok(serviceResponse);
    }

    [HttpGet("{characterId}")]
    public async Task<ActionResult<ServiceResponse<Character>>> GetById(int characterId)
    {
        var serviceResponse = new ServiceResponse<Character>();
        try
        {
            var character = await _characterService.GetById(characterId);
            serviceResponse.Data = character;
        }
        catch (Exception exception)
        {
            serviceResponse.Success = false;
            serviceResponse.Data = null;
            serviceResponse.Message = exception.Message;
        }
        return Ok(serviceResponse);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> Add(Character characterPayload)
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        try
        {
            var characters = await _characterService.Add(characterPayload);
            serviceResponse.Data = characters;
        }
        catch (Exception exception)
        {
            serviceResponse.Success = false;
            serviceResponse.Data = null;
            serviceResponse.Message = exception.Message;
        }

        return Ok(serviceResponse);
    }
}
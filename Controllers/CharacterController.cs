using MicroserviceExample.Models;
using MicroserviceExample.Services;
using Microsoft.AspNetCore.Mvc;
using MicroserviceExample.Common;

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
        try
        {
            var characters = await _characterService.GetAll();
            var successResponse = ServiceResponse<List<Character>>.ThrowSuccessResponse(characters);
            return Ok(successResponse);
        }
        catch (AppException exception)
        {
            var errorResponse = ServiceResponse<string>.ThrowExceptionResponse(exception.Message);
            return StatusCode(exception.HttpStatusCode, errorResponse);
        }
    }

    [HttpGet("{characterId}")]
    public async Task<ActionResult<ServiceResponse<Character>>> GetById(int characterId)
    {
        var serviceResponse = new ServiceResponse<Character>();
        try
        {
            var character = await _characterService.GetById(characterId);
            var successResponse = ServiceResponse<Character>.ThrowSuccessResponse(character);
            return Ok(serviceResponse);
        }
        catch (AppException exception)
        {
            var errorResponse = ServiceResponse<string>.ThrowExceptionResponse(exception.Message);
            return StatusCode(exception.HttpStatusCode, errorResponse);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> Add(Character characterPayload)
    {
        try
        {
            var characters = await _characterService.Add(characterPayload);
            var successResponse = ServiceResponse<List<Character>>.ThrowSuccessResponse(characters);
            return Ok(successResponse);
        }
        catch (AppException exception)
        {
            var errorResponse = ServiceResponse<string>.ThrowExceptionResponse(exception.Message);
            return StatusCode(exception.HttpStatusCode, errorResponse);
        }
    }
}
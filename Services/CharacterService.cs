using MicroserviceExample.Models;

namespace MicroserviceExample.Services;

public class CharacterService
{
    private readonly List<Character> characters = new List<Character>{
        new Character(),
        new Character { Id = 1, Name = "Sam" }
    };

    public async Task<List<Character>> GetAll()
    {
        return characters;
    }

    public async Task<Character> GetById(int characterId)
    {
        Character? character = characters.FirstOrDefault((elem) => elem.Id == characterId);

        if (character == null)
            throw new BadHttpRequestException($"The character with id '{characterId}' was not found.");

        return character;
    }

    public async Task<List<Character>> Add(Character characterPayload)
    {
        characters.Add(characterPayload);
        return characters;
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;
using VideoGameCharacterApi.Dtos;
namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharacterController(IVideoGameCharacterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CharacterResponseDto>>> GetCharacters()
                => Ok(await service.GetAllCharactersAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDto?>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character is null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> CreateCharacter(CreateCharacterDto characterDto)
        {

            var createdCharacter = await service.AddCharacterAsync(characterDto);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCharacterDto?>> UpdateCharacter(int id, UpdateCharacterDto characterDto)
        {
            var updatedCharacter = await service.UpdateCharacterAsync(id, characterDto);
          
           return updatedCharacter ? NoContent() : NotFound("Character not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deletedCharacter = await service.DeleteCharacterAsync(id);
            return deletedCharacter ? NoContent() : NotFound("Character not found");
        }
    }
}

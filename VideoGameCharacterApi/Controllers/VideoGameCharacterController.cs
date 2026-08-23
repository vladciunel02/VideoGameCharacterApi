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
        public async Task<ActionResult<Character?>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character is null)
            {
                return NotFound();
            }
            return Ok(character);
        }
    }
}

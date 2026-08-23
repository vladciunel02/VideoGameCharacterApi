using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Data;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;
namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public Task<CharacterResponseDto> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int characterId)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterResponseDto?> GetCharacterByIdAsync(int characterId)
        {
            var result = await context.Characters.Where(c => c.Id == characterId).Select(c => new CharacterResponseDto
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<CharacterResponseDto>> GetAllCharactersAsync()
            => await context.Characters.Select(c => new CharacterResponseDto
            {
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            }).ToListAsync();

        public Task<bool> UpdateCharacterAsync(int characterId, Character character)
        {
            throw new NotImplementedException();
        }
    }
}

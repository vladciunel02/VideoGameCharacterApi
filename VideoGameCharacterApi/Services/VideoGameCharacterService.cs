using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Data;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;
namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<CharacterResponseDto> AddCharacterAsync(CreateCharacterDto character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new CharacterResponseDto
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Role = newCharacter.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int characterId)
        {
            var characterToDelete = await context.Characters.FindAsync(characterId);
            if (characterToDelete == null)
            {
                return false;
            }

            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<CharacterResponseDto?> GetCharacterByIdAsync(int characterId)
        {
            var result = await context.Characters.Where(c => c.Id == characterId).Select(c => new CharacterResponseDto
            {
                Id = c.Id,
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

        public async Task<bool> UpdateCharacterAsync(int characterId, UpdateCharacterDto character)
        {
            var existingCharacter = await context.Characters.FindAsync(characterId);
            if (existingCharacter == null)
            {
                return false;
            }

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Role = character.Role;

            await context.SaveChangesAsync();
            return true;
        }
    }
}

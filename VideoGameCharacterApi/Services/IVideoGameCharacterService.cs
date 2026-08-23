using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;
namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponseDto>> GetAllCharactersAsync();
        Task<CharacterResponseDto?> GetCharacterByIdAsync(int characterId);
        Task<CharacterResponseDto> AddCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(int characterId, Character character);
        Task<bool> DeleteCharacterAsync(int characterId);

    }
}

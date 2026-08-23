using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;
namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponseDto>> GetAllCharactersAsync();
        Task<CharacterResponseDto?> GetCharacterByIdAsync(int characterId);
        Task<CharacterResponseDto> AddCharacterAsync(CreateCharacterDto character);
        Task<bool> UpdateCharacterAsync(int characterId, UpdateCharacterDto character);
        Task<bool> DeleteCharacterAsync(int characterId);

    }
}

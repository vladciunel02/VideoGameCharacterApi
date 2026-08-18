using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<Character>> GetAllCharactersAsync();
        Task<Character> GetCharacterAsync(int characterId);
        Task<Character> AddCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(int characterId, Character character);
        Task<bool> DeleteCharacterAsync(int characterId);

    }
}

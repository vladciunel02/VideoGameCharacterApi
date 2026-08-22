using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        static List<Character> characters = new List<Character>
        {
            new Character{ Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero" },
            new Character{ Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Hero" },
            new Character { Id = 3, Name = "Samus", Game = "Metroid", Role = "Hero" },
            new Character{ Id = 4, Name = "Pikachu", Game = "Pokemon", Role = "Mascot" }
        };
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int characterId)
        {
            throw new NotImplementedException();
        }

        public async Task<Character?> GetCharacterByIdAsync(int characterId)
        {
            var result = characters.FirstOrDefault(c => c.Id == characterId);
            return await Task.FromResult(result);
        }

        public Task<List<Character>> GetAllCharactersAsync()
            => Task.FromResult(characters);

        public Task<bool> UpdateCharacterAsync(int characterId, Character character)
        {
            throw new NotImplementedException();
        }
    }
}

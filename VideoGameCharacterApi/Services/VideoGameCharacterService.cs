using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Data;
using Microsoft.EntityFrameworkCore;
namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
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
            var result = await context.Characters.FindAsync(characterId);
            return result;
        }

        public async Task<List<Character>> GetAllCharactersAsync()
            => await context.Characters.ToListAsync();

        public Task<bool> UpdateCharacterAsync(int characterId, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
